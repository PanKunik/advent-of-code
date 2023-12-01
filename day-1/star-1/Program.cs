var sum = 0L;

using (var fileReader = File.OpenText("input.txt"))
{
    var line = await fileReader.ReadLineAsync();

    while (line != null)
    {
        var number = Convert.ToInt64(
            line.First(
                c => char.IsDigit(c)
            ).ToString()
            +
            line.Last(
                c => char.IsDigit(c)
            ).ToString()
        );

        sum += number;

        line = await fileReader.ReadLineAsync();
    }
}

Console.WriteLine($"Sum equals: {sum}");