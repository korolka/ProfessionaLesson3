//Завдання 3

//Напишіть програму для пошуку заданого файлу на диску.
//    Додайте код, який використовує клас FileStream 
//    і дозволяє переглядати файл у текстовому вікні. 
//    Насамкінець додайте можливість стиснення знайденого файлу.
using System.IO.Compression;

namespace ProfessionalEx3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string catalog = @"C:";
            string findFile = "test.txt";
            FileInfo file = null;

            //програму для пошуку заданого файлу на диску.
            foreach (string findedFile in Directory.EnumerateFiles(catalog, findFile, SearchOption.AllDirectories))
            {

                try
                {
                    file = new FileInfo(findedFile);
                    Console.WriteLine(file.FullName + " " + file.Name + " " + file.Length + " " + file.CreationTime);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (file != null)
            {
                FileStream stream = file?.OpenRead();//код, який використовує клас FileStream 
                StreamReader reader = new StreamReader(stream);// переглядати файл у текстовому вікні
                Console.WriteLine(reader.ReadToEnd());//Перегляд файлу
                stream.Position = 0;

                //Насамкінець додайте можливість стиснення знайденого файлу.
                FileStream fileStream = File.Create(@"C:\TESTDIR\arhive.zip");
                GZipStream gZip = new GZipStream(fileStream, CompressionMode.Compress);


                stream.CopyTo(gZip);

                reader.Close();
                stream.Close();
                gZip.Close();
            }
            else
            {
                Console.WriteLine("Not exist file");
            }

        }
    }
}