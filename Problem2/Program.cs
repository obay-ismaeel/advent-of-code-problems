string[] lines = File.ReadAllLines("input.txt");

Console.WriteLine($"Part one solution: {SolvePartOne(lines)}");
Console.WriteLine($"Part two solution: {SolvePartTwo(lines)}");

static int SolvePartTwo(string[] lines)
{
    int answer = 0;

    var games = lines.Select(x => x.Split(':')[1]).Select(x => x.Split(';'));

    foreach (var game in games)
    {
        int minRed = 0, minGreen = 0, minBlue = 0;

        foreach (var pick in game)
        {
            var ballColors = pick.Split(',').Select(x => x.Trim());

            foreach (var colorShows in ballColors)
            {
                var number = int.Parse(colorShows.Split(' ')[0]);
                var color = colorShows.Split(' ')[1];

                if(color is "red")
                {
                    minRed = int.Max(minRed, number);
                }else if (color is "green")
                {
                    minGreen = int .Max(minGreen, number);
                }else if (color is "blue")
                {
                    minBlue = int.Max(minBlue, number);
                }
            }
        }

        answer += minBlue * minRed * minGreen;
    }

    return answer;
}

static int SolvePartOne(string[] lines)
{
    int answer = 0;

    var games = lines.Select(x => x.Split(':')[1]).Select(x => x.Split(';'));

    var gameNumber = 1;

    foreach (var game in games)
    {
        bool valid = true;

        foreach (var pick in game)
        {
            var ballColors = pick.Split(',').Select(x => x.Trim());

            foreach (var colorShows in ballColors)
            {
                var number = int.Parse(colorShows.Split(' ')[0]);
                var color = colorShows.Split(' ')[1];

                if (number > MaxColorNumber(color))
                {
                    valid = false;
                }
            }
        }

        if (valid)
            answer += gameNumber;
        gameNumber++;
    }

    return answer;
}

static int MaxColorNumber(string color)
{
    if (color is "red")
        return 12;
    if (color is "green")
        return 13;
    if (color is "blue")
        return 14;
    throw new ArgumentException();
}