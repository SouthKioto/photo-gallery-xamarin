using App1.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Xamarin.Essentials.Permissions;


namespace App1
{
    public class TxtFileHandler
    {
        public static string file_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "photos.txt");

        public static void CreatePhotoDatabase(string path)
        {
            string[] sources = { "https://szkocki.pl/wp-content/uploads/2019/04/The-Old-Man-of-Storr7.jpg",
                                 "https://www.podrozepokulturze.pl/wp-content/uploads/2019/06/szkocja-oban-glencoe-highlands-inveraray-zamki-1.jpg",
                                 "https://80rowerow.pl/wp-content/uploads/2017/08/vbhvhj.png" };

            List<PhotoData> photos = new List<PhotoData>();

            for (int i = 0; i < sources.Length; i++)
            {
                var example_data = new PhotoData
                {
                    Photo_Id = i,
                    Photo_Title = $"Zdjęcie numer. {i}",
                    Photo_Source = sources[i],
                };

                photos.Add(example_data);
            }
           
            string json_photos = JsonConvert.SerializeObject(photos);

            if (!File.Exists(path))
            {
                using(var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(json_photos);
                }
            }
        }

        public static List<PhotoData> GetPhotosFromFile()
        {
            List<PhotoData> photosList = new List<PhotoData>();

            if (File.Exists(file_path))
            {
                string contents = File.ReadAllText(file_path);

                photosList = JsonConvert.DeserializeObject<List<PhotoData>>(contents);
            }

            return photosList;
        }

        public static int GetLastPhotoId()
        {
            int lastPhotoId = 0;

            if (File.Exists(file_path))
            {
                string content = File.ReadAllText(file_path);
                List<PhotoData> photoDatas = new List<PhotoData>();

                photoDatas = JsonConvert.DeserializeObject<List<PhotoData>>(content);

                lastPhotoId = photoDatas.Max(p => p.Photo_Id);
            }
            return lastPhotoId;
        }
        
        public static void AddPhotoToFile(PhotoData data)
        {
            if(data != null)
            {
                List<PhotoData> newPhotos;
                string exist_data = File.ReadAllText(file_path);

                newPhotos = JsonConvert.DeserializeObject<List<PhotoData>>(exist_data);

                newPhotos.Add(data);

                string new_photos_serialized = JsonConvert.SerializeObject(newPhotos);

                if (File.Exists(file_path))
                {
                    using (var sw = new StreamWriter(file_path, false))
                    {
                        sw.WriteLine(new_photos_serialized);
                    }
                }
            }
        }
    }
}
