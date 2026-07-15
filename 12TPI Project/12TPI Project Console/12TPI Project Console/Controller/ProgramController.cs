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

        public void DisplayAllFlights()
        {
            var flights = storageManager.GetAllFlights();
            consoleView.DisplayFlights(flights);
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
                        consoleView.DisplayGeneralView();
                        break;
                    case 2:
                        consoleView.DisplayEditingView();
                        break;
                    case 3:
                        consoleView.DisplayAdminView();
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
