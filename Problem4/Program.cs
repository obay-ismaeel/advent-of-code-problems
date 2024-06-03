string[] input = File.ReadAllLines("input.txt");

Console.WriteLine($"Part one solution: {SolvePartOne(input)}");
Console.WriteLine($"Part two solution: {SolvePartTwo(input)}");

int SolvePartOne(string[] input)
{
    int sum = 0;

    foreach(var card in input)
    {
        var cardContents = card.Split(':')[1];

        var winningNumbers = cardContents.Split('|')[0].Trim().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x));
        var cardNumbers = cardContents.Split('|')[1].Trim().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x));

        var hits = 0;

        foreach(var number in cardNumbers)
        {
            if (winningNumbers.Contains(number))
            {
                hits++;
            }
        }

        if(hits > 0)
        {
            sum += (int)Math.Pow(2, hits-1);
        } 
    }

    return sum;
}

int SolvePartTwo(string[] input)
{
    int[] cardCopies = new int[input.Length];

    foreach (var card in input)
    {
        var currentCardNumber = int.Parse(card.Split(':')[0][4..].Trim());
        var currentCardIndex = currentCardNumber - 1;

        cardCopies[currentCardIndex]++;

        var cardContents = card.Split(':')[1];

        var winningNumbers = cardContents.Split('|')[0].Trim().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x));
        var cardNumbers = cardContents.Split('|')[1].Trim().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x));

        var hits = 0;

        foreach (var number in cardNumbers)
        {
            if (winningNumbers.Contains(number))
            {
                hits++;
            }
        }

        for(int i = 1; i <= hits; i++) 
        {
            cardCopies[currentCardIndex + i] += cardCopies[currentCardIndex];
        }
    }

    return cardCopies.Sum();
}