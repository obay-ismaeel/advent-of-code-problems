string[] input = File.ReadAllLines("input.txt");

Console.WriteLine($"Part one solution: {SolvePartOne(input)}");
Console.WriteLine($"Part two solution: {SolvePartTwo(input)}");

int SolvePartOne(string[] input) 
{
    int sum = 0;

    foreach (string line in input)
    {
        int first = -1, last = -1;

        foreach (char ch in line)
        {
            if (char.IsDigit(ch) && first is -1)
            {
                first = ch - '0';
                last = ch - '0';
            }
            else if (char.IsDigit(ch))
            {
                last = ch - '0';
            }
        }

        sum += first * 10 + last;
    }
    return sum;
}

int SolvePartTwo(string[] input)
{
    int sum = 0;

    foreach (string line in input)
    {
        int first = -1, last = -1;

        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                first = line[i] - '0';
                break;
            }
            else if (line.Length - i >= 3 && StringToIntegerDigit(line[i..(i + 3)]) != -1)
            {
                first = StringToIntegerDigit(line[i..(i + 3)]);
                break;
            }
            else if (line.Length - i >= 4 && StringToIntegerDigit(line[i..(i + 4)]) != -1)
            {
                first = StringToIntegerDigit(line[i..(i + 4)]);
                break;
            }
            else if (line.Length - i >= 5 && StringToIntegerDigit(line[i..(i + 5)]) != -1)
            {
                first = StringToIntegerDigit(line[i..(i + 5)]);
                break;
            }
        }

        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                last = line[i] - '0';
                break;
            }
            else if (line.Length - i >= 3 && StringToIntegerDigit(line[i..(i + 3)]) != -1)
            {
                last = StringToIntegerDigit(line[i..(i + 3)]);
                break;
            }
            else if (line.Length - i >= 4 && StringToIntegerDigit(line[i..(i + 4)]) != -1)
            {
                last = StringToIntegerDigit(line[i..(i + 4)]);
                break;
            }
            else if (line.Length - i >= 5 && StringToIntegerDigit(line[i..(i + 5)]) != -1)
            {
                last = StringToIntegerDigit(line[i..(i + 5)]);
                break;
            }
        }

        sum += first * 10 + last;
    }
    return sum;
}

int StringToIntegerDigit(string number)
{
    switch (number)
    {
        case "zero":
            return 0;
        case "one":
            return 1;
        case "two": 
            return 2;
        case "three":
            return 3;
        case "four": 
            return 4;
        case "five":
            return 5;
        case "six":
            return 6;
        case "seven":
            return 7;
        case "eight":
            return 8;
        case "nine":
            return 9;
        default:
            return -1;
    }
}