namespace L4
{
    public class Car : Vehicle
    {
        public Car() : base() { }
        public Car(string name) : base(name) { }
        public Car(string name, string color) : base(name, color) { }
        public Car(string name, string color, string zodiacSign) : base(name, color, zodiacSign) { }
        public Car(string name, string color, string zodiacSign, int speed) : base(name, color, zodiacSign, speed) { }

        int doors;
        string carType = " ";
        public int Doors { get => doors; set => doors = value; }
        public string CarType { get => carType; set => carType = value; }

        public override void Move(string? endpoint) => Console.WriteLine($"ДВИЖЕМСЯ ПРЯМО ПО КУРСУ В {endpoint} НА {Name} {Color} цвета (между прочим {ZodiacSign}) НА СКОРОСТИ {Speed}км/с!!!!!!!");
        public override void SpeedUp(int newSpeed)
        {
            Speed = newSpeed;
            Console.WriteLine($"СКОРОСТЬ ВАШЕГО АВТОМОБИЛЯ \"{Name}\" ПОДНЯЛАСЬ ДО {newSpeed}, А ЭТО ЗНАЧИТ, ЧТО ...");
            Console.WriteLine($"\tПусть луна нам светит ярко");
            Console.WriteLine($"\tОбгоняем иномарку...");
        }
        public override void Teleport(string? location) => Console.WriteLine($"Телепортация в {location} невозможна, пожалуйста, обновите ваше транспортное средство.");
        public override void BeepBeep(int duration) { for (int i = 0; i < duration; i++) { Console.WriteLine($"Beep ..."); } }
        public override void DopInfo()
        {
            Console.WriteLine("Dop info for Car");
        }
    }
}