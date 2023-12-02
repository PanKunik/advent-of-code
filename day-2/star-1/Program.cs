using var fileReader = File.OpenText("input.txt");

var sum = 0;

var blueCubes = 14;
var redCubes = 12;
var greenCubes = 13;

var line = await fileReader.ReadLineAsync();
while (line != null)
{
    var gameHeaders = line.Split(':');
    var gameId = Convert.ToInt32(gameHeaders[0].Substring(5));

    var gameSets = gameHeaders[1].Split(";");

    foreach (var gameSet in gameSets)
    {
        var blue = 0;
        var green = 0;
        var red = 0;

        var cubes = gameSet.Split(",");

        foreach (var cube in cubes)
        {
            if (cube.ToLower().Contains("red"))
            {
                red += Convert.ToInt32(cube.ToLower().Replace(" ", "").Replace("red", ""));
            }
            else if (cube.ToLower().Contains("green"))
            {
                green += Convert.ToInt32(cube.ToLower().Replace(" ", "").Replace("green", ""));
            }
            else
            {
                blue += Convert.ToInt32(cube.ToLower().Replace(" ", "").Replace("blue", ""));
            }
        }

        if (blue > blueCubes
            || green > greenCubes
            || red > redCubes)
        {
            gameId = 0;
        }
    }

    sum += gameId;
    line = await fileReader.ReadLineAsync();
}

Console.WriteLine($"Sum of game IDs: {sum}");