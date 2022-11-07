using System;

namespace ProjectAssingment_Team_Strawberry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // creating a userInterface with a Switch case
            int Choise = 0;
            switch (Choise)
            {
                default: // default is user's choices, writeline messages with the choices available.

                    Console.WriteLine("1: User management");

                    Choise = 0;
                    break;
                case 1:
                    switch (Choise)
                    {
                        default:
                            Console.WriteLine("1: Create User");
                            Console.WriteLine("2: Login user");
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                    break;
            }
        }
    }
}
