namespace L1
{
    public class Product // Класс Product с реализацией стандартных методов
    {
        string name; // Атрибут с названием товара
        double cost; // Атрибут со стоимостью
        bool isStock; // Атрибут есть ли в наличии
        // Конструкторы 
        public Product() { name = "Product"; cost = 0; isStock = false; }
        public Product(string n) { name = n; cost = 0; isStock = false; }
        public Product(string n, double c) { name = n; cost = c; isStock = false; }
        public Product(string n, double c, bool stock) { name = n; cost = c; isStock = stock; }
        // Свойства
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Cost
        {
            get { return cost; }
            set { cost = value > 0 ? value : 1; }
        }

        public bool IsStock
        {
            get { return isStock; }
            set { isStock = value; }
        }

        public double AddCost
        {
            set { cost += value; }
        }

        public double RemoveCost
        {
            set { if (cost - value >= 0) cost -= value; else cost = 0; }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"╔═══════════╦═══════════╦═══════════╗");
            Console.WriteLine($"║{"Название",10} ║{"Стоимость",10} ║{"В наличии",10} ║");
            Console.WriteLine($"╠═══════════╬═══════════╬═══════════╣");
            Console.WriteLine($"║{Name,10} ║ {Cost,9} ║ {IsStock,9} ║");
            Console.WriteLine($"╚═══════════╩═══════════╩═══════════╝");
        }
    }
}