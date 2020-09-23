using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public class Machine
    {
        //Member Variables
        List<Coin> registerCoins;
        List<Coin> tempCoinRegister;
        List<Soda> sodaInventory;
        int initialColaInventory;
        int initialOrangeInventory;
        int initialRootBeerInventory;
        int initialQuartersInRegister;
        int initialDimesInRegister;
        int initialNickelsInRegister;
        int initialPenniesInRegister;
        Cola cola;
        Orange orange;
        RootBeer rootbeer;
        //Constructor
        public Machine(int initialQuartersInRegister, int initialDimesInRegister, int initialNickelsInRegister, int initialPenniesInRegister, int initialColaInventory, int initialRootBeerInventory, int initialOrangeInventory)
        {
            this.initialColaInventory = initialColaInventory;
            this.initialOrangeInventory = initialOrangeInventory;
            this.initialRootBeerInventory = initialRootBeerInventory;
            this.initialQuartersInRegister = initialQuartersInRegister;
            this.initialDimesInRegister = initialDimesInRegister;
            this.initialNickelsInRegister = initialNickelsInRegister;
            this.initialPenniesInRegister = initialPenniesInRegister;
            registerCoins = new List<Coin>();
            tempCoinRegister = new List<Coin>();
            sodaInventory = new List<Soda>();
            cola = new Cola();
            orange = new Orange();
            rootbeer = new RootBeer();

            InitialSodaInventory(initialColaInventory, cola, "Cola");
            InitialSodaInventory(initialRootBeerInventory, rootbeer, "RootBeer");
            InitialSodaInventory(initialOrangeInventory, orange, "Orange");

        }

        //Methods

        // consider "generic constraints"
        public void InitialSodaInventory(int inventory,Soda soda, string SodaType )
        {
            Soda newsoda;

            for (int i = 0; i < inventory; i++)
            {
                
                newsoda = soda.GetSodaType(SodaType);
                sodaInventory.Add(newsoda);

                // sodaInventory.Add(sodaToAdd);
            }
        }

        public void ListInventory()
        {
            foreach(Soda soda in sodaInventory)
            {
                Console.WriteLine($"{soda.SodaCost}: {soda.SodaType}");
            }
        }

        //private Soda GenerateSodaObject(string sodaName)
        //{
        //    if(sodaName == "Cola")
        //    {
        //        return new Cola();
        //    }
        //}
    }
}
