// .Net22 Daniel Svensson, Jesper Andersson
// Team Strawberry
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
        Loans loan;

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
            loan = new Loans();
        }
        public void StartMenu()
        {
            this.menuChoise = 0;
            this.loopIsRunning = true;
			// creating a userInterface with a Switch case
			if (currentUser == null)
			{
				currentUser = login.LoginUser(Users);
			}
            do
            {
                switch (this.menuChoise)
                {
                    default: // default is user's choices, writeline messages with the choices available.
						this.menuChoise = 0;
                        Console.Clear();
                        //login to system


                        Console.WriteLine("1: User Management");
                        
                        if (currentUser != null)
                        {
							Console.WriteLine("2. Account menu");
                        }
                        Console.WriteLine("99: Terminate Program");
                        do
                        {
                            int.TryParse(Console.ReadLine(), out this.menuChoise);
                            //simple if to check that the number is corrisponding to a 'Menu Item'
                            if (this.menuChoise == 1 || this.menuChoise == 2 && currentUser != null || this.menuChoise == 99)  // ** expand with the numbers of the menu items
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
							UserManagement(Users, currentUser);
                        goto default;
					case 2:
						accountMenu(Users,currentUser);
						goto default;
                    case 99: //Termination Selection
                        this.loopIsRunning = false; // to terminate the do while after choice is to terminate the program
                        Console.Clear();
                        Console.WriteLine("Thank you for running this program. have a nice day!");
                        break;

                }

            } while (this.loopIsRunning);
        }

        /// <summary>
        /// Menu options to handle choices for Users.
        /// </summary>
        /// <param name="Users"></param>
        /// <param name="user"></param>
        public void UserManagement(List<Userhandling> Users, Userhandling user)
		{
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.ForegroundColor = ConsoleColor.Cyan;
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
                        goto case 2;
					
					case 34:
					// Creation of user , ouput from system handled inside respective class that handles the stuff
					this.menuChoise = 0;
					Console.WriteLine("Welcome to User Creation Service");
					user.CreateUser(Users, user);
                        goto default;
                    case 35:
                        // Creation of user , ouput from system handled inside respective class that handles the stuff
                        this.menuChoise = 0;
                        Console.WriteLine("Welcome to User Support Services");
                        UserSupportMenu(Users);
                        goto default;
                    case 2:
					Console.Clear();
					Console.WriteLine("Returning to Mainmenu..");
					Thread.Sleep(1200);
					this.loopIsRunning = false;
					 break;
			}
			} while (this.loopIsRunning);
			Console.ResetColor();
        }
        /// <summary>
        /// Menu options to handle user choices for accounts.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="user"></param>
        public void accountMenu(List<Userhandling> users, Userhandling user)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to the accountmenu!");
            bool isAChoice = false;
            bool doneyet = false;
            int switcheroo = 0;
            do
            {

                Console.WriteLine("Make a choice.");


                switch (switcheroo)
                {

                    case 1:
                        Console.Clear();
                        Console.WriteLine("balance for your accounts.");
                        accounts.ShowMyAccountsBalance(user);
                        Thread.Sleep(6000);
                        goto default;
                    case 2:
                        Console.Clear();

                        accounts.DepositCurrency(user);
                        Thread.Sleep(6000);
                        goto default;
                    case 3:
                        Console.Clear();
                        Loans Loans = new Loans();
                        userLoanMenu(user);
                        goto default;
                    case 4:
                        Console.Clear();
                        accounts.createBankAccounts(user);
                        Thread.Sleep(6000);
                        goto default;
                    case 5:
                        Console.Clear();
                        accounts.transferMoney(user);
                        Thread.Sleep(6000);
                        goto default;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Please enter the username of the one reciveing the transfer");
                        var tempUser = Console.ReadLine();
                        foreach (var us in users)
                        {
                            if (tempUser == us.userName)
                            {
                                accounts.transferMoney(user,us);

                            }
                        }
                            Thread.Sleep(6000);
                        goto default;
                    case 7:
                        Console.Clear();
                        if (user.UserPrivelages == "ADMIN")
                        {
                            Console.WriteLine("Create an account.");
                            accounts.createBankAccounts(users);
                            Thread.Sleep(6000);
                            goto default;
                        }
                        goto default;
                    case 9:
                        doneyet = true;
                        break;
                    default:
                        Console.Clear();
                        //login to system
                        Console.WriteLine("1: Balance.");
                        Console.WriteLine("2: Deposit to account");
                        Console.WriteLine("3: Loan.");
                        Console.WriteLine(user.MyAccounts.Count > 0 ? "4: Create a new account" : "4: Create account.");
                        Console.WriteLine("5: Transfer money between own accounts.");
                        Console.WriteLine("6: Transfer money between users.");
                        Console.Write(user.UserPrivelages == "ADMIN" ? "7: create new account for another user" : "");
                        Console.WriteLine("\n9: Go back to start menu.");

                        do
                        {
                            int.TryParse(Console.ReadLine(), out switcheroo);
                            //simple if to check that the number is corrisponding to a 'Menu Item'
                            if (switcheroo == 1 || switcheroo == 2 || switcheroo == 3 || switcheroo == 4 || switcheroo == 5 || switcheroo == 6 || switcheroo == 7 || switcheroo == 9)  // ** expand with the numbers of the menu items
                            {
                                isAChoice = true;
                            }
                            else
                            {
                                Console.WriteLine("Wrong input! , Can't find a matching menu item!");
                            }
                        } while (!isAChoice); //keep looping if it's not a number
                        break;
                }

            } while (!doneyet);
            Console.ResetColor();
        }

        /// <summary>
        /// Menu options to handle user choices for loans.
        /// </summary>
        /// <param name="user"></param>
        public void userLoanMenu(Userhandling user)
        {
            Console.WriteLine("Welcome to the loansmenu!");
            bool isAChoice = false;
            bool doneyet = false;
            int switcheroo = 0;
            string userAmount;
            do
            {

                switch (switcheroo)
                {

                    case 1:
                        Console.Clear();
                        Console.WriteLine("Make a choice and see interestrate.");
                        userAmount = Console.ReadLine();
                        var amount = loan.customerInterestAmount(Convert.ToDouble(userAmount));
                        Console.WriteLine($"You will have to pay an interestamount : {amount}");
                        Thread.Sleep(4000);
                        goto default;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("How much do you want to loan?");
                        userAmount = Console.ReadLine();
                        bool allowed = loan.issueLoan(user, Convert.ToDouble(userAmount));
                        if (allowed)
                        {
                            Console.WriteLine("You are allowed to loan that amount.");
                        }
                        else
                        {
                            Console.WriteLine("You are not allowed to loan that amount.");
                        }
                        Thread.Sleep(4000);
                        goto default;
                    case 3:
                        doneyet = true;
                        break;
                    default:
                        Console.Clear();
                        //login to system
                        Console.WriteLine("1: Interestrate amount.");
                        Console.WriteLine("2: Get a loan.");
                        Console.WriteLine("3: Go back to menu.");

                        do
                        {
                            int.TryParse(Console.ReadLine(), out switcheroo);
                            //simple if to check that the number is corrisponding to a 'Menu Item'
                            if (switcheroo == 1 || switcheroo == 2 || switcheroo == 3)  // ** expand with the numbers of the menu items
                            {
                                isAChoice = true;
                            }
                            else
                            {
                                Console.WriteLine("Wrong input! , Can't find a matching menu item!");
                            }
                        } while (!isAChoice); //keep looping if it's not a number
                        break;
                }

            } while (!doneyet);
        }


        /// <summary>
        /// contains various Support functions for the admin to handle other users accounts, (remove lockout, change password)
        /// </summary>
        /// <param name="users"></param>
        public void UserSupportMenu(List<Userhandling> users)
        {
            bool doneyet = false;
            int switcheroo = 0;
            do
            {

                Console.WriteLine("Please enter the Account name of the user");
                string tempUser = Console.ReadLine();

                switch (switcheroo)
                {
                    default:
                        Console.WriteLine("1: remove bruteforce lockout");
                        Console.WriteLine($"2: Change password on {tempUser}");
                        Console.WriteLine("3: Return to main menu");
                        int.TryParse(Console.ReadLine(), out switcheroo);
                        break;
                    case 1:
                        currentUser.RemoveLockout(users,tempUser);
                        Console.Clear();
                        goto default;
                    case 2:
                        currentUser.ChangePassword(users, tempUser);
                        Console.Clear();
                        goto default;
                    case 3:
                        doneyet = true;
                        Thread.Sleep(2400);
                        break;
                }

            } while (!doneyet);

        }
    }
}
