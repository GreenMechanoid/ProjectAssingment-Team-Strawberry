//.Net 22 Daniel Svensson, Elias Hammou , Jesper Andersson
using System;
using System.Collections.Generic;

namespace ProjectAssingment_Team_Strawberry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menus menu = new Menus();
            Userhandling admin = new Userhandling(); // added for testing, it has admin currently. no login implemented
            List<Userhandling> Users = new List<Userhandling>();
            menu.StartMenu(Users, admin);
        }
    }
}
