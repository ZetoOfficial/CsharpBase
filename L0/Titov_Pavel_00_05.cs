// Титов Павел Сергеевич, Л0, q5
// Напишите программу, которая вычисляет длину окружности по известному радиусу.

namespace L0
{
    public class Titov_Pavel_00_05
    {
        public void ShowInfo()
        {
            Console.Write("Для вычисления длины окружности, введите радиус: ");
            double Raduis = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Длина окружности равна 2*π*{Raduis:f2}={2 * 3.14 * Raduis:f2}");
        }
    }
}