using var fileReader = File.OpenText("input.txt");

var timeLine = fileReader.ReadLine().Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
var recordDistancesLine = fileReader.ReadLine().Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

var race = new Race(
    Convert.ToUInt64(string.Join("", timeLine)),
    Convert.ToUInt64(string.Join("", recordDistancesLine))
);

var winningWaysMultiplied = race.GetWinningWays();

Console.WriteLine($"Multiplied winnig ways equals: {winningWaysMultiplied}");
Console.ReadLine();

public sealed class Race
{
    public ulong Time { get; }
    public ulong RecordDistance { get; }

    public Race(
        ulong time,
        ulong recordDistance
    )
    {
        Time = time;
        RecordDistance = recordDistance;
    }

    public ulong GetWinningWays()
    {
        var winningWays = 0UL;

        for (ulong i = Time; i > 0; i--)
        {
            var distance = (Time - i) * i;

            if (distance > RecordDistance)
            {
                winningWays++;
            }
        }

        return winningWays;
    }
}