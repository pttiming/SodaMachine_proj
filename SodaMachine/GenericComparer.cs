using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public class GenericComparer<T>
    {
        public bool Compare(T x, T y)
        {
            if (x.Equals(y))
            {
                return true;
            }
            return false;
        }

        

    }

    
}
