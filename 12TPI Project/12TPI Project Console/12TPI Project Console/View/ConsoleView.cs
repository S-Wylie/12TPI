using _12TPI_Project_Console.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.View
{
    public class ConsoleView
    {
        public void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Flight Management System!");
            Console.WriteLine("by Sienna Wylie 12TPI.  (C) 2026.");
        }
        public void DisplayLandingScreen()
        {
            Console.WriteLine("Welcome!");

            Console.WriteLine("1. General View");
            Console.WriteLine("2. Editing View (Requires Login)");
            Console.WriteLine("3. Admin View (Requires Login)");
            Console.WriteLine("4. Ticket Booking (Requires Login)");
            Console.WriteLine("5. Exit");

            Console.Write("Please select an option: ");
        }
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
        public int GetUserChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.Write("Please select an option: ");
            }
            return choice;
        }
        public void DisplayInvalidChoiceMessage()
        {
            Console.WriteLine("Invalid choice. Please try again.");
            Console.Write("Please select an option: ");
        }
        public void DisplayExitMessage()
        {
            Console.WriteLine("Thank you for using the Flight Management System. Goodbye!");
        }
        public void DisplayGeneralView()
        {
            Console.WriteLine("General View");

            Console.WriteLine("1. View Flights");
            Console.WriteLine("2. View Passengers");
            Console.WriteLine("3. View Tickets");
            Console.WriteLine("4. Return");

            Console.Write("Please select an option: ");
        }
        public void DisplayEditingView()
        {
            Console.WriteLine("Editing View");

            Console.WriteLine("1. Planes Menu");
            Console.WriteLine("2. Flights Menu");
            Console.WriteLine("3. Airports Menu");
            Console.WriteLine("4. Passengers Menu");
            Console.WriteLine("5. Tickets Menu");
            Console.WriteLine("6. Return");

            Console.Write("Please select an option: ");
        }
        public void DisplayAdminView()
        {
            Console.WriteLine("Admin View");

            Console.WriteLine("1. Editing Logins");
            Console.WriteLine("2. Admin Logins");
            Console.WriteLine("3. Classes Menu");
            Console.WriteLine("4. Meal Options Menu");
            Console.WriteLine("5. Editing View");
            Console.WriteLine("6. Return");

            Console.Write("Please select an option: ");
        }
        public void DisplayPlanesMenu()
        {
            Console.WriteLine("Planes Menu");

            Console.WriteLine("1. View Planes");
            Console.WriteLine("2. Add Plane");
            Console.WriteLine("3. Update Plane");
            Console.WriteLine("4. Delete Plane");
            Console.WriteLine("5. Return");

            Console.Write("Please select an option: ");
        }
        public void DisplayFlightsMenu()
        {
            Console.WriteLine("Flights Menu");

            Console.WriteLine("1. View Flights");
            Console.WriteLine("2. Add Flight");
            Console.WriteLine("3. Update Flight");
            Console.WriteLine("4. Delete Flight");
            Console.WriteLine("5. Return");

            Console.Write("Please select an option: ");
        }
        public void DisplayAirportsMenu()
        {
            Console.WriteLine("Airports Menu");

            Console.WriteLine("1. View Airports");
            Console.WriteLine("2. Add Airport");
            Console.WriteLine("3. Update Airport");
            Console.WriteLine("4. Delete Airport");
            Console.WriteLine("5. Return");

            Console.Write("Please select an option: ");
        }
        public void DisplayPassengersMenu()
        {
            Console.WriteLine("Passengers Menu");

            Console.WriteLine("1. View Passengers");
            Console.WriteLine("2. Add Passenger");
            Console.WriteLine("3. Update Passenger");
            Console.WriteLine("4. Delete Passenger");
            Console.WriteLine("5. Return");

            Console.Write("Please select an option: ");
        }
        public void DisplayTicketsMenu()
        {
            Console.WriteLine("Tickets Menu");

            Console.WriteLine("1. View Tickets");
            Console.WriteLine("2. Add Ticket");
            Console.WriteLine("3. Update Ticket");
            Console.WriteLine("4. Delete Ticket");
            Console.WriteLine("5. Return");

            Console.Write("Please select an option: ");
        }
        public void DisplayClassesMenu()
        {
            Console.WriteLine("Classes Menu");

            Console.WriteLine("1. View Classes");
            Console.WriteLine("2. Add Class");
            Console.WriteLine("3. Update Class");
            Console.WriteLine("4. Delete Class");
            Console.WriteLine("5. Return");

            Console.Write("Please select an option: ");
        }
        public void DisplayMealOptionsMenu()
        {
            Console.WriteLine("Meal Options Menu");

            Console.WriteLine("1. View Meal Options");
            Console.WriteLine("2. Add Meal Option");
            Console.WriteLine("3. Update Meal Option");
            Console.WriteLine("4. Delete Meal Option");
            Console.WriteLine("5. Return");

            Console.Write("Please select an option: ");
        }
        public void DisplayPlanes(List<Planes> planesList)
        {
            foreach (Planes plane in planesList)
            {
                Console.WriteLine($"{plane.RegistrationID}, {plane.Manufacturer},{plane.Model},{plane.PassengerCapacity},{plane.CargoCapacity},{plane.MinimumTakeoff},{plane.MinimumLanding}");
            }
        }
        public void DisplayFlights(List<Flights> flightsList)
        {
            foreach (Flights flight in flightsList)
            {
                Console.WriteLine($"{flight.FlightID}, {flight.PlaneRegistrationID},{flight.FlightNumber},{flight.PilotName},{flight.DepartingDateTime},{flight.DepartingAirport},{flight.ArrivingDateTime},{flight.ArrivingAirport},{flight.Status}");
            }
        }
        public void DisplayAirports(List<Airports> airportsList)
        {
            foreach (Airports airport in airportsList)
            {
                Console.WriteLine($"{airport.IATACode}, {airport.Name},{airport.Coordinates},{airport.Country},{airport.Timezone}");
            }
        }
        public void DisplayPassengers(List<Passengers> passengersList)
        {
            foreach (Passengers passenger in passengersList)
            {
                Console.WriteLine($"{passenger.CustomerID}, {passenger.FirstName},{passenger.LastName},{passenger.MembershipStatus}");
            }
        }
        public void DisplayTickets(List<PassengerTickets> ticketsList)
        {
            foreach (PassengerTickets ticket in ticketsList)
            {
                Console.WriteLine($"{ticket.TicketID}, {ticket.FlightID},{ticket.CustomerID},{ticket.ClassName},{ticket.MealChoice}");
            }
        }
        public void DisplayClasses(List<Classes> classesList)
        {
            foreach (Classes Class in classesList)
            {
                Console.WriteLine($"{Class.ClassCode}, {Class.Name},{Class.ChangesPermitted},{Class.BaggageAllowance},{Class.MilesAccural}");
            }
        }
        public void DisplayMealOptions(List<MealOptions> mealOptionsList)
        {
            foreach (MealOptions mealOption in mealOptionsList)
            {
                Console.WriteLine($"{mealOption.MealCode}, {mealOption.Name},{mealOption.Conditions}");
            }
        }
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplaySuccessMessage()
        {
            Console.WriteLine("Operation completed successfully.");
        }
        public string GetStringInput(string prompt)
        {
            string response;
            while (true)
            {
                Console.Write(prompt);
                response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
            return response;
        }
        public int GetIntInput(string prompt)
        {
            int response;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out response))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
            return response;
        }
        public Planes PromptAddPlane()
        {
            Planes newPlane = new Planes();
            newPlane.Manufacturer = GetStringInput("Enter the Manufacturer: ");
            newPlane.Model = GetStringInput("Enter the Model: ");
            newPlane.PassengerCapacity = GetIntInput("Enter the Passenger Capacity: ");
            newPlane.CargoCapacity = GetIntInput("Enter the Cargo Capacity: ");
            newPlane.MinimumTakeoff = GetIntInput("Enter the Minimum Takeoff Length: ");
            newPlane.MinimumLanding = GetIntInput("Enter the Minimum Landing Length: ");
            return newPlane;
        }
        public Planes PromptUpdatePlane()
        {
            Planes updatedPlane = new Planes();
            updatedPlane.RegistrationID = GetIntInput("Enter the Registration ID of the plane to update: ");
            updatedPlane.Manufacturer = GetStringInput("Enter the new Manufacturer: ");
            updatedPlane.Model = GetStringInput("Enter the new Model: ");
            updatedPlane.PassengerCapacity = GetIntInput("Enter the new Passenger Capacity: ");
            updatedPlane.CargoCapacity = GetIntInput("Enter the new Cargo Capacity: ");
            updatedPlane.MinimumTakeoff = GetIntInput("Enter the new Minimum Takeoff Length: ");
            updatedPlane.MinimumLanding = GetIntInput("Enter the new Minimum Landing Length: ");
            return updatedPlane;
        }
        public int PromptDeletePlane()
        {
            return GetIntInput("Enter the Registration ID of the plane to delete: ");
        }
    }
}
