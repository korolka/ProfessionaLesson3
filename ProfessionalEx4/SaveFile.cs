using Newtonsoft.Json;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Media;

namespace ProfessionalEx4
{
    class SaveFile
    {
        
        public void SaveSet(Color color)
        {
            IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForAssembly();

            IsolatedStorageFileStream isolatedStream = new IsolatedStorageFileStream("ColorInf.txt", FileMode.Create, storageFile);

            Color colors = color;
            string content = JsonConvert.SerializeObject(colors);
            StreamWriter streamWriter = new StreamWriter(isolatedStream);
            streamWriter.WriteLine(content);
            streamWriter.Close();
            isolatedStream.Close();

        }

        public Color ReadSet()
        {
            IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream isolatedStream = new IsolatedStorageFileStream("ColorInf.txt", FileMode.Open, storageFile);
            using (StreamReader sr = new StreamReader(isolatedStream))
            {
                try
                {
                    Color color = JsonConvert.DeserializeObject<Color>(sr.ReadLine());
                    return color;
                }
                catch
                {
                    return Colors.Black;
                }
                
            }
        }

    }
    
}
