// using System.IO; 							//для чего?
// public enum Institute { ФЭИ, ИФК, ИМиКН, ИнЗем, ИФиЖ, …};
// // названия институтов можно посмотреть на сайте ТюмГУ
// struct Student : Icomparable {
//     public string fam;
//     public Institute inst;
//     public string dat_r;
//     public double sr_ball;
//     public double vozrast {
//         get {
//             return (DateTime.Now.Year - Convert.ToDateTime(dat_r).Year);
//             // возраст лучше вычислить с учётом месяца и дня
//         }
//     }
//     public int CompareTo(Object obj) {
//         Student st = (Student)obj;
//         if (vozrast > st.vozrast) return 1;
//         else { if (vozrast < st.vozrast) return -1; else return 0; }
//     }
// }


// class Program {
//     static void Main(string[] args) {
//         StreamReader f = new StreamReader("baza.dat");
//         string s = f.ReadLine(); int j = 0;
//         while (s != null) {
//             s = f.ReadLine();
//             j++;
//         }
//         f.Close();
//         Student[] students = new Student[j];
//         string[] d = new string[4];
//         f = new StreamReader("baza.dat");
//         s = f.ReadLine(); j = 0;
//         while (s != null) {
//             d = s.Split(';');
//             students[j].fam = d[0];
//             students[j].inst = (Institute)Enum.Parse(typeof(Institute), d[1]);
//             students[j].dat_r = d[2];
//             students[j].sr_ball = Convert.ToDouble(d[3]);
//             s = f.ReadLine();
//             j++;
//         }
//         f.Close();
//         string[] F = Enum.GetNames(typeof(Institute));
//         int v = -1, p = 0;
//         Console.Title = "Студенты";
//         Console.Clear();
//         for (int i = 0; i < F.Length; i++) Console.WriteLine(F[i]);
//         bool ff = true;
//         while (ff) {
//             Console.ForegroundColor = ConsoleColor.Gray;
//             if (!(v == 0 && p == 0)) {
//                 Console.SetCursorPosition(0, p);
//                 Console.WriteLine(F[p]);
//             }
//             Console.SetCursorPosition(0, F.Length);
//             ConsoleKeyInfo k = Console.ReadKey();
//             if (v == -1) p = 0; else p = v;
//             if (k.Key == ConsoleKey.Enter) ff = false;
//             else {
//                 if (Char.GetNumericValue(k.KeyChar) >= 0 &&
//                                        Char.GetNumericValue(k.KeyChar) < F.Length) {
//                     v = Convert.ToInt32(Char.GetNumericValue(k.KeyChar));
//                     Console.SetCursorPosition(0, v);
//                     Console.ForegroundColor = ConsoleColor.Red;
//                     Console.WriteLine(F[v]);
//                 } else v = -1;
//             }
//         }
//         if (v != -1) {
//             Console.Clear();
//             Console.WriteLine(" Институт: " + F[v]);
//             // шапка таблицы…..
//             j = 0;
//             for (int i = 0; i < students.Length; i++) {
//                 if (Enum.GetName(typeof(Institute), students[i].inst) == F[v]) {
//                     j++;
//                     Console.WriteLine("║{0,2} ║ {1,15} ║ {2,15} ║ {3,11} ║", j, students[i].fam, students[i].dat_r, students[i].sr_ball);
//                 }
//             }
//         } else
//             Console.WriteLine(" Институт не выбран ");
//         Array.Sort(students);
//         Console.ReadKey();
//         StreamWriter f1 = new StreamWriter("baza1.txt");
//         for (int ii = 0; ii < F.Length; ii++) {
//             f1.WriteLine(" Институт: " + F[ii]);
//             int q = 0;
//             for (int i = 0; i < students.Length; i++) {
//                 if (students[i].inst.ToString() == F[ii]) {
//                     if (q == 0) {// шапка таблицы…..}
//                         q++;
//                         f1.WriteLine("║{0,2} ║ {1,15} ║ {2,15} ║ {3,11} ║", q, students[i].fam, students[i].sr_ball, students[i].vozrast);
//                     }
//                 }
//                 if (q == 0)
//                     f1.WriteLine("данных нет.");
//                 f1.Close();
//             }
//         }
//     }
// }