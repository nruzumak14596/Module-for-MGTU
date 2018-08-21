using Xamarin.Forms;
using SegmentedControl.FormsPlugin.Abstractions;

namespace Course_Assent_Quiz
{
    public class Segmented_Control_Practical_Work : Frame
    {
        public SegmentedControl.FormsPlugin.Abstractions.SegmentedControl tab_Control;
        public StackLayout view_segmenteds;
        public StackLayout view_frames;

        public Segmented_Control_Practical_Work()
        {
            //этот StackLayout нужен для отображения переключателей
            view_segmenteds = new StackLayout();
            //этот StackLayout нужен для вывода содержимого  
            view_frames = new StackLayout();

            var grades_Segment = new SegmentedControlOption()
            {
                Text = "Оценки",              
            };

            var answer_Segment_Two = new SegmentedControlOption()
            {
                Text = "Ответы"
            };

            tab_Control = new SegmentedControl.FormsPlugin.Abstractions.SegmentedControl
            {           
                TintColor = Color.White,
                SelectedTextColor = Color.Black,              
                BackgroundColor = Color.FromHex("#293991"),
                Children = { grades_Segment, answer_Segment_Two }
            };

            tab_Control.ValueChanged += Handle_ValueChanged;
            view_segmenteds.Children.Add(tab_Control);
            view_segmenteds.Children.Add(view_frames);

            Padding = 1;
            HasShadow = false;
            BackgroundColor = Color.FromHex("#293991");

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { view_segmenteds }
            };
        }

        public void Handle_ValueChanged(
            object o,
            SegmentedControl.FormsPlugin.Abstractions.ValueChangedEventArgs e )
        {
            view_frames.Children.Clear();
            switch ( e.NewValue )
            {
               case 0:
                    Function.Check_Submission_Status_View(view_frames, 
                        Variables.submissionInfo.lastattempt);
                    break;
                case 1:

                    if (Variables.submissionInfo.lastattempt.gradingstatus == "graded" )
                    {
                        view_frames.Children.Add(Structure_Frame.Grade_In_Journal_Frame(
                            Variables.submissionInfo.feedback.gradefordisplay));
                    }

                    view_frames.Children.Add(Structure_Frame.Comment_Grader_On_The_Answer_Frame(
                        Variables.submissionInfo.feedback.plugins));

                    view_frames.Children.Add(Structure_Frame.Grader_Frame(
                        Variables.grader_inf, Variables.submissionInfo.feedback.grade.timemodified));
                    break;
            }
        }
    }
}