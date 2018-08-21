using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    public class Download_File_Progress : CircularProgress
    {
        public Download_File_Progress()
        {
            Progress = 100;
            HorizontalOptions = LayoutOptions.EndAndExpand;
            VerticalOptions = LayoutOptions.Center;
            IsVisible = true;
        }
    }
}
