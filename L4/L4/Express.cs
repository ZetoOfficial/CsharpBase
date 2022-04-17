namespace L4
{
    public class Express : Vehicle
    {
        public Express() : base() { }
        public Express(string name) : base(name) { }
        public Express(string name, string color) : base(name, color) { }
        public Express(string name, string color, string zodiacSign) : base(name, color, zodiacSign) { }
        public Express(string name, string color, string zodiacSign, int speed) : base(name, color, zodiacSign, speed) { }

        int vagons;
        public int Vagons { get => vagons; set => vagons = value; }

        public override void Move(string? endpoint) => Console.WriteLine($"Эксперсс ({Color} {Name}, {ZodiacSign}) отправляется в {endpoint}. У нас есть Wi-Fi.");
        public override void SpeedUp(int newSpeed)
        {
            Speed = newSpeed;
            Console.WriteLine($"Эксперсс \"{Name}\" увеличил свою скорость до {newSpeed}...");
        }
        public override void Teleport(string? location) => Console.WriteLine($"&^%#!@#!@#!@#!JH@G#!@JKGH#!@J#HG!@#K Done. Добро пожаловать в {location}");
        public override void BeepBeep(int duration) { for (int i = 0; i < duration; i++) { Console.WriteLine($"BEEP ..."); } }
        public override void DopInfo()
        {
            Console.WriteLine("Dop info for Express");
        }
    }
}