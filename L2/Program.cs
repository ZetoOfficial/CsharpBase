namespace L2
{
    public class Tasks
    {
        public static double[] CreateDoubleArr(int n, int t1, int t2)
        {   
            double[] a = new double[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = Math.Round(rnd.NextDouble() * (t2 - t1) + t1, 2);
            return a;
        }
        public static int[] CreateIntArr(int n, int t1, int t2)
        {   
            int[] a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(t1, t2);
            return a;
        }

        public static void ShowArray(int[] a)
        {
            Console.WriteLine("Source arr:");
            for (int i = 0; i < a.Length; ++i)
                Console.WriteLine("\t" + a[i]);
            Console.WriteLine();
        }

        public static int[] SortArray(int[] a)
        {
            int len = a.Length;
            int cnt = 0;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
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
            return a;
        }

        public static void Task1()
        {
            const int n = 6;
            int[] a = CreateIntArr(n, -10, 11);
            ShowArray(a);
            
            // a
            long sum = 0;
            int num = 0;
            for (int i = 0; i<n;i++)
            {
                if (a[i] < 0)
                {
                    sum += a[i];
                    ++num;
                }
            }
            Console.WriteLine($"Сумма отрицательных элементов: {sum}");
            Console.WriteLine($"Кол-во отрицательных: {num}");
        
            // b
            int max = a[0];
            for (int i = 1; i < n; i++)
                if (a[i] > max) max = a[i];
            Console.WriteLine($"Max el: {max}");
        }

        public static void Task2()
        {
            const int n = 20;
            int[] a = CreateIntArr(n, -10, 11);
            ShowArray(a);

            bool f = true;
            for (int i = 0; i < n -1 ; i++)
                if (a[i + 1] <= a[i]) f = false;

            if (f) Console.WriteLine("Массив упорядочен по возрастанию");
            else Console.WriteLine("Не упорядочен по возрастанию");
        }

        public static void Task3()
        {
            const int n = 50;
            int[] a = CreateIntArr(n, -10, 11);

            // a) количество отличных от последнего элемента;
            int cnt = 0;
            for (int i = 0; i < n; i++)
                if (a.Last() != a[i]) cnt++;
            Console.WriteLine($"Кол-во отличных от последнего элемента: {cnt}");
            
            // b) кол-во макс элементов
            cnt = 0;
            for (int i = 0; i < n; i++)
                if (a.Max() == a[i]) cnt++;
            Console.WriteLine($"Кол-во макс элементов: {cnt}");

            // c) Номера элементов, являющихся полными квадратами (1, 4, 9, 16, и т. д.) 
            Console.WriteLine("Номера элементов, являющихся полными квадратами (1, 4, 9, 16, и т. д.)");
            for (int i = 0; i < n; i++)
                if (Math.Sqrt(a[i]) % 1 == 0) Console.Write($"{i}({a[i]}) ");
            
            // d) среднее геометрическое нечётных положительных чисел.
            cnt = 0;
            double agr = 1.0;
            for (int i = 0; i < n; i++)
                if (a[i] % 2 != 0 && a[i] > 0){
                    agr *= a[i];
                    cnt++;
                }
            Console.WriteLine($"Среднее геометрическое нечётных положительных чисел: {Math.Pow(agr, 1.0 / cnt)}");

            cnt = 0;
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
            Console.WriteLine("Дан массив из 50 чисел. Используя сортировку массива, определите:");
            Console.WriteLine($"\tЗначение третьего минимума: {a[2]}");
            Console.WriteLine($"\tКол-во уникальных элементов: {a.Distinct().Count()}");
            Console.WriteLine($"\tКол-во перестановок: {cnt}");
        }

        public static void Task4()
        {
            const int n = 366;
            double[] t = CreateDoubleArr(n, -10, 11); // Заполнил темпой

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
            // int[] monthToDay = new int[13]{0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 365};
            int[] monthToDay = new int[13]{0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365};
            // monthToDay[0] = 0;
            // for (int i = 1; i < 12; i++)
            //     monthToDay[i] = monthToDay[i-1] + months[i].Length;
            // foreach (var item in monthToDay)
            //     Console.Write($"{item}, ");
            // return;
            for (int i = 1; i < 13; i++)
            {
                Console.WriteLine($"Month {i} {months[i].Length}:");
                double[] tempArr = new double[months[i].Length];
                for (int j = monthToDay[i-1]+1, q = 0; j <= monthToDay[i]; j++)
                {
                    // months[i] = t[j];
                    Console.Write($"{j} ");
                    tempArr[q] = t[j];
                    q++;
                }
                months[i] = tempArr;
                Console.WriteLine();
            }
            double[] tempA = new double[2]{-10000, 0};
            double[] tempB = new double[2]{0, 0};
            double[] tempC = new double[2]{-10000, 0};
            double[] tempD = new double[2]{0, 0};

            foreach (var item in months)
            {
                double tempThisMonth = Math.Round(months[item.Key].Sum() / months[item.Key].Length, 2);
                if (tempA[0] < tempThisMonth)
                {
                    tempA[0] = tempThisMonth;
                    tempA[1] = item.Key;
                }
                int tempMinusCount = months[item.Key].Where(elem => elem < 0).Count();
                if (tempB[0] < tempMinusCount)
                {
                    tempB[0] = tempMinusCount;
                    tempB[1] = item.Key;
                }
                double minTempThisMonth = Math.Round(months[item.Key].Min(), 2);
                if (tempC[0] < minTempThisMonth)
                {
                    tempC[0] = minTempThisMonth;
                    tempC[1] = item.Key;
                }
                double maxTempThisMonthDecada = Math.Round(months[item.Key][20..months[item.Key].Length].Max(), 2);
                if (tempD[0] < maxTempThisMonthDecada)
                {
                    tempD[0] = maxTempThisMonthDecada;
                    tempD[1] = item.Key;
                }
                Console.WriteLine($"Месяц: {item.Key} Значений: {months[item.Key].Length} 3 деката: {maxTempThisMonthDecada} Мин темпа: {minTempThisMonth} Отрц: {tempMinusCount} Темпа: {tempThisMonth}");
            }
            Console.WriteLine("С максимальной среднемесячной температурой");
            Console.WriteLine($"Макc темпа: {tempA[0]}");
            Console.WriteLine($"Месяц: {tempA[1]}");

            Console.WriteLine($"С наибольшим количеством отрицательных температур");
            Console.WriteLine($"Кол-во наим темп: {tempB[0]}");
            Console.WriteLine($"Месяц: {tempB[1]}");
            
            Console.WriteLine($"С минимальной годовой температурой");
            Console.WriteLine($"Мин темпа: {tempC[0]}");
            Console.WriteLine($"Месяц: {tempC[1]}");
            
            Console.WriteLine($"С максимальной температурой в третьей декаде");
            Console.WriteLine($"Max темп: {tempD[0]}");
            Console.WriteLine($"Месяц: {tempD[1]}");
            // foreach (var item in t)
            //     Console.Write($"{item} ");
            // Console.WriteLine();
            // foreach (var item in monthToDay)
            //     Console.Write($"{item} ");
        }
        public static void Task5()
        {   
            const int n = 10;
            string [] name = {"Ваня","Гена","Олег","Коля","Маша","Нина", "Оля", "Таня","Федя","Галя"};
            bool [] pol = {true,true,true,true,false,false,false,false, true, false};
            double [] ves = CreateDoubleArr(n, 40, 150); //вес в кг в диапазоне от 40 до 150
            int [] rost = CreateIntArr(n, 140, 200); //рост в см в диапазоне от 140 до 200

            Console.WriteLine("определите имя самого высокого мужчины;");
            int[] chelA = new int[3]{0, 0, 0}; // index, ves, rost
            // int[] chelB = new int[3]{0, 0, 0}; // index, ves, rost
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
                bool imtOk = 18 >= IMT(ves[i], rost[i]) && IMT(ves[i], rost[i]) <= 25;
                // bool imtOk = 18 >= IMT(ves[i], rost[i]) <= 25;
                Console.WriteLine($"NAME: {name[i]} MAN: {pol[i]} VES: {ves[i]} ROST: {rost[i]} IMT: {IMT(ves[i], rost[i])} ({imtOk})");
            }
            Console.WriteLine($"{name[chelA[0]]} - самый высокий");
            double srVesGirl = Math.Round(sum / cnt, 2);
            Console.WriteLine($"определите средний вес женщин; - {srVesGirl}");
            Console.WriteLine($"определите индекс массы тела (ИМТ) для каждого (ок - выше);");
            Console.WriteLine($"выведите на экран информацию (имя, рост, вес) о тех людях, чей ИМТ находится вне нормы.");
            Console.WriteLine($"отсортируйте массив name по алфавиту (при этом соответствующие значения роста и веса тоже должны быть отсортированы)");
        }

        public static double IMT(double ves, int rost)
        {
            return Math.Round(ves / Math.Pow(rost/100.0, 2), 2);
        }
        public static void Main(string[] args)
        {
            Task3();
            Task4();
            Task5();
        }
    }
}