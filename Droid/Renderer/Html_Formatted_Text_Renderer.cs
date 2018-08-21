using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Course_Assent_Quiz.Droid;
using Course_Assent_Quiz;

[assembly: ExportRenderer(typeof(Html_Formatted_Text), typeof(Html_Formatted_Text_Renderer))]
namespace Course_Assent_Quiz.Droid
{
    public class Html_Formatted_Text_Renderer : LabelRenderer
    {
#pragma warning disable RECS0004 // Пустой открытый конструктор без параметров является избыточным.
#pragma warning disable CS0618 // Type or member is obsolete
        public Html_Formatted_Text_Renderer(){ }
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore RECS0004 // Пустой открытый конструктор без параметров является избыточным.

        protected override void OnElementChanged( ElementChangedEventArgs<Label> e )
        {
            base.OnElementChanged(e);

            var view = (Html_Formatted_Text)Element;
            if ( view == null ) return;

#pragma warning disable CS0618 // Type or member is obsolete
            Control.SetText(Html.FromHtml(view.Text.ToString()), TextView.BufferType.Spannable);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}