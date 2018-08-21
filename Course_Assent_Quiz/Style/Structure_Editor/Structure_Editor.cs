using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    class Structure_Editor
    {
        public static Editor Text_Submission_Editor( string lastTextSubmission )
        {
            var editor = new Editor()
            {
                BackgroundColor = Color.White,
                Text = lastTextSubmission,
                FontSize = 16,
            };

            return editor;
        }

        public static Editor Rate_Submission_Editor (string grade)
        {
            var editor = new Editor()
            {
                Keyboard = Keyboard.Numeric,
                BackgroundColor = Color.White,
                Text = grade,
                TextColor = Color.Black,
                FontSize = 18,
            };

            return editor;
        }
    }
}
