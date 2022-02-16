// Титов Павел Сергеевич, Л0, q19
// Найти значение y = f(x, t)
namespace L0
{
    public class Titov_Pavel_00_19
    {
        public static double F(int x, int t)
        {
            double firstTerm = (1 + Math.Pow(x, 2) - 2*x*t) / Math.Sin(t);
            double secondTerm = 1;
            double thirdTerm = Math.Sqrt(1 + Math.Pow(Math.Sin(x), 2) + Math.Pow(Math.Cos(x), 2)*t);
            return firstTerm + secondTerm + thirdTerm;
        }

        public static void Main(string[] args)
        {
            int x, t;
            Console.Write("Введите x: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите t: ");
            t = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(F(x, t));
        }
    }
}