using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace ProjectAssingment_Team_Strawberry
{
    class Loans : BankAccounts
    {
        public float interestRate = 0.1F;
        public double ammountLoaned;
        public string creditCheck;
        public float maxAllowedLoan;

        public double customerInterestAmmount(double ammount)
        {
            return ammount * interestRate;
        }

        public bool issueLoan(Userhandling currentUser, double ammount)
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
            return ammount < allowedToLoan * 5;
        }
        public void userLoan(Userhandling user)
        {
            Console.WriteLine("Welcome to the loansmenu!");
            bool isAChoice = false;
            bool doneyet = false;
            int switcheroo = 0;
            do
            {

                Console.WriteLine("Make a choice.");
                string userAmmount = Console.ReadLine();

                switch (switcheroo)
                {
                    
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Make a choice and see interestrate.");
                        userAmmount = Console.ReadLine();
                        var ammount = customerInterestAmmount(Convert.ToDouble(userAmmount));
                        Console.WriteLine($"You will have to pay an interestammount : {ammount}");
                        goto default;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("How much do you want to loan?");
                        userAmmount = Console.ReadLine();
                        bool allowed = issueLoan(user, Convert.ToDouble(userAmmount));
                        if (allowed)
                        {
                            Console.WriteLine("You are allowed to loan that ammount.");
                        }
                        else
                        {
                            Console.WriteLine("You are not allowed to loan that ammount.");
                        }
                        goto default;
                    case 3:
                        doneyet = true;
                        Thread.Sleep(2400);
                        break;
                    default:
                        Console.Clear();
                        //login to system
                        Console.WriteLine("1: Interestrate ammount.");
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

//Som användare vill jag kunna låna av banken och direkt få se hur mycket ränta jag kommer behöva betala på det lånet
//Som bankägare vill jag begränsa hur mycket varje kund kan låna av banken så att de maximalt kan låna 5 ggr de pengar de redan har i banken
