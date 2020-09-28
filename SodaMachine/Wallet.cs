using System;
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
        Quarter quarter;
        Dime dime;
        Nickel nickel;
        Penny penny;
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
            quarter = new Quarter();
            dime = new Dime();
            nickel = new Nickel();
            penny = new Penny();

        }

        //Methods
        public void PopulateCoinsInWallet()
        {
            
        }
    }
}
