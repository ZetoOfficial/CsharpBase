namespace L2Plus
{
    public class SecondQuestion
    {
        public int[,] GenArray(int n, int m)
        {
            Random rnd = new Random();
            int[,] arr = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    arr[i, j] = rnd.Next() % 10;
            return arr;
        }

        public void ShowArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0,2} ", arr[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void TaskA(int n, int m)
        {
            // Дан двумерный массив из N строк и M столбцов. 
            // Переставить первые три и последние три строки, сохранив порядок их следования. 
            int[,] arr = GenArray(n, m);

            Console.WriteLine("before:");
            ShowArray(arr);
            for (int q = 0; q < n; q++)
            {
                for (int i = 0; i < 3; i++)
                {
                    (arr[i, q], arr[n - 3 + i, q]) = (arr[n - 3 + i, q], arr[i, q]);
                }
            }
            Console.WriteLine("after:");
            ShowArray(arr);
        }
        public void TaskB()
        {
            // Дан двумерный массив из пяти строк и двадцати столбцов.
            // Переставить первые три и последние три столбца, сохранив порядок их следования. 
            int[,] arr = GenArray(5, 20);
            Console.WriteLine("before:");
            ShowArray(arr);
            for (int q = 0; q < 5; q++)
            {
                for (int i = 0; i < 3; i++)
                {
                    (arr[q, i], arr[q, 20 - 3 + i]) = (arr[q, 20 - 3 + i], arr[q, i]);
                }
            }
            Console.WriteLine("after:");
            ShowArray(arr);
        }
    }
}