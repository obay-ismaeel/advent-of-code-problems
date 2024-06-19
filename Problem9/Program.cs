var lines = File.ReadAllLines("input.txt");

Console.WriteLine($"Part one solution: {SolvePartOne(lines)}");

long SolvePartOne(string[] lines)
{
    var sum = 0L;
    
    foreach (var line in lines)
    {
        var numSequence = line.Split(' ').Select(x => int.Parse(x)).ToList();

        sum += GetNextValue(numSequence);
    }

    return sum;
}

int GetNextValue(List<int> numSequence)
{
    var sequences = new List<List<int>> { numSequence };

    do
    {
        sequences.Add( GetDiffSequence( sequences.Last()) );
    } while (sequences.Last().Any(x => x is not 0));

    sequences.Last().Add(0);

    for(int i = sequences.Count - 1; i > 0; i--)
    {
        var nextValue = sequences[i - 1].Last() + sequences[i].Last();
        sequences[i - 1].Add(nextValue);
    }

    return sequences.First().Last();
}

List<int> GetDiffSequence(List<int> sequence)
{
    var diffSequence = new List<int>();

    for (int i = 0; i < sequence.Count - 1; i++)
    {
        diffSequence.Add( sequence[i+1] - sequence[i]);
    }

    return diffSequence;
}