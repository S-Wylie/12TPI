using _12TPI_Project_Console.Controller;
using _12TPI_Project_Console.View;

namespace _12TPI_Project_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = "Server=(localdb)\\ProjectModels;Database=test database;Trusted_Connection=True;";
            string connectionString = "Server=(localdb)\\ProjectModels;Database=AirportDatabase;Trusted_Connection=True;";
            ConsoleView consoleView = new ConsoleView();
            StorageManager storageManager = new StorageManager(connectionString);
            ProgramController programController = new ProgramController(storageManager, consoleView);
            programController.Run();
        }
    }
}
