using var fileReadr = File.OpenText("input.txt");

var sum = 0;

var line = await fileReadr.ReadLineAsync();

while (line != null)
{
    var winningNumbers = line.Split(':')[1].Split('|')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var numbers = line.Split(':')[1].Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

    var points = 0;

    foreach (var number in numbers)
    {
        if (winningNumbers.Contains(number))
        {
            if (points == 0)
            {
                points++;
            }
            else
            {
                points *= 2;
            }
        }
    }

    sum += points;
    line = await fileReadr.ReadLineAsync();
}

Console.WriteLine($"Sumf of all game points is: {sum}");
Console.ReadLine();