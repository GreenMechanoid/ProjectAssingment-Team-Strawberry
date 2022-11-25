// .Net22 Daniel Svensson , Elias Hammou , Jesper Andersson
// Team Strawberry
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectAssingment_Team_Strawberry
{
    class BankAccounts : Userhandling
    {
        public string accountName; // toUpper or toLower
        public double balance;
        public string accountType; // toUpper or toLower
        public string currencyType; // toUpper or toLower
        public float savingintrestRate;
        string standardCurrency = "sek";
        

        List<string> transactionLog = new List<string>();
        
        /// <summary>
        /// Method that creates new bankaccounts for a user, takes in the "DB table" with users 
        /// (list in this program as no DB connection)
        /// </summary>
        /// <param name="Users"></param>
        public void createBankAccounts(List<Userhandling> Users)
        {
            string tempUserName;
            bool loopingBool = true;
            do
            {
            Console.WriteLine("Enter the UserName of the accountHolder");
            tempUserName = Console.ReadLine();


            if (CheckUserName(Users, tempUserName) == true)
            {

                foreach (Userhandling user in Users.FindAll(un => un.userName == tempUserName))
                { 
                    BankAccounts newAccount = new BankAccounts();

                    Console.WriteLine("Please enter the account Number");
                        

                    newAccount.accountName = Console.ReadLine().ToUpper();

                    Console.WriteLine("Enter an amount to deposit");
                    newAccount.balance = Convert.ToDouble(Console.ReadLine());

                    user.MyAccounts.Add(newAccount);
                    Console.WriteLine("Account has been created");
                }
                    loopingBool = false;
            }
            else if (tempUserName == "exit")
                {
                    Console.WriteLine("exiting to last menu");
                    loopingBool = false;
                }
            else
            {
                Console.WriteLine("That username is not created");
                Console.WriteLine("either try again or type in ' exit '");
            }

            } while (loopingBool == true);
            

                

        }
        /// <summary>
        /// Overloaded to go create accounts for the Currently loggedin user
        /// </summary>
        /// <param name="currentUser"></param>
        public void createBankAccounts(Userhandling currentUser)
        {
            bool loopingBool = true;

            do
            {
                BankAccounts newAccount = new BankAccounts();

                Console.WriteLine("Please enter the account Number");


                newAccount.accountName = Console.ReadLine().ToUpper();

                Console.WriteLine("Enter an amount to deposit");
                newAccount.balance = Convert.ToDouble(Console.ReadLine());

                currentUser.MyAccounts.Add(newAccount);
                    
                loopingBool = false;

                Console.WriteLine("Account has been created");
            } while (loopingBool == true);

        }
        /// <summary>
        /// Method for transfering between 2 User's bank accounts
        /// </summary>
        /// <param name="user1"></param>
        /// <param name="user2"></param>
        public void transferMoney(Userhandling user1, Userhandling user2)
        {
            bool loopCheck = false;
            double tempBalance = 0; // + - transaction
            string tempacc, tempacc2; //account name holders for the lambda expressions

            foreach (var account in user1.MyAccounts)
            {
                Console.WriteLine($"Account Name: {account.accountName}");
            }
            Console.WriteLine("\n please enter the account name from where the transfer is happening");

            tempacc = Console.ReadLine();

            foreach (var account in user2.MyAccounts)
            {
                Console.WriteLine($"Account Name: {account.accountName}");
            }
            Console.WriteLine("\n please enter the account name where the transfer is going");

            tempacc2 = Console.ReadLine();

            Console.WriteLine("Please enter the amount you wish to transfer");
            
            do
            {
                if (double.TryParse(Console.ReadLine(), out tempBalance))
                {
                    foreach (BankAccounts account in user1.MyAccounts.FindAll(acc => acc.accountName == tempacc))
                    {

                        if ( account.balance >= tempBalance)
                        {
                            account.balance -= tempBalance;
                            account.transactionLog.Add($" Amount was transfered {tempBalance}");
                        }
                        else
                        {
                            Console.WriteLine("Transfer Failed, balance to low");
                            Thread.Sleep(2000);
                            return;
                        }


                    }
                    foreach (BankAccounts account2 in user2.MyAccounts.FindAll(acc2 => acc2.accountName == tempacc2))
                    {
                        account2.balance +=tempBalance;
                        account2.transactionLog.Add($" Amount was recived {tempBalance}");

                    }
                    loopCheck = true;
                }
                else
                {
                    Console.WriteLine("That was not a correct input, try inputting a number for the transfer again.");
                }
                

            } while (loopCheck == false);
            

            
        }

        /// <summary>
        /// method for transgering money between "this" user's accounts
        /// </summary>
        /// <param name="currentUser"></param>
        public void transferMoney(Userhandling currentUser)
        {
            bool loopCheck = false;
            double tempBalance = 0; // + - transaction
            string tempacc, tempacc2; //account name holders for the lambda expressions

            foreach (var account in currentUser.MyAccounts)
            {
                Console.WriteLine($"Account Name: {account.accountName}");
            }
            Console.WriteLine("\n please enter the account name from where the transfer is happening");

            tempacc = Console.ReadLine();

            Console.WriteLine("\n please enter the account name where the transfer is going to");

            tempacc2 = Console.ReadLine();

            Console.WriteLine("Please enter the amount you wish to transfer");

            do
            {
                if (double.TryParse(Console.ReadLine(), out tempBalance))
                {
                    foreach (BankAccounts account in currentUser.MyAccounts.FindAll(acc => acc.accountName == tempacc))
                    {

                        if (account.balance >= tempBalance)
                        {
                            account.balance -= tempBalance;
                            account.transactionLog.Add($" Amount was transfered {tempBalance}");
                            foreach (BankAccounts account2 in currentUser.MyAccounts.FindAll(acc2 => acc2.accountName == tempacc2))
                            {
                                account2.balance += tempBalance;
                                account2.transactionLog.Add($" Amount was recived {tempBalance}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Transfer Failed, balance to low");
                            Thread.Sleep(2000);
                            return;
                        }                       
                    }

                    loopCheck = true;
                }
                else
                {
                    Console.WriteLine("That was not a correct input, try inputting a number for the transfer again.");
                }


            } while (loopCheck == false);



        }
        public void currencyConverter(string currency, string currency2, double exchangeRate)
        {

        }
        public void ShowlogTransaction(List<BankAccounts> accounts)
        {

            foreach (BankAccounts account in accounts) 
            {
                
            }

        }
        /// <summary>
        /// Simple method that goes through the accounts in a user and prints name and balance of the account
        /// </summary>
        /// <param name="currentUser"></param>
        public void ShowMyAccountsBalance(Userhandling currentUser)
        {
            foreach (var accounts in currentUser.MyAccounts)
            {
                Console.WriteLine($"Account number: {accounts.accountName} Balance : {accounts.balance}");
            }

        }
        /// <summary>
        /// Method to add more too the balance of an account
        /// </summary>
        /// <param name="user">current User</param>
        public void DepositCurrency(Userhandling user)
        {
            bool hasDeposited = false;
            bool inputCheck = false;
            if (user.MyAccounts.Count > 0)
            {
                do
                {
                    foreach (var account in user.MyAccounts)
                    {
                        Console.WriteLine($"Account name: {account.accountName + " Balance before deposit:" + account.balance}");
                    }

                    Console.WriteLine("please choose a account the deposit will go to");
                    string input = Console.ReadLine();

                    foreach (var account in user.MyAccounts)
                    {
                        if (input == account.accountName)
                        {
                            do
                            {
                                Console.WriteLine("Please enter the deposited amount: ");
                                if (double.TryParse(Console.ReadLine(), out double result)) 
                                {
                                    account.balance += result;
                                    inputCheck = true;
                                    hasDeposited = true;
                                    Console.WriteLine($"amount: {result} has been deposited to Account{account.accountName}");
                                    account.transactionLog.Add($"amount deposited to account: {result}");
                                }
                                else
                                {
                                    Console.WriteLine("that was not a number, try again");
                                }
                            } while (!inputCheck);
                        }
                    }

                } while (!hasDeposited);
            }
            else
            {
                Console.WriteLine($"{user.userName} currently has no accounts to deposit to.. please create one");
            }
        }


    }
}