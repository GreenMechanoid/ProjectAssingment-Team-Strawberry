//.Net 22 Daniel Svensson, Elias Hammou , Jesper Andersson
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectAssingment_Team_Strawberry
{
    internal class Menus
    {
        int menuChoise = 0;
        bool loopIsRunning = true;
        bool isAnInt = false;
        public void startMenu()
        {
            this.menuChoise = 0;
            loopIsRunning = true;
            // creating a userInterface with a Switch case
            do
            {
                switch (menuChoise)
                {
                    default: // default is user's choices, writeline messages with the choices available.

                        Console.Clear();
                        Console.WriteLine("1: User management");
                        Console.WriteLine("99: Terminate Program");
                        do
                        {
                            int.TryParse(Console.ReadLine(), out menuChoise);
                            //simple if to check that the number is corrisponding to a 'Menu Item'
                            if (menuChoise == 1 || menuChoise == 99)  // ** expand with the numbers of the menu items
                            {
                                isAnInt = true;
                            }
                            else
                            {
                                Console.WriteLine("Wrong input! , Can't find a matching menu item!");
                            }
                        } while (!isAnInt); //keep looping if it's not a number
                        break;
                    case 1:
                        UserManagement();
                        break;
                    case 99: //Termination Selection
                        loopIsRunning = false; // to terminate the do while after choice is to terminate the program
                        Console.Clear();
                        Console.WriteLine("Thank you for running this program. have a nice day!");
                        break;

                }

            } while (loopIsRunning);
        }
        public void UserManagement()
        {
            this.menuChoise = 0;
            this.loopIsRunning = true;
            do
            {
            switch (menuChoise)
            {
                default:
                    Console.Clear();
                    Console.WriteLine("1: Create User");
                    Console.WriteLine("2: Login User");
                    Console.WriteLine("3: Return to Previous Menu");

                    int.TryParse(Console.ReadLine(), out menuChoise);
                    //simple if to check that the number is corrisponding to a 'Menu Item'
                    if (menuChoise == 1 || menuChoise == 2 || menuChoise == 3)  // ** expand with the numbers of the menu items
                    {
                        isAnInt = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input! , Can't find a matching menu item!");
                    }
                    break;
                case 1:
                    // Creation of user , ouput from system handled inside respective class that handles the stuff
                    menuChoise = 0;
                    Console.WriteLine("Welcome to User Creation Service");
                    startMenu();
                    break;
                case 2:
                    // Login of users
                    menuChoise = 0;
                    Console.WriteLine("Welcome to User Login service");
                    startMenu();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Returning to previous menu..");
                    Thread.Sleep(1200);
                    startMenu();
                    break;
            }
            } while (loopIsRunning);
        }
    }
}
