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
		public void startMenu(List<Userhandling> Users, Userhandling currentUser)
		{
            this.menuChoise = 0;
			this.loopIsRunning = true;
			// creating a userInterface with a Switch case
			do
			{
				switch (this.menuChoise)
				{
					default: // default is user's choices, writeline messages with the choices available.

						Console.Clear();
						Console.WriteLine("1: User management");
						Console.WriteLine("99: Terminate Program");
						do
						{
							int.TryParse(Console.ReadLine(), out this.menuChoise);
							//simple if to check that the number is corrisponding to a 'Menu Item'
							if (this.menuChoise == 1 || this.menuChoise == 99)  // ** expand with the numbers of the menu items
							{
								this.isAnInt = true;
							}
							else
							{
								Console.WriteLine("Wrong input! , Can't find a matching menu item!");
							}
						} while (!this.isAnInt); //keep looping if it's not a number
						break;
					case 1:
						UserManagement(Users, currentUser);
						break;
					case 99: //Termination Selection
						this.loopIsRunning = false; // to terminate the do while after choice is to terminate the program
						Console.Clear();
						Console.WriteLine("Thank you for running this program. have a nice day!");
						break;

				}

			} while (this.loopIsRunning);
		}
		public void UserManagement(List<Userhandling> Users, Userhandling user)
		{
			this.menuChoise = 0;
			this.loopIsRunning = true;
			do
			{
			switch (this.menuChoise)
			{
				default:
					Console.Clear();
					Console.WriteLine("1: Create User");
					Console.WriteLine("2: Return to Previous Menu");

					int.TryParse(Console.ReadLine(), out this.menuChoise);
					//simple if to check that the number is corrisponding to a 'Menu Item'
					if (this.menuChoise == 1 || this.menuChoise == 2 || this.menuChoise == 3)  // ** expand with the numbers of the menu items
					{
						this.isAnInt = true;
					}
					else
					{
						Console.WriteLine("Wrong input! , Can't find a matching menu item!");
					}
						break;
				case 1:
					// Creation of user , ouput from system handled inside respective class that handles the stuff
					this.menuChoise = 0;
					Console.WriteLine("Welcome to User Creation Service");
					user.CreateUser(Users, user);
					startMenu(Users,user);
					 break;
				case 2:
					Console.Clear();
					Console.WriteLine("Returning to previous menu..");
					Thread.Sleep(1200);
					startMenu(Users, user);
					this.loopIsRunning = false;
					 break;
			}
			} while (this.loopIsRunning);
		}
	}
}
