using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Quarter : Coin
    {
        //Member Variables

        //Constructor
        public Quarter()
        {
            value = .25;
            name = "Quarter";
        }
        //Methods
        public override Coin GetCoinName(string coinType)
        {
            return new Quarter();
        }
    }
}
