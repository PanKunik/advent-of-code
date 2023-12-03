using var fileReader = File.OpenText("input.txt");

var sum = 0;

string previousLine = null;
var line = await fileReader.ReadLineAsync();
var nextLine = await fileReader.ReadLineAsync();

var matrix = new char[][]
{
    previousLine?.ToCharArray(),
    line?.ToCharArray(),
    nextLine?.ToCharArray()
};

while (line != null)
{
    for (int i = 0; i < matrix[1].Length; i++)
    {
        var character = matrix[1][i];
        if (character != '*')
        {
            continue;
        }
        else
        {
            var numbers = GetAdjacentNumbers(matrix, i);

            if (numbers.Count() == 2)
            {
                sum += Convert.ToInt32(numbers[0]) * Convert.ToInt32(numbers[1]);
            }
        }
    }

    matrix = new char[][]
    {
        previousLine?.ToCharArray(),
        line?.ToCharArray(),
        nextLine?.ToCharArray()
    };

    previousLine = line;
    line = nextLine;
    nextLine = await fileReader.ReadLineAsync();
}

Console.WriteLine($"Gear ratio sum is: {sum}");

string[] GetAdjacentNumbers(char[][] matrix, int index)
{
    List<string> numbers = new List<string>();

    for (int vertical = -1; vertical <= 1; vertical++)
    {
        for (int horizontal = -1; horizontal <= 1; horizontal++)
        {
            if (horizontal + index >= matrix[1].Length)
            {
                continue;
            }

            if (char.IsDigit(matrix[1 + vertical][horizontal + index]))
            {
                var number = GetNumber(matrix, 1 + vertical, horizontal + index);
                if (!numbers.Contains(number))
                    numbers.Add(number);
            }
        }
    }

    return numbers.ToArray();
}

string GetNumber(char[][] matrix, int vertical, int horizontal)
{
    var searchLeft = true;
    var searchRight = true;
    int offset = 1;

    string number = matrix[vertical][horizontal].ToString();

    while (searchLeft || searchRight)
    {
        if (searchLeft)
        {
            if (horizontal - offset < 0 || char.IsDigit(matrix[vertical][horizontal - offset]) == false)
            {
                searchLeft = false;
            }
            else
            {
                number = matrix[vertical][horizontal - offset].ToString() + number;
            }
        }

        if (searchRight)
        {
            if (horizontal + offset >= matrix[1].Length || char.IsDigit(matrix[vertical][horizontal + offset]) == false)
            {
                searchRight = false;
            }
            else
            {
                number = number + matrix[vertical][horizontal + offset].ToString();
            }
        }

        offset++;
    }

    return number;
}