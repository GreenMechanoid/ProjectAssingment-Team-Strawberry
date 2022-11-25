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

        // Menu options to handle user choices.
        public void userLoan(Userhandling user)
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
                        var amount = customerInterestAmount(Convert.ToDouble(userAmount));
                        Console.WriteLine($"You will have to pay an interestamount : {amount}");
                        Thread.Sleep(4000);
                        goto default;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("How much do you want to loan?");
                        userAmount = Console.ReadLine();
                        bool allowed = issueLoan(user, Convert.ToDouble(userAmount));
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
    }
}

