
string[] input = File.ReadAllLines("input.txt");

Console.WriteLine($"Part one solution: {SolvePartOne(input)}");
Console.WriteLine($"Part two solution: {SolvePartTwo(input)}");

int SolvePartOne(string[] input)
{
    int sum = 0;
    
    for (int i =0; i < input.Length; i++)
    {
        for ( int j =0; j < input[i].Length; j++)
        {
            if (char.IsDigit(input[i][j]))
            {
                int startIndex = j, endIndex = j;

                while (endIndex<input[i].Length && char.IsDigit(input[i][endIndex]))
                {
                    endIndex++;
                }

                bool check = HasAdjacentSymbol(input, i, startIndex, endIndex);

                if (check)
                    sum += int.Parse( input[i][startIndex..endIndex] );

                j = endIndex; 
            }
        }
    }
    
    return sum;
}

bool HasAdjacentSymbol(string[] input,int row, int startIndex, int endIndex)
{
    for(int  i = row-1; i <= row + 1; i++)
    {
        for(int j = startIndex-1; j < endIndex+1; j++)
        {
            if (IsValidIndex(input, i, j) && !char.IsDigit(input[i][j]) && input[i][j] is not '.')
            {
                return true;
            }
        }
    }
    return false;
}

int SolvePartTwo(string[] input)
{
    int sum = 0;

    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < input[i].Length; j++)
        {
            if (input[i][j] is '*')
            {
                sum += GetGearRatio(input, i, j);
            }
        }
    }

    return sum;
}

int GetGearRatio(string[] input, int i, int j)
{
    int adjacentNumbers = 0;
    int gearRatio = 1;

    // check row above
    if (IsValidIndexAndDigit(input, i - 1, j))
    {
        adjacentNumbers++;
        gearRatio *= GetFullNumber(input, i - 1, j);
    }
    else
    {
        if (IsValidIndexAndDigit(input, i - 1, j - 1))
        {
            adjacentNumbers++;
            gearRatio *= GetFullNumber(input, i - 1, j - 1);
        }
        if (IsValidIndexAndDigit(input, i - 1, j + 1))
        {
            adjacentNumbers++;
            gearRatio *= GetFullNumber(input, i - 1, j + 1);
        }
    }

    //check same row
    if (IsValidIndexAndDigit(input, i, j-1))
    {
        adjacentNumbers++;
        gearRatio *= GetFullNumber(input, i, j - 1);
    }
    if (IsValidIndexAndDigit(input, i, j + 1))
    {
        adjacentNumbers++;
        gearRatio *= GetFullNumber(input, i, j + 1);
    }

    // check row bellow
    if (IsValidIndexAndDigit(input, i + 1, j))
    {
        gearRatio *= GetFullNumber(input, i + 1, j);
        adjacentNumbers++;
    }
    else
    {
        if (IsValidIndexAndDigit(input, i + 1, j - 1))
        {
            gearRatio *= GetFullNumber(input, i + 1, j - 1);
            adjacentNumbers++;
        }
        if (IsValidIndexAndDigit(input, i + 1, j + 1))
        {
            gearRatio *= GetFullNumber(input, i + 1, j + 1);
            adjacentNumbers++;
        }
    }

    return adjacentNumbers is 2 ? gearRatio : 0;

}

int GetFullNumber(string[] input, int i, int j)
{
    int startIndex = j, endIndex = j;

    while (IsValidIndex(input,i, endIndex+1) && char.IsDigit( input[i][endIndex + 1] ))
    {
        endIndex++;
    }

    while (IsValidIndex(input, i, startIndex-1) && char.IsDigit( input[i][startIndex - 1]) )
    {
        startIndex--;
    }

    return int.Parse(input[i][startIndex..(endIndex+1)]);
}

bool IsValidIndex(string[] input, int i, int j) => i >= 0 && j >= 0 && i < input.Length && j < input[i].Length;

bool IsValidIndexAndDigit(string[] input, int i, int j) => IsValidIndex(input, i, j) && char.IsDigit(input[i][j]);