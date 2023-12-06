using var fileReader = File.OpenText("input.txt");

var timeLine = fileReader.ReadLine().Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
var recordDistancesLine = fileReader.ReadLine().Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

List<Race> races = new List<Race>();

for (int index = 0; index < timeLine.Length; index++)
{
    var race = new Race(
        Convert.ToInt32(timeLine[index]),
        Convert.ToInt32(recordDistancesLine[index])
    );

    races.Add(race);
}

var winningWaysMultiplied = races[0].GetWinningWays();

for(int index = 1; index < races.Count; index++)
{
    winningWaysMultiplied *= races[index].GetWinningWays();
}

Console.WriteLine($"Multiplied winnig ways equals: {winningWaysMultiplied}");
Console.ReadLine();

public sealed class Race
{
    private int _initialSpeed = 0;

    public int Time { get; }
    public int RecordDistance { get; }

    public Race(
        int time,
        int recordDistance
    )
    {
        Time = time;
        RecordDistance = recordDistance;
    }

    public int GetWinningWays()
    {
        var winningWays = 0;

        for (int i = Time; i > 0; i--)
        {
            _initialSpeed++;

            var distance = (Time - i) * i;

            if (distance > RecordDistance)
            {
                winningWays++;
            }
        }

        return winningWays;
    }
}