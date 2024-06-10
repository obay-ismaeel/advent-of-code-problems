using Problem7;

var input = File.ReadAllLines("input.txt");

Console.WriteLine($"Part one solution: {SolvePartOne(input)}");

int SolvePartOne(string[] input)
{
    var totalWinnings = 0;

    var hands = input.Select(x => x.Split(' ')).Select(x => new Hand { Cards = x[0], Bid = int.Parse(x[1]) }).ToList();

    hands.Sort(new HandComparer());

    for (int i = 0; i < hands.Count(); i++)
    {
        totalWinnings += hands[i].Bid * (i+1);
    }

    return totalWinnings;
}

class Hand
{
    public string? Cards { get; set; }
    public int Bid { get; set; }
}

class HandComparer : IComparer<Hand>
{
    public int Compare(Hand? a, Hand? b)
    {
        return Helpers.StrongerThan(a.Cards, b.Cards);
    }
}




