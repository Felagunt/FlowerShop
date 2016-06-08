﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Bouquet[] bouquet = new Bouquet[3];
            //save state to sales check
            SaleHistory sale = new SaleHistory();

            bouquet[0] = new RosesStandard();
            bouquet[1] = new PetuniasStandard(4);
            bouquet[2] = new Custom(3);
            //display participants of bouguet
            foreach(Bouquet participants in bouquet)
            {
                Console.WriteLine("\n" + bouquet.GetType().Name + "--"+
                    " Price:"+participants.Cost);
                foreach (Flower flower in participants.Flowers)
                {
                    Console.WriteLine(" " + flower +
                        " Price:" + flower.price);
                    //sale.History.Add(0,participants.SaveState());
                }
            }

            
            

            //wait
            Console.ReadKey();
        }
    }
    
    /// <summary>
    /// Flower abstract class
    /// </summary>
    public class Flower
    {
        public decimal Price { get; set; }
        
    }

    ///<summary>
    /// concrete flower
    /// </summary>
    class Peony:Flower
    {
        public Peony()
        {
            Price = 100;
        }
    }
    ///<summary>
    /// concrete flower
    /// </summary>
    class Rose : Flower
    {
        public Rose()
        {
            Price = 200;
        }
    }
    ///<summary>
    /// concrete flower
    /// </summary>
    class Petunia : Flower
    {
        public Petunia()
        {
            Price = 132;
        }
    }

    /// <summary>
    /// Creator
    /// </summary>
    abstract class Bouquet
    {
        private List<Flower> _flowers = new List<Flower>();
        public List<Flower> Flowers
        {
            get { return _flowers; }
            private set { _flowers = value; }
        }
        //Flower flowers = new Flower();
        public decimal Cost
        {
            get { return _flowers.Sum(p => p.Price); }
            }
        public int Count { get { return _flowers.Count(); } }
        public Bouquet()
        {
            /*this.Count = c;
            for (int i = 0; i < Count; i++)
            {
                Cost = Flowers.Sum(flower => flower.price);
            }*/
            //this.CreateBouquet();
        }

        /*
        //save state
        public SalesCheck SaveState()
        {
            Console.WriteLine("thx for bought. Spend: for Flower{0} Count{1} Pay{2}",Flowers, Count, Cost);
            return new SalesCheck(Cost, Count, Flowers);
        }
        
        public void RestoreState(SalesCheck memento)
        {
            this.Count = memento.Count;
            this.Cost = memento.Cost;
            this.Flowers = memento.Flowers;
            Console.WriteLine("Was bougth: Flower{0} Count {1} Payed {2}",
                 Count, Cost, Flowers);
        }
        */
        //Factory method
        public abstract void CreateBouquet();
    }

    /// <summary>
    /// Concrete creator
    /// </summary>
    class RosesStandard:Bouquet
    {
        public RosesStandard()
        {
           
        }
        public override void CreateBouquet()
        {
            Flowers.Add(new Rose());
        }

       
    }
    /// <summary>
    /// Concrete creator
    /// </summary>
    class PetuniasStandard:Bouquet
    {
        public PetuniasStandard()
        { }
        public override void CreateBouquet()
        {
            Flowers.Add(new Petunia());
        }
        
    }
    /// <summary>
    /// Concrete creator
    /// </summary>
    class Custom : Bouquet
    {
        public Custom()
        { }
        public override void CreateBouquet()
        {
            Flowers.Add(new Rose());
            Flowers.Add(new Peony());
        }
        
    }
    /// <summary>
    /// memento
    /// </summary>
    class SalesCheck
    {
        public int Count { get; private set; }
        public decimal Cost { get; private set; }

        public List<Flower> Flowers { get; private set; } = new List<Flower>();
       

        public SalesCheck(int Count,decimal Cost,List<Flower> flowers)
        {
            this.Flowers = flowers;
            this.Cost = Cost;
            this.Count = Count;
        }
    }
    /// <summary>
    /// Caretaker
    /// </summary>
    class SaleHistory
    {
        
        public int SId { get; private set; }
        public Dictionary<int, SalesCheck> History = new Dictionary<int, SalesCheck>();
        public SaleHistory()
        {
            History = new Dictionary<int, SalesCheck>();
            SId++;
        }
    }
}
