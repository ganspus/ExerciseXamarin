using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ExerciseXamarin.Views
{
    public partial class Exercise2Page : ContentPage
    {
        private int _currentImageId = 1;

        public Exercise2Page()
        {
            InitializeComponent();

            _currentImageId = 1;

            LoadImage();
        }

        private void LoadImage()
        {
            image.Source = new UriImageSource
            {
                Uri = new Uri(String.Format("http://lorempixel.com/1920/1080/city/{0}", _currentImageId)),
                CachingEnabled = false
            };
        }

        void Left_Clicked(System.Object sender, System.EventArgs e)
        {
            _currentImageId--;
            if (_currentImageId == 0)
                _currentImageId = 10;

            LoadImage();
        }

        void Right_Clicked(System.Object sender, System.EventArgs e)
        {
            _currentImageId++;
            if (_currentImageId == 11)
                _currentImageId = 1;

            LoadImage();
        }
    }
}
