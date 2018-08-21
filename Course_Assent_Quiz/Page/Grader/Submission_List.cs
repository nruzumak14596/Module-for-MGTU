using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    class Submission_List : ContentPage
    {
        public ICommand goToGradingParticipantsPage { get; private set; }

        public Submission_List()
        {
            Title =  "Ответы";

            goToGradingParticipantsPage = new Command<int>(Go_To_Grading_Participants_Page);

            var subm_List_Layout = new StackLayout();

            var participantsList = Task.Run(
                    () => API.Get_Mod_assign_list_participants(Variables.assignId, 0, "", 0, 0, 0, 1));

            foreach ( var participants in participantsList.Result )
            {
                if ( participants.submitted == true )
                {
                    var participantInformation = Structure_Frame.List_Submissions_Information_Frame(participants);
                    subm_List_Layout.Children.Add(participantInformation);
                }
            }

            Padding = 1;
            BackgroundColor = Color.FromHex("#293991");

            var scrollView = new ScrollView
            {
                Content = subm_List_Layout
            };
            this.Content = scrollView;

            this.BindingContext = this; 
        }

        public async void Go_To_Grading_Participants_Page( int participantId )
        {
            Grading_Participants gradingParticipantsPage = new Grading_Participants(participantId);
            await Navigation.PushAsync(gradingParticipantsPage);
        }
    }
}
