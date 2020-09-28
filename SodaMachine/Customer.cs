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
            wallet = new Wallet(10,10,9,8,7);
            backpack = new Backpack();
        }

        //Methods
    }
}
