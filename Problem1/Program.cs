string[] input = File.ReadAllLines("input.txt");

long sum = 0;

foreach(string line in input)
{
    int first = -1, last = -1;
    
    foreach(char ch in line)
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

Console.WriteLine($"Solution: {sum}");