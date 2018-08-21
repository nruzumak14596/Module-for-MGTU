using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    public class Structure_Button
    {
        public static Button Go_To_Submission_Page_Button(string name)
        {
            var button = new Button
            {
                Text = name,
                FontSize = 16,
                BackgroundColor = Color.FromHex("#293991"),
                TextColor = Color.White,
                Margin = new Thickness(-5, 0, -5, 0),
                HeightRequest = 40,
            };
        
            return button;
        }


        public static Button Save_Submission_Button( )
        {
            var button = new Button
            {
                Text = "Сохранить",
            };

            return button;
        }
    }
}
