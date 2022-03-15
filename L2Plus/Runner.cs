namespace L2Plus
{
    public class Runner
    {
        public static void Main(string[] args)
        {
            FirstQuestion fq = new();
            SecondQuestion sq = new();

            Console.WriteLine("1 task");
            fq.Task1();
            Console.WriteLine("2 task a");
            sq.TaskA(6, 6);
            Console.WriteLine("2 task b");
            sq.TaskB();
        }
    }
}