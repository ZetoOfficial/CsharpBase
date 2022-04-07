namespace L5
{
    public class Titov_Pavel_05_02
    {
        public void Task2(string filepath)
        {
            const int width = 120;
            string[] words;
            using (StreamReader sr = new StreamReader(filepath))
            {
                words = sr.ReadToEnd().Split(" |\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            for (var i = 0; i < words.Length; i++)
            {
                string word = words[i];
                int leftPadding = (width - word.Length) / 2;
                int rightPadding = width - word.Length - leftPadding;
                words[i] = new string(' ', leftPadding) + word + new string(' ', rightPadding);
            }
            using (StreamWriter writer = new StreamWriter(filepath, false))
            {
                foreach (var word in words)
                {
                    writer.WriteLine("|" + word + "|");
                }
            }
        }
    }
}