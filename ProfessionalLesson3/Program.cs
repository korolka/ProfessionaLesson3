//Завдання 2

//Створіть файл, запишіть у нього довільні дані та закрийте файл.
//    Потім знову відкрийте цей файл, прочитайте дані і виведіть їх на консоль.
namespace ProfessionalLesson3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo("newFile.txt");
            FileStream stream = file.Create();
            stream.Close();
            StreamWriter writer = file.CreateText();

            writer.WriteLine("Hello world");

            writer.Close();

            StreamReader reader = file.OpenText();
            Console.WriteLine(reader.ReadToEnd());
            reader.Close(); 
         }
    }
}