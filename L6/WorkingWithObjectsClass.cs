using System.Xml.Serialization; // нужно для сериализации объектов и сохранения в файлы

namespace L6
{
    public class WorkingWithObjectsClass
    {
        public int StrToIntDef(string? s, int @default)
        {
            int number;
            if (int.TryParse(s, out number))
                return number;
            return @default;
        }
        public void Serialize(List<Vehicle> vehicles)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Vehicle[])); // для сериализации указывается массив объектов базового класса
            // получаем поток, куда будем записывать сериализованный объект
            foreach (var item in vehicles)
                Console.WriteLine(item);
            using (FileStream fs = new FileStream("list.xml", FileMode.Create)) // для безопасной работы с потоком используется using
            {
                xmlSerializer.Serialize(fs, vehicles.ToArray()); // сериализация, передается массив объектов
                Console.WriteLine("Данные сохранены");
                Console.ReadKey();
            }
        }
        public List<Vehicle> Deserialize()
        {
            try
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Vehicle[])); // по аналогии с сериализацией
                using (FileStream fs = new FileStream("list.xml", FileMode.OpenOrCreate))
                {
                    Vehicle[]? temp = xmlSerializer.Deserialize(fs) as Vehicle[];
                    if (temp is not null)
                        vehicles.AddRange(temp);
                }
                Console.WriteLine("Данные загружены");
                return vehicles;
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось загрузить данные. {0}", e.Message);
                return new List<Vehicle>();
            }
        }
        public void PrintList(List<Vehicle> vehicles)
        {
            int index = 0;
            if (vehicles.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            foreach (var item in vehicles)
            {
                Console.WriteLine("{0}:", index);
                index++;
                if (item is Car)
                {
                    ((Car)item).Info();
                }
                else if (item is Train)
                {
                    ((Train)item).Info();
                }
                else if (item is Express)
                {
                    ((Express)item).Info();
                }
                else
                {
                    item.Info();
                }
            }
        }
        public void Add(List<Vehicle> vehicles) // метод добавления элемента в список, список передается в качестве параметра
        {
            Console.Clear();
            Console.WriteLine("1. Автомобиль");
            Console.WriteLine("2. Поезд");
            Console.WriteLine("3. Экспресс");
            int c = StrToIntDef(Console.ReadLine(), 99);

            Console.Write("Введите название (default: \"Valera\"): ");
            string? name = Convert.ToString(Console.ReadLine());
            if (name is null || name == "") name = "Valera";

            Console.Write("Введите цвет (default: \"Blue\"): ");
            string? color = Convert.ToString(Console.ReadLine());
            if (color is null || color == "") color = "Blue";

            Console.Write("Введите знак зодиака (default: \"Vodoley\"): ");
            string? zz = Convert.ToString(Console.ReadLine());
            if (zz is null || zz == "") zz = "Vodoley";

            Console.Write("Введите скорость (default: \"0\"): ");
            int speed = StrToIntDef(Console.ReadLine(), 0);

            switch (c)
            {

                case 1:
                    vehicles.Add(new Car(name, color, zz, speed));
                    break;
                case 2:
                    vehicles.Add(new Train(name, color, zz, speed));
                    break;
                case 3:
                    vehicles.Add(new Express(name, color, zz, speed));
                    break;
                default:
                    Console.WriteLine("Под номером вашим номером, транспорта пока нет.");
                    break;
            }
        }
        public void Remove(List<Vehicle> vehicles)// метод для удаления из списка
        // удаление просто по индексу элемента в списке
        {
            Console.WriteLine("Введите номер элемента, который хотите удалить:");
            // int c = Convert.ToInt32(Console.ReadLine());
            int c = StrToIntDef(Console.ReadLine(), -1);
            if (c < 0 || c >= vehicles.Count)
            {
                Console.WriteLine("Элемент не найден");
                return;
            }
            else vehicles.RemoveAt(c);
        }
        public void WorkWithObject(List<Vehicle> vehicles)
        {
            Console.WriteLine("Краткий список элементов:");
            int index = 0;
            foreach (var i in vehicles)
            {
                Console.WriteLine($"➻ {index}: {i.Name}");
                index++;
            }
            Console.WriteLine("Введите номер элемента, с которым хотите работать:");
            int c = StrToIntDef(Console.ReadLine(), -1);
            if (c < 0 || c >= vehicles.Count)
            {
                Console.WriteLine("Элемент не найден");
                return;
            }
            Console.WriteLine("1. Изменить имя");
            Console.WriteLine("2. Изменить скорость");
            Console.WriteLine("3. Изменить цвет");
            Console.WriteLine("4. Изменить Знак Зодиака");
            Console.WriteLine("5. Движение");
            Console.WriteLine("6. Телепортация");
            Console.WriteLine("7. SpeedUp");
            Console.WriteLine("8. Побибикать");


            switch (StrToIntDef(Console.ReadLine(), 99))
            {
                case 1:
                    Console.Write("Введите название: ");
                    vehicles[c].Name = Convert.ToString(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Введите скорость: ");
                    vehicles[c].Speed = StrToIntDef(Console.ReadLine(), 99);
                    break;
                case 3:
                    Console.Write("Введите цвет: ");
                    vehicles[c].Color = Convert.ToString(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("Введите Знак Зодиака: ");
                    vehicles[c].ZodiacSign = Convert.ToString(Console.ReadLine());
                    break;
                case 5:
                    Console.Write("Введите конечную точку: ");
                    vehicles[c].Move(Convert.ToString(Console.ReadLine()));
                    break;
                case 6:
                    Console.Write("Введите точку для телепортации: ");
                    vehicles[c].Teleport(Convert.ToString(Console.ReadLine()));
                    break;
                case 7:
                    Console.Write("Введите скорость: ");
                    vehicles[c].SpeedUp(StrToIntDef(Console.ReadLine(), 99));
                    break;
                case 8:
                    Console.Write("Введите кол-во биков: ");
                    vehicles[c].BeepBeep(StrToIntDef(Console.ReadLine(), 99));
                    break;
                default:
                    Console.WriteLine("Такого метода нет");
                    break;
            }
            Console.WriteLine("Уникальные методы: ");
            if (vehicles[c] is Car) // список методов выводится в зависимости от выбранного объекта
            {
                Car car = (Car)vehicles[c];
                Console.WriteLine("1. Вывод количества дверей");
                Console.WriteLine("2. Вывод типа авто");
                switch (StrToIntDef(Console.ReadLine(), 99))
                {
                    case 1:
                        Console.WriteLine(car.Doors);
                        break;
                    case 2:
                        Console.WriteLine(car.CarType);
                        break;
                    default:
                        Console.WriteLine("Такого метода нет");
                        break;
                }
            }
            else if (vehicles[c] is Train)
            {
                Train train = (Train)vehicles[c];
                Console.WriteLine("1. Вывод количества вагонов");
                switch (StrToIntDef(Console.ReadLine(), 99))
                {
                    case 1:
                        Console.WriteLine(train.Vagons);
                        break;
                    default:
                        Console.WriteLine("Такого метода нет");
                        break;
                }
            }
            else if (vehicles[c] is Express)
            {
                Express express = (Express)vehicles[c];
                Console.WriteLine("1. Вывод количества вагонов");
                switch (StrToIntDef(Console.ReadLine(), 99))
                {
                    case 1:
                        Console.WriteLine(express.Vagons);
                        break;
                    default:
                        Console.WriteLine("Такого метода нет");
                        break;
                }
            }
        }

    }
}