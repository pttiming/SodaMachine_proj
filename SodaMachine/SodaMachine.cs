using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        //Member Variables
        List<Coin> register;
        List<Coin> payment;
        List<Coin> change;
        public List<Can> inventory;
        int initialColaInventory;
        int initialOrangeInventory;
        int initialRootBeerInventory;
        int initialQuartersInRegister;
        int initialDimesInRegister;
        int initialNickelsInRegister;
        int initialPenniesInRegister;

        double maxPrice;


        //Constructor
        public SodaMachine(int initialQuartersInRegister, int initialDimesInRegister, int initialNickelsInRegister, int initialPenniesInRegister, int initialColaInventory, int initialRootBeerInventory, int initialOrangeInventory)
        {
            this.initialColaInventory = initialColaInventory;
            this.initialOrangeInventory = initialOrangeInventory;
            this.initialRootBeerInventory = initialRootBeerInventory;
            this.initialQuartersInRegister = initialQuartersInRegister;
            this.initialDimesInRegister = initialDimesInRegister;
            this.initialNickelsInRegister = initialNickelsInRegister;
            this.initialPenniesInRegister = initialPenniesInRegister;
            register = new List<Coin>();
            payment = new List<Coin>();
            inventory = new List<Can>();
            change = new List<Coin>();


            StockCan<Cola>(initialColaInventory);
            StockCan<RootBeer>(initialRootBeerInventory);
            StockCan<Orange>(initialOrangeInventory);
            DepositCoinToList<Quarter>(initialQuartersInRegister, register);
            DepositCoinToList<Dime>(initialDimesInRegister, register);
            DepositCoinToList<Nickel>(initialNickelsInRegister, register);
            DepositCoinToList<Penny>(initialPenniesInRegister, register);


        }

        //Methods

        //Generic Method to add Initial Coins to Register
        public void DepositCoinToList<T>(int count, List<Coin> list) where T : Coin, new()
        {
            T coin;

            for (int i = 0; i < count; i++)
            {
                coin = new T();
                list.Add(coin);
            }
        }
        //Generic Method to add Cans to Inventory
        public void StockCan<T>(int count) where T : Can, new()
        {
            T can;

            for (int i = 0; i < count; i++)
            {

                can = new T();
                inventory.Add(can);

                // sodaInventory.Add(sodaToAdd);
            }
        }

        //Dispenses Can from Soda Machine to Backpack
        public void DistributeCan(Can can, Customer customer)
        {
            customer.backpack.AddCanToBackpack(can);
            inventory.Remove(can);
        }
        //Adds payment amount to Register
        public void DepositPaymentInRegister()
        {
            foreach(Coin coin in payment)
            {
                register.Add(coin);
                
            }
            payment.Clear();
        }
        //Calculates the Value of the Coins in the Register
        public void RegisterValue()
        {
            double registerValue = 0;
            foreach(Coin coin in register)
            {
                registerValue += coin.Value;
            }
            registerValue = Math.Round(registerValue, 2);
            Console.WriteLine(registerValue);
        }
        //Calculates Value of Coins Paid in
        public double PaymentValue()
        {
            double paymentValue = 0;
            foreach (Coin coin in payment)
            {
                paymentValue += coin.Value;
            }
            return Math.Round(paymentValue,2);
        }
        //Checks to see if Transaction Can Continue based on Scenarios from User Stories
        public void CheckTransaction(Customer customer, string canName, SodaMachine sodaMachine)
        {
            if (CheckInventory(canName))
            {
                Can desiredCan = GetDesiredCan(canName);
                if (PaymentValue() == desiredCan.SodaCost)
                {
                    DistributeCan(desiredCan, customer);
                    customer.CheckBackpackStock();
                    DepositPaymentInRegister();
                    UserInterface.MainMenu(customer, sodaMachine);
                }
                else if (PaymentValue() < desiredCan.SodaCost)
                {
                    UserInterface.DisplayMessage("Insufficent Funds Deposited, Come back when you can afford it");
                    ReturnCoinsToWallet(customer);
                    UserInterface.MainMenu(customer, sodaMachine);
                }
                else if (PaymentValue() > desiredCan.SodaCost && SufficientChangeExists(desiredCan, customer))
                {
                    DistributeCan(desiredCan, customer);
                    customer.CheckBackpackStock();
                    DepositPaymentInRegister();
                    GiveChange(desiredCan, customer);
                    UserInterface.MainMenu(customer, sodaMachine);

                }
            }
            else
            {
                UserInterface.DisplayMessage("Item of stock");
                ReturnCoinsToWallet(customer);
                UserInterface.MainMenu(customer, sodaMachine);
            }
            
            
        }
        
        //Redeposits Coins to Wallet in case of failed transaction
        public void ReturnCoinsToWallet(Customer customer)
        {
            foreach(Coin coin in payment)
            {
                customer.wallet.coins.Add(coin);
            }
            payment.Clear();
        }
        //Checks to see if there is enough change in Soda Machine Register to Issue necessary change to Customer
        public bool SufficientChangeExists(Can can, Customer customer)
        {
            if (CorrectChangeAvailable(can, customer))
            {
                return true;
            }
            return false;
        }
        //Checks to make sure the machine has the right coin counts to issue the exact amount of necessary change
        public bool CorrectChangeAvailable(Can can, Customer customer)
        {
            double cost = can.SodaCost;
            double changeDue = PaymentValue() - cost;
            List<Coin> registerPlusPayment = new List<Coin>();
            registerPlusPayment.AddRange(register);
            registerPlusPayment.AddRange(payment);
            int quarterAvailable = registerPlusPayment.OfType<Quarter>().Count();
            int dimeAvailable = registerPlusPayment.OfType<Dime>().Count();
            int nickelAvailable = registerPlusPayment.OfType<Nickel>().Count();
            int pennyAvailable = registerPlusPayment.OfType<Penny>().Count();
            int quarterNeeded = 0;
            int dimeNeeded = 0;
            int nickelNeeded = 0;
            int pennyNeeded = 0;

            while (changeDue > .24 && quarterAvailable > 0)
            {
                changeDue = Math.Round(changeDue, 2);
                changeDue -= .25;
                quarterAvailable--;
                quarterNeeded++;
            }
            while (changeDue > .09 && dimeAvailable > 0)
            {
                changeDue = Math.Round(changeDue, 2);
                changeDue -= .10;
                dimeAvailable--;
                dimeNeeded++;
            }
            while (changeDue > .04 && nickelAvailable > 0)
            {
                changeDue = Math.Round(changeDue, 2);
                changeDue -= .05;
                nickelAvailable--;
                nickelNeeded++;
            }
            while (changeDue > .00 && pennyAvailable > 0)
            {
                changeDue = Math.Round(changeDue, 2);
                changeDue -= .01;
                pennyAvailable--;
                pennyNeeded++;
            }
            changeDue = Math.Round(changeDue, 2);

            DepositCoinToList<Quarter>(quarterNeeded, change);
            DepositCoinToList<Dime>(dimeNeeded, change);
            DepositCoinToList<Nickel>(nickelNeeded, change); 
            DepositCoinToList<Penny>(pennyNeeded, change);
            
            if (changeDue == 0)
            {
                return true;
            }
            return false;
        }

        public void CorrectChangeCalculation(Can can, Customer customer)
        {
            double cost = can.SodaCost;
            double changeDue = PaymentValue() - cost;
            List<Coin> registerPlusPayment = new List<Coin>();
            registerPlusPayment.AddRange(register);
            registerPlusPayment.AddRange(payment);
            int quarterAvailable = registerPlusPayment.OfType<Quarter>().Count();
            int dimeAvailable = registerPlusPayment.OfType<Dime>().Count();
            int nickelAvailable = registerPlusPayment.OfType<Nickel>().Count();
            int pennyAvailable = registerPlusPayment.OfType<Penny>().Count();
            int quarterNeeded = 0;
            int dimeNeeded = 0;
            int nickelNeeded = 0;
            int pennyNeeded = 0;

            while (changeDue > .24 && quarterAvailable > 0)
            {
                changeDue = Math.Round(changeDue, 2);
                changeDue -= .25;
                quarterAvailable--;
                quarterNeeded++;
            }
            while (changeDue > .09 && dimeAvailable > 0)
            {
                changeDue = Math.Round(changeDue, 2);
                changeDue -= .10;
                dimeAvailable--;
                dimeNeeded++;
            }
            while (changeDue > .04 && nickelAvailable > 0)
            {
                changeDue = Math.Round(changeDue, 2);
                changeDue -= .05;
                nickelAvailable--;
                nickelNeeded++;
            }
            while (changeDue > .00 && pennyAvailable > 0)
            {
                changeDue = Math.Round(changeDue, 2);
                changeDue -= .01;
                pennyAvailable--;
                pennyNeeded++;
            }
            changeDue = Math.Round(changeDue, 2);

            DepositCoinToList<Quarter>(quarterNeeded, change);
            DepositCoinToList<Dime>(dimeNeeded, change);
            DepositCoinToList<Nickel>(nickelNeeded, change);
            DepositCoinToList<Penny>(pennyNeeded, change);
        }
        //Issues Change to Customer
        public void GiveChange(Can can, Customer customer)
        {
            customer.wallet.coins.AddRange(change);
            foreach(Coin coin in change)
            {
                register.Remove(coin);
            }
            change.Clear();

        }
        //Checks to see if the can exists in inventory
        public bool CheckInventory(string canName)
        {
            Can desiredCan = inventory.Find(delegate (Can c) { return c.sodaName == canName; });
            if(desiredCan != null)
            {
                return true;
            }
            return false;
            
        }
        //Gets the index of the first can that matches the desired can in inventory
        public int GetDesiredCanID(string canType)
        {
            int canID;

            canID = inventory.FindIndex(delegate (Can c) { return c.SodaType == canType; });

            return canID;
        }
        //Gets Can object of matching desired can
        public Can GetDesiredCan(string canName)
        {
            Can desiredCan = inventory.Find(delegate(Can can1) { return can1.sodaName == canName; });
            return desiredCan;
        }
        //Calculates the Highest Price of any item in inventory
        public void HighestPrice()
        {
            if(inventory.Count == 0)
            {
                UserInterface.DisplayMessage("Soda Machine is Empty.  Please Come Again");
            }
            else
            {
                maxPrice = .00;
                foreach(Can can in inventory)
                {
                    if(can.SodaCost > maxPrice)
                    {
                        maxPrice = can.SodaCost;
                    }
                }
            }
        }
        //Takes a coin from wallet and puts it into the temporary payment list
        public void AddCoinToPayment(Coin coin, Customer customer, SodaMachine sodaMachine)
        {
            if (maxPrice > PaymentValue())
            {
                payment.Add(coin);
                customer.wallet.coins.Remove(coin);
                
            }
            else
            {
                UserInterface.DisplayMessage("Current amount deposited meets or exceeds max item price.  Please select desired item");
                UserInterface.DisplayAvailableCans(customer, sodaMachine);
            }
            UserInterface.MenuTwo(customer, sodaMachine);
            

        }

    }
}
