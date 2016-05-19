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

            bouquet[0] = new RosesStandard(2);
            bouquet[1] = new PetuniasStandard(4);
            bouquet[2] = new Custom(3);
            //display participants of bouguet
            foreach(Bouquet participants in bouquet)
            {
                Console.WriteLine("\n" + bouquet.GetType().Name + "--"+
                    " Price:"+Flower.price);
                foreach (Flower flower in participants.Flowers)
                {
                    Console.WriteLine(" " + flower.GetType().Name +
                        " Price:" + participants.Coast);
                }
            }

            //save state to sales check
            SaleHistory sale = new SaleHistory();
            sale.History.Push(bouquet.SalesCheck());

            //wait
            Console.ReadKey();
        }
    }
    
    abstract class Flower
    {
      public static int price { get; set; }
    }
    class Rose:Flower
    {
        public Rose()
        {
            price = 200;
        }
    }
    class Peony:Flower
    {
        public Peony()
        {
            price = 100;
        }
    }

    class Petunia:Flower
    {
        public Petunia()
        {
            price = 132;
        }
    }

    //
    abstract class Bouquet
    {
        private List<Flower> _flowers = new List<Flower>();
        public int Coast { get; set; }
        public int Count { get; set; }
        public Bouquet(int c)
        {
            Count = c;
            Coast = Flower.price * Count;

            this.CreateBouquet();
        }

        public List<Flower> Flowers
        {
            get { return _flowers; }
        }

        //save state
        public SalesCheck SaveState()
        {
            Console.WriteLine("thx for bought. Spend: for Flower{0} Count{1} Pay{2}",Flowers, Count, Coast);
            return new SalesCheck(Coast, Count, Flowers);
        }
        //restore state - i don't think this need inherited
        public void RestoreState(SalesCheck memento)
        {
            this.Count = memento.Count;
            this.Coast = memento.Coast;
            //this.Flowers = memento.Flowers;
            Console.WriteLine("Was bougth: Flower{0} Count {1} Payed {2}",
                 Count, Coast, Flowers);
        }

        public abstract void CreateBouquet();
    }

    
    class RosesStandard:Bouquet
    {
        public RosesStandard(int c) : base(c)
        { }
        public override void CreateBouquet()
        {
            Flowers.Add(new Rose());
        }

       
    }
    class PetuniasStandard:Bouquet
    {
        public PetuniasStandard(int c):base(c)
        { }
        public override void CreateBouquet()
        {
            Flowers.Add(new Petunia());
        }
        
    }

    class Custom : Bouquet
    {
        public Custom(int c):base(c)
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
        public int Coast { get; private set; }
        public int List<Flower> _flowers= new List<Flower>();//think over
        public List<Flower> Flowers
        {
            get { return _flowers; }
        }*/

        public SalesCheck(int Count,int Coast,List<Flower> flowers)
        {
            //this.Flowers = flowers;
            this.Coast = Coast;
            this.Count = Count;
        }
    }
    /// <summary>
    /// Caretaker
    /// </summary>
    class SaleHistory
    {
        /*need dictionary
        private SalesCheck _saleCheck;

        public SalesCheck SaleCheck
        {
            set { _saleCheck = value; }
            get { return _saleCheck; }
        }*/

        //smth like 
        public int SId { get; private set; }
        public Dictionary<int, SaleHistory> History = new Dictionary<int, SaleHistory>();
        public SaleHistory()
        {
            History.Add(SId, SaleHistory);//think over what need contain here

        }
    }
}
