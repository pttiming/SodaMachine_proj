using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Nickel : Coin
    {
        //Member Variables

        //Constructor
        public Nickel()
        {
            value = .05;
            name = "Nickel";
        }
        //Methods
        public override Coin GetCoinName(string coinType)
        {
            return new Nickel();
        }
    }
}
