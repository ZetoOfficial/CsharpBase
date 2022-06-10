using System.Xml.Serialization; // нужно для сериализации объектов и сохранения в файлы

namespace L4
{
    [XmlInclude(typeof(Car)), XmlInclude(typeof(Train)), XmlInclude(typeof(Express))]
    abstract public class Vehicle
    {
        string? name = "имя не указано";
        string? color = "цвет не указан";
        string? zodiacSign = "зз не указан";
        int speed;

        public string? Name { get => name; set => name = name is null ? "nope" : value; }
        public string? Color { get => color; set => color = color is null ? "nope" : value; }
        public string? ZodiacSign { get => zodiacSign; set => zodiacSign = zodiacSign is null ? "nope" : value; }
        public int Speed { get => speed; set => speed = value; }

        public Vehicle() { }
        public Vehicle(string name)
        {
            Name = name;
        }
        public Vehicle(string name, string color)
        {
            Name = name;
            Color = color;
        }
        public Vehicle(string name, string color, string zodiacSign)
        {
            Name = name;
            Color = color;
            ZodiacSign = zodiacSign;
        }
        public Vehicle(string name, string color, string zodiacSign, int speed)
        {
            Name = name;
            Color = color;
            ZodiacSign = zodiacSign;
            Speed = speed;
        }
        public abstract void Move(string? endpoint);
        public abstract void SpeedUp(int newSpeed);
        public abstract void Teleport(string? location);
        public abstract void BeepBeep(int duration);
        public abstract void DopInfo();

        public void Info()
        {
            Console.WriteLine("----------------INFO--------------------");
            Console.WriteLine($"Название вашей ласточки: {Name}");
            Console.WriteLine($"Цвет: {Color}");
            Console.WriteLine($"Знак зодиака: {ZodiacSign}");
            Console.WriteLine($"Текущая скорость: {Speed}");
            DopInfo();
            Console.WriteLine("----------------------------------------");
        }
    }
}