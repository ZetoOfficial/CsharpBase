namespace L1
{
    public class Runner
    {
        public static void Main(string[] args)
        {
            Triangle t = new Triangle(1, 1, 1);
            Console.WriteLine(t.Info());

            Product p = new();
            p.ShowInfo();
        }
    }
}