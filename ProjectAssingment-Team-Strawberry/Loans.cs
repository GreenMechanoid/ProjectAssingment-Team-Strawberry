// .Net22 Jesper Andersson
// Team Strawberry
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace ProjectAssingment_Team_Strawberry
{
    class Loans : BankAccounts
    {
        double interestRate = 0.1;
        public double amountLoaned;
        public string creditCheck;
        public float maxAllowedLoan;

        // Method to see Interest Amount.
        public double customerInterestAmount(double amount)
        {
            return amount * interestRate;
        }

        // Method to check if currentuser can get the loan amount asked for.
        public bool issueLoan(Userhandling currentUser, double amount)
        {
            double allowedToLoan = 0;
            foreach (var account in currentUser.MyAccounts)
            {
                if (account.currencyType!="sek")
                {
                    //allowedToLoan += accountName.currencyConverter("", "", 1) Måste implementeras senare  // annan valuta
                }
                else
                {
                    allowedToLoan += account.balance;
                }
                
            }
            return amount < allowedToLoan * 5;
        }

        
    }
}

