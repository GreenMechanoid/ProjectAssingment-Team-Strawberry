using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAssingment_Team_Strawberry
{
    class BankAccounts : Userhandling
    {
        public string account; // toUpper or toLower
        public double balance;
        public string accountType; // toUpper or toLower
        public string currencyType; // toUpper or toLower
        public float intrestRate;
        public string standardCurrency = "sek";

        List<string> transactionLog = new List<string>();
        

        public void createBankAccounts(List<Userhandling> Users)
        {
            string tempUserName;
            Console.WriteLine("Enter the UserName of the accountHolder");
            tempUserName = Console.ReadLine();

            foreach (Userhandling user in Users.FindAll(un => un.userName == tempUserName))
            { 
                BankAccounts newAccount = new BankAccounts();

                Console.WriteLine("Please enter the account Number");

                newAccount.account = Console.ReadLine();

                user.MyAccounts.Add(newAccount);

                
            }

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

         foreach(BankAccounts account in user1.MyAccounts.FindAll(acc => acc.account == "Name")) 
            {


                foreach (BankAccounts account2 in user2.MyAccounts.FindAll(acc2 => acc2.account == "Name"))
                {

                    double tempBalance = 0; // + - transaction


                    tempBalance -= account.balance;

                    if (account.balance < 0 ) 
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