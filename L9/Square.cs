namespace L9;

public delegate void EventHandler(double value);

public class Square
{
    private Point[] _points;
    event EventHandler AreaEvent;

    void AreaEqualsToOne(double oldArea)
    {
        Console.WriteLine("Старая площадь равна {0}", oldArea);
        Console.WriteLine("Новая площадь равна 1");
    }

    public Point[] Points
    {
        get => _points;
        set => _points = value;
    }

    public double Area
    {
        get
        {
            double ab = VectorLenght(Vector(Points[0], Points[1]));
            double bc = VectorLenght(Vector(Points[1], Points[2]));
            double ca = VectorLenght(Vector(Points[2], Points[0]));
            double p = (ab + bc + ca) / 2;
            return Math.Abs(p * (p - ab) * (p - bc) * (p - ca));
        }
    }

    public Point this[int index]
    {
        get
        {
            if (index < 0 || index >= _points.Length)
                throw new IndexOutOfRangeException("Такой точки нет. Вы вышли за границы массива точек.");
            return _points[index];
        }
        set
        {
            double area = 0;

            if (_points.Length >= 3)
                area = Area;

            Point[] points = _points;
            points[index] = value;

            if (area != 0 && Math.Abs(Area - 1) < 0.00001)
                AreaEvent?.Invoke(area);
        }
    }

    public Square()
    {
        Point[] points = { new(0, 0), new(0, 1), new(1, 1), new(1, 0) };
        AreaEvent += AreaEqualsToOne;
        Points = points;
    }

    public Square(Point[] points)
    {
        if (points[0].X == points[1].X && points[0].Y == points[1].Y) throw new InvalidInputData(points[1]);
        if (!IsValidPolygon(points)) throw new InvalidInputData(points[2]);
        AreaEvent += AreaEqualsToOne;
        Points = points;
    }

    public bool IsValidPolygon(Point[] points)
    {
        double ab = VectorLenght(Vector(points[0], points[1]));
        double bc = VectorLenght(Vector(points[1], points[2]));
        double ca = VectorLenght(Vector(points[2], points[0]));
        if (ab * bc * ca < 0.01) return false;
        if (ab + bc < ca) return false;
        if (ca + bc < ab) return false;
        if (ca + ab < bc) return false;
        return true;
    }

    private double SideTurn(Point ab, Point bc)
    {
        return ab.X * bc.Y - ab.Y * bc.X;
    }

    private Point Vector(Point p1, Point p2)
    {
        return new Point(p2.X - p1.X, p2.Y - p1.Y);
    }

    private double VectorLenght(Point side)
    {
        return Math.Sqrt((side.X * side.X) + (side.Y * side.Y));
    }

    public void Info()
    {
        for (var i = 0; i < Points.Length; i++)
        {
            Console.WriteLine(i == Points.Length - 1
                ? $"Сторона {this[i]} {this[0]}"
                : $"Сторона {this[i]} {this[i + 1]}");
        }
    }
}