namespace L9;

public class Program
{
    static void Main()
    {
        Square square = new Square();
        bool menu = true;
        while (menu)
        {
            Console.Clear();
            Console.WriteLine("1. Пересоздать фигуру");
            Console.WriteLine("2. Изменить вершину фигуры");
            Console.WriteLine("3. Вывести информацию о фигуре");
            Console.WriteLine("4. Вывести площадь фигуры");
            int choice = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (choice)
                {
                    case 1:
                    {
                        try
                        {
                            Console.Write("Сколько точек хотите создать? ");
                            int numPoints = Convert.ToInt32(Console.ReadLine());
                            Point[] points = new Point[numPoints];
                            if (numPoints != 4) throw new Exception("Не 4 точки ");
                            for (int i = 0; i < numPoints; i++)
                            {
                                Console.WriteLine("{0}:", i);
                                Console.Write("Введите X: ");
                                double x = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Введите Y: ");
                                double y = Convert.ToDouble(Console.ReadLine());
                                points[i] = new Point(x, y);
                            }

                            square = new Square(points);
                        }
                        catch (InvalidInputData e)
                        {
                            Console.WriteLine(e.Message);
                            square = new Square();
                        }
                    }
                        break;
                    case 2:
                    {
                        try
                        {
                            Console.Write("Введите номер точки: ");
                            int numPoint = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите X: ");
                            double x = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Введите Y: ");
                            double y = Convert.ToDouble(Console.ReadLine());
                            square[numPoint] = new Point(x, y);
                            Console.WriteLine("Точка изменена.");
                        }
                        catch (InvalidInputData e)
                        {
                            Console.WriteLine(e.Message);
                            square = new Square();
                        }
                    }
                        break;
                    case 4:
                        Console.WriteLine("Площадь многоугольника: {0}", square.Area);
                        break;
                    case 3:
                        square.Info();
                        break;
                    default:
                        menu = false;
                        Console.WriteLine("Нажмите любую клавишу, чтобы выйти...");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}