using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static Course_Assent_Quiz.ApiModels;

namespace Course_Assent_Quiz
{
    class Grading_Participants : ContentPage
    {
        public static Editor gradeEditor;

        #region Зачем label
        /*
         * Для того чтобы когда мы на странице Edit_Comment_On_Grade 
         * изменили коммент или добавили 
         * он менялся в Grading_Participants
         */
        #endregion
        public static Label commentLabel;

        public ICommand goToCommentOnAnswerPage { get; private set; }
        public ICommand goToEditCommentOnGrade { get; private set; }

        public Grading_Participants(int participantId)
        {
            Title = Variables.true_assign.name;

            var grading_Part_Layout = new StackLayout();

            goToCommentOnAnswerPage = new Command(Go_To_Comments_On_Answer_Page);
            goToEditCommentOnGrade = new Command(Go_To_Edit_Comment_On_Grade);

            var save_Result = new ToolbarItem
            {
                Text = "Сохранить",
                Command = new Command<int>(this.Save_Result),
                CommandParameter = participantId
            };
            this.ToolbarItems.Add(save_Result);

            Variables.submissionInfo = Task.Run(
                () => API.Get_Mod_Assign_Submission_Status(Variables.assignId, participantId)).Result;

            commentLabel = Structure_Label.Description_Label(
                Function.Check_Feedback_Plugins_For_Comments(Variables.submissionInfo.feedback));

            //Если задание оценено то берем информацию о том кто оценил                  
            if (Variables.submissionInfo.feedback != null)
            {
                var userInf = Task.Run(() => API.Get_Core_user_get_users_by_field(
                                "id", Variables.submissionInfo.feedback.grade.grader.ToString()));
                foreach (var item in userInf.Result)
                {
                    if (item.id == Variables.submissionInfo.feedback.grade.grader)
                        Variables.grader_inf = item;
                };

            }

            Variables.sumbissionComments = Task.Run(
                    () => API.Get_core_comment_get_comments("module", Variables.true_assign.cmid, "assignsubmission_comments",
                    Variables.submissionInfo.lastattempt.submission.id, "submission_comments", 0)).Result;

            var participantInformationList = Task.Run(() => API.Get_Core_user_get_users_by_field(
                            "id", participantId.ToString())).Result;
            var participantInformation = participantInformationList.Find(x => x.id == participantId); ;

            var participantInformationFrame = Structure_Frame.Participants_Information_Frame(
                Variables.submissionInfo.lastattempt.submission.status,
                Variables.submissionInfo.lastattempt.gradingstatus,
                participantInformation.profileimageurl, participantInformation.fullname);
            grading_Part_Layout.Children.Add(participantInformationFrame);

            var tab_control = new Segmented_Control_Grading_Participant();
            grading_Part_Layout.Children.Add(tab_control);

            Padding = 1;
            BackgroundColor = Color.FromHex("#293991");

            var scroll_View = new ScrollView
            {
                Content = grading_Part_Layout
            };
            this.Content = scroll_View;

            this.BindingContext = this;
        }

        public async void Save_Result(int participantId)
        {
            if (commentLabel.Text != null)
            {
                if (gradeEditor.Text != null)
                {
                    if (Convert.ToDouble(gradeEditor.Text) <= Variables.true_assign.grade)
                    {
                        Assignfeedbackcomments_editor commentToGrade = new Assignfeedbackcomments_editor();
                        commentToGrade.format = 1; //Какие форматы и чем они отличаются не понятно
                        commentToGrade.text = commentLabel.Text;

                        Plugindata plugindata = new Plugindata { assignfeedbackcomments_editor = commentToGrade };

                        var addGradeAndComment = Task.Run(
                                () => API.Get_Mod_assign_save_grade(Variables.true_assign.id, participantId, Convert.ToDouble(gradeEditor.Text),
                                -1, 1, "", 0, plugindata)).Result;

                        await Navigation.PopAsync();
                    }
                    else
                    {
                        //Ошибка! заданная оценка больше максимальной
                    }                  
                }
                else
                {
                    //Код который добавляет комментарий и удаляет оценку
                }
            }
            else
            {
                if (gradeEditor.Text != null)
                {
                    if (Convert.ToDouble(gradeEditor.Text) <= Variables.true_assign.grade)
                    {
                        //Код который удаляет комментарий и добавляет оценку
                    }
                    else
                    {
                        //Ошибка! заданная оценка больше максимальной
                    }

                }
                else
                {
                    //Код который удаляет оценку и комментарий
                }
            }
        }

        public async void Go_To_Comments_On_Answer_Page()
        {
            Comments_On_Answer commentPage = new Comments_On_Answer(Variables.sumbissionComments.comments);
            await Navigation.PushAsync(commentPage);
        }

        public async void Go_To_Edit_Comment_On_Grade()
        {
            Edit_Comment_On_Grade commentPage = new Edit_Comment_On_Grade(commentLabel.Text);
            await Navigation.PushAsync(commentPage);
        }
    }
}
