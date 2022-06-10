namespace L4
{
    public class Train : Vehicle
    {
        public Train() : base() { }
        public Train(string name) : base(name) { }
        public Train(string name, string color) : base(name, color) { }
        public Train(string name, string color, string zodiacSign) : base(name, color, zodiacSign) { }
        public Train(string name, string color, string zodiacSign, int speed) : base(name, color, zodiacSign, speed) { }

        int vagons;
        public int Vagons { get => vagons; set => vagons = value; }

        public override void Move(string? endpoint) => Console.WriteLine($"Поезд ({Color} {Name}, {ZodiacSign}) отправляется в {endpoint}. У нас есть Wi-Fi + кофе + душ)");
        public override void SpeedUp(int newSpeed)
        {
            Speed = newSpeed;
            Console.WriteLine($"Поезд \"{Name}\" увеличил свою скорость до {newSpeed}. Туалет закрыт)");
        }
        public override void Teleport(string? location) => Console.WriteLine($"Извините, но пока что точка {location} временно недоступна для вашей страны");
        public override void BeepBeep(int duration) => Console.WriteLine($"Чё? Какой бип бип, ты в поезде ...");
        public override void DopInfo()
        {
            Console.WriteLine("Dop info for Train");
        }
    }
}