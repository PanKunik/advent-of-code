using var fileReader = File.OpenText("input.txt");

var sum = 0;

var blueCubes = 14;
var redCubes = 12;
var greenCubes = 13;

var line = await fileReader.ReadLineAsync();
while (line != null)
{
    var gameSets = line.Split(':')[1].Split(";");

    var maxBlue = -1;
    var maxGreen = -1;
    var maxRed = -1;

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

        if (maxBlue < blue)
        {
            maxBlue = blue;
        }

        if (maxRed < red)
        {
            maxRed = red;
        }

        if (maxGreen < green)
        {
            maxGreen = green;
        }
    }

    sum += maxBlue * maxGreen * maxRed;
    line = await fileReader.ReadLineAsync();
}

Console.WriteLine($"Sum of power of games: {sum}");