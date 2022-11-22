using System;
using System.Collections.Generic;
using System.Text;

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
        

        // method contains checking if the username exists, still needs to implement a check if the account actually exists as well
        //currently testing in Menus - option 2, by creating 2 accounts and then transfer stuff, checking done in run-break mode
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
        //public void transferMoney(string account1, string account2)
        //{

        //    MyAccounts.FindAll("hitta första kontot");

        //    double tempvalue; // plocka bort för att ge till andra kontot

        //    MyAccounts.FindIndex("konto nummer 2");
        //    MyAccounts["konto"] += tempvalue;

        //}
        public void transferAccountToAnother(Userhandling user1, Userhandling user2)
        {
            bool loopCheck = false;
            double tempBalance = 0; // + - transaction
            Console.WriteLine("Please enter the ammount you wish to transfer");
            
            do
            {
                if (double.TryParse(Console.ReadLine(), out tempBalance))
                {
                    foreach (BankAccounts account in user1.MyAccounts.FindAll(acc => acc.accountName == "Name"))
                    {


                        foreach (BankAccounts account2 in user2.MyAccounts.FindAll(acc2 => acc2.accountName == "Name"))
                        {



                            tempBalance -= account.balance;

                            if (account.balance < 0)
                            {
                                tempBalance += account.balance;
                                Console.WriteLine("NOT ENOUGH MONEY! EXTERMINATE!");
                                return;
                            }

                            account.transactionLog.Add($" Amount was removed {tempBalance - account.balance}");
                            tempBalance += account2.balance;
                            account2.transactionLog.Add($" Amount was removed {tempBalance - account2.balance}");

                        }

                    }
                    loopCheck = true;
                }
                else
                {
                    Console.WriteLine("That was not a correct input");
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