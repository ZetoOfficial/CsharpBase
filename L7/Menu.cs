namespace test_lab_7;

public class Menu
{
    private const ConsoleColor DefaultColor = ConsoleColor.White;
    private List<InstituteMenu> _instituteMenus = new();
    private List<Student> _students = new();
    private readonly string _fill = new(' ', Console.WindowWidth);
    private bool _isWork;
    private int _lastActiveInstituteIndex = -1;

    private readonly ConsoleKey[] _pointer =
    {
        ConsoleKey.D1,
        ConsoleKey.D2,
        ConsoleKey.D3,
        ConsoleKey.D4,
        ConsoleKey.D5
    };

    public List<Student> Students { get => _students; set => _students = value; }

    public void Write(string text, ConsoleColor color = DefaultColor)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = DefaultColor;
    }

    public void WriteLine(string text, ConsoleColor color = DefaultColor)
    {
        Write(text + "\n", color);
    }

    public string[] GetInstitutesOrderByStudents()
    {
        return Enum
            .GetNames(typeof(Institute))
            .OrderByDescending(x => _students
                .Count(y => Enum
                    .GetName(typeof(Institute), y.Institute) == x))
            .ToArray();
    }

    public void InitializationMenu()
    {
        string[] institutes = GetInstitutesOrderByStudents();

        WriteLine("Список доступных институтов: ", ConsoleColor.DarkCyan);
        for (int i = 0; i < institutes.Length; i++)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            int studentsCount = _students.Count(el => el.Institute.ToString() == institutes[i]);
            WriteLine($"{i + 1,2} {institutes[i],-10} ({studentsCount} students)", ConsoleColor.Blue);

            _instituteMenus.Add(new InstituteMenu()
            {
                Index = i,
                Institute = (Institute)Enum.Parse(typeof(Institute), institutes[i]),
                Left = left,
                Top = top,
                StudentsCount = studentsCount
            });
        }

        WriteLine("Выберите институт", ConsoleColor.DarkCyan);
    }

    private void EnableInstitute(int index)
    {
        if (_lastActiveInstituteIndex >= 0)
            DisableInstitute(_lastActiveInstituteIndex);
        var institute = _instituteMenus[index];

        Console.SetCursorPosition(institute.Left, institute.Top);
        Write($"{institute.Index + 1,2} {institute.Institute,-10} ({institute.StudentsCount} students)",
            ConsoleColor.Red);
        LogMessage($"Выбран {institute.Institute}, для продолжения нажмите Enter", ConsoleColor.White);
        _lastActiveInstituteIndex = index;
    }

    private void DisableInstitute(int index)
    {
        var institute = _instituteMenus[index];

        Console.SetCursorPosition(institute.Left, institute.Top);
        Write($"{institute.Index + 1,2} {institute.Institute,-10} ({institute.StudentsCount} students)",
            ConsoleColor.Blue);
    }

    public void PrintCurrentStudentsInInstitute(Institute institute)
    {
        Console.WriteLine($"Институт: {institute}");
        Console.WriteLine($"|{"№",2} | {"Фамилия",10} | {"Cредний балл",15} | {"Возраст",10} |");
        var curStudents = _students
            .Where(stud => stud.Institute == institute)
            .OrderByDescending(el => el.Age)
            .ThenByDescending(el => el.AverageScore)
            .Take(5)
            .ToList();
        Console.WriteLine(new string('-', 49));
        for (int i = 0; i < curStudents.Count; i++)
        {
            Console.WriteLine(
                $"|{i + 1,2} | {curStudents[i].Surname,10} | {curStudents[i].AverageScore,15} | {curStudents[i].Age,10} |");
        }
    }

    public void ChoiceMenu()
    {
        Console.Clear();
        InitializationMenu();
        _isWork = true;

        var userHook = new Task(GetInput);
        userHook.Start();

        while (_isWork)
        {
            Thread.Sleep(50);
        }

        Console.WriteLine();
        userHook.Dispose();
        PrintCurrentStudentsInInstitute(GetCurrentInstitute());
    }

    public Institute GetCurrentInstitute()
    {
        return _instituteMenus[_lastActiveInstituteIndex].Institute;
    }

    private void LogMessage(string message, ConsoleColor color)
    {
        Console.SetCursorPosition(0, 20);
        Console.Write(_fill);
        Console.SetCursorPosition(0, 20);
        Write($"> {message}", color);
    }

    private void GetInput()
    {
        while (_isWork)
        {
            var a = Console.ReadKey(true);
            if (a.Key == ConsoleKey.Escape)
            {
                _isWork = false;
            }
            else if (_pointer.Contains(a.Key))
            {
                EnableInstitute(Array.IndexOf(_pointer, a.Key));
                LogMessage($"Выбран {_instituteMenus[Array.IndexOf(_pointer, a.Key)].Institute}", ConsoleColor.Cyan);
            }
            else if (a.Key == ConsoleKey.Enter)
            {
                if (_lastActiveInstituteIndex < 0)
                {
                    LogMessage("Вы не выбрали институт. Выход ...", ConsoleColor.Red);
                    Environment.Exit(0);
                }

                var institute = _instituteMenus[_lastActiveInstituteIndex];
                LogMessage($"Выбран {institute.Institute}, вывод первых элементов ...", ConsoleColor.White);
                _isWork = false;
            }
            else
            {
                LogMessage($"Pressed {a.Key} key", ConsoleColor.Gray);
            }
        }
    }
}