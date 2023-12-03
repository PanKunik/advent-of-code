using var fileReader = File.OpenText("input.txt");

string previousLine = null;
var line = await fileReader.ReadLineAsync();
var nextLine = await fileReader.ReadLineAsync();

var sum = 0;

var matrix = new char[][]
{
    previousLine?.ToCharArray(),
    line?.ToCharArray(),
    nextLine?.ToCharArray()
};

while (line != null)
{
    var number = string.Empty;
    var isPartNumber = false;

    for (int i  = 0; i < matrix[1].Length; i++)
    {
        var character = matrix[1][i];

        if (char.IsDigit(character) == false)
        {
            if (isPartNumber)
                sum += Convert.ToInt32(string.IsNullOrEmpty(number) ? "0" : number);
            number = string.Empty;
            isPartNumber = false;
            continue;
        }

        number += character.ToString();

        for (var vertical = -1; vertical <= 1; vertical++)
        {
            if (previousLine is null && vertical == -1)
            {
                continue;
            }

            if (nextLine is null && vertical == 1)
            {
                continue;
            }

            for (var horizontal = -1; horizontal <= 1; horizontal++)
            {
                if (horizontal + i >= matrix[1].Length || horizontal + i < 0)
                {
                    continue;
                }

                if (vertical == 0 && horizontal == 0)
                {
                    continue;
                }

                var adjacentCharacter = matrix[1 + vertical][i + horizontal];
                if (adjacentCharacter == '.')
                {
                    continue;
                }

                if (char.IsDigit(adjacentCharacter) == false && adjacentCharacter != '.')
                {
                    isPartNumber = true;
                }
            }
        }
    }

    if (isPartNumber)
    {
        sum += Convert.ToInt32(number);
    }

    previousLine = line;
    line = nextLine;
    nextLine = await fileReader.ReadLineAsync();

    matrix = new char[][]
    {
        previousLine.ToCharArray(),
        line?.ToCharArray(),
        nextLine?.ToCharArray()
    };
}

Console.WriteLine($"Sum of the aprt numbers is: {sum}");