using BikeStoreConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.ConsoleView
{
    public class ConsoleView
    {

        public void DisplayBrandMenu()

        {

            Console.WriteLine("Brand Menu:");

            Console.WriteLine("1. View all records in production.Brands table");

            Console.WriteLine("2. Update a brand's name by brand_id");

            Console.WriteLine("3. Insert a new brand");

            Console.WriteLine("4. Delete a brand by brand_name");

            Console.WriteLine("5. Exit");

            Console.Write("Select an option: ");

        }


        public void DisplayBrands(List<Brands> brandsList)

        {

            foreach (Brands brandsObject in brandsList)

            {

                Console.WriteLine($"{brandsObject.BrandID}, {brandsObject.BrandName}");

            }

        }


        public void DisplayMessage(string message)

        {

            Console.WriteLine(message);

        }


        public string GetInput()

        {

            return Console.ReadLine();

        }


        public int GetIntInput()

        {

            return int.Parse(Console.ReadLine());


        }
    }
}
