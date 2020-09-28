using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Dime : Coin
    {
        //Member Variables

        //Constructor
        public Dime()
        {
            value = .10;
            name = "Dime";
        }

        //Methods
        public override Coin GetCoinName(string coinType)
        {
            return new Dime();
        }
    }
}
