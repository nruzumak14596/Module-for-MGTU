using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    public class App : Application
    {
        public App()
        {
            API.Host = new Uri("http://newlms2.magtu.ru");
            Variables.parameters = Post_Parameters.URL;

            MainPage = new NavigationPage(new Practical_Work())
            { BarBackgroundColor = Color.FromHex("#293991"), BarTextColor = Color.White };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
