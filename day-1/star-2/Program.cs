var sum = 0L;

var textToSearch = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

using (var fileReader = File.OpenText("input.txt"))
{
    var line = await fileReader.ReadLineAsync();

    while (line != null)
    {
        var firstNumber = GetFirstNumber(line);
        var lastNumber = GetLastNumber(line);
        sum += Convert.ToInt32(firstNumber.ToString() + lastNumber.ToString());
        line = await fileReader.ReadLineAsync();
    }
}

Console.WriteLine($"Sum equals: {sum}");

int GetFirstNumber(string line)
{
    var minIndex = line.Length;
    var number = "0";

    for (int i = 0; i < textToSearch.Length; i++)
    {
        var index = line.IndexOf(textToSearch[i]);

        if (index != -1 && index < minIndex)
        {
            minIndex = index;
            number = textToSearch[i % 9];
        }
    }

    return Convert.ToInt32(number);
}

int GetLastNumber(string line)
{
    var maxIndex = -1;
    var number = "0";

    for (int i = 0; i < textToSearch.Length; i++)
    {
        var index = line.LastIndexOf(textToSearch[i]);

        if (index != -1 && index > maxIndex)
        {
            maxIndex = index;
            number = textToSearch[i % 9];
        }
    }

    return Convert.ToInt32(number);
}