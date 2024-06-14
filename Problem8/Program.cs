var lines = File.ReadAllLines("input.txt");

Console.WriteLine($"Part one solution: {SolvePartOne()}");

int SolvePartOne()
{
    var nodes = new Dictionary<string, Node>();

    var directions = lines[0];

    for (int i = 2; i < lines.Length; i++)
    {
        var key = lines[i].Split('=')[0].Trim();
        var left = lines[i].Split('=')[1].Split(',')[0].Trim(['(', ')', ' ']);
        var right = lines[i].Split('=')[1].Split(',')[1].Trim(['(', ')', ' ']);
        nodes.Add(key, new Node { Left = left, Right = right });
    }

    var steps = 0; var isSolved = false; var currentNode = "AAA";
    while (!isSolved)
    {
        var index = steps % directions.Length;
        if (directions[index] is 'L')
        {
            currentNode = nodes[currentNode].Left;
        }
        else
        {
            currentNode = nodes[currentNode].Right;
        }
        steps++;
        if (currentNode is "ZZZ")
            break;
    }

    return steps;
}

class Node
{
    public string Left { get; set; }
    public string Right { get; set; }
}