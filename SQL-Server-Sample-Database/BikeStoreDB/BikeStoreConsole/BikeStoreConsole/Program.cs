using BikeStoreConsole.Controller;
using BikeStoreConsole.Model;
using Microsoft.Data.SqlClient;
using BikeStoreConsole.View;

namespace BikeStoreConsole

{

    internal class Program
    {

        private static StorageManager storageManager;

        private static ConsoleView myView;

        static void Main(string[] args)

        {



            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=BikeStores;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";



            storageManager = new StorageManager(connectionString);

            myView = new ConsoleView();

            bool exit = false;

            while (!exit)

            {

                myView.DisplayBrandMenu();

                string choice = myView.GetInput();


                switch (choice)

                {

                    case "1":

                        ViewAllBrands();

                        break;

                    case "2":

                        UpdateBrandName();

                        break;

                    case "3":

                        InsertNewBrand();

                        break;

                    case "4":

                        DeleteBrandByName();
                        break;
                    //Need to ensure that can't delete if the linked to an exisisting relationships and catches errorsbreak;

                    case "5":

                        exit = true;

                        break;

                    default:

                        myView.DisplayMessage("Invalid option. Please try again.");

                        break;

                }

            }


            storageManager.CloseConnection();

        }



        private static void ViewAllBrands()

        {

            List<Brands> brandList = storageManager.GetAllBrands();

            myView.DisplayBrands(brandList);



        }

        private static void UpdateBrandName()

        {

            myView.DisplayMessage("Enter the brand_id to update: ");

            int brandId = myView.GetIntInput();

            myView.DisplayMessage("Enter the new brand name: ");

            string brandName = myView.GetInput();

            int rowsAffected = storageManager.UpdateBrandName(brandId, brandName);

            myView.DisplayMessage($"Rows affected: {rowsAffected}");

        }


        private static void InsertNewBrand()

        {

            myView.DisplayMessage("Enter the new brand name: ");

            string brandName = myView.GetInput();

            int generatedId = storageManager.InsertBrand(brandName);

            myView.DisplayMessage($"New brand inserted with ID: {generatedId}");


        }

        private static void DeleteBrandByName()

        {

            int rowsAffected;

            myView.DisplayMessage("Enter the brand name to delete: ");

            string brandName = myView.GetInput();


            try
            {

                rowsAffected = storageManager.DeleteBrandByName(brandName);

                if (rowsAffected > 0)

                {

                    myView.DisplayMessage($"Rows affected: {rowsAffected}");

                }

                else
                {

                    myView.DisplayMessage("No brand found with that name.");

                }

            }

            catch (SqlException ex)

            {

                if (ex.Number == 547) // Foreign key violation
                {

                    myView.DisplayMessage("Cannot delete brand because it is referenced by existing products.");

                }

                else
                {

                    myView.DisplayMessage($"SQL Error occurred while deleting brand: {ex.Message}");


                }


            }

            catch (Exception ex)

            {

                myView.DisplayMessage($"Error occurred while deleting brand: {ex.Message}");

                Console.ReadKey();


            }
        }
    }
}

