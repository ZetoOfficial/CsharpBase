namespace test_lab_7;

public class Program
{
    public static void Main()
    {
        FileConverter fc = new();
        string filePath = "input.data";
        string savedPath = "output.data";
        List<Student> students = fc.LoadStudentsFromFile(filePath);

        Menu menu = new Menu();
        menu.Students = students;
        menu.ChoiceMenu();

        // AverageScoreAndAge(students);
        // MinimalScore(students);
        // MaximumScore(students);
        fc.StudentsToFile(savedPath, students);
    }

    static void MinimalScore(List<Student> students)
    {
        Console.WriteLine("Минимальный средний балл у:");

        if (students.Any())
        {
            var student = students.OrderBy(el => el.AverageScore).ToArray()[0];
            Console.WriteLine($"{student.Surname} - {student.AverageScore}");
        }
    }

    static void MaximumScore(List<Student> students)
    {
        Console.WriteLine("Максимальный средний балл у:");

        if (students.Any())
        {
            var student = students.OrderByDescending(el => el.AverageScore).ToArray()[0];
            Console.WriteLine($"{student.Surname} - {student.AverageScore}");
        }
    }

    static void AverageScoreAndAge(List<Student> students)
    {
        Console.WriteLine("Средний возраст и балл студентов по каждому институту:");
        foreach (string institute in Enum.GetNames(typeof(Institute)))
        {
            List<Student> studentsThis = students
                .Where(x => Enum
                    .GetName(typeof(Institute), x.Institute) == institute)
                .ToList();
            Console.WriteLine($"Институт: {institute}");
            if (!studentsThis.Any())
            {
                Console.WriteLine("\tНедостаточно данных для подсчёта");
                continue;
            }

            Console.WriteLine($"\tСредний балл - {studentsThis.Average(x => x.AverageScore)}");
            Console.WriteLine($"\tСредний возраст - {studentsThis.Average(x => x.Age)}");
        }

        Console.WriteLine();
    }
}