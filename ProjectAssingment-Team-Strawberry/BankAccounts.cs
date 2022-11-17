using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAssingment_Team_Strawberry
{
    class BankAccounts : Userhandling
    {
        public string account;
        public double balance;
        public string accountType;
        public string currencyType;
        public float intrestRate;

        List<string> transactionLog = new List<string>();

        Userhandling uh = new Userhandling();


        public void createBankAccounts()
        {
            uh.CreateUser();
        }
        public bool transferMoney(string account1, string account2)
        {

        }
        public bool transferAccountToAnother()
        {

        }
        public void currencyConverter(string currency, string currency2, double exchangeRate)
        {

        }
        public bool logTransaction(List<string> tLog, double amount)
        {

        }

    }
}