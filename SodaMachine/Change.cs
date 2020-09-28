using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public static class Change
    {
        public static double ChangeNeeded(double payment, double cost)
        {
            double change = payment - cost;
            return change;
        }
    }
}
