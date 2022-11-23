//.Net 22 Daniel Svensson
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
		bool isAChoice = false;
        LoginServices login;
        Userhandling currentUser;
		Userhandling admin; 
		Userhandling guest;
		BankAccounts accounts;
        List<Userhandling> Users;

		public void createadmin()
		{
			admin = new Userhandling();
			var bankacc = new BankAccounts() { accountName = "admin1", balance = 1000, currencyType = "sek" };
			var bankacc1 = new BankAccounts() { accountName = "admin2", balance = 1000, currencyType = "sek" };
			admin.MyAccounts.AddRange(new List<BankAccounts>() { bankacc, bankacc1});
		}

		public Menus()
		{
			login = new LoginServices();
            Users = new List<Userhandling>();
            
			createadmin();
            guest = new Userhandling("guest", "guest", "guest", "guest",
            "guest", "guest", "guest", "guest", "guest", "guest");
            Users.Add(admin);// added for testing, it has admin currently
            Users.Add(guest);// added in for non admin accountName, also for testing logins
			accounts = new BankAccounts();
        }
        public void StartMenu()
        {
            this.menuChoise = 0;
            this.loopIsRunning = true;
            // creating a userInterface with a Switch case
			
            do
            {
                switch (this.menuChoise)
                {
                    default: // default is user's choices, writeline messages with the choices available.
						this.menuChoise = 0;
                        Console.Clear();
                        //login to system
                        Console.WriteLine("1: User Management");
						Console.WriteLine("2: transfer test");
                        Console.WriteLine("3. show currentuser account balance test");
                        if (currentUser != null)
                        {
                            Console.WriteLine("4. Account menu");
                        }
                        Console.WriteLine("99: Terminate Program");
                        do
                        {
                            int.TryParse(Console.ReadLine(), out this.menuChoise);
                            //simple if to check that the number is corrisponding to a 'Menu Item'
                            if (this.menuChoise == 1 || this.menuChoise == 2 || this.menuChoise == 3 || this.menuChoise == 4 && currentUser != null || this.menuChoise == 99)  // ** expand with the numbers of the menu items
                            {
                                this.isAChoice = true;
                            }
                            else
                            {
                                Console.WriteLine("Wrong input! , Can't find a matching menu item!");
                            }
                        } while (!this.isAChoice); //keep looping if it's not a number
                        break;
                    case 1:
						if (currentUser == null)
						{
							currentUser = login.LoginUser(Users);
						}
						else 
						{
							UserManagement(Users, currentUser);
						}
                        goto default;
                    case 2:
						accounts.createBankAccounts(Users);
                        accounts.createBankAccounts(Users);
                        accounts.transferMoney(admin,guest);
                        goto default;
					case 3:
                        if (currentUser != null)
                        {
							currentUser.ShowMyAccountsBalance(currentUser);
						}
                        else
                        {
							admin.ShowMyAccountsBalance(admin);
                        }

						Thread.Sleep(3500);
						goto default;
					case 4:
						new BankAccounts().accountMenu(currentUser);
						goto default;
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
						Console.WriteLine("1: Login as another User");
						if (currentUser.UserPrivelages == "ADMIN") 
						{ 
							Console.WriteLine("34: Create User");
							Console.WriteLine("35: User Support");
						}
						Console.WriteLine("2: Return to Previous Menu");

					int.TryParse(Console.ReadLine(), out this.menuChoise);
					//simple if to check that the number is corrisponding to a 'Menu Item'
					if (this.menuChoise == 1 || this.menuChoise == 2 || this.menuChoise == 34 || this.menuChoise == 35)  // ** expand with the numbers of the menu items
					{
						this.isAChoice = true;
					}
					else
					{
						Console.WriteLine("Wrong input! , Can't find a matching menu item!");
					}
						break;
					case 1:
						currentUser = login.LoginUser(Users);
                        Console.WriteLine("Returning to startmenu..");
                        Thread.Sleep(1200);
                        StartMenu();
						break;
					
					case 34:
					// Creation of user , ouput from system handled inside respective class that handles the stuff
					this.menuChoise = 0;
					Console.WriteLine("Welcome to User Creation Service");
					user.CreateUser(Users, user);
						StartMenu();
						break;
                    case 35:
                        // Creation of user , ouput from system handled inside respective class that handles the stuff
                        this.menuChoise = 0;
                        Console.WriteLine("Welcome to User Support Services");
                        user.UserSupport(Users);
                        StartMenu();
                        break;
                    case 2:
					Console.Clear();
					Console.WriteLine("Returning to Mainmenu..");
					Thread.Sleep(1200);
					StartMenu();
					this.loopIsRunning = false;
					 break;
			}
			} while (this.loopIsRunning);
		}
	}
}
