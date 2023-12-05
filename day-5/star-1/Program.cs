using var fileReader = File.OpenText("input.txt");

var line = await fileReader.ReadLineAsync();
var initialSeeds = line.Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

var map = new List<List<string>>();
map.Add(new List<string>(initialSeeds));

line = await fileReader.ReadLineAsync();

while (line != null)
{
    if (line == "")
    {
        line = await fileReader.ReadLineAsync();
    }

    if (line.Contains("map"))
    {
        map.Add(new List<string>(map.Last()));
    }
    else
    {
        var mapValues = line
            .Split(' ')
            .Select(v => Convert.ToInt64(v))
            .ToArray();

        for (int i = 0; i < map[^2].Count; i++)
        {
            var previousMap = map[^2];
            var previousComponentValue = Convert.ToInt64(previousMap[i]);

            if (previousComponentValue >= mapValues[1] && previousComponentValue <= mapValues[1] - 1 + mapValues[2])
            {
                map[^1][i] = (Convert.ToInt64(mapValues[0]) - Convert.ToInt64(mapValues[1]) + previousComponentValue).ToString();
            }
        }
    }

    line = await fileReader.ReadLineAsync();
}

var minLocation = map.Last().Select(c => Convert.ToInt64(c)).Min();
Console.WriteLine($"Lowest location containing initial seed is {minLocation} for seed.");
Console.ReadLine();