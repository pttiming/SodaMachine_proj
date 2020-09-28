using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        //Member Variables
        public Wallet wallet;
        public Backpack backpack;
        int quarterCount;
        int dimeCount;
        int nickelCount;
        int pennyCount;

        public int QuarterCount
        {
            get
            {
                return quarterCount;
            }
        }

        public int DimeCount
        {
            get
            {
                return dimeCount;
            }
        }

        public int NickelCount
        {
            get
            {
                return nickelCount;
            }
        }

        public int PennyCount
        {
            get
            {
                return pennyCount;
            }
        }

        //Constructor
        public Customer()
        {
            wallet = new Wallet(10,10,9,8,7);
            backpack = new Backpack();
        }

        //Methods
        public double CheckWalletCoinValue()
        {
            double walletCoinValue = 0;
            foreach (Coin coin in wallet.coins)
            {
                walletCoinValue += coin.Value;
            }
            walletCoinValue = Math.Round(walletCoinValue, 2);
            return walletCoinValue;
        }
        public void CheckWalletCoinCount()
        {
            quarterCount = wallet.coins.OfType<Quarter>().Count();
            dimeCount = wallet.coins.OfType<Dime>().Count();
            nickelCount = wallet.coins.OfType<Nickel>().Count();
            pennyCount = wallet.coins.OfType<Penny>().Count();
        }
    }
}
