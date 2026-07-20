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
        public void DeletePlane()
        {
            var planeToDelete = consoleView.PromptDeletePlane();
            storageManager.DeletePlaneByID(planeToDelete);
            consoleView.DisplaySuccessMessage();
        }
        public void LaunchPlanesMenu()
        {
            bool exit = false;
            while (!exit)
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
                        ;
                        break;
                    case 3:
                        ;
                        break;
                    case 4:
                        ;
                        break;
                    case 5:
                        ;
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
