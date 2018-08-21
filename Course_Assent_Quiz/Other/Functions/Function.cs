using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Course_Assent_Quiz.ApiModels;


namespace Course_Assent_Quiz
{
    public class Function
    {
        public static void Check_Answer_Status_For_List( bool submissionStatus, bool gradeStatus )
        {
            if ( submissionStatus == false)
            {
                if ( gradeStatus == true )
                {
                    Variables.submission_status = "Ответ не представлен";
                    Variables.submission_color = Color.Red;
                }
                else
                {
                    Variables.submission_status = "Оценено";
                    Variables.submission_color = Color.Green;
                }
            }
            else
            {
                if ( gradeStatus == true )
                {
                    Variables.submission_status = "Не оценено";
                    Variables.submission_color = Color.Red;
                }
                else
                {
                    Variables.submission_status = "Оценено";
                    Variables.submission_color = Color.Green;
                }
            }
        }      

        public static void Submission_Color( string submissionStatus, bool submissionEnabled )
        {
            #region
            /*
             * if ( Variables.assignmentSubmissionStatus.lastattempt.submissionsenabled == true) 
             * этим я проверяю ответ вне системы или нет
             * Но возможно я не прав и проверять надо 
             * configs в courses->assignments на наличие file(прикрепить файл) и onlinetext(ответ в виде комментария) 
             */
            #endregion

            if ( submissionEnabled == true )
            {
                if ( submissionStatus == "submitted" )
                {
                    Variables.submission_status = "Отправлено для оценивания";
                    Variables.submission_color = Color.Green;
                }
                else
                {
                    if ( submissionStatus == "new" )
                    {
                        Variables.submission_status = "Ни одной попытки";
                        Variables.submission_color = Color.Red;
                    }
                }
            }
            else
            {
                Variables.submission_status = "Ответ на задание " +
                            "должен быть предоставлен вне сайта";
                Variables.submission_color = Color.Red;
            }
        }

        public static void Grading_Color( string grading_status )
        {

            if ( grading_status == "graded" )
            {
                Variables.grading_status = "Оценено";
                Variables.grading_color = Color.Green;
            }
            else
            {
                if ( grading_status == "notgraded" )
                {
                    Variables.grading_status = "Не оценено";
                    Variables.grading_color = Color.Red;
                }
            }
        }

        public static void Check_Submission_Status_View( StackLayout view, Lastattempt lastattempt)
        {
            if ( lastattempt.submission.status == "new" )
            {
                if ( lastattempt.gradingstatus == "graded" )
                {
                    view.Children.Add(Structure_Frame.Value_comments_on_the_answer_frame(
                        Variables.sumbissionComments.comments));

                    view.Children.Add(Structure_Frame.Time_Left_Frame(
                        Variables.submissionInfo.lastattempt.submission.timemodified,
                        Variables.true_assign.duedate));

                    view.Children.Add(Structure_Frame.Grading_Due_Date_Frame(
                            Variables.true_assign.duedate));                  
                }
                else
                {
                    view.Children.Add(Structure_Frame.Value_comments_on_the_answer_frame(
                        Variables.sumbissionComments.comments));

                    view.Children.Add(Structure_Frame.Time_Left_Frame(
                        Variables.submissionInfo.lastattempt.submission.timemodified,
                        Variables.true_assign.duedate));

                    view.Children.Add(Structure_Frame.Grading_Due_Date_Frame(
                            Variables.true_assign.duedate));
                }

                if ( lastattempt.canedit == true )
                    view.Children.Add(Structure_Frame.Go_To_Submission_Page_Frame("Добавить ответ на задание"));
            }
            else
            {
                if ( lastattempt.gradingstatus == "graded" )
                {
                    view.Children.Add(Structure_Frame.Answer_Frame(
                        lastattempt.submission.plugins));

                    view.Children.Add(Structure_Frame.Value_comments_on_the_answer_frame(
                        Variables.sumbissionComments.comments));

                    view.Children.Add(Structure_Frame.Last_Change_Frame(
                        Variables.submissionInfo.lastattempt.submission.timemodified));

                    view.Children.Add(Structure_Frame.Attempt_number_frame(
                    Variables.submissionInfo.lastattempt.submission.attemptnumber,
                    Variables.true_assign.maxattempts.ToString()));
                }
                else
                {
                    view.Children.Add(Structure_Frame.Answer_Frame(
                       Variables.submissionInfo.lastattempt.submission.plugins));

                    view.Children.Add(Structure_Frame.Value_comments_on_the_answer_frame(
                        Variables.sumbissionComments.comments));

                    view.Children.Add(Structure_Frame.Last_Change_Frame(
                        Variables.submissionInfo.lastattempt.submission.timemodified));

                    view.Children.Add(Structure_Frame.Time_Left_Frame(
                        Variables.submissionInfo.lastattempt.submission.timemodified,
                        Variables.true_assign.duedate));

                    view.Children.Add(Structure_Frame.Grading_Due_Date_Frame(
                        Variables.true_assign.duedate));

                    view.Children.Add(Structure_Frame.Attempt_number_frame(
                        Variables.submissionInfo.lastattempt.submission.attemptnumber,
                        Variables.true_assign.maxattempts.ToString()));
                }

                if ( lastattempt.canedit == true )
                    view.Children.Add(Structure_Frame.Go_To_Submission_Page_Frame("Редактировать ответ"));
            }
        }
  
        public static string Text_Unix_Time_In_Date_Time(double unixTime, string format)
        {
            var time = Variables.UNIX_EPOCH.AddSeconds(unixTime).ToLocalTime();
            return time.ToString(format, Variables.ru_Ru);
        }

        public static bool Compare_Dates(double firstUnixTime, double secondUnixTime)
        {
            if (firstUnixTime >= secondUnixTime)
                return true;

            return false;
        }

        public static string Difference_Of_Dates(double firstUnixTime, double secondUnixTime)
        {
            var time1 = Variables.UNIX_EPOCH.AddSeconds(firstUnixTime).ToLocalTime();
            var time2 = Variables.UNIX_EPOCH.AddSeconds(secondUnixTime).ToLocalTime();

            int days = ( time1 - time2 ).Days;
            int hours = ( time1 - time2 ).Hours;
            int minutes = ( time1 - time2 ).Minutes;

            return ( days + " дней " + hours + " часов " + minutes + " минут" );
        }

        public static void Check_Plugins_View( StackLayout view, List<Plugins> plugins )
        {
            List<File> files = new List<File>();

            List<Filearea> fileareas = new List<Filearea>();
            List<Editorfield> editorfields = new List<Editorfield>();

            foreach ( var item in plugins )
            {
                //для файлов
                if ( item.type == "file" )
                {
                    fileareas = item.fileareas;
                    foreach ( var item_ in fileareas )
                    {
                        files = item_.files;
                    }
                }
                //для ответа в виде комментария
                if ( item.type == "onlinetext" )
                {
                    editorfields = item.editorfields;
                }
            }

            if ( editorfields.Count != 0 )
                view.Children.Add(Structure_Frame.Answer_comments_frame(editorfields));

            if ( files.Count != 0 )
                view.Children.Add(Structure_Frame.Answer_files_frame(files));
        }

        //не закончено (НУЖНО ДЛЯ ПРОСМОТРА КАКИЕ ОТВЕТЫ МОЖНО ДАТЬ НА ЗАДАНИЕ)
        public static void Check_Configs_In_Assignments(StackLayout view)
        {
            foreach ( var config in Variables.true_assign.configs )
            {
                if ( config.plugin == "onlinetext" && config.name == "enabled" && config.value == "1" )
                {
                    #region wordLimit
                    /*
                     * Проверка на ограничение символов (по хорошему нужно сперва найти wordlimitEnable если оно 0
                     * то нету ограничение, если 1, то есть и кидаем его в wordlimit, но я думаю что если 
                     * wordlimitEnable равен 1, то wordlimit должен быть больше 0 и тем самым проверка на wordlimitEnable
                     * не нужна)
                     */
                    #endregion
                    Variables.wordLimit = Convert.ToInt32(Variables.true_assign.configs.Find(x => x.name == "wordlimit").value);
										
                    foreach ( var plugin in Variables.submissionInfo.lastattempt.submission.plugins )
                    {
                        if ( plugin.type == "onlinetext" )
                        {
                            foreach ( var editorfield in plugin.editorfields )
                            {
                                var onlineTextFrame = Structure_Frame.Comment_On_Submission_Frame(editorfield.text);
                                view.Children.Add(onlineTextFrame);
                            }
                        }
                    }
                }
                
                if ( config.plugin == "file" && config.name == "enabled" && config.value == "1" )
                {
                    //незаконечно для ответов в виде файла
					Variables.fileCountLimit = Convert.ToInt32(Variables.true_assign.configs.Find(x => x.name == "maxfilesubmissions").value);
                    Variables.fileSizeLimit = Convert.ToInt32(Variables.true_assign.configs.Find(x => x.name == "maxsubmissionsizebytes").value);

                    foreach ( var plugin in Variables.submissionInfo.lastattempt.submission.plugins )
                    {
                        if ( plugin.type == "file" )
                        {
                            foreach ( var fileareas in plugin.fileareas )
                            {
                                /*
								 *Тут писать вызов frame с ответом в виде файла
								 *Если появляется вопрос почему именно через Variables.submissionInfo
								 *Надо учитывать что это может быть редактировать ответ и файлы уже могут быть на сервере и нам нужно их вытащить
                                */

                            }
                        }
                    }
                }
            }
        }

        public static string Check_Feedback_Plugins_For_Comments(Feedbackattempt feedback)
        {
            if ( feedback != null )
            {
                foreach ( var item in feedback.plugins )
                {
                    if ( item.type == "comments" )
                    {
                        foreach ( var item_ in item.editorfields )
                        {
                            return item_.text; ;
                        }
                    }                      
                }
            }
            return "";
        }

        public static string Set_Image_For_Type(string mimeType)
        {

            string trueMimeType = MimeTypeMap.GetExtension(mimeType);

            switch ( trueMimeType )
            {
                case ".pdf":
                    return "pdf_64.png";

                case ".docx":
                    return "document_64.png";

                case ".ppt":
                case ".pptm":
                case ".pptx":
                case ".pot":
                case ".potm":
                case ".potx":
                case ".ppa":
                case ".ppam":
                case ".ppm":
                case ".pps":
                case ".ppsm":
                case ".ppsx":
                    return "powerpoint_64.png";

                case ".jpeg":
                case ".jpe":
                case ".jpg":
                    return "jpeg_64.png";

                case ".gif":
                    return "gif_64.png";

                case ".png":
                    return "png_64.png";

                case ".xlc":
                case ".xld":
                case ".xlk":
                case ".xll":
                case ".xlm":
                case ".xls":
                    return "spreadsheet_64.png";

                case ".txt":
                    return "text_64.png";

                default:
                    return "unknown_64.png";
            }
        }

        public static string Take_Image_Url_From_String(string text)
        {
            /*(?<=src="") это находит src=" 
             * (\S*(?="")) это берет все до "
             * Все вместе находит src=" потом добавляет все до первой "
             */
            Regex regex = new Regex(@"((?<=src="")+(\S*(?="")))");
            Match match = regex.Match(text);

            string URL = match.ToString();
            
            return URL;
        }

        public static string Round_Up_Grade (string grade)
        {
            Debug.WriteLine("grade " + grade);
            var doubleGrade = Convert.ToDouble(grade, CultureInfo.InvariantCulture);
            Debug.WriteLine("doubleGrade " + doubleGrade);
            var roundUpGrade = String.Format("{0:N2}", doubleGrade);
            Debug.WriteLine("roundUpGrade " + roundUpGrade);
            return roundUpGrade;
        }

        public static void Info_For_Submission(StackLayout view)
        {
            if (!CrossConnectivity.Current.IsConnected)
                throw new Exception();

            if ( Variables.u_grader == 0 )
            {
                Variables.submissionInfo = Task.Run(
                    () => API.Get_Mod_Assign_Submission_Status(Variables.assignId, Variables.userId)).Result;

                var comments = Task.Run(
                    () => API.Get_core_comment_get_comments("module", Variables.true_assign.cmid, "assignsubmission_comments",
                    Variables.submissionInfo.lastattempt.submission.id, "submission_comments", 0));

                Variables.sumbissionComments = comments.Result;

                var task_response_status = Structure_Frame.Task_Response_Status_Frame(
                    Variables.submissionInfo.lastattempt.submission.status,
                    Variables.submissionInfo.lastattempt.gradingstatus);
                view.Children.Add(task_response_status);

                #region
                /*
                * для ответа вне системы (submissionsenabled если true то можно 
                * дать ответ, если false то нельзя), можно так же отследить в 
                * ответ вне системы или нет (но это не точно, лучше проверять plugins на наличие onlinetext и file)
                 */
                #endregion

                if ( Variables.submissionInfo.feedback != null )
                {
                    //Если feedack не пустой то будет segmented_control, а значит нужен кто оценил
                    var grader_list = Task.Run(() => API.Get_Core_user_get_users_by_field(
                       "id",
                       Variables.submissionInfo.feedback.grade.grader.ToString())).Result;
                    foreach ( var item in grader_list )
                        Variables.grader_inf = item;

                    var segmented_Control = new Segmented_Control_Practical_Work();
                    view.Children.Add(segmented_Control);
                }
                else
                {
                    Function.Check_Submission_Status_View(view,
                        Variables.submissionInfo.lastattempt);
                }

            }
            else
            {
                var participantsListFrame = Structure_Frame.Go_Participants_List_Page();
                view.Children.Add(participantsListFrame);

                var submissionListFrame = Structure_Frame.Go_Submission_List_Page();
                view.Children.Add(submissionListFrame);
            }
        }
        
        public static void Alert_Message_App(string text)
        {
            if (text == null)
            {
                DependencyService.Get <IDisplayAlertService>().ShowAlert(
                      "Внимание!!!", "Соединение с интернетом отсутствует", "Ok");
            }
            else
            {
                DependencyService.Get < IDisplayAlertService >().ShowAlert(
                      "Внимание!!!", text, "Ok");
            }
        }
    }

}