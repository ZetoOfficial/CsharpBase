namespace L2Plus
{
    public class FirstQuestion
    {
        public void Task1()
        {
            List<List<string>> animals = new List<List<string>>
            {
                new List<string> {"собака", "собака", "кошка", "жираф"},
                new List<string> {"собака", "кошка", "жираф"},
                new List<string> {"собака", "собака", "кошка"},
                new List<string> {"собака", "кошка", "жираф"},
            };

            Array.ForEach(animals.ToArray(), x => Console.WriteLine(string.Join(" ", x)));
            var result = animals.Select(y => y.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key))
                .Aggregate((a, b) => a.Intersect(b)).ToArray();
            Array.ForEach(result, x => Console.WriteLine(string.Join(" ", x)));
        }
    }
}