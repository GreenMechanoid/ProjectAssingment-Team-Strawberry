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
        public float intrestRate;
        public string standardCurrency = "sek";

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

                user.MyAccounts.Add(newAccount);
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

            Console.WriteLine("Please enter the ammount you wish to transfer");
            
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
                        tempBalance += account2.balance;
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

            Console.WriteLine("Please enter the ammount you wish to transfer");

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
                                tempBalance += account2.balance;
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

    }
}