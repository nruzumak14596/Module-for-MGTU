using System;
using Android.App;
using Android.Content.Res;
using Android.Widget;
using Course_Assent_Quiz.Droid;
using Xamarin.Forms;

// Этот класс используется для вызова окна с представление ошибки или предупреждение
[assembly: Dependency(typeof(AndroidDisplayAlertService))]
namespace Course_Assent_Quiz.Droid
{
    public class AndroidDisplayAlertService : IDisplayAlertService
    {
        public void ShowAlert(string title, string content, string buttonText)
        {
            var alert = new AlertDialog.Builder(Forms.Context);
            alert.SetTitle(title);
            alert.SetMessage(content);
            alert.SetNegativeButton(buttonText, (sender, e) => { });

            var dialog = alert.Show();
            BrandAlertDialog(dialog);
        }
        
        public static void BrandAlertDialog(AlertDialog dialog)
        {
            try
            {
                Resources resources = dialog.Context.Resources;

                #pragma warning disable CS0618 // Type or member is obsolete
                var color = dialog.Context.Resources.GetColor(Resource.Color.abc_btn_colored_text_material);
                #pragma warning restore CS0618 // Type or member is obsolete

                var alertTitleId = resources.GetIdentifier("alertTitle", "id", "android");
                var alertTitle = (TextView)dialog.Window.DecorView.FindViewById(alertTitleId);
                alertTitle.SetTextColor(color); // change title text color

                var titleDividerId = resources.GetIdentifier("titleDivider", "id", "android");
                var titleDivider = dialog.Window.DecorView.FindViewById(titleDividerId);
                titleDivider.SetBackgroundColor(color); // change divider color
            }
            catch
            {
                //Can't change dialog brand color
            }
        }
    }
}