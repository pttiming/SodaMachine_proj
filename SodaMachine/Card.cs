using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Card : PaymentMethod
    {
        //Member Variables
        double availableFunds;

        //Properties
        public double AvailableFunds
        {
            get => availableFunds;
        }
        //Constructor
        public Card(double availableFunds)
        {
            this.availableFunds = availableFunds;

        }
        //Methods
        public void AddCharge(double charge)
        {
            availableFunds -= charge;
        }
        public void ReverseCharge(double charge)
        {
            availableFunds += charge;
        }
    }
}
