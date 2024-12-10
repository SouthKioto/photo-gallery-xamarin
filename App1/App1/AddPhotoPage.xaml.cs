using App1.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPhotoPage : ContentPage
	{
		public AddPhotoPage ()
		{
			InitializeComponent ();
		}

        private void AddPhotoToDatabase(object sender, EventArgs e)
        {
			string title = entry_title.Text;
			string source = entry_source.Text;

			if(!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(source))
            {
                int lastId = TxtFileHandler.GetLastPhotoId();

                

                var newPhoto = new PhotoData
                {
                    Photo_Title = title,
                    Photo_Source = source,
                    Photo_Id = lastId + 1,
                };

                TxtFileHandler.AddPhotoToFile(newPhoto);
            }
        }
    }
}