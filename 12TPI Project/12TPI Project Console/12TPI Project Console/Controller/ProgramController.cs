using _12TPI_Project_Console.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Controller
{
    public class ProgramController
    {
        private readonly StorageManager storageManager;
        private readonly ConsoleView consoleView;

        public ProgramController(StorageManager storageManager, ConsoleView consoleView)
        {
            this.storageManager = storageManager;
            this.consoleView = consoleView;
        }
        public void DisplayAllPlanes()
        {
            var planes = storageManager.GetAllPlanes();
            consoleView.DisplayPlanes(planes);
        }

        public void DisplayAllFlights()
        {
            var flights = storageManager.GetAllFlights();
            consoleView.DisplayFlights(flights);
        }

        public void DisplayAllAirports()
        {
            var airports = storageManager.GetAllAirports();
            consoleView.DisplayAirports(airports);
        }

        public void DisplayAllPassengers()
        {
            var passengers = storageManager.GetAllPassengers();
            consoleView.DisplayPassengers(passengers);
        }

        public void DisplayAllPassengerTickets()
        {
            var tickets = storageManager.GetAllPassengerTickets();
            consoleView.DisplayTickets(tickets);
        }

        public void DisplayAllClasses()
        {
            var classes = storageManager.GetAllClasses();
            consoleView.DisplayClasses(classes);
        }

        public void DisplayAllMealOptions()
        {
            var mealOptions = storageManager.GetAllMealOptions();
            consoleView.DisplayMealOptions(mealOptions);
        }
        public void AddNewPlane()
        {
            var newPlane = consoleView.PromptAddPlane();
            storageManager.AddPlane(newPlane);
            consoleView.DisplaySuccessMessage();
        }
        public void AddNewFlight()
        {
            var newFlight = consoleView.PromptAddFlight();
            storageManager.AddFlight(newFlight);
            consoleView.DisplaySuccessMessage();
        }
        public void AddNewAirport()
        {
            var newAirport = consoleView.PromptAddAirport();
            storageManager.AddAirport(newAirport);
            consoleView.DisplaySuccessMessage();
        }
        public void AddNewPassenger()
        {
            var newPassenger = consoleView.PromptAddPassenger();
            storageManager.AddPassenger(newPassenger);
            consoleView.DisplaySuccessMessage();
        }
        public void AddNewTicket()
        {
            var newTicket = consoleView.PromptAddTicket();
            storageManager.AddTicket(newTicket);
            consoleView.DisplaySuccessMessage();
        }
        public void AddNewClass()
        {
            var newClass = consoleView.PromptAddClass();
            storageManager.AddClasses(newClass);
            consoleView.DisplaySuccessMessage();
        }
        public void AddNewMealOption()
        {
            var newMealOption = consoleView.PromptAddMealOption();
            storageManager.AddMealOption(newMealOption);
            consoleView.DisplaySuccessMessage();
        }
        public void UpdatePlane()
        {
            var updatedPlane = consoleView.PromptUpdatePlane();
            storageManager.UpdatePlane(updatedPlane);
            consoleView.DisplaySuccessMessage();
        }
        public void UpdateFlight()
        {
            var updatedFlight = consoleView.PromptUpdateFlight();
            storageManager.UpdateFlight(updatedFlight);
            consoleView.DisplaySuccessMessage();
        }
        public void UpdateAirport()
        {
            var updatedAirport = consoleView.PromptUpdateAirport();
            storageManager.UpdateAirport(updatedAirport);
            consoleView.DisplaySuccessMessage();
        }
        public void UpdatePassenger()
        {
            var updatedPassenger = consoleView.PromptUpdatePassenger();
            storageManager.UpdatePassenger(updatedPassenger);
            consoleView.DisplaySuccessMessage();
        }
        public void UpdateTicket()
        {
            var updatedTicket = consoleView.PromptUpdateTicket();
            storageManager.UpdateTicket(updatedTicket);
            consoleView.DisplaySuccessMessage();
        }
        public void UpdateClass()
        {
            var updatedClass = consoleView.PromptUpdateClass();
            storageManager.UpdateClass(updatedClass);
            consoleView.DisplaySuccessMessage();
        }
        public void UpdateMealOption()
        {
            var updatedMealOption = consoleView.PromptUpdateMealOption();
            storageManager.UpdateMealOption(updatedMealOption);
            consoleView.DisplaySuccessMessage();
        }
        public void DeletePlane()
        {
            var planeToDelete = consoleView.PromptDeletePlane();
            storageManager.DeletePlaneByID(planeToDelete);
            consoleView.DisplaySuccessMessage();
        }
        public void DeleteFlight()
        {
            var flightToDelete = consoleView.PromptDeleteFlight();
            storageManager.DeleteFlightByID(flightToDelete);
            consoleView.DisplaySuccessMessage();
        }
        public void DeleteAirport()
        {
            var airportToDelete = consoleView.PromptDeleteAirport();
            storageManager.DeleteAirportByIATACode(airportToDelete);
            consoleView.DisplaySuccessMessage();
        }
        public void DeletePassenger()
        {
            var passengerToDelete = consoleView.PromptDeletePassenger();
            storageManager.DeletePassengerByID(passengerToDelete);
            consoleView.DisplaySuccessMessage();
        }
        public void DeleteTicket()
        {
            var ticketToDelete = consoleView.PromptDeleteTicket();
            storageManager.DeleteTicketByID(ticketToDelete);
            consoleView.DisplaySuccessMessage();
        }
        public void DeleteClass()
        {
            var classToDelete = consoleView.PromptDeleteClass();
            storageManager.DeleteClassByCode(classToDelete);
            consoleView.DisplaySuccessMessage();
        }
        public void DeleteMealOption()
        {
            var mealOptionToDelete = consoleView.PromptDeleteMealOption();
            storageManager.DeleteMealOptionByCode(mealOptionToDelete);
            consoleView.DisplaySuccessMessage();
        }
        public void LaunchPlanesMenu()
        {
            bool exit = false; 
            while (!exit) //Prevents the program from exiting until the user chooses to exit
            {
                consoleView.DisplayPlanesMenu();
                int choice = consoleView.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        DisplayAllPlanes();
                        break;
                    case 2:
                        AddNewPlane();
                        break;
                    case 3:
                        UpdatePlane();
                        break;
                    case 4:
                        DeletePlane();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        consoleView.DisplayInvalidChoiceMessage();
                        break;
                }
            }

        }
        public void LaunchFlightsMenu()
        {
            bool exit = false;
            while (!exit)
            {
                consoleView.DisplayFlightsMenu();
                int choice = consoleView.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        DisplayAllFlights();
                        break;
                    case 2:
                        AddNewFlight();
                        break;
                    case 3:
                        UpdateFlight();
                        break;
                    case 4:
                        DeleteFlight();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        consoleView.DisplayInvalidChoiceMessage();
                        break;
                }
            }

        }
        public void LaunchAirportsMenu()
        {
            bool exit = false;
            while (!exit)
            {
                consoleView.DisplayAirportsMenu();
                int choice = consoleView.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        DisplayAllAirports();
                        break;
                    case 2:
                        AddNewAirport();
                        break;
                    case 3:
                        UpdateAirport();
                        break;
                    case 4:
                        DeleteAirport();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        consoleView.DisplayInvalidChoiceMessage();
                        break;
                }
            }

        }

        public void LaunchPassengersMenu()
        {
            bool exit = false;
            while (!exit)
            {
                consoleView.DisplayPassengersMenu();
                int choice = consoleView.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        DisplayAllPassengers();
                        break;
                    case 2:
                        AddNewPassenger();
                        break;
                    case 3:
                        UpdatePassenger();
                        break;
                    case 4:
                        DeletePassenger();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        consoleView.DisplayInvalidChoiceMessage();
                        break;
                }
            }

        }
        public void LaunchTicketsMenu()
        {
            bool exit = false;
            while (!exit)
            {
                consoleView.DisplayTicketsMenu();
                int choice = consoleView.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        DisplayAllPassengerTickets();
                        break;
                    case 2:
                        AddNewTicket();
                        break;
                    case 3:
                        UpdateTicket();
                        break;
                    case 4:
                        DeleteTicket();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        consoleView.DisplayInvalidChoiceMessage();
                        break;
                }
            }

        }
        public void LaunchClassesMenu()
        {
            bool exit = false;
            while (!exit)
            {
                consoleView.DisplayClassesMenu();
                int choice = consoleView.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        DisplayAllClasses();
                        break;
                    case 2:
                        AddNewClass();
                        break;
                    case 3:
                        UpdateClass();
                        break;
                    case 4:
                        DeleteClass();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        consoleView.DisplayInvalidChoiceMessage();
                        break;
                }
            }

        }
        public void LaunchMealOptionsMenu()
        {
            bool exit = false;
            while (!exit)
            {
                consoleView.DisplayMealOptionsMenu();
                int choice = consoleView.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        DisplayAllMealOptions();
                        break;
                    case 2:
                        AddNewMealOption();
                        break;
                    case 3:
                        UpdateMealOption();
                        break;
                    case 4:
                        DeleteMealOption();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        consoleView.DisplayInvalidChoiceMessage();
                        break;
                }
            }

        }
        public void LaunchGeneralMenu()
        {
            bool exit = false;
            while (!exit)
            {
                consoleView.DisplayGeneralView();
                int choice = consoleView.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        DisplayAllFlights();
                        break;
                    case 2:
                        DisplayAllPassengers();
                        break;
                    case 3:
                        DisplayAllPassengerTickets();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        consoleView.DisplayInvalidChoiceMessage();
                        break;
                }
            }
        }
        public void LaunchEditingMenu() {
            bool exit = false;
            while (!exit)
            {
                consoleView.DisplayEditingView();
                int choice = consoleView.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        LaunchPlanesMenu();
                        break;
                    case 2:
                        LaunchFlightsMenu();
                        break;
                    case 3:
                        LaunchAirportsMenu();
                        break;
                    case 4:
                        LaunchPassengersMenu();
                        break;
                    case 5:
                        LaunchTicketsMenu();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        consoleView.DisplayInvalidChoiceMessage();
                        break;
                }
            }


        }

        public void LaunchAdminMenu()
        {
            bool exit = false;
            while (!exit)
            {
                consoleView.DisplayAdminView();
                int choice = consoleView.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        ;
                        break;
                    case 2:
                        ;
                        break;
                    case 3:
                        DisplayAllClasses();
                        break;
                    case 4:
                        DisplayAllMealOptions();
                        break;
                    case 5:
                        LaunchEditingMenu();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        consoleView.DisplayInvalidChoiceMessage();
                        break;
                }
            }
        }

        public void Run()
        {
            consoleView.DisplayWelcomeMessage();
            bool exit = false;
            while (!exit)
            {
                consoleView.DisplayLandingScreen();
                int choice = consoleView.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        LaunchGeneralMenu();
                        break;
                    case 2:
                        LaunchEditingMenu();
                        break;
                    case 3:
                        LaunchAdminMenu();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        consoleView.DisplayInvalidChoiceMessage();
                        break;
                }
            }
            consoleView.DisplayExitMessage();
        }
    }
}
