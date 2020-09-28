using System;
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
        List<Can> offerings;
        public List<Can> inventory;
        int initialColaInventory;
        int initialOrangeInventory;
        int initialRootBeerInventory;
        int initialQuartersInRegister;
        int initialDimesInRegister;
        int initialNickelsInRegister;
        int initialPenniesInRegister;
        public Cola cola;
        public Orange orange;
        public RootBeer rootbeer;
        Quarter quarter;
        Dime dime;
        Nickel nickel;
        Penny penny;


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
            offerings = new List<Can>();
            cola = new Cola();
            orange = new Orange();
            rootbeer = new RootBeer();
            quarter = new Quarter();
            dime = new Dime();
            nickel = new Nickel();
            penny = new Penny();


            InitialSodaInventory(initialColaInventory, cola, "Cola");
            InitialSodaInventory(initialRootBeerInventory, rootbeer, "RootBeer");
            InitialSodaInventory(initialOrangeInventory, orange, "Orange");
            DepositCoinToRegister(initialQuartersInRegister, quarter, "Quarter");
            DepositCoinToRegister(initialDimesInRegister, dime, "Dime");
            DepositCoinToRegister(initialNickelsInRegister, nickel, "Nickel");
            DepositCoinToRegister(initialPenniesInRegister, penny, "Penny");
            offerings.Add(cola);
            offerings.Add(orange);
            offerings.Add(rootbeer);


        }

        //Methods

        // consider "generic constraints"
        public void DepositCoinToRegister(int count, Coin coin, string coinName)
        {
            Coin newcoin;

            for (int i = 0; i < count; i++)
            {
                newcoin = coin.GetCoinName(coinName);
                register.Add(newcoin);
            }
        }
        public void InitialSodaInventory(int inventorycount,Can soda, string sodaType )
        {
            Can newsoda;

            for (int i = 0; i < inventorycount; i++)
            {
              
                newsoda = soda.GetSodaType(sodaType);
                inventory.Add(newsoda);

                // sodaInventory.Add(sodaToAdd);
            }
        }

        public void ListInventory()
        {
            int rootbeerCount = inventory.OfType<RootBeer>().Count();
            int colaCount = inventory.OfType<Cola>().Count();
            int oragneCount = inventory.OfType<Orange>().Count();
            Console.WriteLine($"Root Beer:{rootbeerCount} Cola:{colaCount} Orange{oragneCount}");

        }

        public void DistributeCan(Can can, Customer customer)
        {
            inventory.Remove(can);
            customer.backpack.AddCanToBackpack(can);


        }

        //private Soda GenerateSodaObject(string sodaName)
        //{
        //    if(sodaName == "Cola")
        //    {
        //        return new Cola();
        //    }
        //}

        public void DepositPaymentInRegister()
        {
            foreach(Coin coin in payment)
            {
                register.Add(coin);
                
            }
            payment.Clear();
        }

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

        public double PaymentValue()
        {
            double paymentValue = 0;
            foreach (Coin coin in payment)
            {
                paymentValue += coin.Value;
            }
            return paymentValue;
        }

        //public void DisplaySoda(Can can, string type)
        //{
        //    if (inventory.Contains(can.SodaType))
        //    {
        //        Console.WriteLine($"{can.SodaType}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"{can.SodaType} (OUT OF STOCK)");
        //    }
        //}

        public void CheckTransaction(Can can, Customer customer)
        {
            
            
            if (PaymentValue() == can.SodaCost)
            {
                DistributeCan(can, customer);
                DepositPaymentInRegister();
            }
            else if(PaymentValue() < can.SodaCost)
            {
                UserInterface.DisplayMessage("Insufficent Funds Deposited, Come back when you can afford it");
                ReturnCoinsToWallet(customer);
            }
            else if(PaymentValue() > can.SodaCost && SufficientChangeExists(can, customer))
            {
                DistributeCan(can, customer);
                DepositPaymentInRegister();
                GiveChange(can, customer);

            }
        }

        public void ReturnCoinsToWallet(Customer customer)
        {
            foreach(Coin coin in payment)
            {
                customer.wallet.coins.Add(coin);
                payment.Remove(coin);

            }
        }

        public bool SufficientChangeExists(Can can, Customer customer)
        {
            if (Change.ChangeNeeded(can.SodaCost, PaymentValue()) > 0  && CorrectChangeAvailable())
            {
                return true;
            }
            return false;
        }

        public bool CorrectChangeAvailable()
        {
            if (0 == 0)
            {
                return true;
            }
            return false;
        }

        public void GiveChange(Can can, Customer customer)
        {

        }

        public bool CheckInventory(Can can)
        {
            Can desiredCan = inventory.Find(delegate (Can c) { return c.SodaType == can.SodaType; });
            if(desiredCan != null)
            {
                return true;
            }
            return false;
            
        }

        public int GetDesiredCanID(Can can)
        {
            int canID;

            canID = inventory.FindIndex(delegate (Can c) { return c.SodaType == can.SodaType; });

            return canID;
        }

        //public void DisplayOfferings()
        //{
        //    int inventorycount = inventory.Count;
        //    foreach (Can can in inventory)
        //    {
        //        for (int i = 0; i < inventorycount; i++)
        //        {
        //            if(i == (inventorycount - 1))
        //            {
                        
                        
        //            }

        //        }
        //    }
        //}
    }
}
