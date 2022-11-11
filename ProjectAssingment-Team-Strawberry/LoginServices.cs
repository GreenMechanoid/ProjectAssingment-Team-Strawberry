using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjectAssingment_Team_Strawberry
{
    internal class LoginServices : Userhandling
    {
        //empty constructor, login creds and such is in user, this is a middle hand class that has the code for login and attempts

        public bool LoginUser(List<Userhandling> users,string username, string password)
        {
            bool loginsuccess = false;
            foreach (Userhandling user in users.FindAll(un => un.userName == username))
            {
                do
                {

                    if (user.Password == password)
                    {
                        Console.WriteLine($"Login successfull, Welcome {user.FirstName} {user.LastName}");
                        loginsuccess = true;
                    }
                    else
                    {
                        Console.WriteLine($"Username / Password was incorrect!, please try again. Attempts Left : {3 - user.loginAttempts}");
                        user.loginAttempts++;
                        if (loginAttempts == 3)
                        {
                            user.lockedLogin = true;
                            Console.WriteLine("You have done all attempts allowed. Your account has been locked\n please contact a Administrator to unlock it");

                        }
                    }
                
                } while (loginsuccess == false && user.lockedLogin == false);
            }
                

            return loginsuccess;
        }
    }
}
