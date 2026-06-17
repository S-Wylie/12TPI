using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.View
{
    public class ConsoleView
    {
        public void DisplayBrandMenu()
        {
            Console.WriteLine("Welcome!");

            Console.WriteLine("1. General View");
            Console.WriteLine("2. Admin View (Requires Login)");
            Console.WriteLine("3. Manager View (Requires Login)");
            Console.WriteLine("4. Ticket Booking");
            Console.WriteLine("5. Exit");

            Console.Write("Please select an option: ");
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
