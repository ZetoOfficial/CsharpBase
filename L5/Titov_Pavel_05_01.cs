namespace L5
{
    public class Titov_Pavel_05_01
    {
        public int Task1(string filepath)
        {
            using (StreamReader sr = new StreamReader(filepath))
            {
                int count = 0;
                string[] words = sr.ReadToEnd().Split(" .,!?:\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    if (word != "" && char.ToLower(word[0]) == char.ToLower(word[word.Length - 1]))
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }
}