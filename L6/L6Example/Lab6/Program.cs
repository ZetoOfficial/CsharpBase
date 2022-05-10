using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            //пример работы с объектом одного из дочерних классов
            Tiger tiger = new Tiger("Амур", 60, 8);
            Console.WriteLine(tiger);
            // несколько раз вызовем делегат, значение веса изменяется и сохраняется для объекта
            tiger.Action();
            Console.WriteLine(tiger);
            tiger.Action();
            Console.WriteLine(tiger);
            // вызов метода второго делегата. здесь нужно привести объект к типу делегата и вызывать метод. изменения в объекте также сохраняются
            ((INamed)tiger).Change();
            Console.WriteLine(tiger);
            //---------------------------------------------------
            Console.ReadKey();
        }
    }
}
