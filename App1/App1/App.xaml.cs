using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "photos.txt");

            Console.WriteLine($"DataPath {path}");

            TxtFileHandler.CreatePhotoDatabase(path);

            MainPage = new HomeTabbetPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
