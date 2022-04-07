namespace L5
{
    class Program
    {
        public static void Main(string[] args)
        {
            Titov_Pavel_05_01 ft = new();
            Console.WriteLine(ft.Task1("file.txt"));
            Titov_Pavel_05_02 sd = new();
            sd.Task2("file2.txt");
            Working wr = new();
            wr.Filepath = "file.csv";
            foreach (var item in wr.GetVagonsNumber())
                Console.Write($"{item} ");
            Console.WriteLine();
            Console.WriteLine(wr.AverageCostItem());
            wr.SortedDataByDate();
        }
    }
}