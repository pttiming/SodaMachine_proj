using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public abstract class Can
    {
        //Member Variables
        public string sodaName;
        protected double sodaCost;
        protected string sodaType;

        //Properties
        public double SodaCost
        {
            get => sodaCost;
        }

        public string SodaType
        {
            get => sodaType;
        }


        //Constructor
        public Can()
        {

        }
        //Methods
        public abstract Can GetSodaType(string sodaType);
    }
}
