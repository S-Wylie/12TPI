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
            Console.WriteLine("by S-Wylie");
        }
        public void DisplayLandingScreen()
        {
            Console.WriteLine("Welcome!");

            Console.WriteLine("1. General View");
            Console.WriteLine("2. Editing View (Requires Login)");
            Console.WriteLine("3. Admin View (Requires Login)");
            Console.WriteLine("4. Exit");

            Console.Write("Please select an option: ");
        }
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
        public int GetUserChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice)) //Makes sure the input will lead to an outcome
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

        public void DisplayEditingNameLogin()
        {
            Console.WriteLine("Editing Login");
            Console.WriteLine("Please input Username: ");
        }

        public void DisplayEditingPINLogin()
        {
            Console.WriteLine("Please input PIN: ");
        }

        public void DisplayAdminNameLogin()
        {
            Console.WriteLine("Admin Login");
            Console.WriteLine("Please input Username: ");
        }

        public void DisplayAdminPINLogin()
        {
            Console.WriteLine("Please input PIN: ");
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
                Console.WriteLine($"{ticket.TicketID}, {ticket.FlightID},{ticket.CustomerID},{ticket.ClassCode},{ticket.MealChoice}");
            }
        }
        public void DisplayClasses(List<Classes> classesList)
        {
            foreach (Classes Class in classesList)
            {
                Console.WriteLine($"{Class.ClassCode}, {Class.Name},{Class.ChangesPermitted},{Class.BaggageAllowance},{Class.MilesAccrual}");
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
        public string GetStringInput(string prompt) //Prevents null data from being inserted into the string data type
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
        public int GetIntInput(string prompt) //Prevents null data from being inserted into the int data type, and makes sure the input is translated from string to int correctly
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
        public DateTime GetDateTimeInput(string prompt) //Prevents null data from being inserted into the date time data type, and makes sure the input is translated from string to date time correctly
        {
            DateTime response;
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out response))
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
        public Flights PromptAddFlight()
        {
            Flights newFlight = new Flights();
            newFlight.PlaneRegistrationID = GetIntInput("Enter the Plane Registration ID: ");
            newFlight.FlightNumber = GetStringInput("Enter the Flight Number: ");
            newFlight.PilotName = GetStringInput("Enter the Pilot Name: ");
            newFlight.DepartingDateTime = GetDateTimeInput("Enter the Departing Date and Time: ");
            newFlight.DepartingAirport = GetStringInput("Enter the Departing Airport: ");
            newFlight.ArrivingDateTime = GetDateTimeInput("Enter the Arriving Date and Time: ");
            newFlight.ArrivingAirport = GetStringInput("Enter the Arriving Airport: ");
            newFlight.Status = GetStringInput("Enter the Flight's Status: ");
            return newFlight;
        }
        public Airports PromptAddAirport()
        {
            Airports newAirport = new Airports();
            newAirport.IATACode = GetStringInput("Enter the IATA Code: ");
            newAirport.Name = GetStringInput("Enter the Airport's Name: ");
            newAirport.Coordinates = GetStringInput("Enter the Coordinates: ");
            newAirport.Country = GetStringInput("Enter the Airport's Country: ");
            newAirport.Timezone = GetStringInput("Enter the Timezone: ");
            return newAirport;
        }
        public Passengers PromptAddPassenger()
        {
            Passengers newPassenger = new Passengers();
            newPassenger.FirstName = GetStringInput("Enter First Name: ");
            newPassenger.LastName = GetStringInput("Enter Last Name: ");
            newPassenger.MembershipStatus = GetStringInput("Enter the Passenger's Membership Status: ");
            return newPassenger;
        }
        public PassengerTickets PromptAddTicket()
        {
            PassengerTickets newTicket = new PassengerTickets();
            newTicket.FlightID = GetIntInput("Enter the Flight ID: ");
            newTicket.CustomerID = GetIntInput("Enter the Customer ID: ");
            newTicket.ClassCode = GetStringInput("Enter the Ticket's Class Code: ");
            newTicket.MealChoice = GetStringInput("Enter the Ticket's Meal Choice: ");
            return newTicket;
        }
        public Classes PromptAddClass()
        {
            Classes newClass = new Classes();
            newClass.ClassCode = GetStringInput("Enter the Classe Code");
            newClass.Name = GetStringInput("Enter the Class Name: ");
            newClass.ChangesPermitted = GetStringInput("Enter if changes are permitted (Yes/No): ");
            newClass.BaggageAllowance = GetIntInput("Enter the Baggage Allowance: ");
            newClass.MilesAccrual = GetStringInput("Enter if Miles can be accrued (Yes/No): ");
            return newClass;
        }
        public MealOptions PromptAddMealOption()
        {
            MealOptions newMealOption = new MealOptions();
            newMealOption.MealCode = GetStringInput("Enter the Meal Code: ");
            newMealOption.Name = GetStringInput("Enter the Meal's Name: ");
            newMealOption.Conditions = GetStringInput("Enter the Meal's Conditions: ");
            return newMealOption;
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
        public Flights PromptUpdateFlight()
        {
            Flights updatedFlight = new Flights();
            updatedFlight.FlightID = GetIntInput("Enter the Flight ID of the flight to update: ");
            updatedFlight.FlightNumber = GetStringInput("Enter the new Flight Number: ");
            updatedFlight.PilotName = GetStringInput("Enter the new Pilot's Name: ");
            updatedFlight.DepartingDateTime = GetDateTimeInput("Enter the new Departing Date and Time: ");
            updatedFlight.DepartingAirport = GetStringInput("Enter the new Departing Airport's IATA Code: ");
            updatedFlight.ArrivingDateTime = GetDateTimeInput("Enter the new Arriving Date and Time: ");
            updatedFlight.ArrivingAirport = GetStringInput("Enter the new Arriving Airport's IATA Code: ");
            updatedFlight.Status = GetStringInput("Enter the new Flight's Status: ");
            return updatedFlight;
        }
        public Airports PromptUpdateAirport()
        {
            Airports updatedAirport = new Airports();
            updatedAirport.IATACode = GetStringInput("Enter the IATA Code of the airport to update: ");
            updatedAirport.Name = GetStringInput("Enter the new Name: ");
            updatedAirport.Coordinates = GetStringInput("Enter the new Coordinates: ");
            updatedAirport.Country = GetStringInput("Enter the new Country: ");
            updatedAirport.Timezone = GetStringInput("Enter the new Timezone: ");
            return updatedAirport;
        }
        public Passengers PromptUpdatePassenger()
        {
            Passengers updatedPassenger = new Passengers();
            updatedPassenger.CustomerID = GetIntInput("Enter the Customer ID of the passenger to update: ");
            updatedPassenger.FirstName = GetStringInput("Enter the new First Name: ");
            updatedPassenger.LastName = GetStringInput("Enter the new Last Name: ");
            updatedPassenger.MembershipStatus = GetStringInput("Enter the new Membership Status: ");
            return updatedPassenger;
        }
        public PassengerTickets PromptUpdateTicket()
        {
            PassengerTickets updatedTicket = new PassengerTickets();
            updatedTicket.TicketID = GetIntInput("Enter the Ticket ID of the ticket to update: ");
            updatedTicket.FlightID = GetIntInput("Enter the new Flight ID: ");
            updatedTicket.CustomerID = GetIntInput("Enter the new Customer ID: ");
            updatedTicket.ClassCode = GetStringInput("Enter the new Class Code: ");
            updatedTicket.MealChoice = GetStringInput("Enter the new Meal Choice: ");
            return updatedTicket;
        }
        public Classes PromptUpdateClass()
        {
            Classes updatedClass = new Classes();
            updatedClass.ClassCode = GetStringInput("Enter the Class Code of the class to update: ");
            updatedClass.Name = GetStringInput("Enter the new Class Name: ");
            updatedClass.ChangesPermitted = GetStringInput("Enter if changes are permitted? (Yes/No): ");
            updatedClass.BaggageAllowance = GetIntInput("Enter the new Baggage Allowance: ");
            updatedClass.MilesAccrual = GetStringInput("Enter if miles are able to be accrued? (Yes/No): ");
            return updatedClass;
        }
        public MealOptions PromptUpdateMealOption()
        {
            MealOptions updatedMealOption = new MealOptions();
            updatedMealOption.MealCode = GetStringInput("Enter the Meal Code of the meal option to update: ");
            updatedMealOption.Name = GetStringInput("Enter the new Meal Name: ");
            updatedMealOption.Conditions = GetStringInput("Enter the new Conditions: ");
            return updatedMealOption;
        }   
        public int PromptDeletePlane()
        {
            return GetIntInput("Enter the Registration ID of the plane to delete: ");
        }
        public int PromptDeleteFlight()
        {
            return GetIntInput("Enter the Flight ID of the flight to delete: ");
        }
        public string PromptDeleteAirport()
        {
            return GetStringInput("Enter the IATA Code of the airport to delete: ");
        }
        public int PromptDeletePassenger()
        {
            return GetIntInput("Enter the Customer ID of the passenger to delete: ");
        }
        public int PromptDeleteTicket()
        {
            return GetIntInput("Enter the Ticket ID of the ticket to delete: ");
        }
        public string PromptDeleteClass()
        {
            return GetStringInput("Enter the Class Code of the class to delete: ");
        }
        public string PromptDeleteMealOption()
        {
            return GetStringInput("Enter the Meal Code of the meal option to delete: ");
        }
    }
}
