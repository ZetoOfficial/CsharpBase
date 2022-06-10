namespace L6
{
    class Program
    {
        static void SearchVagons(List<Vehicle> vehicles, int i)
        {
            var selectedVehicles = vehicles.Where(el => el is Express && ((Express)el).checkVagons(i));
            foreach (var vehicle in selectedVehicles)
                Console.WriteLine(vehicle);
        }
        static void SearchDoors(List<Vehicle> vehicles, int i)
        {
            var selectedVehicles = vehicles.Where(el => el is Car && ((Car)el).checkDoor(i));
            foreach (var vehicle in selectedVehicles)
                Console.WriteLine(vehicle);
        }
        static void SearchMaxSpeed(List<Vehicle> vehicles, int i)
        {
            var selectedVehicles = vehicles.Where(el => el is Train && ((Train)el).checkMaxSpeed(i));
            foreach (var vehicle in selectedVehicles)
                Console.WriteLine(vehicle);
        }
        static void SearchColor(List<Vehicle> vehicles, string c)
        {
            var selectedVehicles = vehicles.Where(el => el.checkColor(c));
            foreach (var vehicle in selectedVehicles)
                Console.WriteLine(vehicle);
        }
        static void Main(string[] args)
        {
            WorkingWithObjectsClass wwoc = new();

            List<Vehicle> vehicles = wwoc.Deserialize();
            SearchVagons(vehicles, 2);
            SearchDoors(vehicles, 2);
            SearchMaxSpeed(vehicles, 2);
            SearchColor(vehicles, "Blue");

            try
            {
                Console.WriteLine("Нажмите любую клавишу для начала взаимодействия с данными");
                Console.ReadKey();
                bool work = true;
                while (work)
                {
                    Console.Clear();
                    Console.WriteLine(" * МЕНЮ * ");
                    Console.WriteLine("1. Вывести весь список");
                    Console.WriteLine("2. Добавить новый элемент в список");
                    Console.WriteLine("3. Удалить элемент из списка");
                    Console.WriteLine("4. Работа с элементом");
                    Console.WriteLine("Любая другая клавиша - выход");
                    switch (wwoc.StrToIntDef(Console.ReadLine(), 99))
                    {
                        case 1:
                            wwoc.PrintList(vehicles);
                            break;
                        case 2:
                            wwoc.Add(vehicles);
                            break;
                        case 3:
                            wwoc.Remove(vehicles);
                            break;
                        case 4:
                            wwoc.WorkWithObject(vehicles);
                            break;
                        default:
                            work = false;
                            break;
                    }
                    if (work)
                    {
                        Console.WriteLine("Чтобы продолжить нажмите любую клавишу");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Очень жаль, что не получилось");
                Console.WriteLine(e);
                foreach (var i in vehicles)
                    Console.WriteLine(i);
            }
            finally
            {
                wwoc.Serialize(vehicles); // в конце работы сохраняем список в файл
            }
        }
    }
}
