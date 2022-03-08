namespace L2Plus
{
    public class SecondQuestion
    {
        public void TaskA()
        {
            // Дан двумерный массив из N строк и M столбцов. 
            // Переставить первые три и последние три строки, сохранив порядок их следования. 
            int n = 2;
            Random rnd = new Random();
            int[,] arr = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    arr[i, j] = rnd.Next();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3} ", arr[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void TaskB()
        {

        }
    }
}