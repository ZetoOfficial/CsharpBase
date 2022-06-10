namespace L8;

using System.Text.Json;

public class Word
{
    public string En { get; set; }
    public string Ru { get; set; }

    public Word(string en, string ru)
    {
        En = en;
        Ru = ru;
    }
}

public class WordList
{
    public List<Word> Words { get; set; }

    public WordList(List<Word> words)
    {
        Words = words;
    }
}

public class Player
{
    public string? Name { get; set; }
    public int Score { get; set; }
    public int Words { get; set; }
    public DateTime TestDate { get; set; }

    public Player(string? name, int score, int words, DateTime testDate)
    {
        Name = name;
        Score = score;
        Words = words;
        TestDate = testDate;
    }
}

public class EnglishWords
{
    public static void ReMain()
    {
        Console.Write("Введите имя: ");
        var username = Console.ReadLine();

        var player = new Player(username, 0, 0, DateTime.Now);

        Console.WriteLine($"Очков: {player.Score}");

        using var fsRead = new FileStream("Words.json",
            FileMode.OpenOrCreate);
        WordList? words = JsonSerializer.Deserialize<WordList>(fsRead);

        foreach (var word in words?.Words!)
        {
            Console.Write($"Translate <{word.En}>: ");
            player.Words++;
            var userWord = Console.ReadLine();
            if (userWord == word.Ru) player.Score++;
        }

        Console.WriteLine($"Очков: {player.Score}");
        using var fsWrite = new FileStream("EnglishWords.json",
            FileMode.OpenOrCreate);

        JsonSerializer.SerializeAsync<Player>(fsWrite, player);
    }
}