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

        //Constructor
        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
        }

        //Methods
    }
}
