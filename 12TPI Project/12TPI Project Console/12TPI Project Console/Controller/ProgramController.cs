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
                        // Handle option 1
                        break;
                    case 2:
                        // Handle option 2
                        break;
                    case 3:
                        // Handle option 3
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
