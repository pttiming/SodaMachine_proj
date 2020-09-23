using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    abstract class Coin : PaymentMethod
    {
        //Member Variables
        protected double value;

        //Properties
        public double Value
        {
            get
            {
                return value;
            }
        }

        //Constructor
        public Coin()
        {

        }

        //Methods
    }
}
