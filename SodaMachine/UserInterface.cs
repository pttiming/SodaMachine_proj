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
        public static void DisplayAvailableSoda()
        {
            
        }
        public static void DisplayPaymentMenu()
        {

        }

        public static void DisplayBagContents()
        {

        }

        public static void DisplayWalletContents(Customer customer)
        {
            foreach(Coin coin in customer.wallet.coins)
            {

            }
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
