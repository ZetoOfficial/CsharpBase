// В файле хранится информация (в соответствии с вариантом). Для обработки информации создать класс. 
// Дополнить задание своими методами (минимум 3). 
// 17. Информация в БД
// - название груза
// - дата отгрузки
// - номер вагона
// - стоимость перевозки
// а) Получить список номеров вагонов, использовавшихся в первом квартале заданного года.
// б) Найти среднюю стоимость перевозки угля.
// с) Упорядочить данные по дате отгрузки.
using FileHelpers;

namespace L5
{
    [DelimitedRecord(",")]
    [IgnoreFirst()]
    public class Item
    {
        public string? Name;
        public int VagonNumber;
        [FieldConverter(ConverterKind.Date, "dd-MM-yyyy")]
        public DateTime Date;
        public int Price;
    }

    public class Working
    {
        public string Filepath
        {
            get; set;
        }
        public Working(string filepath)
        {
            Filepath = filepath;
        }
        public List<int> GetVagonsNumber()
        {
            var engine = new FileHelperEngine<Item>();
            var records = engine.ReadFile(Filepath);
            List<int> vagonNumbers = new();
            foreach (var item in records)
            {
                if ((item.Date.Month + 2) / 3 == 1)
                    vagonNumbers.Add(item.VagonNumber);
            }
            return vagonNumbers;
        }
        public double AverageCostItem()
        {
            var engine = new FileHelperEngine<Item>();
            var records = engine.ReadFile(Filepath);
            int average = 0;
            foreach (var item in records)
            {
                average += item.Price;
            }
            if (records.Length == 0)
                throw new DivideByZeroException("Деление на ноль невозможно");
            return average / records.Length;
        }
        public void SortedDataByDate()
        {
            var engine = new FileHelperEngine<Item>();
            var records = engine.ReadFile(Filepath);

            records.OrderBy(i => i.Date);

            foreach (var item in records)
                Console.WriteLine($"{item.Name} {item.VagonNumber} {item.Date} {item.Price}");
        }

        public int GetMinCost()
        {
            var engine = new FileHelperEngine<Item>();
            var records = engine.ReadFile(Filepath);
            return records.Min(item => item.Price);
        }
        public int GetMaxCost()
        {
            var engine = new FileHelperEngine<Item>();
            var records = engine.ReadFile(Filepath);
            return records.Max(item => item.Price);
        }
        public int GetSumPrice()
        {
            var engine = new FileHelperEngine<Item>();
            var records = engine.ReadFile(Filepath);
            return records.Sum(item => item.Price);
        }
    }
}