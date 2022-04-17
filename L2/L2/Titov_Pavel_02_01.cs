namespace L2
{
    public class Tasks
    {
        public double[] CreateDoubleArr(int n, int t1, int t2)
        {
            double[] a = new double[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = Math.Round(rnd.NextDouble() * (t2 - t1) + t1, 2);
            return a;
        }

        public int[] CreateIntArr(int n, int t1, int t2)
        {
            int[] a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(t1, t2);
            return a;
        }

        public void ShowArray(int[] a)
        {
            foreach (var i in a)
                Console.Write($"{a[i]} ");
        }

        public void Task1()
        {
            const int n = 6;
            int[] a = CreateIntArr(n, -10, 11);
            ShowArray(a);

            // a
            long sum = 0;
            int num = 0;
            foreach (var i in a)
                if (i < 0) { sum += i; num++; }
            Console.WriteLine($"Сумма отрицательных элементов: {sum}");
            Console.WriteLine($"Кол-во отрицательных: {num}");

            // b
            int max = a[0];
            foreach (var i in a)
                if (i > max) max = i;
            Console.WriteLine($"Максимальный элемент: {max}");
        }

        public void Task2()
        {
            const int n = 20;
            int[] a = CreateIntArr(n, -10, 11);
            ShowArray(a);

            bool flag = true;
            for (int i = 0; i < n - 1; i++)
                if (a[i + 1] <= a[i]) flag = false;
            Console.WriteLine($"Массив упорядочен {(flag ? "по возрастанию" : "плохо")}");
        }

        public void Task3()
        {
            const int n = 50;
            int[] a = CreateIntArr(n, -10, 11);
            Console.WriteLine("3 задание:");

            // a) количество отличных от последнего элемента;
            int cntUniqueElemetns = a.Where(elem => a.Last() != elem).Count();
            Console.WriteLine($"a) Кол-во отличных от последнего элемента: {cntUniqueElemetns}");

            // b) кол-во макс элементов
            int cntMaxElements = a.Where(elem => a.Max() != elem).Count();
            Console.WriteLine($"b) Кол-во макс элементов: {cntMaxElements}");

            // c) Номера элементов, являющихся полными квадратами (1, 4, 9, 16, и т. д.) 
            Console.WriteLine($"c) Номера элементов, являющихся полными квадратами (1, 4, 9, 16, и т. д.)");
            foreach (var el in a)
                if (el > 0 && Math.Sqrt(el) % 1 == 0) Console.Write($"{el}, ");
            Console.WriteLine();

            // d) среднее геометрическое нечётных положительных чисел.
            double agr = 1.0;
            foreach (var el in a)
                if (el % 2 != 0 && el > 0)
                    agr *= el;
            int okNums = a.Where(elem => elem % 2 != 0 && elem > 0).Count();
            Console.WriteLine($"d) Среднее геометрическое нечётных положительных чисел: {Math.Round(Math.Pow(agr, 1.0 / okNums), 2)}");

            int cnt = 0;
            for (var i = 1; i < a.Length; i++)
            {
                for (var j = 0; j < a.Length - i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        cnt++;
                    }
                }
            }
            Console.WriteLine("e) Дан массив из 50 чисел. Используя сортировку массива, определите:");
            Console.WriteLine($"\tf) Значение третьего минимума: {a[2]}");
            Console.WriteLine($"\tg) Кол-во уникальных элементов: {a.Distinct().Count()}");
            Console.WriteLine($"\th) Кол-во перестановок: {cnt}");

            Console.WriteLine();
        }

        public void Task4()
        {
            const int n = 366; // 366 элементов, потому что чуть ниже идёт сдвиг на 1, который лучше не менять. Поэтому элементов на 1 больше, зато первый пустым можно сделать)
            double[] t = CreateDoubleArr(n, -9, 9);
            Console.WriteLine("4 задание:");

            Dictionary<int, double[]> months = new Dictionary<int, double[]>()
            {
                [1] = new double[31],
                [2] = new double[28],
                [3] = new double[31],
                [4] = new double[30],
                [5] = new double[31],
                [6] = new double[30],
                [7] = new double[31],
                [8] = new double[31],
                [9] = new double[30],
                [10] = new double[31],
                [11] = new double[30],
                [12] = new double[31],
            };

            int[] lastDaysOfTheMonth = new int[13]; //  { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 }
            // Для формирования строки выше используется этот код
            lastDaysOfTheMonth[0] = 0;
            for (int i = 1; i < 12; i++)
                lastDaysOfTheMonth[i] = lastDaysOfTheMonth[i - 1] + months[i].Length;

            for (int i = 1; i < 13; i++)
            {
                double[] tempArr = new double[months[i].Length];
                for (int j = lastDaysOfTheMonth[i - 1] + 1, q = 0; j <= lastDaysOfTheMonth[i]; j++)
                {
                    tempArr[q] = t[j];
                    q++;
                }
                months[i] = tempArr;
            }
            double[] temperatureA = new double[2] { -10000, 0 };
            double[] temperatureB = new double[2] { 0, 0 };
            double[] temperatureC = new double[2] { -10000, 0 };
            double[] temperatureD = new double[2] { 0, 0 };

            foreach (var item in months)
            {
                double averageTemperatureThisMonth = Math.Round(item.Value.Sum() / item.Value.Length, 1);
                if (temperatureA[0] < averageTemperatureThisMonth)
                {
                    temperatureA[0] = averageTemperatureThisMonth;
                    temperatureA[1] = item.Key;
                }
                int cntNegativeDaysThisMonth = months[item.Key].Where(elem => elem < 0).Count();
                if (temperatureB[0] < cntNegativeDaysThisMonth)
                {
                    temperatureB[0] = cntNegativeDaysThisMonth;
                    temperatureB[1] = item.Key;
                }
                double minTempThisMonth = Math.Round(item.Value.Min(), 1);
                if (temperatureC[0] < minTempThisMonth)
                {
                    temperatureC[0] = minTempThisMonth;
                    temperatureC[1] = item.Key;
                }
                double maxTempThisMonthDecada = Math.Round(item.Value[20..item.Value.Length].Max(), 1);
                if (temperatureD[0] < maxTempThisMonthDecada)
                {
                    temperatureD[0] = maxTempThisMonthDecada;
                    temperatureD[1] = item.Key;
                }
                Console.WriteLine($"Месяц: {item.Key} | Дней: {item.Value.Length} | 3 деката: {maxTempThisMonthDecada} | Min C°: {minTempThisMonth} | Отрицательная C°: {cntNegativeDaysThisMonth} | Средняя C°: {averageTemperatureThisMonth}");
            }
            Console.WriteLine();
            Console.WriteLine("a) С максимальной среднемесячной температурой (C°)");
            Console.WriteLine($"Максимальная C°: {temperatureA[0]}");
            Console.WriteLine($"Месяц: {temperatureA[1]}");
            Console.WriteLine();
            Console.WriteLine($"b) С наибольшим количеством отрицательных температур (C°)");
            Console.WriteLine($"Количество дней с отрицательной C°: {temperatureB[0]}");
            Console.WriteLine($"Месяц: {temperatureB[1]}");
            Console.WriteLine();
            Console.WriteLine($"c) С минимальной годовой температурой (C°)");
            Console.WriteLine($"Минимальная C°: {temperatureC[0]}");
            Console.WriteLine($"Месяц: {temperatureC[1]}");
            Console.WriteLine();
            Console.WriteLine($"d) С максимальной температурой (C°) в третьей декаде");
            Console.WriteLine($"Максимальная C°: {temperatureD[0]}");
            Console.WriteLine($"Месяц: {temperatureD[1]}");
            Console.WriteLine();
        }

        public void Task5()
        {
            const int n = 10;
            string[] name = { "Ваня", "Гена", "Олег", "Коля", "Маша", "Нина", "Оля", "Таня", "Федя", "Галя" };
            bool[] pol = { true, true, true, true, false, false, false, false, true, false };
            double[] ves = CreateDoubleArr(n, 40, 150); //вес в кг в диапазоне от 40 до 150
            int[] rost = CreateIntArr(n, 140, 200); //рост в см в диапазоне от 140 до 200
            Console.WriteLine("5 задание:");

            int[] chelA = new int[3] { 0, 0, 0 }; // index, ves, rost

            double sum = 0;
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                if (pol[i] && rost[i] > chelA[2])
                {
                    chelA[0] = i;
                    chelA[2] = rost[i];
                }
                if (!pol[i])
                {
                    sum += ves[i];
                    cnt++;
                }
                string imtOk = IMT(ves[i], rost[i]) <= 25 && 18 >= IMT(ves[i], rost[i]) ? "В норме" : "Плохо";
                string sex = pol[i] ? "Мужской" : "Женский";
                Console.WriteLine($"Имя: {name[i]} | Пол: {sex} | Вес: {ves[i]} | Рост: {rost[i]} | ИМТ: {IMT(ves[i], rost[i])} ({imtOk})");
            }

            Console.WriteLine($"a) Определите имя самого высокого мужчины: {name[chelA[0]]}");
            double averageWeightOfWomen = Math.Round(sum / cnt, 2); // Average weight of women
            Console.WriteLine($"b) определите средний вес женщин: {averageWeightOfWomen}");
            Console.WriteLine($"c) определите индекс массы тела (ИМТ) для каждого (ок - выше);");
            Console.WriteLine($"d) выведите на экран информацию (имя, рост, вес) о тех людях, чей ИМТ находится вне нормы;");
        }

        public double IMT(double ves, int rost)
        {
            return Math.Round(ves / Math.Pow(rost / 100.0, 2), 1);
        }
    }
}