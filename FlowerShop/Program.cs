using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Bouquet[] bouquet = new Bouquet[2];

            bouquet[0] = new RosesStandard();
            bouquet[1] = new PetuniasStandard();

            //display participants of bouguet
            foreach(Bouquet participants in bouquet)
            {
                Console.WriteLine("\n" + bouquet.GetType().Name + "--");
                foreach(Flower flower in participants.Flowers)
                {
                    Console.WriteLine(" " + flower.GetType().Name);
                }
            }

            //wait
            Console.ReadKey();
        }
    }
    
    abstract class Flower
    {
       /* public int count { get; set; }

        public Flower()
        {
            
        }*/
    }
    class Rose:Flower
    {
        public Rose()
        {
            Console.WriteLine("Rose adding");
        }
    }
    class Peony:Flower
    {

    }

    class Petunia:Flower
    {

    }

    //
    abstract class Bouquet
    {
        private List<Flower> _flowers = new List<Flower>();

        public Bouquet()
        {
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
        public override void CreateBouquet()
        {
            Flowers.Add(new Rose());
        }
    }
    class PetuniasStandard:Bouquet
    {
        public override void CreateBouquet()
        {
            Flowers.Add(new Petunia());
        }
    }
}
