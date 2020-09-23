using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Orange : Soda
    {
        //Member Variables

        //Constructor
        public Orange()
        {
            sodaCost = .06;
            sodaName = "Orange";
            sodaType = "Orange";
        }
        //Methods
        public override Soda GetSodaType(string sodaType)
        {
            return new Orange();
        }
    }
}
