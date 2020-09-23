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
        //Reduces available funds once a charge is completed
        public void AddCharge(double charge)
        {
            availableFunds -= charge;
        }
        //Restores available funds due to a return or failed transaction
        public void ReverseCharge(double charge)
        {
            availableFunds += charge;
        }
        public bool CheckFunds(double charge)
        {
            if(availableFunds >= charge)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
