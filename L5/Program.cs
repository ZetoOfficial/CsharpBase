namespace L5
{
    class Program
    {
        public static void Main(string[] args)
        {
            Titov_Pavel_05_01 ft = new("file.txt");
            Console.WriteLine(ft.Task1());

            Titov_Pavel_05_02 sd = new("file2.txt");
            sd.Task2();

            Working wr = new("file.csv");
            foreach (var item in wr.GetVagonsNumber())
                Console.Write($"{item} ");
            Console.WriteLine();
            Console.WriteLine(wr.AverageCostItem());
            wr.SortedDataByDate();
        }
    }
}