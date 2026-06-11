using BikeStoreConsole.Controller;
using BikeStoreConsole.ConsoleView;
using BikeStoreConsole.Model;
using System.Threading.Channels;

namespace BikeStoreConsole
{
    internal class Program
    {
        private static StorageManager storagemanager; //'StorageManager' creates connection between class and file, but doesn't fill the object
            private static ConsoleView myView;
            static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=BikeStores;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

            storagemanager = new StorageManager(connectionString); //fills the object through the connection made perviously between 'StorageManager' and 'storagemanager'

            ConsoleView = new View();
        }
    }
}