using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    static class UserInterface
    {
        //Member Variables

        //Constructor

        //Methods
        public static void MainMenu(Customer customer)
        {
            Console.WriteLine("1. Make a Purchase");
            Console.WriteLine("2. View Wallet Contents");
            Console.WriteLine("3. View Backpack Contents");
            Console.WriteLine("4. Leave the Soda Machine");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    DepositCoinsMenu(customer);
                    break;
                case "2":
                    DisplayWalletContents(customer);
                    break;
                case "3":
                    DisplayBackpackContents(customer);
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Response, Please try again");
                    Console.WriteLine();
                    MainMenu(customer);
                    break;





            }

        }
        public static void DisplayBackpackContents(Customer customer)
        {

        }
        public static void DisplayAvailableSoda()
        {
            
        }
        public static void DepositCoinsMenu(Customer customer)
        {

        }


        public static void DisplayWalletContents(Customer customer)
        {
            Console.WriteLine($"You have ${customer.CheckWalletCoinValue()} in coins");
            customer.CheckWalletCoinCount();
            Console.WriteLine($"You have {customer.QuarterCount} Quarters");
            Console.WriteLine($"You have {customer.DimeCount} Dimes");
            Console.WriteLine($"You have {customer.NickelCount} Nickels");
            Console.WriteLine($"You have {customer.PennyCount} Pennies");
        }


        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void InsufficientInventory()
        {
            Console.WriteLine("Sorry!  Your selection is out of stock.");
        }

    }
}
