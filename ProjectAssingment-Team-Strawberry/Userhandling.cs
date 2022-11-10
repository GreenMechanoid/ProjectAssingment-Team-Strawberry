// .Net22 Daniel Svensson
using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectAssingment_Team_Strawberry
{
    internal class Userhandling : Menus
    {
        // keeping default as an admin account, this should be removed once the system is published
        protected string userName = "admin";
        protected string password = "admin"; // will not be hashing the password due to this being a assignment and all partys needs to be able to access it.
        protected string firstName = "admin";
        protected string lastName = "adminsson";
        protected string birthDate = "2000-01-12";
        protected string country = "adminland";
        protected string street = "admin street";
        protected string postalCode = "991122"; // is a string due to some postalcodes contain letters. (exampel Canada's contain letters)
        protected string cityName = "admin Town";
        protected string userPrivelages = "ADMIN";

        // empty constructor to get the admin account rolling so users can be managed from it later
        public Userhandling() 
        {

        }
        // used later to make new user's during runtime
        protected Userhandling(string userName, string password, string fName, string lName, string birthDate, string country, string street, string postalCode, string cityName, string privlages)
        {
            this.userName = userName.ToLower(); //converting to lowercase to store the information
            this.password = password;
            this.firstName = fName;
            this.lastName = lName;
            this.birthDate = birthDate;
            this.country = country;
            this.street = street;
            this.postalCode = postalCode;
            this.cityName = cityName;
            this.userPrivelages = privlages.ToUpper();
        }

        //takes in the current List of users in the "database"
        public void CreateUser(List<Userhandling> Users, Userhandling currentUser)
        {
            string tempString;
            bool checkingBool = false;
            int countingInt = 0;
            List<string> savedInfo = new List<string> { };
            string placeHolder;
            ConsoleKey yesorno;
            if (Users.Count == 0)
            {
                Users.Add(currentUser);
            }

            Console.Clear();
            Console.WriteLine("Welcome to the bank 'New User' Please enter your information so we can set you up with an account");
            Console.WriteLine("Please enter a username for your account");
            tempString = Console.ReadLine().ToLower();
            do
            {
                checkingBool = CheckUserName(Users, tempString);
                if (checkingBool == true)
                {

                    Console.WriteLine("That username is already taken. Please choose another username");
                    tempString = Console.ReadLine().ToLower();
                    if (countingInt == 3) Console.Clear(); countingInt = 0; ; // simple clean-up of the screen if they are looping too much
                    countingInt++;
                }
                else
                {
                    checkingBool = false;
                }
            } while (checkingBool == true);
            savedInfo.Add(tempString);
            //Console.Clear();
            Console.WriteLine("Please enter you Password for the account");
            tempString = Console.ReadLine();
            savedInfo.Add(tempString);
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
                        savedInfo.Add(tempString);
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
            savedInfo.Add(tempString);
            placeHolder = "First Name:";
            CorrectInput(savedInfo, tempString, placeHolder); // converted the checking if correct input into a method
            Console.Clear();
            Console.WriteLine("Please enter the Last name of the Account holder\n");
            tempString = Console.ReadLine();
            savedInfo.Add(tempString);
            placeHolder = "Last Name:";
            CorrectInput(savedInfo, tempString, placeHolder);
            Console.Clear();
            Console.WriteLine("Please enter the birthDate of the Account holder\n");
            tempString = Console.ReadLine();
            savedInfo.Add(tempString);
            placeHolder = "Date of Birth:";
            CorrectInput(savedInfo, tempString, placeHolder);
            Console.Clear();
            Console.WriteLine("Please enter the Country of the Account holder\n (exampel: Sweden)");
            tempString = Console.ReadLine();
            savedInfo.Add(tempString);
            placeHolder = "Country:";
            CorrectInput(savedInfo, tempString, placeHolder);
            Console.Clear();
            Console.WriteLine("Please enter the Street + street number of the Account holder\n (exampel: Mariboplan 44)");
            tempString = Console.ReadLine();
            savedInfo.Add(tempString);
            placeHolder = "Street inc number:";
            CorrectInput(savedInfo, tempString, placeHolder);
            Console.Clear();
            Console.WriteLine("Please enter the Postal Code of the Account holder\n (exampel: 824 41");
            tempString = Console.ReadLine();
            savedInfo.Add(tempString);
            placeHolder = "Postal code:";
            CorrectInput(savedInfo, tempString, placeHolder);
            Console.Clear();
            Console.WriteLine("Please enter the City's name of the Account holder (exampel: Hudiksvall )\n");
            tempString = Console.ReadLine();
            savedInfo.Add(tempString);
            placeHolder = "City Name:";
            CorrectInput(savedInfo, tempString, placeHolder);
            Console.Clear();
            Console.WriteLine("This is the current Saved information\n");
            Console.WriteLine($"Name:{savedInfo[0].ToString()}\nPassword: {savedInfo[1].ToString()}\nFirst Name: {savedInfo[2].ToString()}\nLast Name: {savedInfo[3].ToString()}\n" +
                $"BirthDate: {savedInfo[4].ToString()}\nCountry: {savedInfo[5].ToString()}\nAdress: {savedInfo[6].ToString()}\nPostal Code: {savedInfo[7].ToString()}\nCity Name: {savedInfo[8].ToString()}\n");
            Console.WriteLine("Is this information correct? Y/N");
            yesorno = Console.ReadKey(false).Key;
            if (yesorno == ConsoleKey.Y)
            {
                if (currentUser.userPrivelages == "ADMIN")
                {
                    checkingBool = false;
                    Console.Clear();
                    Console.WriteLine("Great, Is this new User a Admin (Y) or a Customer (N)??");
                    do
                    {
                        yesorno = Console.ReadKey(false).Key;
                        if (yesorno == ConsoleKey.Y)
                        {
                            Userhandling NewUser = new Userhandling(savedInfo[0].ToString(), savedInfo[1].ToString(), savedInfo[2].ToString(), savedInfo[3].ToString(), savedInfo[4].ToString(), savedInfo[5].ToString(), savedInfo[6].ToString(), savedInfo[7].ToString(), savedInfo[8].ToString(),"ADMIN");
                            Users.Add(NewUser);
                            checkingBool = true;
                            Console.WriteLine("User Created as a Admin");
                            Thread.Sleep(6000);
                            Console.Clear();
                        }
                        else if (yesorno == ConsoleKey.N)
                        {
                            Userhandling NewUser = new Userhandling(savedInfo[0].ToString(), savedInfo[1].ToString(), savedInfo[2].ToString(), savedInfo[3].ToString(), savedInfo[4].ToString(), savedInfo[5].ToString(), savedInfo[6].ToString(), savedInfo[7].ToString(), savedInfo[8].ToString(), "CUSTOMER");
                            Users.Add(NewUser);
                            checkingBool = true;
                            Console.WriteLine("User Created as a Customer.");
                            Thread.Sleep(6000);
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"{yesorno} Was not an option, (Y) for admin, (N) for Customer");
                            yesorno = Console.ReadKey(false).Key;
                        }
                    } while (checkingBool == false);
                }
                else
                {
                    Userhandling NewUser = new Userhandling(savedInfo[0].ToString(), savedInfo[1].ToString(), savedInfo[2].ToString(), savedInfo[3].ToString(), savedInfo[4].ToString(), savedInfo[5].ToString(), savedInfo[6].ToString(), savedInfo[7].ToString(), savedInfo[8].ToString(), "CUSTOMER");
                    Users.Add(NewUser);
                    checkingBool = true;
                    Console.WriteLine("Welcome as a new Customer to the bank!");
                    Thread.Sleep(6000);
                }
            }
        }

        //checks if username already exists in the "database".
        public bool CheckUserName(List<Userhandling> userList, string username) 
        {

            if (userList.Count != 0)
            {
            foreach (var user in userList)
            {
                if (user.userName == username)
                {
                    return true;
                }
                
            }
            }
            return false;
        }

        public virtual void CorrectInput(List<string> savedinfo, string tempString,string placeholder)
        {
            ConsoleKey yesorno;
            int tempArrayIndex = 0;
            int screenClearInt = 0;
            bool loopTrigger = true;
            Console.Clear();
            do
            {
                for (int i = 0; i < savedinfo.Count; i++)
                {
                    if (tempString == savedinfo[i].ToString() ) 
                    {
                        Console.WriteLine($"Is this {placeholder} Correct? : {savedinfo[i]} \nY to continue to next entry");
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
                            tempString = Console.ReadLine();
                            savedinfo[int.Parse(tempArrayIndex.ToString())] = tempString;
                            if (screenClearInt == 3) Console.Clear(); screenClearInt = 0; ; // simple clean-up of the screen if they are looping too much
                            screenClearInt++;
                        }
                    } 
                   
                }
            } while (loopTrigger == true);
        }
        //checks if the inputed info is correct, if not then keeps looping until it is
        public virtual void CorrectInput(List<string> savedinfo, int tempInt) 
        {
            ConsoleKey yesorno;
            int tempArrayIndex = 99;
            int temp = 0;
            int screenClearInt = 0;
            bool loopTrigger = true;
            Console.Clear();
            do
            {
                for (int i = 0; i < savedinfo.Count; i++)
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
                                savedinfo[int.Parse(tempArrayIndex.ToString())] = temp.ToString();
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
