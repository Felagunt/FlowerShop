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
}
