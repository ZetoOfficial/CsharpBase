using System;
using System.Collections.Generic;
using System.IO; // потоковывй ввод вывод (для сохраниения в файлы)
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization; // нужно для сериализации объектов и сохранения в файлы

namespace Lab2
{
    class Program
    {
        static void Serialize(List<PublishingOffice> publishingOffices)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PublishingOffice[])); // для сериализации указывается массив объектов базового класса
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("list.xml", FileMode.OpenOrCreate)) // для безопасной работы с потоком используется using
            {
                xmlSerializer.Serialize(fs, publishingOffices.ToArray()); // сериализация, передается массив объектов
                Console.WriteLine("Данные сохранены");
                Console.ReadKey();
            }
        }
        static List<PublishingOffice> Deserialize()
        {
            try
            {
                List<PublishingOffice> publishingOffices = new List<PublishingOffice>();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(PublishingOffice[])); // по аналогии с сериализацией
                using (FileStream fs = new FileStream("list.xml", FileMode.OpenOrCreate))
                {
                    PublishingOffice[] temp = xmlSerializer.Deserialize(fs) as PublishingOffice[];
                    publishingOffices.AddRange(temp);
                }
                Console.WriteLine("Данные загружены");
                return publishingOffices;
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось загрузить данные. {0}", e.Message);
                return new List<PublishingOffice>();
            }
        }
        static void PrintList(List<PublishingOffice> publishingOffices)
        {
            int index = 0;
            if (publishingOffices.Count == 0)
                Console.WriteLine("Список пуст");
            else
                foreach (var item in publishingOffices)
                {
                    Console.WriteLine("{0}:", index);
                    index++;
                    if (item is Article)
                    {
                        ((Article)item).Print();
                    }
                    else if (item is Section)
                    {
                        ((Section)item).Print();
                    }
                    else if (item is Journal)
                    {
                        ((Journal)item).Print();
                    }
                    else
                    {
                        item.Print();
                    }
                    Console.WriteLine("--------------------------------------");
                }
        }
        static void Add(List<PublishingOffice> publishingOffices) // метод добавления элемента в список, список передается в качестве параметра
        {
            try
            {
                Console.Clear();
                Console.WriteLine("1. Издательство");
                Console.WriteLine("2. Журнал");
                Console.WriteLine("3. Раздел");
                Console.WriteLine("4. Статья");
                int c = int.Parse(Console.ReadLine()); // ввод пункта меню
                PublishingOffice temp = new PublishingOffice(); // создание переменной базового класса, в эту же переменную потом можно присовить объекты других классов
                switch (c)
                {
                    case 1:
                        // тут ввод данных с клавиатуры для создания объекта класса, эти данные передаются в конструктор
                        temp = new PublishingOffice();
                        break;
                    case 2:
                        // тут ввод данных с клавиатуры для создания объекта класса, эти данные передаются в конструктор
                        temp = new Journal();
                        break;
                    case 3:
                        // тут ввод данных с клавиатуры для создания объекта класса, эти данные передаются в конструктор
                        temp = new Section();
                        break;
                    case 4:
                        // тут ввод данных с клавиатуры для создания объекта класса, эти данные передаются в конструктор
                        temp = new Article();
                        break;
                    default:
                        Console.WriteLine("Такого класса нет");
                        break;
                }
                publishingOffices.Add(temp); // добавление в список
            }
            catch // на случай, если где то при создании объекта генерируется исключение, чтобы не добавлять в список объект, который создать не получилось
            {
                Console.WriteLine("Операция не может быть выполнена!");
            }
        }
        static void Remove(List<PublishingOffice> publishingOffices)// метод для удаления из списка
        // удаление просто по индексу элемента в списке
        {
            try
            {
                Console.WriteLine("Введите номер элемента, который хотите удалить:");
                int c = int.Parse(Console.ReadLine());
                if (c <= 0 || c >= publishingOffices.Count)
                    throw new Exception();
                else
                {
                    publishingOffices.RemoveAt(c);
                }
            }
            catch
            {
                Console.WriteLine("Операция не может быть выполнена!");
            }
        }
        static void WorkWithObject(List<PublishingOffice> publishingOffices)
        {
            try
            {
                Console.WriteLine("Введите номер элемента, с которым хотите работать:");
                int c = int.Parse(Console.ReadLine());
                if (c <= 0 || c >= publishingOffices.Count)
                    throw new Exception();
                else
                {
                    if (publishingOffices[c] is Article) // список методов выводится в зависимости от выбранного объекта
                    {
                        Article article = (Article)publishingOffices[c]; // временная переменная, нужна, если методы каким то образом изменяют поля 
                        // в случае если поля изменяются, как например в методе 2, то на месте под индексом "с" в списке должен встать измененный элемент
                        Console.WriteLine("1. Method1");
                        Console.WriteLine("2. Method2");
                        int c1 = int.Parse(Console.ReadLine());
                        switch (c1)
                        {
                            case 1:
                                article.Method1();
                                break;
                            case 2:
                                article.Method2();
                                publishingOffices[c] = article;
                                break;
                            default:
                                Console.WriteLine("Такого метода нет");
                                break;
                        }
                    }
                    // для остальных классов должно быть сделано по аналогии
                    else if (publishingOffices[c] is Section)
                    {

                    }
                    else if (publishingOffices[c] is Journal)
                    {

                    }
                    else
                    {

                    }
                }
            }
            catch
            {
                Console.WriteLine("Операция не может быть выполнена!");
            }
        }

        static void Main(string[] args)
        {
            List<PublishingOffice> publishingOffices = Deserialize(); // в самом начале загружаем данные из файла
            Console.WriteLine("Нажмите любую клавишу для начала работы");
            Console.ReadKey();
            try
            {
                bool work = true;
                while (work)
                {
                    Console.Clear();
                    Console.WriteLine(" * МЕНЮ * ");
                    Console.WriteLine("1. Вывести весь список");
                    Console.WriteLine("2. Добавить новый элемент в список");
                    Console.WriteLine("3. Удалить элемент из списка");
                    Console.WriteLine("4. Работа с элементом");
                    Console.WriteLine("Любая другая клавиша - выход");
                    int c = int.Parse(Console.ReadLine());// ввод пункта меню
                    switch (c)
                    {
                        case 1:
                            PrintList(publishingOffices);
                            break;
                        case 2:
                            Add(publishingOffices);
                            break;
                        case 3:
                            Remove(publishingOffices);
                            break;
                        case 4:
                            WorkWithObject(publishingOffices);
                            break;
                        default:
                            work = false;
                            break;
                    }
                    if (work)
                    {
                        Console.WriteLine("Чтобы продолжить нажмите любую клавишу");
                        Console.ReadKey();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Возникла ошибка. Принудительный выход");
            }
            Serialize(publishingOffices); // в конце работы сохраняем список в файл
        }
    }
}
