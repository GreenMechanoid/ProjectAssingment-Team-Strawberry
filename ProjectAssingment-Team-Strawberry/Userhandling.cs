// .Net22 Daniel Svensson
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAssingment_Team_Strawberry
{
    internal class Userhandling
    {
        // keeping default as an admin account, this should be removed once the system is published
        protected string userName = "admin";
        protected string password = "admin"; // will not be hashing the password due to this being a assignment and all partys needs to be able to access it.
        protected string firstName = "admin";
        protected string lastName = "adminsson";
        protected int age = 999;
        protected string country = "adminland";
        protected string adress = "admin street";
        protected string postalCode = "991122"; // is a string due to some postalcodes contain letters. (exampel Canada's contain letters)
        protected string cityName = "admin Town";
        protected string userPrivelages = "notAdmin";

        // empty constructor to get the admin account rolling so users can be managed from it later
        public Userhandling() 
        {

        }
        // used later to make new user's during runtime
        protected Userhandling(string userName, string password, string fName, string lName, int age, string country, string adress, string postalCode, string cityName)
        {
            this.userName = userName.ToLower(); //converting to lowercase to store the information
            this.password = password;
            this.firstName = fName;
            this.lastName = lName;
            this.age = age;
            this.country = country;
            this.adress = adress;
            this.postalCode = postalCode;
            this.cityName = cityName;
        }

        //takes in the current List of users in the "database" 
        public void CreateUser(Userhandling[] users)
        {
            string tempString;
            bool checkingBool = false;
            int countingInt = 0;
            object[] savedInfo = new object[]{};

            Console.Clear();
            Console.WriteLine("Welcome to the bank 'New User' \n Please enter your information so we can set you up with an account\n");
            Console.WriteLine("Please enter a username for your account");
            tempString = Console.ReadLine().ToLower();
            do
            {
                checkingBool = CheckUserName(users, tempString);
                if (checkingBool == true)
                {

                    Console.WriteLine("That username is already taken. Please choose another username");
                    tempString = Console.ReadLine().ToLower();
                    if (countingInt == 3) Console.Clear(); countingInt = 0; ; // simple clean-up of the screen if they are looping too much
                    countingInt++;
                }
            } while (checkingBool == false);
            savedInfo[0] = tempString;
            checkingBool = false;
            countingInt = 0;
            Console.Clear();
            Console.WriteLine("Please enter you Password for the account\n");
            tempString = Console.ReadLine();
            savedInfo[1] = tempString;
            Console.WriteLine("Please confirm you password\n");
            tempString = Console.ReadLine();
            do
            {
                if (tempString == savedInfo[1].ToString()) 
                {
                    checkingBool = true;
                } 
                else
                {
                    do
                    {
                        Console.WriteLine("the passwords you entered did not match! \n please try again\n");
                        Console.WriteLine("Please enter you Password for the account\n");
                        tempString = Console.ReadLine();
                        savedInfo[1] = tempString;
                        Console.WriteLine("Please confirm you password\n");
                        tempString = Console.ReadLine();
                        if (countingInt == 3) Console.Clear(); countingInt = 0; ; // simple clean-up of the screen if they are looping too much
                        countingInt++;
                    } while (tempString != savedInfo[1].ToString());
                }
            } while (checkingBool == false);
            checkingBool = false;
            countingInt = 0;
            Console.Clear();
            Console.WriteLine("Please enter the First name of the Account holder\n");
            tempString = Console.ReadLine();
            savedInfo[2] = tempString;
            CorrectInput(savedInfo, tempString);
            Console.Clear();
            Console.WriteLine("Please enter the Last name of the Account holder\n");
            tempString = Console.ReadLine();
            savedInfo[3] = tempString;
            CorrectInput(savedInfo, tempString);
        }

        //checks if username already exists in the "database".
        public bool CheckUserName(Userhandling[] userList, string username) 
        {
            foreach (var user in userList)
            {
                if (user.userName == username)
                {
                    return true;
                }
                
            }
            return false;
        }

        public virtual void CorrectInput(object[] savedinfo, string tempString)
        {
            ConsoleKey yesorno = ConsoleKey.K;
            int tempArrayIndex = 0;
            int screenClearInt = 0;
            bool loopTrigger = true;
            Console.Clear();
            do
            {
                for (int i = 0; i < savedinfo.Length; i++)
                {
                    if (tempString == savedinfo[i].ToString()) 
                    {
                        Console.WriteLine($"Is this info Correct? : {savedinfo[i]} \nY to continue to next entry");
                        tempArrayIndex = i;
                        if (yesorno == ConsoleKey.Y)
                        {
                            loopTrigger = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Then please enter the info again\n");
                            tempString = Console.ReadLine();
                            savedinfo[int.Parse(tempArrayIndex.ToString())] = tempString;
                            if (screenClearInt == 3) Console.Clear(); screenClearInt = 0; ; // simple clean-up of the screen if they are looping too much
                            screenClearInt++;
                        }
                    } 
                   
                }

                if (yesorno == ConsoleKey.Y)
                {
                    break;
                }
            } while (loopTrigger == true);
        }
        //checks if the inputed info is correct, if not then keeps looping until it is
        public virtual void CorrectInput(object[] savedinfo, int tempInt) 
        {
            ConsoleKey yesorno;
            int tempArrayIndex = 99;
            int temp = 0;
            int screenClearInt = 0;
            bool loopTrigger = true;
            Console.Clear();
            do
            {
                for (int i = 0; i < savedinfo.Length; i++)
                {
                    if (tempInt == int.Parse(savedinfo[i].ToString())) 
                    {
                        Console.WriteLine($"Is this info Correct? : {savedinfo[i]} \nY to continue to next entry");
                        tempArrayIndex = i;
                        yesorno = Console.ReadKey().Key;
                        if (yesorno == ConsoleKey.Y)
                        {
                            loopTrigger = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Then please enter the info again\n");
                            if (int.TryParse(Console.ReadLine(), out temp))
                            {
                                savedinfo[int.Parse(tempArrayIndex.ToString())] = temp;
                            }

                            if (screenClearInt == 3) Console.Clear(); screenClearInt = 0; // simple clean-up of the screen if they are looping too much
                            screenClearInt++;
                        }
                    } 
                    
                }

            } while (loopTrigger == true);
        }
    }
}
