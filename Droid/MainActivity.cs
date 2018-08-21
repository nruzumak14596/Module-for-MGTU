using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Course_Assent_Quiz.Droid;
using FFImageLoading.Forms.Droid;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Course_Assent_Quiz.Droid
{
    [Activity(Label = "Course_Assent_Quiz.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate( Bundle bundle )
        {
            CachedImageRenderer.Init(enableFastRenderer: true);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
           
            global::Xamarin.Forms.Forms.Init(this, bundle);

            Downloaded();
            LoadApplication(new App());
        }
        
        
        public void Downloaded()
        {
            CrossDownloadManager.Current.PathNameForDownloadedFile = new Func<IDownloadFile, string>(file =>
            {
                string fileName = Android.Net.Uri.Parse(file.Url).Path.Split('/').Last();
                return Path.Combine(ApplicationContext.GetExternalFilesDir(
                    Android.OS.Environment.DirectoryDownloads).AbsolutePath, fileName);
            });           
        }
    }
}
