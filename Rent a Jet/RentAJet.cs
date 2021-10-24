using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Controllers;

namespace Rent_a_Jet
{
    public static class RentAJet
    {
        public static void topBar()
        {
            Console.WriteLine("\n========================= RENT A JET APPLICATION =========================\n");
        }

        public static void bottomBar()
        {
            Console.WriteLine("==========================================================================\n");

        }

        public static void showMenu()
        {
            topBar();
            Console.WriteLine("Press 1 to charter a jet for a single flight from destination to source.");
            Console.WriteLine("Press 2 to charter a jet for a flight from A to B with intermediate stops.");
            Console.WriteLine("Press 3 to charter a jet for a specific period of time.\n");
            Console.WriteLine("Press 0 to quit the app.\n");
            bottomBar();
        }

        public static void charterOp1()
        {
        }

        public static void charterOp2()
        {
        }

        public static void charterOp3()
        {
        }

        public static void startApp()
        {
            string choice;
            do
            {
                showMenu();
                Console.WriteLine("Your Choice: ");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    charterOp1();
                }
                else if (choice == "2")
                {
                    charterOp2();
                }
                else if (choice == "3")
                {
                    charterOp3();
                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
                }
            } while (choice != "0");
        }
    }
}
