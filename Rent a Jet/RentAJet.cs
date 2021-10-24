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
            Console.WriteLine("\n======================== RENT A JET APPLICATION =========================\n");
        }

        public static void bottomBar()
        {
            Console.WriteLine("=========================================================================\n");

        }

        public static void showMenu()
        {
            topBar();
            Console.WriteLine(" Press 1 to charter a jet for a single flight from destination to source ");
            Console.WriteLine("Press 2 to charter a jet for a flight from A to B with intermediate stops");
            Console.WriteLine("         Press 3 to charter a jet for a specific period of time          ");
            Console.WriteLine("                       Press 0 to quit the app                       \n");
            bottomBar();
        }

        public static Customer enquireDetails()
        {
            Customer customer = new Customer();
            topBar();
            Console.Write(" Enter Customer Name: ");
            customer.name = Console.ReadLine();
            Console.Write("Enter Customer Email: ");
            customer.email = Console.ReadLine();
            Console.Write("Enter Customer Phone: ");
            customer.phone = Console.ReadLine();
            bottomBar();
            return customer;
        }

        public static void charterOp1()
        {
            CharterTransactionSingle transaction = new CharterTransactionSingle();
            Customer customer = enquireDetails();
            customer.transactionType = 1;
            Console.Clear();
            transaction.customer = customer;
            topBar();
            Console.Write("            Please Enter Departure Place: ");
            transaction.departurePlace = Console.ReadLine();
            Console.Write("\n         Please Enter Destionation Place: ");
            transaction.destinationPlace = Console.ReadLine();
            Console.Write("\nPlease Enter Departure Date (YYYY-MM-DD): ");
            transaction.departureDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("\nPlease Enter Number of People Travelling: ");
            transaction.travellingAmount = Convert.ToInt32(Console.ReadLine());
            List<Aircraft> aircrafts = AircraftDBHandler.getAircraftsByCapacity(transaction.travellingAmount);
            if (aircrafts.Count() == 0)
            {
                Console.WriteLine("\nSorry, we currently do not have an aircraft that can cater the number of\n " +
                    "people you want to travel with. Press any key to return to main menu");
                Console.ReadLine();
            }
            else
            {
                int index = 0;
                foreach (var aircraft in aircrafts)
                {
                    Console.WriteLine((index + 1) + ": ");
                    Console.WriteLine(aircraft.ToString());
                    index++;
                }
                Console.WriteLine("Please select an aircraft you want to book(1^" + aircrafts.Count() + "): ");
                int selectedIndex = Convert.ToInt32(Console.ReadLine());
                while (!(selectedIndex >= 1 && selectedIndex <= aircrafts.Count()))
                {
                    Console.WriteLine("Invalid Input! ");
                    Console.WriteLine("Enter again: ");
                    selectedIndex = Convert.ToInt32(Console.ReadLine());
                }
                transaction.aircraft = aircrafts[selectedIndex - 1];
                if (aircrafts[selectedIndex - 1].crewFlight > 1)
                {
                    Console.WriteLine("Do you want to book addition flight crew? Following are the costs\n" +
                        "of booking additional flight crew: \n\n");

                    Console.WriteLine(PersonnelCostDBHandler.GetPersonnelByRole("Captain"));
                    Console.WriteLine(PersonnelCostDBHandler.GetPersonnelByRole("First Officer"));
                    Console.WriteLine("Enter index of Flight Crew(1^2) (0 for no): ");
                    int crewIndex = Convert.ToInt32(Console.ReadLine());
                    while (!(crewIndex >= 0 && crewIndex <= 2))
                    {
                        Console.WriteLine("Invalid Input! ");
                        Console.WriteLine("Enter again: ");
                        crewIndex = Convert.ToInt32(Console.ReadLine());
                    }
                    if (crewIndex == 1)
                    {
                        transaction.extraCaptain = true;
                    }
                    else
                    {
                        transaction.extraOfficer = true;
                    }
                    if (aircrafts[selectedIndex - 1].cabin > 1)
                    {
                        Console.WriteLine("Do you want to book addition flight attendant? Following is the cost\n" +
                        "of booking additional flight attendant: \n\n");

                        Console.WriteLine(PersonnelCostDBHandler.GetPersonnelByRole("Flight Attendant (Cabin)"));
                        Console.WriteLine("Enter y for yes else for no: ");
                        if (Console.ReadLine() == "y")
                        {
                            transaction.extraCabin = true;
                        }
                    }
                }
            }
            bottomBar();
            sendContract(transaction);
        }

        public static void charterOp2()
        {
            CharterTransactionStops transaction = new CharterTransactionStops();
            Customer customer = enquireDetails();
            customer.transactionType = 2;
            Console.Clear();
            transaction.customer = customer;
            topBar();
            Console.Write("            Please Enter Departure Place: ");
            transaction.departurePlace = Console.ReadLine();
            Console.Write("\n         Please Enter Destionation Place: ");
            transaction.destinationPlace = Console.ReadLine();
            Console.Write("\n            Please Enter Number of Stops: ");
            transaction.stopovers = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n      Please Enter Length of Stay (DAYS): ");
            transaction.lengthOfStay = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nPlease Enter Departure Date (YYYY-MM-DD): ");
            transaction.departureDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("\nPlease Enter Number of People Travelling: ");
            transaction.travellingAmount = Convert.ToInt32(Console.ReadLine());
            List<Aircraft> aircrafts = AircraftDBHandler.getAircraftsByCapacity(transaction.travellingAmount);
            if (aircrafts.Count() == 0)
            {
                Console.WriteLine("\nSorry, we currently do not have an aircraft that can cater the number of\n " +
                    "people you want to travel with. Press any key to return to main menu");
                Console.ReadLine();
            }
            else
            {
                int index = 0;
                foreach (var aircraft in aircrafts)
                {
                    Console.WriteLine((index + 1) + ": ");
                    Console.WriteLine(aircraft.ToString());
                    index++;
                }
                Console.WriteLine("Please select an aircraft you want to book(1^" + aircrafts.Count() + "): ");
                int selectedIndex = Convert.ToInt32(Console.ReadLine());
                while (!(selectedIndex >= 1 && selectedIndex <= aircrafts.Count()))
                {
                    Console.WriteLine("Invalid Input! ");
                    Console.WriteLine("Enter again: ");
                    selectedIndex = Convert.ToInt32(Console.ReadLine());
                }
                transaction.aircraft = aircrafts[selectedIndex - 1];
                if (aircrafts[selectedIndex - 1].crewFlight > 1)
                {
                    Console.WriteLine("Do you want to book addition flight crew? Following are the costs\n" +
                        "of booking additional flight crew: \n\n");

                    Console.WriteLine(PersonnelCostDBHandler.GetPersonnelByRole("Captain"));
                    Console.WriteLine(PersonnelCostDBHandler.GetPersonnelByRole("First Officer"));
                    Console.WriteLine("Enter index of Flight Crew(1^2) (0 for no): ");
                    int crewIndex = Convert.ToInt32(Console.ReadLine());
                    while (!(crewIndex >= 0 && crewIndex <= 2))
                    {
                        Console.WriteLine("Invalid Input! ");
                        Console.WriteLine("Enter again: ");
                        crewIndex = Convert.ToInt32(Console.ReadLine());
                    }
                    if (crewIndex == 1)
                    {
                        transaction.extraCaptain = true;
                    }
                    else
                    {
                        transaction.extraOfficer = true;
                    }
                    if (aircrafts[selectedIndex - 1].cabin > 1)
                    {
                        Console.WriteLine("Do you want to book addition flight attendant? Following is the cost\n" +
                        "of booking additional flight attendant: \n\n");

                        Console.WriteLine(PersonnelCostDBHandler.GetPersonnelByRole("Flight Attendant (Cabin)"));
                        Console.WriteLine("Enter y for yes else for no: ");
                        if (Console.ReadLine() == "y")
                        {
                            transaction.extraCabin = true;
                        }
                    }
                }
            }
            bottomBar();
            sendContract(transaction);
        }

        public static void charterOp3()
        {
            CharterTransactionDuration transaction = new CharterTransactionDuration();
            Customer customer = enquireDetails();
            customer.transactionType = 3;
            Console.Clear();
            transaction.customer = customer;
            topBar();
            Console.Write("Please Enter Duration of Booking (DAYS): ");
            transaction.charterDuration = Convert.ToInt32(Console.ReadLine());
            List<Aircraft> aircrafts = AircraftDBHandler.getAllAircrafts();
            int index = 0;
            foreach (var aircraft in aircrafts)
            {
                Console.WriteLine((index + 1) + ": ");
                Console.WriteLine(aircraft.ToString());
                index++;
            }
            Console.WriteLine("Please select an aircraft you want to book(1^" + aircrafts.Count() + "): ");
            int selectedIndex = Convert.ToInt32(Console.ReadLine());
            while (!(selectedIndex >= 1 && selectedIndex <= aircrafts.Count()))
            {
                Console.WriteLine("Invalid Input! ");
                Console.WriteLine("Enter again: ");
                selectedIndex = Convert.ToInt32(Console.ReadLine());
            }
            transaction.aircraft = aircrafts[selectedIndex - 1];
            if (aircrafts[selectedIndex - 1].crewFlight > 1)
            {
                Console.WriteLine("Do you want to book addition flight crew? Following are the costs\n" +
                    "of booking additional flight crew: \n\n");

                Console.WriteLine(PersonnelCostDBHandler.GetPersonnelByRole("Captain"));
                Console.WriteLine(PersonnelCostDBHandler.GetPersonnelByRole("First Officer"));
                Console.WriteLine("Enter index of Flight Crew(1^2) (0 for no): ");
                int crewIndex = Convert.ToInt32(Console.ReadLine());
                while (!(crewIndex >= 0 && crewIndex <= 2))
                {
                    Console.WriteLine("Invalid Input! ");
                    Console.WriteLine("Enter again: ");
                    crewIndex = Convert.ToInt32(Console.ReadLine());
                }
                if (crewIndex == 1)
                {
                    transaction.extraCaptain = true;
                }
                else
                {
                    transaction.extraOfficer = true;
                }
                if (aircrafts[selectedIndex - 1].cabin > 1)
                {
                    Console.WriteLine("Do you want to book addition flight attendant? Following is the cost\n" +
                    "of booking additional flight attendant: \n\n");

                    Console.WriteLine(PersonnelCostDBHandler.GetPersonnelByRole("Flight Attendant (Cabin)"));
                    Console.WriteLine("Enter y for yes else for no: ");
                    if (Console.ReadLine() == "y")
                    {
                        transaction.extraCabin = true;
                    }
                }
            }
            bottomBar();
            sendContract(transaction);
        }


        public static void sendContract(CharterTransaction transaction) {
            Console.Clear();
            topBar();
            Console.WriteLine("Your Receipt: \n\n");
            Console.WriteLine(transaction.ToString());
            bottomBar();
            Console.WriteLine("Enter Y to accept, N to reject");
            String choice = Console.ReadLine();
            while (choice != "Y" && choice != "N") {
                Console.WriteLine("Invalid Input! ");
                Console.WriteLine("Enter again: ");
                choice = Console.ReadLine();
            }
            if (choice == "Y")
            {
                Console.WriteLine("Generating PDF...");
                PDF.generatePDF(transaction);
                Console.WriteLine("Sending Email...");
                SMTP.mailTo(transaction.customer.email, "JET RENTAL CONTRACT", "PFA");
                AircraftDBHandler.decQuantity(transaction.aircraft.id);
                Console.WriteLine("Your contract has been emailed to specified email.");
            }
            else {
                Console.WriteLine("Please give a reason for rejecting: ");
                Console.ReadLine();
                Console.WriteLine("Thanks for sharing your opinion.");
            }
            Console.WriteLine("Press Enter to return to main menu");
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
                    Console.Clear();
                    charterOp1();
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    charterOp2();
                }
                else if (choice == "3")
                {
                    Console.Clear();
                    charterOp3();
                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
                }
                Console.Clear();
            } while (choice != "0");
        }
    }
}
