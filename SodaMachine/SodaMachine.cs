using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        //Member Variables
        List<Coin> register;
        List<Coin> payment;
        List<Coin> potentialRegister;
        public List<Can> inventory;
        int initialColaInventory;
        int initialOrangeInventory;
        int initialRootBeerInventory;
        int initialQuartersInRegister;
        int initialDimesInRegister;
        int initialNickelsInRegister;
        int initialPenniesInRegister;
        Quarter quarter;
        Dime dime;
        Nickel nickel;
        Penny penny;
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
            quarter = new Quarter();
            dime = new Dime();
            nickel = new Nickel();
            penny = new Penny();


            StockCan<Cola>(initialColaInventory);
            StockCan<RootBeer>(initialRootBeerInventory);
            StockCan<Orange>(initialOrangeInventory);
            DepositCoinToRegister<Quarter>(initialQuartersInRegister);
            DepositCoinToRegister<Dime>(initialDimesInRegister);
            DepositCoinToRegister<Nickel>(initialNickelsInRegister);
            DepositCoinToRegister<Penny>(initialPenniesInRegister);


        }

        //Methods

        //Generic Method to add Initial Coins to Register
        public void DepositCoinToRegister<T>(int count) where T : Coin, new()
        {
            T coin;

            for (int i = 0; i < count; i++)
            {
                coin = new T();
                register.Add(coin);
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
            inventory.Remove(can);
            customer.backpack.AddCanToBackpack(can);
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
            return paymentValue;
        }
        //Checks to see if Transaction Can Continue based on Scenarios from User Stories
        public void CheckTransaction(Can can, Customer customer)
        {
            if (CheckInventory(can))
            {
                if (PaymentValue() == can.SodaCost)
                {
                    DistributeCan(can, customer);
                    DepositPaymentInRegister();
                }
                else if (PaymentValue() < can.SodaCost)
                {
                    UserInterface.DisplayMessage("Insufficent Funds Deposited, Come back when you can afford it");
                    ReturnCoinsToWallet(customer);
                }
                else if (PaymentValue() > can.SodaCost && SufficientChangeExists(can, customer))
                {
                    DistributeCan(can, customer);
                    DepositPaymentInRegister();
                    GiveChange(can, customer);

                }
            }
            else
            {
                UserInterface.DisplayMessage("Item of stock");
                ReturnCoinsToWallet(customer);
            }
            
            
        }
        //Redeposits Coins to Wallet in case of failed transaction
        public void ReturnCoinsToWallet(Customer customer)
        {
            foreach(Coin coin in payment)
            {
                customer.wallet.coins.Add(coin);
                payment.Remove(coin);

            }
        }
        //Checks to see if there is enough change in Soda Machine Register to Issue necessary change to Customer
        public bool SufficientChangeExists(Can can, Customer customer)
        {
            if (Change.ChangeNeeded(can.SodaCost, PaymentValue()) > 0  && CorrectChangeAvailable())
            {
                return true;
            }
            return false;
        }
        //Checks to make sure the machine has the right coin counts to issue the exact amount of necessary change
        public bool CorrectChangeAvailable()
        {
            if (0 == 0)
            {
                return true;
            }
            return false;
        }
        //Issues Change to Customer
        public void GiveChange(Can can, Customer customer)
        {

        }
        //Checks to see if the can exists in inventory
        public bool CheckInventory(Can can)
        {
            Can desiredCan = inventory.Find(delegate (Can c) { return c.SodaType == can.SodaType; });
            if(desiredCan != null)
            {
                return true;
            }
            return false;
            
        }
        //Gets the index of the first can that matches the desired can in inventory
        public int GetDesiredCanID(Can can)
        {
            int canID;

            canID = inventory.FindIndex(delegate (Can c) { return c.SodaType == can.SodaType; });

            return canID;
        }
        //Gets Can object of matching desired can
        public Can GetDesiredCan(Can can)
        {
            Can desiredCan = inventory.Find(delegate(Can can1) { return can1.SodaType == can.SodaType; });
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
        public void AddCoinToPayment(Coin coin)
        {
            if (maxPrice > PaymentValue())
            {
                payment.Add(coin);
            }
            UserInterface.DisplayMessage("Current amount deposited meets or exceeds max item price.  Please select desired item");
        }

    }
}
