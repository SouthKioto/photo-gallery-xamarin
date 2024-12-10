using App1.Classes;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        List<PhotoData> photos;
        List<PhotoData> photosByIndex;
        int index = 0;
        bool start_timer = false;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            photos = TxtFileHandler.GetPhotosFromFile();

            if (start_timer)
            {
                StartAutoChangePhotos();
            }
            else
            { 
                photoSlider.ItemsSource = photos;
                timer_button.Text = "Start";
            }
        }

        private void ChangePhotoPer5sec(object sender, EventArgs e)
        {
            start_timer = !start_timer;

            if (start_timer)
            {
                timer_button.Text = "Stop";
                StartAutoChangePhotos();
            }
            else
            {
                timer_button.Text = "Start";

                ReturnBaseSliderValue();

                if (photoSlider is CarouselView carousel)
                {
                    carousel.Position = 0;
                }
            }
        }

        private void StartAutoChangePhotos()
        {
            
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                index = (index + 1) % photos.Count;
                photosByIndex = new List<PhotoData> { photos[index] };

                photoSlider.ItemsSource = photosByIndex;

                return start_timer;
            });
        }

        private void ReturnBaseSliderValue()
        {
            photoSlider.ItemsSource = null;
            photoSlider.ItemsSource = photos;

            index = 0;
        }
    }
}
