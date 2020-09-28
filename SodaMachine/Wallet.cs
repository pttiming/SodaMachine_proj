using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        //Member Variables
        public List<Coin> coins;
        public Card card;
        int pennyCount;
        int nickelCount;
        int dimeCount;
        int quarterCount;

        //Constructor
        public Wallet(double cardValue, int pennyCount, int nickelCount, int dimeCount, int quarterCount)
        {
            this.pennyCount = pennyCount;
            this.nickelCount = nickelCount;
            this.dimeCount = dimeCount;
            this.quarterCount = quarterCount;
            coins = new List<Coin>();
            card = new Card(cardValue);
            PopulateCoinsInWallet<Quarter>(quarterCount);
            PopulateCoinsInWallet<Dime>(dimeCount);
            PopulateCoinsInWallet<Nickel>(nickelCount);
            PopulateCoinsInWallet<Penny>(pennyCount);

        }

        //Methods
        public void PopulateCoinsInWallet<T>(int count) where T : Coin, new()
        {
            T coin;
            for (int i = 0; i < count; i++)
            {
                coin = new T();
                coins.Add(coin);
            }


        }
    }
}
