﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Cola : Soda
    {
        //Member Variables

        //Constructor
        public Cola()
        {
            sodaCost = .35;
            sodaName = "Cola";
            sodaType = "Cola";
        }

        //Methods
        public override Soda GetSodaType(string sodaType)
        {
            return new Cola();
        }
    }
}
