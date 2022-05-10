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

        public bool checkColor(string colorInput)
        {
            return colorInput == this.color;
        }

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
            return $"Переопределённый вывод: \n{Info()}";
        }
        public string Info()
        {
            string s = ("----------------INFO--------------------\n");
            s += ($"Название вашей ласточки: {Name}\n");
            s += ($"Цвет: {Color}\n");
            s += ($"Знак зодиака: {ZodiacSign}\n");
            s += ($"Текущая скорость: {Speed}\n");
            s += ("----------------------------------------\n");
            DopInfo();
            return s;
        }
    }
}