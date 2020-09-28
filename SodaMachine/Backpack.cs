using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Backpack
    {
        //Member Variables
        public List<Can> cans;

        //Constructor
        public Backpack()
        {
            cans = new List<Can>();
        }

        //Methods
        public void AddCanToBackpack(Can can)
        {
            cans.Add(can);
        }
    }
}
