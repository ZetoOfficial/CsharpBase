namespace L2Plus
{
    public class Program
    {
        public static void Main()
        {
            List<string> animals = new List<string> { "собака", "собака", "кошка", "жираф" };
            var animalsUnique = animals.Distinct();
            foreach (var item in animals)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach (var item in animalsUnique)
            {
                Console.Write($"{item} ");
            }
        }
    }
}