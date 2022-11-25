// .Net22 Daniel Svensson
// Team Strawberry
using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection.Metadata;

namespace ProjectAssingment_Team_Strawberry
{
    internal class Userhandling
    {
        // keeping default as an admin accountName, this should be removed once the system is published
        public string userName = "admin";
        private string password = "admin"; // will not be hashing the password due to this being a assignment and all partys needs to be able to access it.
        private readonly string firstName = "admin";
        private readonly string lastName = "adminsson";
        protected string birthDate = "2000-01-12";
        protected string country = "adminland";
        protected string street = "admin street";
        protected string postalCode = "991122"; // is a string due to some postalcodes contain letters. (exampel Canada's contain letters)
        protected string cityName = "admin Town";
        private readonly string userPrivelages = "ADMIN";

        // keeping the login stuff in the user due to the structure it would have in a database (same table)
        public int loginAttempts = 0; // always start at 0 attempts from created accounts
        public bool lockedLogin = false; // can't be locked if the attempts havn't been made

        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName;}
        public string LastName { get => lastName;}
        public string UserPrivelages { get => userPrivelages;}

        public List<BankAccounts> MyAccounts = new List<BankAccounts>();

        // empty constructor to get the admin accountName rolling so users can be managed from it later
        public Userhandling() 
        {

        }
        // used later to make new user's during runtime
        public Userhandling(string userName, string password, string fName, string lName, string birthDate, string country, string street, string postalCode, string cityName, string privlages)
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

        /// <summary>
        /// Creates a New user and adds it to the "DB Table" (list)
        /// </summary>
        /// <param name="Users">All Users from "DB" (list)</param>
        /// <param name="currentUser"></param>
        public void CreateUser(List<Userhandling> Users, Userhandling currentUser)
        {
            string tempString;
            bool checkingBool;
            int countingInt = 0;
            List<string> savedInfo = new List<string> { };
            string placeHolder;
            ConsoleKey yesorno;

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
                        savedInfo[1] = tempString;
                        Console.WriteLine("Please confirm you password\n");
                        tempString = Console.ReadLine();
                        if (countingInt == 3) Console.Clear(); countingInt = 0; ; // simple clean-up of the screen if they are looping too much
                        countingInt++;
                    } while (tempString != savedInfo[1].ToString());
                }
            } while (checkingBool == false);
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
            Console.WriteLine($"Name:{savedInfo[0]}\nPassword: {savedInfo[1]}\nFirst Name: {savedInfo[2]}\nLast Name: {savedInfo[3]}\n" +
                $"BirthDate: {savedInfo[4]}\nCountry: {savedInfo[5]}\nAdress: {savedInfo[6]}\nPostal Code: {savedInfo[7]}\nCity Name: {savedInfo[8]}\n");
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
                    Console.WriteLine("Welcome as a new Customer to the bank!");
                    Thread.Sleep(6000);
                }
            }
        }

        /// <summary>
        /// checks if username already exists in the "DB table".
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="username">takes in the username that needs to be checked</param>
        /// <returns></returns>
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

        /// <summary>
        /// Asks the user if the input they gave is correct
        /// </summary>
        /// <param name="savedinfo"></param>
        /// <param name="tempString"></param>
        /// <param name="placeholder"></param>
        public void CorrectInput(List<string> savedinfo, string tempString,string placeholder)
        {
            ConsoleKey yesorno;
            
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
                        int tempArrayIndex = i;
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

        /// <summary>
        /// Asks the user if the input they gave is correct (integer overload)
        /// </summary>
        /// <param name="savedinfo"></param>
        /// <param name="tempInt"></param>
        /// <param name="placeholder"></param>
        public void CorrectInput(List<int> savedinfo, int tempInt, string placeholder) 
        {
            ConsoleKey yesorno;
            int tempArrayIndex;
            int screenClearInt = 0;
            bool loopTrigger = true;
            Console.Clear();
            do
            {
                for (int i = 0; i < savedinfo.Count; i++)
                {
                    if (tempInt == savedinfo[i]) 
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
                            if (int.TryParse(Console.ReadLine(), out int temp))
                            {
                                savedinfo[tempArrayIndex] = temp;
                            }

                            if (screenClearInt == 3) Console.Clear(); screenClearInt = 0; // simple clean-up of the screen if they are looping too much
                            screenClearInt++;
                        }
                    } 
                    
                }

            } while (loopTrigger == true);
        }

        public void RemoveLockout(List<Userhandling> users, string tempUser) 
        {
            foreach (Userhandling user in users)
            {
                if (user.userName == tempUser)
                {
                    user.lockedLogin = false;
                    user.loginAttempts = 0;
                    Console.WriteLine($"This account {user.userName} is now unlocked");
                }
            }
        }
        public void ChangePassword(List<Userhandling> users, string tempUser)
        {
            Console.WriteLine("enter new password: ");
            string tempPass = Console.ReadLine();

            foreach (Userhandling user in users)
            {
                if (user.userName == tempUser)
                {
                    user.Password = tempPass;
                    Console.WriteLine($"This accounts ({user.userName}) Password is now {user.Password}");
                    
                    Thread.Sleep(2400);
                }
            }
        }


    }
}
