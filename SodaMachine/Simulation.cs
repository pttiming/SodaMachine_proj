using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Simulation
    {
        //Member Variables
        public SodaMachine sodaMachine;
        public Customer customer;

        //Constuctor
        public Simulation()
        {
            sodaMachine = new SodaMachine(20, 10, 20, 50, 5, 1, 1);
            customer = new Customer();

        }

        //Methods
        public void RunSimulation()
        {
            UserInterface.DisplayMessage("Welcome to the Soda Machine");
            Cola testCola = new Cola();
            Orange testOrange = new Orange();

            if (sodaMachine.CheckInventory(testCola))
            {
                Console.WriteLine("Cola True");
            }
            else
            {
                Console.WriteLine("Cola False");
            }

            if (sodaMachine.CheckInventory(testOrange))
            {
                Console.WriteLine("Orange True");
            }
            else
            {
                Console.WriteLine("Orange False");
            }
            

            Console.ReadLine();

        }
    }
}
