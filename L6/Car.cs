namespace L6
{
    public class Car : Vehicle, IRepair, IMod
    {
        private int doors;
        private string carType = "Car";
        public int Doors { get => doors; set => doors = value; }
        public string CarType { get => carType; set => carType = value; }

        void IRepair.Code(string? cheatCode)
        {
            if (cheatCode == "HESOYAM")
                Console.WriteLine("Починка удалась");
            else
                Console.WriteLine("Починка не удалась");
        }
        void IMod.Code(string? cheatCode)
        {
            if (cheatCode == "freefarm")
                Console.WriteLine("Модификация удалась");
            else
                Console.WriteLine("Модификация не удалась");
        }
        public bool checkDoor(int doorNum)
        {
            return (doorNum == this.doors);
        }
        public Car() : base() { }
        public Car(string name) : base(name) { }
        public Car(string name, string color) : base(name, color) { }
        public Car(string name, string color, string zodiacSign) : base(name, color, zodiacSign) { }
        public Car(string name, string color, string zodiacSign, int speed) : base(name, color, zodiacSign, speed) { }

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

        delegate void Movement(string s);
        delegate void Edit(int x);
        delegate void Cheat(string s);

        public override void DopInfo()
        {
            Console.WriteLine("Dop info for Car");
            Cheat repair, modi, multiCheatDel;
            Movement move, teleport, multiMoveDel;
            Edit speedup, beeper, multiEditDel;

            move = Move;
            teleport = Teleport;

            speedup = SpeedUp;
            beeper = BeepBeep;

            multiMoveDel = move + teleport;
            multiEditDel = speedup + beeper;
            multiMoveDel("Казахстан");
            multiEditDel(2);
        }
    }
}