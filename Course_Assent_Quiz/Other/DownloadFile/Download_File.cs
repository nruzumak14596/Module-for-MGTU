using FormsPlugin.Iconize;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    public class Download_File : IconImage
    {
        public IDownloadFile File;
        Download_File_Progress download_File_Process;

        public Download_File( string file_url, Download_File_Progress download_File_Process )
        {
            this.download_File_Process = download_File_Process;
            Icon = "ion-ios-cloud-download-outline";
            //IconColor = Brand_Color.BrandColor;
            IconColor = Color.Red;
            BackgroundColor = Color.Transparent;
            HorizontalOptions = LayoutOptions.EndAndExpand;
            VerticalOptions = LayoutOptions.Center;
            HeightRequest = 30;
            WidthRequest = 30;

            int tapCount = 1;
            var FrametapGestureRecognizer = new TapGestureRecognizer();
            FrametapGestureRecognizer.NumberOfTapsRequired = tapCount;

            FrametapGestureRecognizer.Tapped += ( sender, e ) =>
            {
                if ( IsDownloading() )
                {
                    AbortDownloading();
                    return;
                }

                IsVisible = false;

                InitializeDownload(file_url);

                OnPropertyChanged();
                download_File_Process.IsVisible = true;

                StartDownloading(true);
            };

            GestureRecognizers.Add(FrametapGestureRecognizer);
        }


        public void OnPropertyChanged()
        {
            File.PropertyChanged += ( sender, e ) =>
            {

                // Update UI text-fields
                var downloadFile = ( ( IDownloadFile )sender );
                switch ( e.PropertyName )
                {
                    case nameof(IDownloadFile.Status):
                        //Text = downloadFile.Status.ToString();
                        break;
                    case nameof(IDownloadFile.StatusDetails):
                        //Text = downloadFile.StatusDetails;
                        break;
                    case nameof(IDownloadFile.TotalBytesExpected):
                        //Text = downloadFile.TotalBytesExpected.ToString();
                        break;
                    case nameof(IDownloadFile.TotalBytesWritten):
                        //Text = downloadFile.TotalBytesWritten.ToString();
                        break;
                }

                // Update UI if download-status changed.
                if ( e.PropertyName == "Status" )
                {
                    switch ( ( ( IDownloadFile )sender ).Status )
                    {
                        case DownloadFileStatus.COMPLETED:
                            //Alert_Message.Download_File_Finish();
                            download_File_Process.IsVisible = false;
                            download_File_Process.Progress = 0;
                            Icon = "ion-ios-cloud-download-outline";

                            //Text = Variables.ion_icon.Keys.First(p => p.StartsWith("ion-ios-cloud-download-outline", StringComparison.Ordinal));
                            IsVisible = true;
                            break;
                        case DownloadFileStatus.FAILED:
                        case DownloadFileStatus.CANCELED:
                            download_File_Process.IsVisible = false;
                            download_File_Process.Progress = 0;
                            Icon = "ion-ios-cloud-download-outline";

                            //Text = Variables.ion_icon.Keys.First(p => p.StartsWith("ion-ios-cloud-download-outline", StringComparison.Ordinal));
                            IsVisible = true;

                            // Get the path this file was saved to. When you didn't set a custom path, this will be some temporary directory.
                            // var nativeDownloadManager = (DownloadManager)ApplicationContext.GetSystemService(DownloadService);
                            //System.Diagnostics.Debug.WriteLine (nativeDownloadManager.GetUriForDownloadedFile (((DownloadFileImplementation)sender).Id));

                            // If you don't want your download to be listed in the native "Download" app after the download is finished
                            //nativeDownloadManager.Remove(((DownloadFileImplementation)sender).Id);
                            break;
                    }
                }

                // Update UI while donwloading.
                if ( e.PropertyName == "TotalBytesWritten" || e.PropertyName == "TotalBytesExpected" )
                {
                    var bytesExpected = ( ( IDownloadFile )sender ).TotalBytesExpected;

                    var bytesWritten = ( ( IDownloadFile )sender ).TotalBytesWritten;

                    if ( bytesExpected > 0 )
                    {
                        download_File_Process.Progress = Math.Round(bytesWritten / bytesExpected * 100);
                        var percentage = Math.Round(bytesWritten / bytesExpected * 100);
                    }
                }
            };
        }

        public void StartDownloading( bool mobileNetworkAllowed )
        {
            CrossDownloadManager.Current.Start(File, mobileNetworkAllowed);
        }

        public void InitializeDownload( string url_File )
        {
            Debug.WriteLine("url_File " + url_File);
            File = CrossDownloadManager.Current.CreateDownloadFile(url_File);
        }

        public void AbortDownloading()
        {
            CrossDownloadManager.Current.Abort(File);
        }

        public bool IsDownloading()
        {
            if ( File == null ) return false;

            switch ( File.Status )
            {
                case DownloadFileStatus.INITIALIZED:
                case DownloadFileStatus.PAUSED:
                case DownloadFileStatus.PENDING:
                case DownloadFileStatus.RUNNING:
                    return true;

                case DownloadFileStatus.COMPLETED:
                case DownloadFileStatus.CANCELED:
                case DownloadFileStatus.FAILED:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }
    }
}
