namespace L9;

class Point {
    public double X { get; set; }
    public double Y { get; set; }
    public Point() { X = 0; Y = 0; }
    public Point(double x, double y) {
        X = x;
        Y = y;
    }
}

class Square {
    private List<Point> _points = new List<Point>();
    public Point this[int i] { get => _points[i]; set => _points[i] = value; }
    public double A { get; set; }
    public Square() { A = 1; }
    public Square(double a) { A = a > 0 ? a : throw new ArgumentException("Сторона не может быть меньше 0"); }
    public double S() {
        double s = Math.Pow(A, 2);
        if (Math.Abs(s - 1) < 0.000001) { Notify(); }
        return s;
    }
    public delegate void EventHandler(double oldS);
    public event EventHandler Notify;
}