using var linesToCountReader = File.OpenText("input.txt");

var lines = (await linesToCountReader.ReadToEndAsync()).Count(c => c == '\n');

using var fileReader = File.OpenText("input.txt");

var sum = 0L;
var line = await fileReader.ReadLineAsync();

var copiesOfCards = new List<int>(Enumerable.Range(0, lines).Select(r => 1).ToList());

while (line != null)
{
    var game = line.Split(':');
    var gameHeader = game[0];
    var gameNumber = Convert.ToInt32(gameHeader.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
    var gameSets = game[1].Split("|");
    var winningNumbers = gameSets[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var numbers = gameSets[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

    for (int j = 0; j < (copiesOfCards.ElementAtOrDefault(gameNumber - 1) == 0 ? 1 : copiesOfCards.ElementAtOrDefault(gameNumber - 1)); j++)
    {
        var matchingNumbers = 0;

        foreach (var number in numbers)
        {
            if (winningNumbers.Contains(number))
            {
                matchingNumbers++;
            }
        }

        for (int i = 1; i <= matchingNumbers; i++)
        {
            copiesOfCards[gameNumber + i - 1] = copiesOfCards.ElementAtOrDefault(gameNumber + i - 1) + 1;
        }
    }

    sum += copiesOfCards.ElementAtOrDefault(gameNumber - 1) == 0 ? 1L : copiesOfCards.ElementAtOrDefault(gameNumber - 1);
    line = await fileReader.ReadLineAsync();
}

Console.WriteLine($"Sum of all game points is: {sum}");
Console.ReadLine();