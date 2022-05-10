using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Horse: Animal
    {
        string species;

        public Horse(): base()
        {
            Species = "Орловский рысак";
        }

        public Horse(string habitat, double weight, string species) : base(habitat, weight)
        {
            Species = species;
        }

        public string Species { get => species; set => species = value; }

        public override string ToString()
        {
            return base.ToString() + "\nПорода лошади: " + Species;
        }

        public override void Sound()
        {
            Console.WriteLine("Звуки счастливой лошади, мчащейся по полю");
        }

        public override void Pet()
        {
            base.Pet();
            Console.WriteLine("Лошадь лизнула вас в руку.");
        }
    }
}
