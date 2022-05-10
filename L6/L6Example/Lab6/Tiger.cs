using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Tiger: Animal
    {
        double canineLength;

        public Tiger(): base()
        {
            CanineLength = 5;
        }

        public Tiger(string habitat, double weight, double canineLength) : base(habitat, weight)
        {
            CanineLength = canineLength;
        }

        public double CanineLength { get => canineLength; set => canineLength = value; }

        public override string ToString()
        {
            return base.ToString() + "\nДлина клыков: " + CanineLength;
        }

        public override void Sound()
        {
            Console.WriteLine("Ррррррмяу");
        }

        public override void Pet()
        {
            base.Pet();
            Random rnd = new Random();
            if (rnd.Next(2) == 0)
                Console.WriteLine("Тигр укусил вас.");
            else
                Console.WriteLine("Тигр замурчал.");
        }
    }
}
