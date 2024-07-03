var input = File.ReadAllLines("input.txt");

Console.WriteLine($"Part one solution: {SolvePartOne()}");

int SolvePartOne()
{
    var expandedUniverse = GetExpandedUniverse();

    var galaxiesPositions = GetGalaxiesPositions(expandedUniverse);

    return CalculateShortestPathsSum(galaxiesPositions);
}

int CalculateShortestPathsSum(List<Position> galaxiesPositions)
{
    int sum = 0;

    for(int i=0; i<galaxiesPositions.Count; i++)
    {
        for(int j=i+1; j<galaxiesPositions.Count; j++)
        {
            sum += CalculateDistance(galaxiesPositions[i], galaxiesPositions[j]);
        }
    }

    return sum;
}

List<Position> GetGalaxiesPositions(List<string> expandedUniverse)
{
    var positions = new List<Position>();
    for(int i = 0; i < expandedUniverse.Count; i++)
    {
        for (int j = 0; j < expandedUniverse.First().Length; j++)
        {
            if (expandedUniverse[i][j] is '#')
                positions.Add(new Position(i, j));
        }
    }
    return positions;
}

List<string> GetExpandedUniverse()
{
    var verticallyExpandedUniverse = new List<string>();

    for(int i = 0; i < input.Length; i++)
    {
        if(input[i].All(x => x is '.'))
        {
            verticallyExpandedUniverse.Add(input[i]);
            verticallyExpandedUniverse.Add(input[i]);
        }
        else
        {
            verticallyExpandedUniverse.Add(input[i]);
        }
    }

    var expandedUniverse = verticallyExpandedUniverse;

    for(int col = 0; col < expandedUniverse[0].Length; col++)
    {
        var isEmpty = true;
        for(int row=0; row<expandedUniverse.Count(); row++)
        {
            if (expandedUniverse[row][col] is '#')
            {
                isEmpty = false;
            }
        }

        if (isEmpty)
        {
            for (int row = 0; row < expandedUniverse.Count(); row++)
            {
                expandedUniverse[row] = expandedUniverse[row].Insert(col, ".");
            }
            col++;
        }
    }

    return expandedUniverse.Select(x => new string(x.ToArray())).ToList();
}

int CalculateDistance(Position p1, Position p2) => Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);

struct Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}