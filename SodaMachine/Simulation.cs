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
            sodaMachine = new SodaMachine(20, 10, 20, 50, 5, 6, 7);
            customer = new Customer();

        }

        //Methods
        public void RunSimulation()
        {
            UserInterface.DisplayMessage("Welcome to the Soda Machine");

            sodaMachine.ListInventory();



            Console.ReadLine();

        }
    }
}
