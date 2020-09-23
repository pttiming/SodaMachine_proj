using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public class RootBeer : Soda
    {
        //Member Variables

        //Constructor
        public RootBeer()
        {
            sodaCost = .60;
            sodaName = "Root Beer";
            sodaType = "RootBeer";
        }
        //Methods
        public override Soda GetSodaType(string sodaType)
        {
            return new RootBeer();
        }
    }
}
