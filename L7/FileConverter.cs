namespace test_lab_7;

public class FileConverter
{
    public List<Student> LoadStudentsFromFile(string filePath)
    {
        string[][] data = File.ReadAllLines(filePath).Select(x => x.Split(';')).ToArray();

        List<Student> students = new();
        foreach (string[] line in data)
        {
            students.Add(new Student()
            {
                Surname = line[0],
                DateOfBirth = line[1],
                Institute = (Institute)Enum.Parse(typeof(Institute), line[2]),
                AverageScore = Convert.ToDouble(line[3])
            });
        }

        return students;
    }

    public void StudentsToFile(string savePath, List<Student> students)
    {
        //Подготовка информации для записи в файл
        using var file = new StreamWriter(savePath);
        string[] instituteNames = Enum.GetNames(typeof(Institute));
        foreach (var institute in instituteNames)
        {
            file.WriteLine($"Институт: {institute}");
            var curStudents = students
                .Where(stud => stud.Institute.ToString() == institute)
                .OrderByDescending(el => el.Age)
                .ThenByDescending(el => el.AverageScore).ToList();
            if (curStudents.Count == 0)
            {
                file.WriteLine("Данных нет");
                continue;
            }

            file.WriteLine($"|{"№",2} | {"Фамилия",10} | {"Cредний балл",15} | {"Возраст",10} |");
            file.WriteLine(new string('-', 49));
            for (int i = 0; i < curStudents.Count; i++)
            {
                file.WriteLine(
                    $"|{i + 1,2} | {curStudents[i].Surname,10} | {curStudents[i].AverageScore,15} | {curStudents[i].Age,10} |");
            }
            file.WriteLine();
        }
    }
}