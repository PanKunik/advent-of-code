using var seedsReader = File.OpenText("input.txt");

var minLocation = uint.MaxValue;
var line = await seedsReader.ReadLineAsync();
var initialSeeds = line.Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

var minLocationInRange = uint.MaxValue;

for (uint x = 0; x < initialSeeds.Length; x += 2)
{
    using var fileReader = File.OpenText("input.txt");
    Console.WriteLine($"X: {x}");

    var map = new List<List<uint>>();
    var seeds = new List<uint>();

    for (uint y = 0; y < Convert.ToUInt32(initialSeeds[x + 1]); y++)
    {
        seeds.Add((Convert.ToUInt32(initialSeeds[x]) + y));
    }

    map.Add(new List<uint>(seeds));
    map.Add(new List<uint>(seeds));

    line = await fileReader.ReadLineAsync();

    while (line != null)
    {
        while (line == "" || line.Contains("seeds:"))
        {
            line = await fileReader.ReadLineAsync();
        }

        if (line.Contains("map"))
        {
            map[0] = new List<uint>(map[1]);
        }
        else
        {
            var mapValues = line
                .Split(' ')
                .Select(v => Convert.ToUInt32(v))
                .ToArray();

            for (int i = 0; i < map[^2].Count; i++)
            {
                var previousMap = map[^2];
                var previousComponentValue = previousMap[i];

                if (previousComponentValue >= mapValues[1] && previousComponentValue <= mapValues[1] - 1 + mapValues[2])
                {
                    map[^1][i] = mapValues[0] - mapValues[1] + previousComponentValue;
                }
            }
        }

        line = await fileReader.ReadLineAsync();
    }

    minLocationInRange = map.Last().Min();

    if (minLocation > minLocationInRange)
    {
        minLocation = minLocationInRange;
    }
}

Console.WriteLine($"Lowest location containing initial seed is {minLocation} for seed.");
Console.ReadLine();