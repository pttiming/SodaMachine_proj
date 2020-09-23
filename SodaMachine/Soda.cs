using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public abstract class Soda
    {
        //Member Variables
        protected string sodaName;
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
        public Soda()
        {

        }
        //Methods
        public abstract Soda GetSodaType(string sodaName);
    }
}
