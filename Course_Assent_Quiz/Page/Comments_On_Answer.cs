using System.Collections.Generic;
using Xamarin.Forms;
using static Course_Assent_Quiz.ApiModels;

namespace Course_Assent_Quiz
{
    class Comments_On_Answer : ContentPage
    {
        public Comments_On_Answer( List <Comment> sumbissionComments)
        {
            Title = "Комментарии к ответу";

            var comments_Layout = new StackLayout();

            if ( sumbissionComments.Count != 0)
            {
                foreach ( var comment in Variables.sumbissionComments.comments )
                {
                    var commentsOnAnswer = Structure_Frame.Comment_on_the_answer_frame(comment);
                    comments_Layout.Children.Add(commentsOnAnswer);
                }
            }
            else
            {
                //Добавить картинку что нет комментариев
            }

            Padding = 1;
            BackgroundColor = Color.FromHex("#293991");

            var scrollView = new ScrollView
            {
                Content = comments_Layout
            };
            this.Content = comments_Layout;
        }
    }
}
