using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using static Course_Assent_Quiz.ApiModels;

namespace Course_Assent_Quiz
{
    public class Variables
    {
        public static Dictionary<string, string> parameters;

        public static CultureInfo ru_Ru = new CultureInfo("ru-Ru");

        public static DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        

        public static string token_user = "e253b001a9d8210755c9869f712c21d2";

        public static string submission_status;
        public static Color submission_color;
        public static string grading_status;
        public static Color grading_color;

        public static Assignment true_assign;
        public static Users grader_inf;
        public static Core_comment_get_comments sumbissionComments;
        public static Mod_assign_get_submission_status submissionInfo;
        public static int wordLimit;
		public static int fileCountLimit;
		public static int fileSizeLimit;
        public static FileData file;

        //Студент 0, препод 1
        public static int u_grader = 0;
        public static int userId = 5265;
        public static int assignId = 9473; //9449;
        public static int courseId = 78427; //78426;

        //Студент курс = 78426
        //int assign_id = 9449; //первое задание, файл, отправлен, оценен
        //int assign_id = 9450; //второе задание, отправлено на проверку, но не оценено (нет кнопки)
        //int assign_id = 9452; //отправить файл (пустое все)
        //int assign_id = 9462; //отправить файл 1(отправлено для ответа но не оценено, кнопка редактировать есть))
        //int assign_id = 9465; //отправить несколько файлов 3 (отправлено два, кнопка редактировать есть)
        //int assign_id = 9471; //ответ вне системы 3 
        //int assign_id = 9457; //отправить файл 2 (возможность дать ответ откроется через некоторое время) 
        //int assign_id = 9466; //отправить комментарий 1 (дан ответ не просрочен)
        //int assign_id = 9454; //отправить комментарий (комментарий есть, просрочено не оценено, есть кнопка редактировать)
        //int assign_id = 9455; //отправить комментарий или файл (отправлено и то и то, просрочено, не оценено)
        //int assign_id = 9469; //отправить файл или комментарий 3 (ничего не отправленно, просроченно)
        //int assign_id = 9464; //отправить несколько файлов 1 (ничего не отправлено, просроченно) 
        //9453 - отправить несколько файлов (есть коммент)

        //Преподаватель курс = 78427
        //int assign_id = 9473; //отправить файл, файлов нет, ответа нет
        //int assign_id = 9474; //отправить файл 1, отправлен, оценен
        //int assign_id = 9477; //отправить несколько файлов 1, отправлен
        //int assign_id = 9479; //отправить комментарий 1, отправлен
        //int assign_id = 9478; //отправить комментарий , ничего нет
        //int assign_id = 9475; //Отправить несколько файлов, не отправлено, НО ОЦЕНЕНО!


    }
}

