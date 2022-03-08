namespace L1
{
    public class Triangle
    {
        double A1;
        double A2;
        double A3;

        public double CheckZero(double n)
        {
            return n == 0 ? throw new ArgumentException("No zero man") : n;
        }

        public Triangle() { A1 = 1; A2 = 1; A3 = 1; }

        public Triangle(double x, double y)
        {
            A1 = CheckZero(x);
            A2 = CheckZero(y);
            A3 = x + y / 2;
        }

        public Triangle(double x, double y, double z)
        {
            A1 = CheckZero(x);
            A2 = CheckZero(y);
            A3 = CheckZero(z);
        }

        public double GetP()
        {
            return A1 + A2 + A3;
        }

        public double GetS()
        {
            double p = GetP() / 2;
            return Math.Sqrt(p * (p - A1) * (p - A2) * (p - A3));
        }

        public bool IsEqual(Triangle t)
        {
            return GetS() == t.GetS();
        }

        public string Info()
        {
            string s = "Подробная информация: ";
            s += $"1) Первая сторона: {A1}\n";
            s += $"2) Вторая сторона: {A2}\n";
            s += $"3) Третья сторона: {A3}\n";
            s += $"4) Площадь: {GetP()}\n";
            s += $"5) Периметр: {GetS()}\n";
            return s;
        }
    }
}