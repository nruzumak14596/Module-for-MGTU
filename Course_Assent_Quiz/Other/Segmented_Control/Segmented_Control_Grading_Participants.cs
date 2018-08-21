using SegmentedControl.FormsPlugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    class Segmented_Control_Grading_Participant : Frame
    {
        public SegmentedControl.FormsPlugin.Abstractions.SegmentedControl tab_Control;     
        public StackLayout view_segmenteds;
        public StackLayout view_frames;

        public Segmented_Control_Grading_Participant()
        {
            view_segmenteds = new StackLayout();
            view_frames = new StackLayout();

            var answer_Segment_Two = new SegmentedControlOption()
            {
                Text = "Ответ",   
            };

            var grades_Segment = new SegmentedControlOption()
            {
                Text = "Оценка",
            };

            tab_Control = new SegmentedControl.FormsPlugin.Abstractions.SegmentedControl
            {
                TintColor = Color.White,
                SelectedTextColor = Color.Black,
                BackgroundColor = Color.FromHex("#293991"),
                Children = { answer_Segment_Two, grades_Segment  }
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
            SegmentedControl.FormsPlugin.Abstractions.ValueChangedEventArgs e)
        {
            view_frames.Children.Clear();
            switch ( e.NewValue )
            {
                case 0:
                    if ( Variables.submissionInfo.lastattempt.submission.status == "new" )
                    {
                        view_frames.Children.Add(Structure_Frame.Value_comments_on_the_answer_frame(
                            Variables.sumbissionComments.comments));

                        view_frames.Children.Add(Structure_Frame.Can_Edit_Status_Frame(
                            Variables.submissionInfo.lastattempt.caneditowner));
                    }
                    else
                    {
                        
                        view_frames.Children.Add(Structure_Frame.Answer_Frame(
                            Variables.submissionInfo.lastattempt.submission.plugins));

                        view_frames.Children.Add(Structure_Frame.Value_comments_on_the_answer_frame(
                            Variables.sumbissionComments.comments));

                        view_frames.Children.Add(Structure_Frame.Last_Change_Frame(
                            Variables.submissionInfo.lastattempt.submission.timemodified));

                        view_frames.Children.Add(Structure_Frame.Can_Edit_Status_Frame(
                            Variables.submissionInfo.lastattempt.caneditowner));
                    }
                    break;
                case 1:
                    if ( Variables.submissionInfo.lastattempt.gradingstatus == "graded" )
                    {
                        view_frames.Children.Add(Structure_Frame.Rate_Participant_Submission_Frame(
                            Variables.true_assign.grade, 
                            Variables.submissionInfo.feedback.grade.grade));
                    }
                    else
                    {
                        var frame = Structure_Frame.Rate_Participant_Submission_Frame(
                            Variables.true_assign.grade, "");

                        view_frames.Children.Add(frame);
                    }

                    view_frames.Children.Add(Structure_Frame.Edit_Comment_On_Grade_Frame());

                    if ( Variables.submissionInfo.feedback != null )
                    {
                        var frame = Structure_Frame.Grader_Frame(
                            Variables.grader_inf, Variables.submissionInfo.feedback.grade.timemodified);
                                                  
                        view_frames.Children.Add(frame);
                    }
                    
                    break;
            }
        }
    }
}
