namespace L9;

public class InvalidInputData : Exception
{
    private readonly Point _poin;

    public override string Message => $"точка ({_poin.X}; {_poin.Y}) не подходит для построения квадрата";

    public InvalidInputData(Point poin)
    {
        _poin = poin;
    }
}