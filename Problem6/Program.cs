using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

Console.WriteLine($"Part one solution: {SolvePartOne(input)}");
Console.WriteLine($"Part two solution: {SolvePartTwo(input)}");

int SolvePartOne(string[] input)
{

    var times = GetNumbersList(input[0]);
    var distances = GetNumbersList(input[1]);

    var answer = 1;

    for (int i = 0; i < times.Count(); i++)
    {
        var time = times[i];
        var distance = distances[i];

        // to find the answer I should solve the following
        // distance < holdtime ( time - holdtime )  
        //    c     <    X     (  b   -     X    )   =>    X^2 - bX + c < 0
        //    delta = b^2 - 4ac

        var delta = Math.Pow(time, 2) - (4 * 1 * distance);

        var x1 = (-time + Math.Sqrt(delta)) / 2;
        var x2 = (-time - Math.Sqrt(delta)) / 2;

        var waysToWin = CalcWholeNumbersCountBetween(x1, x2);

        answer *= waysToWin;
    }

    return answer;
}

int SolvePartTwo(string[] input)
{
    var time = GetNumber(input[0]);
    var distance = GetNumber(input[1]);

    var delta = Math.Pow(time, 2) - (4 * 1 * distance);

    var x1 = (-time + Math.Sqrt(delta)) / 2;
    var x2 = (-time - Math.Sqrt(delta)) / 2;

    return CalcWholeNumbersCountBetween(x1, x2);
}

List<int> GetNumbersList(string line) => Regex.Split(line.Split(':')[1].Trim(), @"\s+").Select(x => int.Parse(x)).ToList();

long GetNumber(string line) => long.Parse(Regex.Replace(line.Split(':')[1], @"\s+", ""));

int CalcWholeNumbersCountBetween(double x1, double x2) => (int)Math.Abs(Math.Ceiling(x1) - Math.Floor(x2)) - 1;