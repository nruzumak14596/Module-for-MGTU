using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;
using static Course_Assent_Quiz.ApiModels;
using System.Diagnostics;
using System.Net;

namespace Course_Assent_Quiz
{
    public class API
    {
        #region Properties

        public static bool True_Or_False(string text)
        {

            bool result;

            if (text.Length != 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        private static Uri _host;

        public static Uri Host
        {
            get { return _host; }
            set { _host = value; }
        }

        /// <summary>
        /// Represents if the host address is set.
        /// </summary>
        /*в Host у нас храниться url http://newlms2.magtu.ru
        AbsoluteUri вытаскивает вот этот url 
        мы кидаем host в True_Or_False для того чтобы определить живой ли сервер
        */
        
        private static bool HostIsSet => True_Or_False(Host.AbsoluteUri); //Host.AbsoluteUri.Any();

        #endregion

        #region Assign

        #region Mod_assign_get_assignments

        public static Task<string> URL_Data_Post(string url, FormUrlEncodedContent data)
        {
            if (HostIsSet)
                return Get_Test(Host.AbsoluteUri + url, data);   //к http://newlms2.magtu.ru добавляем наш адрес

            else
                throw new Exception("Host is not set");
        }

        #endregion

        #endregion

        public static CookieContainer CookieJar = new CookieContainer();

        private static async Task<string> Get_Test(string uri, FormUrlEncodedContent data)
        {
            try
            {
                using (HttpClientHandler handler = new HttpClientHandler { CookieContainer = CookieJar })
                /*
                  создаем переменную типа HttpClientHandler с нашими куками
                */

                using (var client = new HttpClient(handler))
                /*
                  создаем запрос на сервер который даст нам куки
                  HttpClient(HttpMessageHandler) Инициализирует новый экземпляр класса HttpClient указанным обработчиком.
                */

                using (HttpResponseMessage response = await client.PostAsync(uri, data))
                // делаем запрос и закидываем результат в response

                using (HttpContent content = response.Content) //закидываем в content полученные данные
                {
                    var result = await content.ReadAsStringAsync();
                    //расшифровка того что там сказал сервер  json

                    return result;
                }
            }
            catch (WebException)
            {
                throw new WebException("No server connection.");
            }
        }

        /*
         Крус id - 78426 (Проверка заданий)

        core_course_get_contents - что лежит внутри курса

        {
            "id": 752529,
            "name": "Практические занятия",
            "visible": 1,
            "summary": "",
            "summaryformat": 1,
            "section": 2,
            "hiddenbynumsections": 0,
            "uservisible": true,
            "modules": [
              {
                "id": 305112,
                "url": "http://newlms2.magtu.ru/mod/assign/view.php?id=305112",
                "name": "ПРАКТИЧЕСКАЯ РАБОТА №1",
                "instance": 9449,
                "description": "<div class=\"no-overflow\"><p><strong>Тема: \"Контурное взрывание на карьерах\".</strong></p>\n<p>Задание оценивается в 5 баллов. Минимальная оценка необходимая для сдачи - 3 балла.</p></div>",
                "visible": 1,
                "uservisible": true,
                "visibleoncoursepage": 1,
                "modicon": "http://newlms2.magtu.ru/theme/image.php?theme=eguru&component=assign&image=icon&svg=0",
                "modname": "assign",
                "modplural": "Задания",
                "availability": null,
                "indent": 0
              },
              {
                "id": 305113,
                "url": "http://newlms2.magtu.ru/mod/assign/view.php?id=305113",
                "name": "ПРАКТИЧЕСКАЯ РАБОТА №2",
                "instance": 9450,
                "description": "<div class=\"no-overflow\"><p><strong>Тема: \"Буровзрывные работы у бокового контура котлованов ответственных сооружений\".</strong></p>\n<p>Задание оценивается в 5 баллов. Минимальная оценка необходимая для сдачи - 3 балла.</p></div>",
                "visible": 1,
                "uservisible": true,
                "visibleoncoursepage": 1,
                "modicon": "http://newlms2.magtu.ru/theme/image.php?theme=eguru&component=assign&image=icon&svg=0",
                "modname": "assign",
                "modplural": "Задания",
                "availability": null,
                "indent": 0
              }
            ]
          },
          {
            "id": 752531,
            "name": "Текущая аттестация",
            "visible": 1,
            "summary": "",
            "summaryformat": 1,
            "section": 4,
            "hiddenbynumsections": 0,
            "uservisible": true,
            "modules": [
              {
                "id": 305114,
                "url": "http://newlms2.magtu.ru/mod/quiz/view.php?id=305114",
                "name": "Контрольная работа (тест) №1",
                "instance": 2543,
                "description": "<div class=\"no-overflow\"><p>Контрольная работа по материалам 1-4 лекции.</p></div>",
                "visible": 1,
                "uservisible": true,
                "visibleoncoursepage": 1,
                "modicon": "http://newlms2.magtu.ru/theme/image.php?theme=eguru&component=quiz&image=icon&svg=0",
                "modname": "quiz",
                "modplural": "Тесты",
                "availability": null,
                "indent": 0
              },
              {
                "id": 305115,
                "url": "http://newlms2.magtu.ru/mod/quiz/view.php?id=305115",
                "name": "Контрольная работа (тест) №2",
                "instance": 2544,
                "description": "<div class=\"no-overflow\"><p>Контрольная работа по материалам 5-8 лекции.</p></div>",
                "visible": 1,
                "uservisible": true,
                "visibleoncoursepage": 1,
                "modicon": "http://newlms2.magtu.ru/theme/image.php?theme=eguru&component=quiz&image=icon&svg=0",
                "modname": "quiz",
                "modplural": "Тесты",
                "availability": null,
                "indent": 0
              }
            ]
          },
         */

        private static string token_User = "e253b001a9d8210755c9869f712c21d2";
        // Глеб токен - 737a4b4331402dd8f78ae8418937b1ff
        // Андрей токен - e253b001a9d8210755c9869f712c21d2
        private static string id_client_t = "5265";
        // Глеб id user - 5178
        // Андрей id user - 5265
        public static string alert_message_no_connection_to_the_internet = "Нет интернета";
        private static string moodle_URL = "webservice/rest/server.php";
        private static string moodle_URL_upload = "/webservice/upload.php";

        public static async Task<List<Users>> Get_Core_user_get_users_by_field( string field, string values )
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

               var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "core_user_get_users_by_field"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["field"], field.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["values[0]"], values.ToString()),
                });
                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("response Core_user_get_users_by_field " + response);

                var result = JsonConvert.DeserializeObject<List<Users>>(response);
                return result;
            }
            catch ( Exception ex )
            {
                // Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Core_comment_get_comments> Get_core_comment_get_comments( string contextlevel, int instanceid,
                                                                                           string component , int itemid, 
                                                                                           string area, int page)
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "core_comment_get_comments"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["contextlevel"], contextlevel),
                        new KeyValuePair<string, string>(Variables.parameters["instanceid"], instanceid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["component"], component),
                        new KeyValuePair<string, string>(Variables.parameters["itemid"], itemid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["area"], area.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["page"], page.ToString())
                });
                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("response Core_comment_get_comments " + response);

                var result = JsonConvert.DeserializeObject<Core_comment_get_comments>(response);
                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_get_assignments> Get_Mod_Assign_Assignments(int courseid) 
        {

            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_get_assignments"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"), 
                        new KeyValuePair<string, string>(Variables.parameters["courseids[0]"], courseid.ToString())  
                });
                var response = await Task.Run(() =>  URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("response_mod_assign_get_assignments " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_get_assignments>(response);
                return result;
            }
            catch (Exception ex)
            {
                // Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_get_grades> Get_Mod_Assign_Get_Grades(int assignmentids )
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                    throw new Exception(alert_message_no_connection_to_the_internet);
                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_get_grades"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentids[0]"], assignmentids.ToString()),
                        //new KeyValuePair<string, string>(Variables.parameters["since"], since.ToString())

                });
                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("response_mod_assign_get_grades " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_get_grades>(response);
                return result;
            }
            catch (Exception ex)
            {
                // Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_copy_previous_attempt> Get_Mod_assign_copy_previous_attempt( int assignmentid )    //Access to the function Mod_assign_copy_previous_attempt() is not allowed
        {
          
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);
                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "Mod_assign_copy_previous_attempt"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString())

                });
                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                var result = JsonConvert.DeserializeObject<Mod_assign_copy_previous_attempt>(response);

                Debug.WriteLine("result " + response);

                return result;
            }
            catch ( Exception ex )
            {
                // Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_get_participant> Get_Mod_assign_get_participant( int assignid, int userid, int embeduser ) //вроде как работает но ругается что пользователя нет в этом курсе
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);
                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_get_participant"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["userid"], userid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["assignid"], assignid.ToString()),      
                        new KeyValuePair<string, string>(Variables.parameters["embeduser"], embeduser.ToString()),
                });
                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("response Mod_assign_get_participant " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_get_participant>(response);

                return result;
            }
            catch ( Exception ex )
            {
                // Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_get_submissions> Get_Mod_assign_get_submissions( int assignmentids, string status ) //норм 
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);
                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_get_submissions"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentids[0]"], assignmentids.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["status"], status.ToString())


                });
                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("response Mod_assign_get_submissions " + response);
                var result = JsonConvert.DeserializeObject<Mod_assign_get_submissions>(response);



                return result;
            }
            catch ( Exception ex )
            {
                // Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_get_submission_status> Get_Mod_Assign_Submission_Status(int assignId, int userId ) //норм
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_get_submission_status"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignid"], assignId.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["userid"], userId.ToString())
                    });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                var result = JsonConvert.DeserializeObject<Mod_assign_get_submission_status>(response);

                Debug.WriteLine("response_Mod_assign_get_submission_status " + response);

                return result;
            }
            catch (Exception ex)
            {
                // Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_get_user_flags> Get_assign_get_user_flags( int assignmentids ) //не полностью параметры для Assigments//создал класс userflags
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_get_user_flags"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentids[0]"], assignmentids.ToString()) //assign-задание instance - пример
                    });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_get_user_flags>(response);

                return result;
            }
            catch ( Exception ex )
            {
                // Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_get_user_mappings> Get_Mod_assign_get_user_mappings( int assignmentids ) //не полностью параметры для Assigments//создал класс Mappings
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_get_user_mappings"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentids[0]"], assignmentids.ToString()) //assign-задание instance - пример
                    });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_get_user_mappings>(response);

                return result;
            }
            catch ( Exception ex )
            {
                // Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<List<Mod_assign_list_participants>> Get_Mod_assign_list_participants( int assignid, int groupid, string filter,
            int skip, int limit, int onlyids, int includeenrolments) //работает, но ниего не выдает скорее всего связанно с тем что нет участников
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_list_participants"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignid"], assignid.ToString()), //assign-задание instance - пример
                        new KeyValuePair<string, string>(Variables.parameters["groupid"], groupid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["filter"], filter.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["skip"], skip.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["limit"], limit.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["onlyids"], onlyids.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["includeenrolments"], includeenrolments.ToString())
                    });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("response Get_Mod_assign_list_participants" + response);

                var result = JsonConvert.DeserializeObject<List<Mod_assign_list_participants>>(response);

                return result;
            }
            catch ( Exception ex )
            {
                 //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_lock_submissions> Get_Mod_assign_lock_submissions( int assignmentid) //сервер отвечает пустое сообщение
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_lock_submissions"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["userids[0]"], id_client_t)

                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_lock_submissions>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_reveal_identities> Get_Mod_assign_reveal_identities( int assignmentid ) //норм
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_reveal_identities"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString()),

                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_reveal_identities>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_revert_submissions_to_draft> Get_Mod_assign_revert_submissions_to_draft( int assignmentid ) //сервер отвечает пустое сообщение
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_revert_submissions_to_draft"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["userids[0]"], id_client_t)

                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_revert_submissions_to_draft>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_save_grade> Get_Mod_assign_save_grade( int assignmentid, int userid, double grade, int attemptnumber,
            int addattempt, string workflowstate, int applytoall, Plugindata plugindata ) //сложно не могу сделать
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_save_grade"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["userid"], userid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["grade"], grade.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["attemptnumber"], attemptnumber.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["addattempt"], addattempt.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["workflowstate"], workflowstate),
                        new KeyValuePair<string, string>(Variables.parameters["applytoall"], applytoall.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["plugindata[assignfeedbackcomments_editor][text]"], plugindata.assignfeedbackcomments_editor.text.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["plugindata[assignfeedbackcomments_editor][format]"], plugindata.assignfeedbackcomments_editor.format.ToString()),
                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("response  Get_Mod_assign_save_grade " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_save_grade>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_save_grades> Get_Mod_assign_save_grades( int assignmentid, int applytoall ) //сложно не могу сделать
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_save_grades"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["applytoall"], applytoall.ToString())


                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_save_grades>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_save_submission> Get_Mod_assign_save_submission( int assignmentid, Plugindata plugindata) //сложно не могу сделать
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_save_submission"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["plugindata[onlinetext_editor][text]"], plugindata.onlinetext_editor.text.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["plugindata[onlinetext_editor][format]"], plugindata.onlinetext_editor.format.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["plugindata[onlinetext_editor][itemid]"], plugindata.onlinetext_editor.itemid.ToString()),
                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("response Mod_assign_save_submission " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_save_submission>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_save_user_extensions> Get_Mod_assign_save_user_extensions( int assignmentid, int userids, int dates ) //вообще нет реакции
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_save_user_extensions"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["userids[0]"], userids.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["dates[0]"], dates.ToString()),
                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_save_user_extensions>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_set_user_flags> Get_Mod_assign_set_user_flags( int assignmentid, Userflags userflags ) //не понятно с классом
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_set_user_flags"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["userflags"], userflags.ToString())
                        
                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_set_user_flags>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_submit_for_grading> Get_Mod_assign_submit_for_grading( int assignmentid, int acceptsubmissionstatement ) //вроде норм, но говорит что нет прав
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_submit_for_grading"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["acceptsubmissionstatement"], acceptsubmissionstatement.ToString())

                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_submit_for_grading>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_submit_grading_form> Get_Mod_assign_submit_grading_form( int assignmentid, int userid, string jsonformdata ) //не понятно с jsonformdata
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_submit_grading_form"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["userid"], userid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["jsonformdata"], jsonformdata)

                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_submit_grading_form>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_unlock_submissions> Get_Mod_assign_unlock_submissions( int assignmentid, int userids) //вроде ок
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_unlock_submissions"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignmentid"], assignmentid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["userids[0]"], userids.ToString()),
                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_unlock_submissions>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_view_assign> Get_Mod_assign_view_assign( int assignid ) //вроде ок
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_view_assign"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignid"], assignid.ToString()),
                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_view_assign>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_view_grading_table> Get_Mod_assign_view_grading_table( int assignid ) //вроде ок
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_view_grading_table"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignid"], assignid.ToString()),
                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_view_grading_table>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Mod_assign_view_submission_status> Get_Mod_assign_view_submission_status( int assignid ) //вроде ок
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "mod_assign_view_submission_status"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["assignid"], assignid.ToString()),
                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result " + response);

                var result = JsonConvert.DeserializeObject<Mod_assign_view_submission_status>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Core_files_upload> Get_Core_Files_Upload( int contextid, string component,
                                                                            string filearea, int itemid,
                                                                            string filepath, string filename,
                                                                            string filecontent, string contextlevel,
                                                                            int instanceid) 
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "core_files_upload"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                        new KeyValuePair<string, string>(Variables.parameters["contextid"], contextid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["component"], component.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["filearea"], filearea.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["itemid"], itemid.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["filepath"], filepath.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["filename"], filename.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["filecontent"], filecontent.ToString()),                
                        new KeyValuePair<string, string>(Variables.parameters["contextlevel"], contextlevel.ToString()),
                        new KeyValuePair<string, string>(Variables.parameters["instanceid"], instanceid.ToString()),
                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("result Get_Core_Files_Upload" + response);

                var result = JsonConvert.DeserializeObject<Core_files_upload>(response);

                return result;
            }
            catch ( Exception ex )
            {
                //Function.Alert_Message_App(ex.Message);
                return null;
            }
        }

        public static async Task<Object> Core_Files_Get_Files()
        {
            try
            {
                if ( !CrossConnectivity.Current.IsConnected )
                    throw new Exception(alert_message_no_connection_to_the_internet);

                var data = new FormUrlEncodedContent(new[]
                {
                        //new KeyValuePair<string, string>(Variables.parameters["token"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wstoken"], token_User),
                        new KeyValuePair<string, string>(Variables.parameters["wsfunction"], "core_files_upload"),
                        new KeyValuePair<string, string>(Variables.parameters["moodlewsrestformat"], "json"),
                });

                var response = await Task.Run(() => URL_Data_Post(moodle_URL, data));

                Debug.WriteLine("response Get_Core_Files_Upload " + response);

                var result = JsonConvert.DeserializeObject<Object>(response);
                return result;
            }
            catch ( Exception ex )
            {
                // Function.Alert_Message_App(ex.Message);
                return null;
            }
        }
    }
}