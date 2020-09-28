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
        int colaCount;
        int orangeCount;
        int rootbeerCount;

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
        public int RootbeerCount
        {
            get
            {
                return rootbeerCount;
            }
        }

        public int OrangeCount
        {
            get
            {
                return orangeCount;
            }
        }

        public int ColaCount
        {
            get
            {
                return colaCount;
            }
        }

        //Constructor
        public Customer()
        {
            wallet = new Wallet(5,50,20,20,10);
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
        public void CheckBackpackStock()
        {
            colaCount = backpack.cans.OfType<Cola>().Count();
            orangeCount = backpack.cans.OfType<Orange>().Count();
            rootbeerCount = backpack.cans.OfType<RootBeer>().Count();
            
        }
        //Gets Can object of matching desired can
        public Coin GetDesiredCoin(string coinType)
        {
            Coin desiredCoin = wallet.coins.Find(delegate (Coin coin1) { return coin1.name == coinType; });
            return desiredCoin;
        }
    }
}
