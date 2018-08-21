using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    class Participants_List : ContentPage
    {
        public ICommand goToGradingParticipantsPage { get; private set; }

        public Participants_List()
        {
            Title = "Участники";

            //Команды
            goToGradingParticipantsPage = new Command<int>(Go_To_Grading_Participant_Page);

            var part_List_Layout = new StackLayout();

            //Запрашиваем список студентов на задание (Второй параметр не понятен зачем и для чего)
            var participantsList = Task.Run(
                    () => API.Get_Mod_assign_list_participants(Variables.assignId, 0, "", 0, 0, 0, 1));

            foreach ( var participants in participantsList.Result )
            {
                var participantInformation = Structure_Frame.List_Submissions_Information_Frame(participants);
                part_List_Layout.Children.Add(participantInformation);
            }

            Padding = 1;
            BackgroundColor = Color.FromHex("#293991");

            var scrollView = new ScrollView
            {
                Content = part_List_Layout
            };
            this.Content = scrollView;

            this.BindingContext = this;
        }

        public async void Go_To_Grading_Participant_Page( int participantId )
        {
            Grading_Participants gradingParticipantsPage = new Grading_Participants(participantId);
            await Navigation.PushAsync(gradingParticipantsPage);
        }

    }
}
