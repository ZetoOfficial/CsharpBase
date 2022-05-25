namespace test_lab_7;

public struct Student : IComparable
{
    public string Surname;
    public string DateOfBirth;
    public Institute Institute;
    public double AverageScore;
    public double Age => (int)Math.Floor((DateTime.Now - Convert.ToDateTime(DateOfBirth)).TotalDays / 365.25D);
    public int CompareTo(object obj) => Age.CompareTo(((Student)obj).Age);
}

public struct InstituteMenu
{
    public Institute Institute;
    public int Top;
    public int Left;
    public int Index;
    public int StudentsCount;
}