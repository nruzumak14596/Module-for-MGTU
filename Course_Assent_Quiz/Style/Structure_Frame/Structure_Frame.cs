using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using static Course_Assent_Quiz.ApiModels;


namespace Course_Assent_Quiz
{
    public class Structure_Frame 
    {
        public static Frame Inside_Frame(StackLayout view){

            var frame = new Frame
            {
                Padding = 10,
                HasShadow = false,
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Content = view
            };

            return frame;
        }

        public static Frame View_Frame(StackLayout view){

            var frame = new Frame
            {
                Padding = 3,
                HasShadow = false,
                BackgroundColor = Color.Gray,
                Content = view
            };

            return frame;
        }

    
        public static Frame Go_To_Submission_Page_Frame(string name)
        { 
            var button = Structure_Button.Go_To_Submission_Page_Button(name);

            button.SetBinding(Button.CommandProperty, "goToSaveOrEditPage");
           
            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();
            inside_View.Children.Add(button);
           
            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Save_Or_Edit_Comment_On_Grade_Frame(string commentText)
        {
            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var theme = Structure_Label.Theme_Label("Отзыв в виде комментария");
            inside_View.Children.Add(theme);

            Edit_Comment_On_Grade.editor = Structure_Editor.Text_Submission_Editor(commentText);
            inside_View.Children.Add(Edit_Comment_On_Grade.editor);

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);
            view_Frame.Padding = 0;

            return view_Frame;
        }

        public static Frame Save_Or_Edit_Submission_Frame()
        {
            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();
            Function.Check_Configs_In_Assignments(inside_View);

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(inside_View);
            view_Frame.Padding = 0;

            return view_Frame;
        }

        public static Frame Answer_comments_frame( List<Editorfield> comments )
        {
            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var theme = Structure_Label.Theme_Label("Ответ в виде комментария");
            inside_View.Children.Add(theme);

            foreach ( var item in comments )
            {
                var comment_text_label = Structure_Label.Tag_Label(item.text, Color.Gray, 16);
                inside_View.Children.Add(comment_text_label);
            }

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Theme_And_Description_Frame( string intro )
        {

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var theme_and_description_label = Structure_Label.Tag_Label(
                intro, Color.Black, 16);
            inside_View.Children.Add(theme_and_description_label);

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Comment_On_Submission_Frame( string lastTextSubmission )
        {
            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var theme = Structure_Label.Theme_Label("Ответ в виде комменатрия");
            inside_View.Children.Add(theme);

            Save_or_edit_submission.editor = Structure_Editor.Text_Submission_Editor(lastTextSubmission);
            inside_View.Children.Add(Save_or_edit_submission.editor);

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }
        
        public static Frame Comment_on_the_answer_frame(Comment comment)
        {
            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var commentatorView = Structure_StackLayout.Inside_Frame_View_Orientation(StackOrientation.Horizontal);

            var urlImage = Function.Take_Image_Url_From_String(comment.avatar);
            var profile_image = Structure_Image.Image_Profile( urlImage );
            commentatorView.Children.Add(profile_image);

            var commentatorInfoView = Structure_StackLayout.Inside_Frame_StackLayout();

            var nameOfСommentator = Structure_Label.Theme_Label(comment.fullname);
            commentatorInfoView.Children.Add(nameOfСommentator);

            var textDate = Function.Text_Unix_Time_In_Date_Time(
                comment.timecreated, "d MMMM yyyy г., HH:mm");
            var dateOfComment = Structure_Label.Description_Label(textDate);
            commentatorInfoView.Children.Add(dateOfComment);

            commentatorView.Children.Add(commentatorInfoView);

            var commentText = Structure_Label.Tag_Label(comment.content, Color.Black, 18);

            inside_View.Children.Add(commentatorView);
            inside_View.Children.Add(commentText);

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Value_comments_on_the_answer_frame( List<Comment> comments )
        {
            var theme = Structure_Label.Theme_Label("Комментарии к ответу");

            var valueComments = comments.Count;
            var countComments = Structure_Label.Description_Label(( "Комментарии (" + valueComments + ")" ));

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();
            inside_View.Children.Add(theme);
            inside_View.Children.Add(countComments);

            var inside_Frame = Inside_Frame(inside_View);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "goToCommentOnAnswerPage");
            var binding = new Binding();
            inside_View.GestureRecognizers.Add(tapGestureRecognizer);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }
        
        public static Frame Attempt_number_frame( int attempt_number, string max_attempt )
        {
            attempt_number++;

            var theme = Structure_Label.Theme_Label("Номер попытки");

            if ( max_attempt == "-1" )
                max_attempt = "Неограничено";

            var attempt = Structure_Label.Description_Label((attempt_number + " из " + max_attempt));

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();
            inside_View.Children.Add(theme);
            inside_View.Children.Add(attempt);

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Answer_Frame(List<Plugins> plugins)
        {
            var view = Structure_StackLayout.Inside_Frame_StackLayout();
            Function.Check_Plugins_View(view, plugins);

            var view_Frame = View_Frame(view);
            view_Frame.Padding = 0;

            return view_Frame;
        }
                      
        public static Frame Answer_files_frame(List<File> files)
        {
            var theme = Structure_Label.Theme_Label("Ответ в виде файла");

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            inside_View.Children.Add(theme);

            foreach ( var item in files )
            {
                /*
                var download_File_Circle = new Download_File_Progress();
                download_File_Circle.WidthRequest = 25;
                download_File_Circle.HeightRequest = 25;
                

                var URL = item.fileurl + "?&token=" + Variables.token_user;
                var download_File = new Download_File(URL, download_File_Circle);
                */

                var file_name_label = Structure_Label.File_Name_Label(item.filename);

                var file_image = Structure_Image.File_Type_Image(item.mimetype);

                var inside_File_View = Structure_StackLayout.Inside_Frame_View_Orientation(StackOrientation.Horizontal);

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "downloadSubmissionFile");

                var binding = new Binding();
                binding.Source = item.fileurl;
                tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, binding);
                inside_File_View.GestureRecognizers.Add(tapGestureRecognizer);

                inside_File_View.Children.Add(file_image);
                inside_File_View.Children.Add(file_name_label);
                
                /*
                inside_File_View.Children.Add(download_File);
                inside_File_View.Children.Add(download_File_Circle);
                */
                
                inside_View.Children.Add(inside_File_View);
            }

            var inside_Frame = Inside_Frame(inside_View);
            

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Intro_Attachments_Files_Frame(List<Introattachments> intro_attachments)
        {

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            foreach ( var item in intro_attachments )
            {
                /*
                var download_File_Circle = new Download_File_Progress();
                download_File_Circle.WidthRequest = 25;
                download_File_Circle.HeightRequest = 25;
                
                var URL = item.fileurl + "?&token=" + Variables.token_user;
                var download_File = new Download_File(URL, download_File_Circle);
                */

                var file_name_label = Structure_Label.File_Name_Label(item.filename);

                var file_image = Structure_Image.File_Type_Image(item.mimetype);

                var inside_File_View = Structure_StackLayout.Inside_Frame_View_Orientation(StackOrientation.Horizontal);

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "downloadSubmissionFile");

                var binding = new Binding();
                binding.Source = (item.fileurl);
                tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, binding);
                inside_File_View.GestureRecognizers.Add(tapGestureRecognizer);

                inside_File_View.Children.Add(file_image);
                inside_File_View.Children.Add(file_name_label);

                /*
                inside_File_View.Children.Add(download_File);
                inside_File_View.Children.Add(download_File_Circle);
                */

                inside_View.Children.Add(inside_File_View);
            }

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Task_Response_Status_Frame(string submission_status,
                                                       string grading_status)
        {
            Function.Submission_Color(submission_status,
                Variables.submissionInfo.lastattempt.submissionsenabled);
            Function.Grading_Color(grading_status);

            var theme = Structure_Label.Theme_Label(
                "Состояние ответа на задание:");

            var sumbission_status_label = Structure_Label.Response_Status_Frame_Label(
                Variables.submission_status, Variables.submission_color);

            var grading_status_label = Structure_Label.Response_Status_Frame_Label(
                Variables.grading_status, Variables.grading_color);

            var status_stack = Structure_StackLayout.Inside_Frame_StackLayout();
            status_stack.Children.Add(sumbission_status_label);
            status_stack.Children.Add(grading_status_label);

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();
            inside_View.Children.Add(theme);
            inside_View.Children.Add(status_stack);
            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Last_Change_Frame(long unixTime)
        {           
            var theme = Structure_Label.Theme_Label("Последнее изменение");

            var text_Date = Function.Text_Unix_Time_In_Date_Time(
                unixTime, "d MMMM yyyy г., HH:mm");

            var date_label = Structure_Label.Custom_Label(text_Date, 
                                                          Color.Gray, 16);

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();
            inside_View.Children.Add(theme);
            inside_View.Children.Add(date_label);
            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Grading_Due_Date_Frame(long unix_grading_due_date)
        {

            var theme = Structure_Label.Theme_Label("Последний срок сдачи");

            var text_Date = Function.Text_Unix_Time_In_Date_Time(
                unix_grading_due_date, "d MMMM yyyy г., HH:mm");

            var date_label = Structure_Label.Custom_Label(text_Date,
                                                          Color.Gray, 16);

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();
            inside_View.Children.Add(theme);
            inside_View.Children.Add(date_label);
            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        #region 
        /*
         * если ответ на задание еще не дан и последний срок еще не наступил, 
         * то пишется так ОСТАВШЕЕСЯ ВРЕМЯ: ВРЕМЯ (где время = последний срок - сейчас)
         */
        #endregion 
        public static Frame Time_Left_Frame(double unix_time_modified, 
                                            long unix_grading_due_date)
        {

            var theme = Structure_Label.Theme_Label("Оставшееся время");

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();
            inside_View.Children.Add(theme);

            var time_left_label = Structure_Label.Time_Left_Frame_Label(
                unix_time_modified, unix_grading_due_date);

            inside_View.Children.Add(time_left_label);

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Comment_Grader_On_The_Answer_Frame(List<Plugins> plugins )
        {
            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var theme = Structure_Label.Theme_Label("Отзыв в виде комментария");
            inside_View.Children.Add(theme);

            //данный способ не хороший, стоит сделать через Core_comment_get_comments
            foreach ( var item in plugins )
            {
                if ( item.type == "comments" )
                {
                    foreach ( var item_ in item.editorfields )
                    {
                        var comment = Structure_Label.Tag_Label(item_.text, Color.Gray, 16);
                        inside_View.Children.Add(comment);
                    }
                }
            }

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Cut_Off_Date_Frame(long unixTime){

            var text = "Это назначение будет приниматься с <strong>" +
                Function.Text_Unix_Time_In_Date_Time(
                    unixTime, "d MMMM yyyy г., HH:mm" + "</strong>"
                );

            var theme_and_time = Structure_Label.Tag_Label(
                text, Color.Black, 18);

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();
            inside_View.Children.Add(theme_and_time);
            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Grade_In_Journal_Frame(string submission_grade){

            var theme = Structure_Label.Theme_Label("Текущая оценка в журнале");

            var grade = Structure_Label.Tag_Label(
                submission_grade, Color.Gray, 16);

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();
            inside_View.Children.Add(theme);
            inside_View.Children.Add(grade);
            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Grader_Frame( Users graderInf, double timeGrading )
        {
            var theme = Structure_Label.Theme_Label("Оценено");

            var grader = Structure_Label.Theme_Label(
                graderInf.fullname);

            var text_Date = Function.Text_Unix_Time_In_Date_Time(
                timeGrading, "d MMMM yyyy г., HH:mm");

            var time_grade = Structure_Label.Custom_Label(
                text_Date, Color.Gray, 16);

            var profile_image = Structure_Image.Image_Profile(graderInf.profileimageurl);

            var vertical_stack = Structure_StackLayout.Inside_Frame_View_Orientation(
                StackOrientation.Vertical);
            vertical_stack.Children.Add(grader);
            vertical_stack.Children.Add(time_grade);

            var horizontal_stack = Structure_StackLayout.Inside_Frame_View_Orientation(
                StackOrientation.Horizontal);
            horizontal_stack.Children.Add(profile_image);
            horizontal_stack.Children.Add(vertical_stack);

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();
            inside_View.Children.Add(theme);
            inside_View.Children.Add(horizontal_stack);

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame File_Ready_For_Upload_Frame(string fileName)
        {
            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var inside_File_View = Structure_StackLayout.Inside_Frame_View_Orientation(StackOrientation.Horizontal);

            //Картинка должна не так но нет времени
            var file_image = Structure_Image.Fake_File_Type_Image("document_64.png");
            inside_File_View.Children.Add(file_image);

            var file_name_label = Structure_Label.File_Name_Label(fileName);
            inside_File_View.Children.Add(file_name_label);

            inside_View.Children.Add(inside_File_View);

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        #region FramesForGrader

        public static Frame Go_Submission_List_Page( )
        {
            var label = Structure_Label.Theme_Label("Ответы");

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "goToSubmissionListPage");
            var binding = new Binding();
            inside_View.GestureRecognizers.Add(tapGestureRecognizer);

            inside_View.Children.Add(label);
            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Go_Participants_List_Page()
        {
            var label = Structure_Label.Theme_Label("Участники");

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "goToParticipantsListPage");
            var binding = new Binding();
            inside_View.GestureRecognizers.Add(tapGestureRecognizer);

            inside_View.Children.Add(label);
            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame List_Submissions_Information_Frame(Mod_assign_list_participants participant)
        {

            Function.Check_Answer_Status_For_List(participant.submitted, participant.requiregrading);

            var insideView = Structure_StackLayout.Inside_Frame_View_Orientation(StackOrientation.Horizontal); ;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "goToGradingParticipantsPage");
            var binding = new Binding();
            binding.Source = participant.id;
            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, binding);
            insideView.GestureRecognizers.Add(tapGestureRecognizer);

            var participantsView = Structure_StackLayout.Inside_Frame_StackLayout();

            var profile_image = Structure_Image.Image_Profile( participant.profileimageurl);

            var fullName = Structure_Label.Custom_Label(participant.fullname, Color.Black, 18);

            var sumbission_status_label = Structure_Label.Response_Status_Frame_Label(
                Variables.submission_status, Variables.submission_color);
          
            participantsView.Children.Add(fullName);
            participantsView.Children.Add(sumbission_status_label);

            insideView.Children.Add(profile_image);
            insideView.Children.Add(participantsView);

            var inside_Frame = Inside_Frame(insideView);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Participants_Information_Frame( string submissionStatus, string gradingStatus, 
                                                            string imageURL, string fullname )
        {
            Function.Submission_Color(
                submissionStatus,
                Variables.submissionInfo.lastattempt.submissionsenabled);
            Function.Grading_Color(gradingStatus);

            var insideView = Structure_StackLayout.Inside_Frame_View_Orientation(StackOrientation.Horizontal);

            var participantsView = Structure_StackLayout.Inside_Frame_StackLayout();

            var profile_image = Structure_Image.Image_Profile( imageURL );

            var fullName = Structure_Label.Custom_Label(fullname, Color.Black, 18);

            var sumbission_status_label = Structure_Label.Response_Status_Frame_Label(
                Variables.submission_status, Variables.submission_color);

            var grading_status_label = Structure_Label.Response_Status_Frame_Label(
                Variables.grading_status, Variables.grading_color);

            participantsView.Children.Add(fullName);
            participantsView.Children.Add(sumbission_status_label);
            participantsView.Children.Add(grading_status_label);

            insideView.Children.Add(profile_image);
            insideView.Children.Add(participantsView);

            var inside_Frame = Inside_Frame(insideView);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }
      
        public static Frame Can_Edit_Status_Frame(bool canEditStatus)
        {
            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var theme = Structure_Label.Theme_Label("Изменение статуса");
            inside_View.Children.Add(theme);

            string text;
            if ( canEditStatus == true )
            {
                text = "Студент может править свой ответ";
            }
            else
            {
                text = "Студент не может править свой ответ";
            }


            var editText = Structure_Label.Description_Label(text);
            inside_View.Children.Add(editText);

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Rate_Participant_Submission_Frame(int maxGrade, string currentGrade )
        {
            Debug.WriteLine("maxGrade " + maxGrade);
            Debug.WriteLine("currentGrade " + currentGrade);

            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var label = Structure_Label.Theme_Label("Оценка из " + maxGrade);
            inside_View.Children.Add(label);

            if (currentGrade != "")
            {
                var text = Function.Round_Up_Grade(currentGrade);
                Debug.WriteLine("text " + text);
                Grading_Participants.gradeEditor = Structure_Editor.Rate_Submission_Editor(text);
                inside_View.Children.Add(Grading_Participants.gradeEditor);
            }
            else
            {
                Grading_Participants.gradeEditor = Structure_Editor.Rate_Submission_Editor("");
                inside_View.Children.Add(Grading_Participants.gradeEditor);
            }

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        public static Frame Edit_Comment_On_Grade_Frame( )
        {
            var inside_View = Structure_StackLayout.Inside_Frame_StackLayout();

            var theme_And_Image_View = Structure_StackLayout.Inside_Frame_View_Orientation(StackOrientation.Horizontal);

            var theme = Structure_Label.Theme_Label("Отзыв в виде комментария");
            theme_And_Image_View.Children.Add(theme);

            var image_Go_Edit_Page = Structure_Image.Custom_Image("edit_comment.png", 24, 24,
                LayoutOptions.EndAndExpand, LayoutOptions.FillAndExpand);
            theme_And_Image_View.Children.Add(image_Go_Edit_Page);

            inside_View.Children.Add(theme_And_Image_View);

            var tapGestureRecognizer = new TapGestureRecognizer();

            /*
             * Решил передавать параметр на новую страницу по другому
            var binding = new Binding();
            binding.Source = Grading_Participants.commentLabel.Text;
            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, binding);
            */

            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "goToEditCommentOnGrade");
            
            image_Go_Edit_Page.GestureRecognizers.Add(tapGestureRecognizer);

            inside_View.Children.Add(Grading_Participants.commentLabel);

            var inside_Frame = Inside_Frame(inside_View);

            var view = Structure_StackLayout.View_Frame();
            view.Children.Add(inside_Frame);

            var view_Frame = View_Frame(view);

            return view_Frame;
        }

        #endregion


    }
}

