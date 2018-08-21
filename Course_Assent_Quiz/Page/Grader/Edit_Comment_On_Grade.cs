using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    class Edit_Comment_On_Grade : ContentPage
    {
        public static Editor editor;

        public Edit_Comment_On_Grade(string commentText)
        {
            Title = Variables.true_assign.name;

            var edit_Comment_Layout = new StackLayout();

            var saveResult = new ToolbarItem
            {
                Text = "Сохранить",
                Command = new Command(this.Save_Result),
            };

            var edit_Comment = Structure_Frame.Save_Or_Edit_Comment_On_Grade_Frame(commentText);
            edit_Comment_Layout.Children.Add(edit_Comment);

            this.ToolbarItems.Add(saveResult);

            Padding = 1;
            BackgroundColor = Color.FromHex("#293991");

            var scroll_View = new ScrollView
            {
                Content = edit_Comment_Layout
            };
            this.Content = scroll_View;

            this.BindingContext = this;
        }

        public async void Save_Result()
        {
            Grading_Participants.commentLabel.Text = editor.Text;

            await Navigation.PopAsync();
        }
    }
}
