namespace L3
{
    public class Runner
    {
        public static void Main(string[] args)
        {
            FirstQuestion fq = new();
            SecondQuestion sq = new();
            ThirdQuestion tq = new();

            // 1
            int n = 6;
            int[] x = new int[n];
            Random rnd = new();
            for (int i = 0; i < n; i++)
            {
                x[i] = rnd.Next(-10, 10) % 10;
            }
            Console.WriteLine(fq.Task(x));

            // 2
            Console.WriteLine(sq.Task(x));

            // 3
            int[,] arr = tq.GenArray(5, 5);
            Console.WriteLine(tq.TaskA(arr, 4));
            Console.WriteLine(tq.TaskB(arr, 4));
        }
    }
}