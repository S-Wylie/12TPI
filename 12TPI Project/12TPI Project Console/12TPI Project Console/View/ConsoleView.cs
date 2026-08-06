using _12TPI_Project_Console.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _12TPI_Project_Console.View
{
    public class ConsoleView
    {
        const int minDefaultLength = 1;

        //Airports table
        const int minIATACodeLength = 3;
        const int maxIATACodeLength = 3;
        const int maxAirportNameLength = 50;
        const int maxCoordinatesLength = 50;
        const int maxCountryLength = 50;
        const int minTimezoneLength = 5;
        const int maxTimezoneLength = 6;

        //Planes table
        const int maxManufacturerLength = 50;
        const int maxModelLength = 50;
        const int maxPassengerCapacityLength = 1000;
        const int maxCargoCapacityLength = 10000;
        const int maxMinimumTakeoffLength = 1000;
        const int maxMinimumLandingLength = 1000;

        //Flights table
        const int minFlightNumberLength = 5;
        const int maxFlightNumberLength = 5;
        const int maxPilotNameLength = 50;
        const int maxStatusLength = 10;

        //Passengers table
        const int maxFirstNameLength = 25;
        const int maxLastNameLength = 25;
        const int minMembershipStatusLength = 6;
        const int maxMembershipStatusLength = 8;

        //Classes table
        const int minClassCodeLength = 3;
        const int maxClassCodeLength = 3;
        const int maxClassNameLength = 25;
        const int minChangesPermittedLength = 3;
        const int maxChangesPermittedLength = 3;
        const int maxBaggageAllowanceLength = 5;
        const int minMilesAccrualLength = 2;
        const int maxMilesAccrualLength = 3;

        //MealOptions table
        const int minMealCodeLength = 4;
        const int maxMealCodeLength = 4;
        const int maxMealNameLength = 50;
        const int maxMealConditionsLength = 150;

        //Logins table
        const int maxUsernameLength = 25;
        const int maxPINLength = 42;
        const int maxAccessLevelLength = 20;

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
        public void DisplayCurrentUser(string username, string accessLevel)
        {
            Console.WriteLine($"Current User: {username} | Access Level: {accessLevel}");
        }
        public void DisplayInsufficientAccessMessage()
        {
            Console.WriteLine("You do not have sufficient access to view this menu.");
        }
        public void DisplayUserLogin()
        { 
            Console.WriteLine("Please login with your credentials.");
            Console.Write("Username: ");
        }
        public void DisplayPINLogin()
        {
            Console.Write("Please input PIN: ");
        }
        public void DisplayLoginSuccess()
        {
            Console.WriteLine("Login successful!");
        }
        public void DisplayLoginFailure()
        {
            Console.WriteLine("Login failed. Please try again.");
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

            Console.WriteLine("1. Logins Menu");
            Console.WriteLine("2. Classes Menu");
            Console.WriteLine("3. Meal Options Menu");
            Console.WriteLine("4. Editing View");
            Console.WriteLine("5. Preset Queries");
            Console.WriteLine("6. Return");

            Console.Write("Please select an option: ");
        }
        public void DisplaySimpleQueriesMenu()
        {
            Console.WriteLine("Preset Queries");
            Console.WriteLine("Simple Queries");

            Console.WriteLine("1. Airbus Planes");
            Console.WriteLine("2. Delayed Flights");
            Console.WriteLine("3. Australian Airports");
            Console.WriteLine("4. Active Memberships");
            Console.WriteLine("5. Sidney Valdez Flights");
            Console.WriteLine("6. Next Page");
            Console.WriteLine("7. Return");

            Console.WriteLine("Please select an option:");
        }
        public void DisplayAdvancedQueriesMenu()
        {
            Console.WriteLine("Advanced Queries");

            Console.WriteLine("1. Ticket and Passenger Information");
            Console.WriteLine("2. All Ticket Information");
            Console.WriteLine("3. Flight and Plane Information");
            Console.WriteLine("4. Business Passengers");
            Console.WriteLine("5. Gluten Intolerant Passengers");
            Console.WriteLine("6. Next Page");
            Console.WriteLine("7. Return");

            Console.WriteLine("Please select an option: ");
        }
        public void DisplayComplexQueriesMenu()
        {
            Console.WriteLine("Complex Queries");

            Console.WriteLine("1. Plane Capacity Average");
            Console.WriteLine("2. Top Flights");
            Console.WriteLine("3. Top Countries");
            Console.WriteLine("4. Top Pilots");
            Console.WriteLine("5. Top Meals");
            Console.WriteLine("6. Return");

            Console.WriteLine("Please select an option: ");
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
        public void DisplayLoginsMenu()
        {
            Console.WriteLine("Logins Menu");

            Console.WriteLine("1. View Logins");
            Console.WriteLine("2. Add Login");
            Console.WriteLine("3. Update Login");
            Console.WriteLine("4. Delete Login");
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
        public void DisplayLogins(List<Logins> loginsList)
        {
            foreach (Logins login in loginsList)
            {
                Console.WriteLine($"{login.Username}, {login.PINHash},{login.AccessLevel}");
            }
        }
        public void DisplayAirbusPlanesQuery(List<Planes> planesList)
        {
            foreach (Planes plane in planesList)
            {
                Console.WriteLine($"{plane.RegistrationID}, {plane.Manufacturer},{plane.Model},{plane.PassengerCapacity},{plane.CargoCapacity},{plane.MinimumTakeoff},{plane.MinimumLanding}");
            }
        }
        public void DisplayDelayedFlightsQuery(List<Flights> flightsList)
        {
            foreach (Flights flight in flightsList)
            {
                Console.WriteLine($"{flight.FlightID}, {flight.PlaneRegistrationID},{flight.FlightNumber},{flight.PilotName},{flight.DepartingDateTime},{flight.DepartingAirport},{flight.ArrivingDateTime},{flight.ArrivingAirport},{flight.Status}");
            }
        }
        public void DisplayAustralianAirportsQuery(List<Airports> airportsList)
        {
            foreach (Airports airport in airportsList)
            {
                Console.WriteLine($"{airport.IATACode}, {airport.Name},{airport.Coordinates},{airport.Country},{airport.Timezone}");
            }
        }
        public void DisplayActiveMembershipsQuery(List<Passengers> passengersList)
        {
            foreach (Passengers passenger in passengersList)
            {
                Console.WriteLine($"{passenger.CustomerID}, {passenger.FirstName},{passenger.LastName},{passenger.MembershipStatus}");
            }
        }
        public void DisplaySidenyValdezFlightsQuery(List<Flights> flightsList)
        {
            foreach (Flights flight in flightsList)
            {
                Console.WriteLine($"{flight.FlightID}, {flight.PlaneRegistrationID},{flight.FlightNumber},{flight.PilotName},{flight.DepartingDateTime},{flight.DepartingAirport},{flight.ArrivingDateTime},{flight.ArrivingAirport},{flight.Status}");
            }
        }
        public void DisplayTicketandPassengerInfoQuery(List<Tuple<PassengerTickets, Passengers>> ticketAndPassengerList)
        {
            foreach (var (ticket, passenger) in ticketAndPassengerList)
            {
                Console.WriteLine($"{ticket.TicketID}, {ticket.FlightID}, {ticket.ClassCode}, {ticket.MealChoice}, {passenger.CustomerID}, {passenger.FirstName},{passenger.LastName}, {passenger.MembershipStatus}");
            }
        }
        public void DisplayAllTicketInfoQuery(List<Tuple<Passengers, PassengerTickets, Flights, Classes, MealOptions>> AllTicketList)
        {
            foreach (var (passenger, ticket, flight, Class, mealOption) in AllTicketList)
            {
                Console.WriteLine($"{passenger.CustomerID}, {passenger.FirstName},{passenger.LastName},{passenger.MembershipStatus}{ticket.TicketID}, {ticket.FlightID},{flight.PlaneRegistrationID},{flight.FlightNumber},{flight.PilotName},{flight.DepartingDateTime},{flight.DepartingAirport},{flight.ArrivingDateTime},{flight.ArrivingAirport},{flight.Status},{Class.ClassCode},{Class.Name},{Class.ChangesPermitted},{Class.BaggageAllowance},{Class.MilesAccrual},{ticket.MealChoice},{mealOption.Name},{mealOption.Conditions}");
            }
        }
        public void DisplayPlaneAndFlightInfoQuery(List<Tuple<Planes, Flights>> planeAndflightList)
        {
            foreach (var (plane, flight) in planeAndflightList)
            {
                Console.WriteLine($"{plane.RegistrationID},{plane.Manufacturer},{plane.Model}, {plane.PassengerCapacity},{plane.CargoCapacity},{plane.MinimumTakeoff},{plane.MinimumLanding},{flight.FlightID},{flight.PilotName},{flight.DepartingDateTime},{flight.DepartingAirport},{flight.ArrivingDateTime},{flight.ArrivingAirport}`,{flight.Status}");
            }
        }
        public void DisplayBusinessPassengersQuery(List<Tuple<Passengers, PassengerTickets>> passengerandticketList)
        {
            foreach (var (passenger, ticket) in passengerandticketList)
            {
                Console.WriteLine($"{passenger.CustomerID},{passenger.FirstName},{passenger.LastName},{passenger.MembershipStatus},{ticket.TicketID},{ticket.FlightID},{ticket.ClassCode},{ticket.MealChoice}");
            }
        }
        public void DisplayGlutenIntolPassengersQuery(List<Tuple<Passengers, PassengerTickets>> passengerandticketList)
        {
            foreach (var (passenger, ticket) in passengerandticketList)
            {
                Console.WriteLine($"{passenger.CustomerID},{passenger.FirstName},{passenger.LastName},{passenger.MembershipStatus},{ticket.TicketID},{ticket.FlightID},{ticket.ClassCode},{ticket.MealChoice}");
            }
        }
        public void DisplayPlaneCapAvgQuery(List<AvgPlaneCapStats> avgCapList)
        {
            foreach (AvgPlaneCapStats stats in avgCapList)
            {
                Console.WriteLine($"{stats.PassengerCapAvg},{stats.CargoCapAvg}");
            }
        }
        public void DisplayTopFlightsQuery(List<Tuple<Flights, TopFlightsStats>> topFlightsList)
        {
            foreach (var (flight, stats) in topFlightsList)
            {
                Console.WriteLine($"{flight.FlightNumber},{stats.FlightPopularity}");
            }
        }
        public void DisplayTopCountriesQuery(List<Tuple<Airports, TopCountriesStats>> topCountriesList)
        {
            foreach (var (airport, stats) in topCountriesList)
            {
                Console.WriteLine($"{airport.Country},{stats.CountryPopularity}");
            }
        }
        public void DisplayTopPilotsQuery(List<Tuple<Flights, TopPilotsStats>> topPilotsList)
        {
            foreach (var (flight, stats) in topPilotsList)
            {
                Console.WriteLine($"{flight.PilotName},{stats.PilotPopularity}");
            }
        }
        public void DisplayTopMealsQuery(List<Tuple<PassengerTickets, TopMealsStats>> topCountriesList)
        {
            foreach (var (ticket, stats) in topCountriesList)
            {
                Console.WriteLine($"{ticket.MealChoice},{stats.MealPopularity}");
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
        public string GetStringInput(string prompt, int minLength, int maxLength) //Prevents null data from being inserted into the string data type
        {
            var regex = new Regex("^[a-zA-Z0-9]*$");
            string response;
            while (true)
            {
                Console.Write(prompt);
                response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response) && response.Length <= maxLength && response.Length >= minLength && regex.IsMatch(response))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
            return response;
        }

        public string GetSpaceStringInput(string prompt, int minLength, int maxLength)
        {
            var regex = new Regex("^[a-zA-Z0-9 ]*$");
            string response;
            while (true)
            {
                Console.Write(prompt);
                response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response) && response.Length <= maxLength && response.Length >= minLength && regex.IsMatch(response))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
            return response;
        }
        public string GetSpclStringInput(string prompt, int minLength, int maxLength)
        {
            var regex = new Regex("^[a-zA-Z0-9-+!@#$%^&*().,]*$");
            string response;
            while (true)
            {
                Console.Write(prompt);
                response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response) && response.Length <= maxLength && response.Length >= minLength && regex.IsMatch(response))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
            return response;
        }

        public string GetCoordStringInput(string prompt, int minLength, int maxLength)
        {
            var regex = new Regex("^[a-zA-Z0-9,° ]*$");
            string response;
            while (true)
            {
                Console.Write(prompt);
                response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response) && response.Length <= maxLength && response.Length >= minLength && regex.IsMatch(response))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
            return response;
        }
        public string GetTimezoneStringInput(string prompt, int minLength, int maxLength)
        {
            var regex = new Regex("^[a-zA-Z0-9-+.,]*$");
            string response;
            while (true)
            {
                Console.Write(prompt);
                response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response) && response.Length <= maxLength && response.Length >= minLength && regex.IsMatch(response))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
            return response;
        }

        public string GetTextStringInput(string prompt, int minLength, int maxLength)
        {
            var regex = new Regex("^[a-zA-Z0-9,. ]*$");
            string response;
            while (true)
            {
                Console.Write(prompt);
                response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response) && response.Length <= maxLength && response.Length >= minLength && regex.IsMatch(response))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
            return response;
        }
        public int GetIntInput(string prompt, int maxValue) //Prevents null data from being inserted into the int data type, and makes sure the input is translated from string to int correctly
        {
            int response;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out response) && response > 0 && response <= maxValue)
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
                    if(response >= DateTime.Today)
                    {
                        break;
                    }
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
            return response;
        }
        public Planes PromptAddPlane()
        {
            Planes newPlane = new Planes();
            newPlane.Manufacturer = GetStringInput("Enter the Manufacturer: ",minDefaultLength,maxManufacturerLength);
            newPlane.Model = GetStringInput("Enter the Model: ",minDefaultLength,maxModelLength);
            newPlane.PassengerCapacity = GetIntInput("Enter the Passenger Capacity: ", maxPassengerCapacityLength);
            newPlane.CargoCapacity = GetIntInput("Enter the Cargo Capacity: ", maxCargoCapacityLength);
            newPlane.MinimumTakeoff = GetIntInput("Enter the Minimum Takeoff Length: ", maxMinimumTakeoffLength);
            newPlane.MinimumLanding = GetIntInput("Enter the Minimum Landing Length: ", maxMinimumLandingLength);
            return newPlane;
        }
        public Flights PromptAddFlight(int  maxPlaneID)
        {
            Flights newFlight = new Flights();
            newFlight.PlaneRegistrationID = GetIntInput("Enter the Plane Registration ID: ", maxPlaneID);
            newFlight.FlightNumber = GetStringInput("Enter the Flight Number: ",minFlightNumberLength,maxFlightNumberLength);
            newFlight.PilotName = GetSpaceStringInput("Enter the Pilot Name: ",minDefaultLength,maxPilotNameLength);
            newFlight.DepartingDateTime = GetDateTimeInput("Enter the Departing Date and Time: ");
            newFlight.DepartingAirport = GetStringInput("Enter the Departing Airport’s IATA Code: ",minIATACodeLength,maxIATACodeLength);
            newFlight.ArrivingDateTime = GetDateTimeInput("Enter the Arriving Date and Time: ");
            newFlight.ArrivingAirport = GetStringInput("Enter the Arrival Airport’s IATA Code: ",minIATACodeLength,maxIATACodeLength);
            newFlight.Status = GetStringInput("Enter the Flight's Status: ",minDefaultLength, maxStatusLength);
            return newFlight;
        }
        public Airports PromptAddAirport()
        {
            Airports newAirport = new Airports();
            newAirport.IATACode = GetStringInput("Enter the IATA Code: ",minIATACodeLength,maxIATACodeLength);
            newAirport.Name = GetSpaceStringInput("Enter the Airport's Name: ",minDefaultLength,maxAirportNameLength);
            newAirport.Coordinates = GetCoordStringInput("Enter the Coordinates: ",minChangesPermittedLength,maxCoordinatesLength);
            newAirport.Country = GetSpaceStringInput("Enter the Airport's Country: ",minDefaultLength,maxCountryLength);
            newAirport.Timezone = GetTimezoneStringInput("Enter the Timezone: ",minTimezoneLength,maxTimezoneLength);
            return newAirport;
        }
        public Passengers PromptAddPassenger()
        {
            Passengers newPassenger = new Passengers();
            newPassenger.FirstName = GetStringInput("Enter First Name: ",minDefaultLength,maxFirstNameLength);
            newPassenger.LastName = GetStringInput("Enter Last Name: ",minDefaultLength,maxLastNameLength);
            newPassenger.MembershipStatus = GetStringInput("Enter the Passenger's Membership Status (Inactive/Active): ",minMembershipStatusLength, maxMembershipStatusLength);
            return newPassenger;
        }
        public PassengerTickets PromptAddTicket(int maxFlightId, int maxCustomerID)
        {
            PassengerTickets newTicket = new PassengerTickets();
            newTicket.FlightID = GetIntInput("Enter the Flight ID: ", maxFlightId);
            newTicket.CustomerID = GetIntInput("Enter the Customer ID: ", maxCustomerID);
            newTicket.ClassCode = GetStringInput("Enter the Ticket's Class Code: ",minClassCodeLength,maxClassCodeLength);
            newTicket.MealChoice = GetStringInput("Enter the Ticket's Meal Choice: ",minDefaultLength,maxMealCodeLength);
            return newTicket;
        }
        public Classes PromptAddClass()
        {
            Classes newClass = new Classes();
            newClass.ClassCode = GetStringInput("Enter the Class Code: ",minClassCodeLength,maxClassCodeLength);
            newClass.Name = GetSpaceStringInput("Enter the Class Name: ",minDefaultLength,maxClassNameLength);
            newClass.ChangesPermitted = GetStringInput("Enter if changes are permitted (Yes/No): ",minChangesPermittedLength,maxChangesPermittedLength);
            newClass.BaggageAllowance = GetIntInput("Enter the Baggage Allowance: ",maxBaggageAllowanceLength);
            newClass.MilesAccrual = GetStringInput("Enter if Miles can be accrued (Yes/No): ",minMilesAccrualLength,maxMilesAccrualLength);
            return newClass;
        }
        public MealOptions PromptAddMealOption()
        {
            MealOptions newMealOption = new MealOptions();
            newMealOption.MealCode = GetStringInput("Enter the Meal Code: ",minClassCodeLength,maxMealCodeLength);
            newMealOption.Name = GetSpaceStringInput("Enter the Meal's Name: ",minDefaultLength,maxMealNameLength);
            newMealOption.Conditions = GetTextStringInput("Enter the Meal's Conditions: ", minDefaultLength,maxMealConditionsLength);
            return newMealOption;
        }
        public Logins PromptAddLogin()
        {
            Logins newLogin = new Logins();
            newLogin.Username = GetSpclStringInput("Enter the Username: ",minDefaultLength,maxUsernameLength);
            newLogin.PINHash = GetStringInput("Enter the PIN: ",minDefaultLength,maxPINLength);
            newLogin.AccessLevel = GetStringInput("Enter the Access Level: ",minDefaultLength,maxAccessLevelLength);
            return newLogin;
        }
        public Planes PromptUpdatePlane(int maxPlaneID)
        {
            Planes updatedPlane = new Planes();
            updatedPlane.RegistrationID = GetIntInput("Enter the Registration ID of the plane to update: ",maxPlaneID);
            updatedPlane.Manufacturer = GetStringInput("Enter the new Manufacturer: ",minDefaultLength,maxManufacturerLength);
            updatedPlane.Model = GetStringInput("Enter the new Model: ",minDefaultLength,maxModelLength);
            updatedPlane.PassengerCapacity = GetIntInput("Enter the new Passenger Capacity: ",maxPassengerCapacityLength);
            updatedPlane.CargoCapacity = GetIntInput("Enter the new Cargo Capacity: ",maxCargoCapacityLength);
            updatedPlane.MinimumTakeoff = GetIntInput("Enter the new Minimum Takeoff Length: ",maxMinimumTakeoffLength);
            updatedPlane.MinimumLanding = GetIntInput("Enter the new Minimum Landing Length: ",maxMinimumLandingLength);
            return updatedPlane;
        }
        public Flights PromptUpdateFlight(int maxFlightID, int maxPlaneID)
        {
            Flights updatedFlight = new Flights();
            updatedFlight.FlightID = GetIntInput("Enter the Flight ID of the flight to update: ",maxFlightID);
            updatedFlight.PlaneRegistrationID = GetIntInput("Enter the new Plane Registration ID: ", maxPlaneID);
            updatedFlight.FlightNumber = GetStringInput("Enter the new Flight Number: ",minFlightNumberLength,maxFlightNumberLength);
            updatedFlight.PilotName = GetSpaceStringInput("Enter the new Pilot Name: ",minDefaultLength,maxPilotNameLength);
            updatedFlight.DepartingDateTime = GetDateTimeInput("Enter the new Departing Date and Time: ");
            updatedFlight.DepartingAirport = GetStringInput("Enter the new Departing Airport's IATA Code: ",minIATACodeLength, maxIATACodeLength);
            updatedFlight.ArrivingDateTime = GetDateTimeInput("Enter the new Arriving Date and Time: ");
            updatedFlight.ArrivingAirport = GetStringInput("Enter the new Arriving Airport's IATA Code: ",minIATACodeLength,maxIATACodeLength);
            updatedFlight.Status = GetStringInput("Enter the new Flight's Status: ",minDefaultLength,maxStatusLength);
            return updatedFlight;
        }
        public Airports PromptUpdateAirport()
        {
            Airports updatedAirport = new Airports();
            updatedAirport.IATACode = GetStringInput("Enter the IATA Code of the airport to update: ",minIATACodeLength, maxIATACodeLength);
            updatedAirport.Name = GetSpaceStringInput("Enter the new Name: ",minDefaultLength,maxAirportNameLength);
            updatedAirport.Coordinates = GetCoordStringInput("Enter the new Coordinates: ",minDefaultLength,maxCoordinatesLength);
            updatedAirport.Country = GetSpaceStringInput("Enter the Airport's new Country: ",minDefaultLength,maxCountryLength);
            updatedAirport.Timezone = GetTimezoneStringInput("Enter the new Timezone: ",minTimezoneLength,maxTimezoneLength);
            return updatedAirport;
        }
        public Passengers PromptUpdatePassenger(int maxCustomerID)
        {
            Passengers updatedPassenger = new Passengers();
            updatedPassenger.CustomerID = GetIntInput("Enter the Customer ID of the passenger to update: ",maxCustomerID);
            updatedPassenger.FirstName = GetStringInput("Enter the new First Name: ",minDefaultLength,maxFirstNameLength);
            updatedPassenger.LastName = GetStringInput("Enter the new Last Name: ",minDefaultLength,maxLastNameLength);
            updatedPassenger.MembershipStatus = GetStringInput("Enter the new Membership Status: ",minMembershipStatusLength,maxMembershipStatusLength);
            return updatedPassenger;
        }
        public PassengerTickets PromptUpdateTicket(int maxTicketID, int maxFlightID, int maxCustomerID)
        {
            PassengerTickets updatedTicket = new PassengerTickets();
            updatedTicket.TicketID = GetIntInput("Enter the Ticket ID of the ticket to update: ",maxTicketID);
            updatedTicket.FlightID = GetIntInput("Enter the new Flight ID: ",maxFlightID);
            updatedTicket.CustomerID = GetIntInput("Enter the new Customer ID: ",maxCustomerID);
            updatedTicket.ClassCode = GetStringInput("Enter the new Class Code: ",minClassCodeLength,maxClassCodeLength);
            updatedTicket.MealChoice = GetStringInput("Enter the new Meal Choice: ",minMealCodeLength,maxMealCodeLength);
            return updatedTicket;
        }
        public Classes PromptUpdateClass()
        {
            Classes updatedClass = new Classes();
            updatedClass.ClassCode = GetStringInput("Enter the Class Code of the class to update: ",minClassCodeLength,maxClassCodeLength);
            updatedClass.Name = GetSpaceStringInput("Enter the new Class Name: ",minDefaultLength,maxClassNameLength);
            updatedClass.ChangesPermitted = GetStringInput("Enter if changes are permitted (Yes/No): ",minDefaultLength,maxChangesPermittedLength);
            updatedClass.BaggageAllowance = GetIntInput("Enter the new Baggage Allowance: ",maxBaggageAllowanceLength);
            updatedClass.MilesAccrual = GetStringInput("Enter if miles are able to be accrued (Yes/No): ",minDefaultLength,maxMilesAccrualLength);
            return updatedClass; 
        }
        public MealOptions PromptUpdateMealOption()
        {
            MealOptions updatedMealOption = new MealOptions();
            updatedMealOption.MealCode = GetStringInput("Enter the Meal Code of the meal option to update: ",minMealCodeLength,maxMealCodeLength);
            updatedMealOption.Name = GetSpaceStringInput("Enter the new Meal Name: ",minDefaultLength,maxMealNameLength);
            updatedMealOption.Conditions = GetTextStringInput("Enter the new Conditions: ",minDefaultLength,maxMealConditionsLength);
            return updatedMealOption;
        }
        public Logins PromptUpdateLogin()
        {
            Logins updatedLogin = new Logins();
            updatedLogin.Username = GetSpclStringInput("Enter the Username of the login to update: ",minDefaultLength,maxUsernameLength);
            updatedLogin.PINHash = GetStringInput("Enter the new PIN: ",minDefaultLength,maxPINLength);
            updatedLogin.AccessLevel = GetStringInput("Enter the new Access Level: ",minDefaultLength,maxAccessLevelLength);
            return updatedLogin;
        }
        public int PromptDeletePlane(int maxRegistrationID)
        {
            return GetIntInput("Enter the Registration ID of the plane to delete: ", maxRegistrationID);
        }
        public int PromptDeleteFlight(int maxFlightID)
        {
            return GetIntInput("Enter the Flight ID of the flight to delete: ", maxFlightID);
        }
        public string PromptDeleteAirport()
        {
            return GetStringInput("Enter the IATA Code of the airport to delete: ",minDefaultLength,maxIATACodeLength);
        }
        public int PromptDeletePassenger(int maxCustomerID)
        {
            return GetIntInput("Enter the Customer ID of the passenger to delete: ", maxCustomerID);
        }
        public int PromptDeleteTicket(int maxTicketID)
        {
            return GetIntInput("Enter the Ticket ID of the ticket to delete: ", maxTicketID);
        }
        public string PromptDeleteClass()
        {
            return GetStringInput("Enter the Class Code of the class to delete: ",minClassCodeLength,maxClassCodeLength);
        }
        public string PromptDeleteMealOption()
        {
            return GetStringInput("Enter the Meal Code of the meal option to delete: ",minMealCodeLength,maxMealCodeLength);
        }
        public string PromptDeleteLogin()
        {
            return GetSpclStringInput("Enter the Username of the login to delete: ",minDefaultLength,maxUsernameLength);
        }
    }
}
