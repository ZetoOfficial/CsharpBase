namespace L5
{
    public class Titov_Pavel_05_02
    {
        public string Filepath
        {
            get; set;
        }
        public Titov_Pavel_05_02(string filepath)
        {
            Filepath = filepath;
        }
        public void Task2()
        {
            const int width = 120;
            string[] words;
            using (StreamReader sr = new StreamReader(Filepath))
            {
                words = sr.ReadToEnd().Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            for (var i = 0; i < words.Length; i++)
            {
                string word = words[i];
                int leftPadding = (width - word.Length) / 2;
                int rightPadding = width - word.Length - leftPadding;
                words[i] = new string(' ', leftPadding) + word + new string(' ', rightPadding);
            }
            using (StreamWriter writer = new StreamWriter(Filepath, false))
            {
                foreach (var word in words)
                {
                    writer.WriteLine("|" + word + "|");
                }
            }
        }
    }
}