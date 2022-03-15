namespace L3
{
    public class ThirdQuestion
    {
        public int[,] GenArray(int n, int q)
        {
            Random rnd = new Random();
            int[,] arr = new int[n, q];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < q; j++)
                    arr[i, j] = rnd.Next(1, 10) % 10;
            return arr;
        }
        public void ShowArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    // Console.Write($"{arr[i, j]}[{i};{j}] ");
                    Console.Write("{0,2} ", arr[i, j]);
                }
                Console.WriteLine();
            }
        }
        public bool TaskA(int[,] arr, int k)
        {
            if (k >= arr.GetLength(0)) throw new Exception("k столбца не существует");

            int mainDiagonal = 1;
            int kStolb = 1;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == j)
                        mainDiagonal *= arr[i, j];
                    if (j == k)
                        kStolb *= arr[i, k];
                }
            }
            return kStolb < mainDiagonal;
        }
        public bool TaskB(int[,] arr, int k)
        {
            bool flag = true;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1) - 1; j++)
                {
                    flag = arr[k, j] > arr[k, j + 1];
                    if (!flag) break;
                }
            }
            return flag;
        }
    }
}