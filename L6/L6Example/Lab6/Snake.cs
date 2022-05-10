using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Snake: Animal
    {
        bool isPoisonous;

        public Snake(): base()
        {
            IsPoisonous = false;
        }

        public Snake(string habitat, double weight, bool isPoisonous) : base(habitat, weight)
        {
            IsPoisonous = isPoisonous;
        }

        public bool IsPoisonous { get => isPoisonous; set => isPoisonous = value; }

        public override string ToString()
        {
            return base.ToString() + "\nЯдовитая: " + (IsPoisonous?"да":"нет");
        }

        public override void Sound()
        {
            Console.WriteLine("Шшшшш...");
        }

        public override void Pet()
        {
            base.Pet();
            Random rnd = new Random();
            if (rnd.Next(2) == 0)
            {
                Console.WriteLine("Змея укусила вас.");
                if (IsPoisonous)
                    Console.WriteLine("Змея ядовитая! Срочно примите антидот!");
                else
                    Console.WriteLine("Ничего страшного не случилось, змея безобидная.");
            }
            else
                Console.WriteLine("Змея никак не реагирует на вас.");
        }
    }
}
