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
            sodaMachine = new SodaMachine(1, 1, 1, 1, 5, 5, 10);
            customer = new Customer();

        }

        //Methods
        public void RunSimulation()
        {
            UserInterface.DisplayMessage("Welcome to the Soda Machine");
            UserInterface.DisplayMessage("What would you like to do?");
            UserInterface.MainMenu(customer, sodaMachine);
            Console.ReadLine();

        }
    }
}
