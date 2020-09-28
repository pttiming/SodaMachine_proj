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
        public static void MainMenu(Customer customer, SodaMachine sodaMachine)
        {
            sodaMachine.RegisterValue();
            Console.WriteLine("1. Make a Purchase");
            Console.WriteLine("2. View Wallet Contents");
            Console.WriteLine("3. View Backpack Contents");
            Console.WriteLine("4. Leave the Soda Machine");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    sodaMachine.HighestPrice();
                    MenuTwo(customer, sodaMachine);
                    break;
                case "2":
                    Console.Clear();
                    DisplayWalletContents(customer, sodaMachine);
                    break;
                case "3":
                    Console.Clear();
                    DisplayBackpackContents(customer, sodaMachine);
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Response, Please try again");
                    Console.WriteLine();
                    MainMenu(customer, sodaMachine);
                    break;
            }

        }
        public static void DisplayBackpackContents(Customer customer, SodaMachine sodaMachine)
        {
            if(customer.backpack.cans == null)
            {
                Console.Clear();
                Console.WriteLine("Backpack is Currently Empty");
                MainMenu(customer, sodaMachine);
            }
            else
            {
                Console.WriteLine("Backpack Contains");
                Console.WriteLine($"{customer.ColaCount} Cola Cans");
                Console.WriteLine($"{customer.OrangeCount} Orange Cans");
                Console.WriteLine($"{customer.RootbeerCount} Root Beer Cans");
                Console.WriteLine("");
                MainMenu(customer, sodaMachine);
            }
        }
        public static void DisplayAvailableCans(Customer customer, SodaMachine sodaMachine)
        {
            Console.WriteLine("Which item would you like to purchase?");
            Console.WriteLine();
            Console.WriteLine("1. Cola - $.35");
            Console.WriteLine("2. Orange - $.06");
            Console.WriteLine("3. Root Beer - $.60");
            Console.WriteLine("4. Return to Main Menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    sodaMachine.CheckTransaction(customer, "Cola", sodaMachine);
                    break;
                case "2":
                    sodaMachine.CheckTransaction(customer, "Orange", sodaMachine);
                    break;
                case "3":
                    sodaMachine.CheckTransaction(customer, "Root Beer", sodaMachine);
                    break;
                case "4":
                    MainMenu(customer, sodaMachine);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Response, Please try again");
                    Console.WriteLine();
                    DisplayAvailableCans(customer, sodaMachine);
                    break;
            }
        }
        public static void MenuTwo(Customer customer, SodaMachine sodaMachine)
        {
            Console.Clear();
            Console.WriteLine($"You have deposited ${sodaMachine.PaymentValue()}");
            Console.WriteLine("");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Make a Selection");
            Console.WriteLine("2. Deposit Additional Coins");
            Console.WriteLine("3. Return to Main Menu");
            Console.WriteLine("4. Leave Soda Machine");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    DisplayAvailableCans(customer, sodaMachine);
                    break;
                case "2":
                    Console.Clear();
                    customer.CheckWalletCoinCount();
                    DepositCoinsMenu(customer, sodaMachine);
                    break;
                case "3":
                    MainMenu(customer, sodaMachine);
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Response, Please try again");
                    Console.WriteLine();
                    MenuTwo(customer, sodaMachine);
                    break;

            }
        }
        public static void DepositCoinsMenu(Customer customer, SodaMachine sodaMachine)
        {
            Console.Clear();
            Console.WriteLine("Which Coin Type would you like to deposit?");
            Console.WriteLine("");
            Console.WriteLine($"1. Quarter: {customer.QuarterCount} available");
            Console.WriteLine($"2. Dime: {customer.DimeCount} available");
            Console.WriteLine($"3. Nickel: {customer.NickelCount} available");
            Console.WriteLine($"4. Penny: {customer.PennyCount} available");
            Console.WriteLine("5. Proceed to Selection Menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    if(customer.QuarterCount > 0)
                    {
                        sodaMachine.AddCoinToPayment(customer.GetDesiredCoin("Quarter"), customer, sodaMachine);
                        break;
                    }
                    else
                    {
                        UserInterface.DisplayMessage("You do not have any quarters, please try again");
                        DepositCoinsMenu(customer, sodaMachine);
                        break;
                    }
                    
                case "2":
                    if (customer.DimeCount > 0)
                    {
                        sodaMachine.AddCoinToPayment(customer.GetDesiredCoin("Dime"), customer, sodaMachine);
                        break;
                    }
                    else
                    {
                        UserInterface.DisplayMessage("You do not have any dimes, please try again");
                        DepositCoinsMenu(customer, sodaMachine);
                        break;
                    }
                case "3":
                    if (customer.NickelCount > 0)
                    {
                        sodaMachine.AddCoinToPayment(customer.GetDesiredCoin("Nickel"), customer, sodaMachine);
                        break;
                    }
                    else
                    {
                        UserInterface.DisplayMessage("You do not have any nickels, please try again");
                        DepositCoinsMenu(customer, sodaMachine);
                        break;
                    }
                case "4":
                    if (customer.PennyCount > 0)
                    {
                        sodaMachine.AddCoinToPayment(customer.GetDesiredCoin("Penny"), customer, sodaMachine);
                        break;
                    }
                    else
                    {
                        UserInterface.DisplayMessage("You do not have any pennies, please try again");
                        DepositCoinsMenu(customer, sodaMachine);
                        break;
                    }
                case "5":
                    DisplayAvailableCans(customer, sodaMachine);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Response, Please try again");
                    Console.WriteLine();
                    MenuTwo(customer, sodaMachine);
                    break;
            }
        }


        public static void DisplayWalletContents(Customer customer, SodaMachine sodaMachine)
        {
            Console.WriteLine($"You have ${customer.CheckWalletCoinValue()} in coins");
            customer.CheckWalletCoinCount();
            Console.WriteLine($"You have {customer.QuarterCount} Quarters");
            Console.WriteLine($"You have {customer.DimeCount} Dimes");
            Console.WriteLine($"You have {customer.NickelCount} Nickels");
            Console.WriteLine($"You have {customer.PennyCount} Pennies");
            Console.WriteLine("");
            MainMenu(customer, sodaMachine);
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
