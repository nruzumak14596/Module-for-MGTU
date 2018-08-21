using System.Windows.Input;
using Xamarin.Forms;
using Plugin.DownloadManager;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using Plugin.Connectivity;
using System;
using System.Net;

namespace Course_Assent_Quiz
{
    class Practical_Work : ContentPage
    {
        public ICommand goToSaveOrEditPage { get; private set; }
        public ICommand downloadSubmissionFile { get; private set; }
        public ICommand goToCommentOnAnswerPage { get; private set; }
        public ICommand goToSubmissionListPage { get; private set; }
        public ICommand goToParticipantsListPage { get; private set; }

        private List<Frame> List_Header_Assing;
        private StackLayout practical_Work_Layout;

        public Practical_Work()
        {
            practical_Work_Layout = new StackLayout();

            downloadSubmissionFile = new Command<string>(Download_Submission_File);
            goToSaveOrEditPage = new Command(Go_To_Save_Of_Edit_Submission);
            goToCommentOnAnswerPage = new Command(Go_To_Comments_On_Answer_Page);
            goToSubmissionListPage = new Command(Go_To_Submission_List_Page);
            goToParticipantsListPage = new Command(Go_To_Participants_List_Page);

            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                    throw new Exception();

                var coursesInfo = Task.Run(
                        () => API.Get_Mod_Assign_Assignments(Variables.courseId)).Result;

                foreach (var course in coursesInfo.courses)
                {
                    Variables.true_assign = course.assignments.Find(x => x.id == Variables.assignId);
                }

                Title = Variables.true_assign.name;

                List_Header_Assing = new List<Frame>();

                //Вывод темы и описания задания
                if (Variables.true_assign.intro != "")
                {
                    var theme_and_description = Structure_Frame.Theme_And_Description_Frame(
                        Variables.true_assign.intro);
                    practical_Work_Layout.Children.Add(theme_and_description);
                    List_Header_Assing.Add(theme_and_description);
                }

                //Вывод приложеных файлов
                if (Variables.true_assign.introattachments.Count != 0)
                {
                    var intro_attachments_files = Structure_Frame.Intro_Attachments_Files_Frame(
                        Variables.true_assign.introattachments);
                    practical_Work_Layout.Children.Add(intro_attachments_files);
                    List_Header_Assing.Add(intro_attachments_files);
                }


                #region Info_For_Submission
                /*
                 * Вызываем функцию в которой провериться, студент или преподователь в курсе
                 * Проверит наличие feedback
                 * и вызывет нужные Frame
                 */
                #endregion
                Function.Info_For_Submission(practical_Work_Layout);
            }
            catch(Exception ex)
            {
                Function.Alert_Message_App(ex.Message);
            }
            Padding = 0;
            this.BackgroundColor = Color.White;

            var scrollView = new ScrollView
            {
                Content = practical_Work_Layout
            };
            this.Content = scrollView;

            this.BindingContext = this;
        }

        public void Download_Submission_File( string fileURL)
        {
            var URL = fileURL + "?&token=" + Variables.token_user;

            Debug.WriteLine("URL " + URL);

            var downloadManager = CrossDownloadManager.Current;
            var file = downloadManager.CreateDownloadFile(URL);
            downloadManager.Start(file, true);

            #region Open file (not work)
            /*
             * string trueMimeType = MimeTypeMap.GetExtension(mimeType);
             * DependencyService.Get<IDownloadAndOpenFile>().Open_File(fileURL, "text / plain");
             */
            #endregion
        }

        public async void Go_To_Save_Of_Edit_Submission()
        {
            Save_or_edit_submission saveOrEditSubmission = new Save_or_edit_submission(
                practical_Work_Layout, List_Header_Assing);
            await Navigation.PushAsync(saveOrEditSubmission);
        }

        public async void Go_To_Comments_On_Answer_Page()
        {
            Comments_On_Answer commentPage = new Comments_On_Answer
                (Variables.sumbissionComments.comments);
            await Navigation.PushAsync(commentPage);
        }

        public async void Go_To_Submission_List_Page()
        {
            Submission_List submissionListPage = new Submission_List();
            await Navigation.PushAsync(submissionListPage);
        }

        public async void Go_To_Participants_List_Page()
        {
            Participants_List participantsListPage = new Participants_List();
            await Navigation.PushAsync(participantsListPage);
        }
    }
}
