using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Machine machine = new Machine(20, 20, 20, 20, 5, 4, 3);
            machine.ListInventory();
            Console.ReadLine();
        }
    }
}
