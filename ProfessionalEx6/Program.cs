//Завдання 6

//Створіть на диску 100 директорій із іменами від Folder_0 до Folder_99, потім видаліть їх.
namespace ProfessionalEx6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int directoriesLenght = 100;
            for(int i=0;i<directoriesLenght;i++)
            Directory.CreateDirectory($@"C:\TESTDIR\Folder_{i}");

            Console.ReadKey();

            for (int i = 0; i < directoriesLenght; i++)
                Directory.Delete($@"C:\TESTDIR\Folder_{i}");

        }
    }
}