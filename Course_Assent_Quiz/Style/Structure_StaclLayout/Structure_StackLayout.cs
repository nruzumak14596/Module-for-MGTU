using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    public class Structure_StackLayout 
    {     
        public static StackLayout Inside_Frame_StackLayout(){

            var view = new StackLayout();

            return view;
        }

        public static StackLayout Inside_Frame_View_Orientation(
            StackOrientation orientation){

            var view = new StackLayout();
            view.Orientation = orientation;

            return view;
        }

        public static StackLayout View_Frame(){

            var view = new StackLayout{
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            return view;
        }

    }
}

