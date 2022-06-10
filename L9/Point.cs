namespace L9;

public class Point
{
    private string _nextName = "A";
    private int _nextNameNum = 0;

    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;

        Name = _nextName;
        if (_nextName.Length == 1 && _nextName == "Z" || _nextName.Length != 1 && _nextName[0] == 'Z')
        {
            _nextNameNum += 1;
            _nextName = "A" + _nextNameNum;
        }
        else if (_nextName.Length != 1 && _nextName != "Z")
            _nextName = ((char)(_nextName[0] + 1)).ToString() + _nextNameNum;
        else
            _nextName = ((char)(_nextName[0] + 1)).ToString();
    }

    public override string ToString()
    {
        return $"{Name}: x={X} y={Y}";
    }
}