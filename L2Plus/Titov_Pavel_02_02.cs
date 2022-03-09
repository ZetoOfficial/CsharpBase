namespace L2Plus
{
    public class SecondQuestion
    {
        public int[,] GenArray(int n, int q)
        {
            Random rnd = new Random();
            int[,] arr = new int[n, q];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < q; j++)
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

        public void TaskA(int n)
        {
            // Дан двумерный массив из N строк и M столбцов. 
            // Переставить первые три и последние три строки, сохранив порядок их следования. 
            int[,] arr = GenArray(n, n);

            ShowArray(arr);
            for (int q = 0; q < n; q++)
            {
                for (int i = 0; i < 3; i++)
                {
                    (arr[i, q], arr[n - 3 + i, q]) = (arr[n - 3 + i, q], arr[i, q]);
                }
            }
            Console.WriteLine();
            ShowArray(arr);
        }
        public void TaskB()
        {
            // Дан двумерный массив из пяти строк и двадцати столбцов.
            // Переставить первые три и последние три столбца, сохранив порядок их следования. 
            int[,] arr = GenArray(5, 20);
            ShowArray(arr);
            for (int q = 0; q < 5; q++)
            {
                for (int i = 0; i < 3; i++)
                {
                    (arr[q, i], arr[q, 20 - 3 + i]) = (arr[q, 20 - 3 + i], arr[q, i]);
                }
            }
            Console.WriteLine();
            ShowArray(arr);
        }
    }
}