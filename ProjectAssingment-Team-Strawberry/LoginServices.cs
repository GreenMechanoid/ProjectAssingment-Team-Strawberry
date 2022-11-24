//.Net22 Daniel Svensson
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProjectAssingment_Team_Strawberry
{
    internal class LoginServices
    {
        //empty constructor, login creds and such is in user, this is a middle hand class that has the code for login and attempts
        public bool loginSuccess = false;
        public bool loginLocked = false;
        protected string tempUser;
        protected string tempPass;

        /// <summary>
        /// Checks the inputed username and password
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public Userhandling LoginUser(List<Userhandling> users)
        {
            Console.WriteLine("Please enter the Username\n");
            tempUser = Console.ReadLine().ToLower();
            Console.WriteLine("and please enter the password\n");
            tempPass = Console.ReadLine();

            do
            {


                foreach (Userhandling user in users)
                {
                    if (user.lockedLogin == true && user.userName == tempUser)
                    {
                        Console.WriteLine("This account is locked due to Bruteforce attempts : Contact a Administrator to unlock");
                        Thread.Sleep(2400);
                    }

                    else if (user.Password == tempPass && user.userName == tempUser)
                    {
                        Console.WriteLine($"Login successfull, Welcome {user.FirstName} {user.LastName}");
                        loginSuccess = true;
                        Thread.Sleep(3000);
                        return user;
                    }

                    else if (user.Password != tempPass && user.userName == tempUser)
                    {
                        Console.WriteLine($"Username / Password was incorrect!, please try again. Attempts Left : {3 - user.loginAttempts}");
                        Console.WriteLine("please try again\n");
                        tempPass = Console.ReadLine();
                        user.loginAttempts++;
                        if (user.loginAttempts == 3)
                        {
                            user.lockedLogin = true;
                            loginLocked = true;
                            Console.WriteLine("You have done all attempts allowed. Your account has been locked\n please contact a Administrator to unlock it");
                            Thread.Sleep(2400);
                        }
                    }


                }
            } while (loginLocked == false || loginLocked == false);
            return null;
        }
    }
}
