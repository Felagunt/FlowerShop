using System;
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

            bouquet[0] = new RosesStandard(2);
            bouquet[1] = new PetuniasStandard(4);
            bouquet[2] = new Custom(3);
            //display participants of bouguet
            foreach(Bouquet participants in bouquet)
            {
                Console.WriteLine("\n" + bouquet.GetType().Name + "--"+
                    " Price:"+participants.Coast);
                foreach (Flower flower in participants.Flowers)
                {
                    Console.WriteLine(" " + flower.GetType().Name +
                        " Price:" + flower.price);
                    sale.History.Add(0,participants.SaveState());
                }
            }

            
            

            //wait
            Console.ReadKey();
        }
    }
    
    /// <summary>
    /// Flower class
    /// </summary>
    public class Flower
    {
        public decimal price;
        Dictionary<string, decimal> flowers = new Dictionary<string, decimal>()
        {
            ["rose"] = 200m,
            ["peony"] = 100m,
            ["petunia"] = 132m
        };
        public Flower CreateFlower(string nameFlower)
        {
            decimal price;
            if (flowers.TryGetValue(nameFlower, out price))
                return new Flower()
                {
                    price = price
                };
        return null;
        }
    }

    

    /// <summary>
    /// Creator
    /// </summary>
    abstract class Bouquet
    {
        /*public List<Flower> _flowers = new List<Flower>();
        public List<Flower> Flowers
        {
            get { return _flowers; }
            private set { _flowers = value; }
        }*/
        Flower flowers = new Flower();
        public decimal Coast { get; set; }
        public int Count { get; set; }
        public Bouquet(int c)
        {
            Count = c;
            foreach (var flower in flowers)
                Coast += flower.price;
            flowers.CreateFlower("rose");
            Coast = flowers.price;
            this.CreateBouquet();
        }

        
        //save state
        public SalesCheck SaveState()
        {
            Console.WriteLine("thx for bought. Spend: for Flower{0} Count{1} Pay{2}",Flowers, Count, Coast);
            return new SalesCheck(Convert.ToInt32(Coast), Count, Flowers);
        }
        
        public void RestoreState(SalesCheck memento)
        {
            this.Count = memento.Count;
            this.Coast = memento.Coast;
            this.Flowers = memento.Flowers;
            Console.WriteLine("Was bougth: Flower{0} Count {1} Payed {2}",
                 Count, Coast, Flowers);
        }

        //Factory method
        public abstract void CreateBouquet();
    }

    /// <summary>
    /// Concrete creator
    /// </summary>
    class RosesStandard:Bouquet
    {
        public RosesStandard(int c) : base(c)
        {
            Count = c;
        }
        public override void CreateBouquet()
        {
            
            //flowers.CreateFlower("rose");
        }

       
    }
    /// <summary>
    /// Concrete creator
    /// </summary>
    class PetuniasStandard:Bouquet
    {
        public PetuniasStandard(int c):base(c)
        { }
        public override void CreateBouquet()
        {
            //Flowers.Add(new Petunia());
        }
        
    }
    /// <summary>
    /// Concrete creator
    /// </summary>
    class Custom : Bouquet
    {
        public Custom(int c):base(c)
        { }
        public override void CreateBouquet()
        {
            //Flowers.Add(new Rose());
            //Flowers.Add(new Peony());
        }
        
    }
    /// <summary>
    /// memento
    /// </summary>
    class SalesCheck
    {
        public int Count { get; private set; }
        public decimal Coast { get; private set; }

        public List<Flower> Flowers { get; private set; } = new List<Flower>();
       

        public SalesCheck(int Count,decimal Coast,List<Flower> flowers)
        {
            this.Flowers = flowers;
            this.Coast = Coast;
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
