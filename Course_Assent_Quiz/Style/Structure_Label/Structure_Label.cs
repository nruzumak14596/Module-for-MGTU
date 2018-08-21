using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    public class Structure_Label
    {
        public static Html_Formatted_Text Tag_Label(string text, Color color, 
                                                    int size)
        {

            var label = new Html_Formatted_Text{
                Text = text,
                TextColor = color,
                FontSize = size
            };

            return label;
        }

        public static Label Custom_Label(string text, Color color,
                                            int size){

            var label = new Label
            {
                Text = text,
                TextColor = color,
                FontSize = size
            };

            return label;
        }

        public static Label Theme_Label(string text)
        {
            var label = new Label {
                Text = text,
                TextColor = Color.Black,
                FontSize = 18
            };

            return label;
        }

        public static Label Description_Label( string text )
        {
            var label = new Label
            {
                Text = text,
                TextColor = Color.Gray,
                FontSize = 16
            };

            return label;
        }

        public static Label Response_Status_Frame_Label(string text, Color color)
        {
            var label = new Label
            {
                Text = text,
                TextColor = color,
                FontSize = 18,
                FontAttributes = FontAttributes.Bold
            };

            return label;
        }

        public static Label File_Name_Label( string text)
        {
            var label = new Label
            {
                Text = text,
                TextColor = Color.Gray,
                FontSize = 16
            };

            return label;
        }

        public static Label Time_Left_Frame_Label(double unix_time_modified, 
                                                  long unix_grading_due_date)
        {

            if (unix_time_modified > unix_grading_due_date) {
                
                var date = Function.Difference_Of_Dates(unix_time_modified, 
                                                        unix_grading_due_date);

                if ( Variables.submissionInfo.lastattempt.submission.status == "new" )
                {
                    var text = "Задание просроченно на: " + date;
                    return Custom_Label(text, Color.Red, 16);
                }
                else
                {
                    var text = "Задание представлено с опозданием - " + date;
                    return Custom_Label(text, Color.Gray, 16);
                }
            } else {
                
                var text = Function.Difference_Of_Dates(unix_grading_due_date,
                                                        unix_time_modified);

                return Custom_Label(text, Color.Gray, 16);
            }
        }
    }
}

