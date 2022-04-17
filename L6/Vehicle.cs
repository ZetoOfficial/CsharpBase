using System.Xml.Serialization; // нужно для сериализации объектов и сохранения в файлы

namespace L6
{
    [XmlInclude(typeof(Car)), XmlInclude(typeof(Train)), XmlInclude(typeof(Express))]
    abstract public class Vehicle
    {
        private string name = "имя не указано";
        private string color = "цвет не указан";
        private string zodiacSign = "зз не указан";
        private int speed;

        public string? Name { get => name; set => name = value is null ? name : value; }
        public string? Color { get => color; set => color = value is null ? color : value; }
        public string? ZodiacSign { get => zodiacSign; set => zodiacSign = value is null ? zodiacSign : value; }
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

        public override string ToString()
        {
            return $"Переопределённый вывод: {base.ToString()}";
        }
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