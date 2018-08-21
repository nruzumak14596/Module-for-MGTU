using Plugin.Connectivity;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static Course_Assent_Quiz.ApiModels;

namespace Course_Assent_Quiz
{
    class Save_or_edit_submission : ContentPage
    {

        private StackLayout practical_Work_Layout;
        private List<Frame> List_Header_Assing;

        public static Editor editor;
		
		#region Зачем fileView
		/*
		Данный StackLayout нужен чтобы в него добавлять файлы
		которые мы выбрали на мобиле
		*/
		#endregion
        public static StackLayout fileView = new StackLayout();

        public ICommand openFilePicker { get; private set; }

        public Save_or_edit_submission(StackLayout practical_Work_Layout, List<Frame> List_Header_Assing)
        {
            this.practical_Work_Layout = practical_Work_Layout;
            this.List_Header_Assing = List_Header_Assing;
            var save_or_edit_Layout = new StackLayout();

            Title = Variables.true_assign.name;

            openFilePicker = new Command(Cross_File_Picker);

            var saveResult = new ToolbarItem
            {
                Text = "Сохранить",
                Command = new Command(this.Save_Result),
            };

            this.ToolbarItems.Add(saveResult);

            Variables.submissionInfo = Task.Run(
                   () => API.Get_Mod_Assign_Submission_Status(Variables.assignId, Variables.userId)).Result;

            var save_Or_Edit_Submission = Structure_Frame.Save_Or_Edit_Submission_Frame();
            save_or_edit_Layout.Children.Add(save_Or_Edit_Submission);

            Padding = 1;
            BackgroundColor = Color.FromHex("#293991");

            var scrollView = new ScrollView
            {
                Content = save_or_edit_Layout
            };
            this.Content = save_or_edit_Layout;

            this.BindingContext = this;
        }
		
		public async void Cross_File_Picker()
        {
            Variables.file = await CrossFilePicker.Current.PickFile();  
           
            if ( Variables.file != null)
            {
                //Нужно сделать так, кнопка с вызовом crossfilepicker видна пока не достигнут лимит файлов
                //То что сейчас сделано прокатит только с 1 файлом
                fileView.Children.Add(Structure_Frame.File_Ready_For_Upload_Frame(Variables.file.FileName));
            }         
        }
		
		public async void Save_Result()
		{
            if ( editor != null )
            {
                if ( Variables.wordLimit != 0 )
                {
                    if (editor.Text.Length > Variables.wordLimit)
                    {
                        //Размер для коммента слишком большой
                    }
                }
                else
                {
                    Onlinetext_editor textFromEdit = new Onlinetext_editor();
                    textFromEdit.format = 1; //Какие форматы и чем они отличаются тоже не понятно
                    textFromEdit.itemid = Variables.true_assign.id; //не до конца понятно зачем это
                    textFromEdit.text = editor.Text;

                    Plugindata plugindata = new Plugindata { onlinetext_editor = textFromEdit };

                    var saveAnswer = Task.Run(() => API.Get_Mod_assign_save_submission(
                        Variables.true_assign.id, plugindata));

                    practical_Work_Layout.Children.Clear();
                    foreach(var frame in List_Header_Assing){
                        practical_Work_Layout.Children.Add(frame);
                    }

                    Function.Info_For_Submission(practical_Work_Layout);
                }
            }

            if ( Variables.file != null )
            {
                //Здесь команда которая загружает файл на сервер
            }

            await Navigation.PopAsync();
        }       
    }
}
