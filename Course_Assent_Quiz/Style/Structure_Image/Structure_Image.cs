using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Course_Assent_Quiz
{
    class Structure_Image
    {
        public static Image File_Type_Image(string mimeType)
        {
            string pathToImage = Function.Set_Image_For_Type(mimeType);

            var image = new Image()
            {
                Source = pathToImage,
                HeightRequest = 24,
                WidthRequest = 24,
            };

            return image;
        }
        public static CachedImage Image_Profile( string source )
        {
            var image = new CachedImage
            {
                Source = new Uri(source),

                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                DownsampleToViewSize = true,
                BackgroundColor = Color.White,
                Aspect = Aspect.AspectFill,
                HeightRequest = 40,
                WidthRequest = 40,
                Transformations = new List<ITransformation>() {
                    new CircleTransformation()
                }
            };

            return image;
        }

        public static Image Custom_Image(string pathToImage, int height, int width, 
                                        LayoutOptions horizontalOptions, LayoutOptions verticalOptions )
        {
            var image = new Image()
            {
                VerticalOptions = verticalOptions,
                HorizontalOptions = horizontalOptions,
                Source = pathToImage,
                HeightRequest = height,
                WidthRequest = width,
            };

            return image;
        }

        public static Image Fake_File_Type_Image(string source)
        {
            var image = new Image()
            {
                Source = source,
                HeightRequest = 24,
                WidthRequest = 24,
            };

            return image;
        }
    }
}
