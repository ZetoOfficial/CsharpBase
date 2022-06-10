namespace L8;

public interface ILinkedPro
{
    LinkedListNode<string> AddLast(string value);
    LinkedListNode<string> InsertAfter(LinkedListNode<string> node, string value);
    void Append(LinkedList<string> linkedList2);
    LinkedList<string> Reversed();
    void Keep(int from, int to);
    int Sum();
}

public class LinkedPro : ILinkedPro
{
    private LinkedList<string> _linkedList = new();

    public LinkedListNode<string> AddLast(string value) => _linkedList.AddLast(value);

    public LinkedListNode<string> InsertAfter(LinkedListNode<string> node, string value) =>
        _linkedList.AddAfter(node, value);

    public void Append(LinkedList<string> linkedList2)
    {
        foreach (var item in linkedList2)
        {
            AddLast(item);
        }
    }

    public LinkedList<string> Reversed()
    {
        LinkedList<string> newList = new LinkedList<string>();
        LinkedList<string> sList = _linkedList;
        while (_linkedList.Any())
        {
            newList.AddLast(sList.Last());
            sList.RemoveLast();
        }

        return newList;
    }

    public void Keep(int from, int to)
    {
        if ((from > to) || (from < 0) || (to > _linkedList.Count - 1)) throw new Exception("Выход за границы");

        LinkedList<string> newLinked = new LinkedList<string>(_linkedList.Skip(from).Take(to - from));
        for (var recentNode = newLinked.First; recentNode != null; recentNode = recentNode.Next)
        {
            _linkedList.Remove(recentNode);
        }

        _linkedList = newLinked;
    }

    public int Sum()
    {
        Console.WriteLine("Нельзя расчитать сумму для списка строк");
        return _linkedList.Count();
    }

    public LinkedList<string> AddL2toL1Start(LinkedList<string> l1, LinkedList<string> l2)
    {
        foreach (var item in l2)
        {
            l1.AddFirst(item);
        }

        return l1;
    }

    public LinkedList<string> RemoveL1elementsByL2Element(LinkedList<string> l1, LinkedList<string> l2)
    {
        string removeItem = l2.Last();
        foreach (var item in l1)
        {
            if (item == removeItem)
            {
                l1.Remove(item);
            }
        }

        return l1;
    }
}

public class Program
{
    public static void Main()
    {
        Random rnd = new Random(40);
        LinkedPro lp = new();

        var node1 = lp.AddLast("1");
        var node2 = lp.AddLast("2");
        var node3 = lp.AddLast("3");
        IEnumerable<string> enumerable = Enumerable.Repeat(0, 5).Select(x => Convert.ToString(rnd.Next(1, 10)));
        lp.Append(new LinkedList<string>(enumerable));
        var reversed = lp.Reversed();
        lp.InsertAfter(node1, "10");
        lp.Keep(1, 2);
        lp.Sum();
    }
}