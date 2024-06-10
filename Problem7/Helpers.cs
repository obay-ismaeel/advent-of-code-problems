using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7;
internal static class Helpers
{
    public static int StrongerThan(string? cards1, string? cards2)
    {
        var type1 = GetCardsType(cards1);
        var type2 = GetCardsType(cards2);

        if (type1 > type2)
            return 1;
        else if (type2 > type1)
            return -1;
        else
        {
            for (int i = 0; i < cards1.Length; i++)
            {
                if (GetCardValue(cards1[i]) > GetCardValue(cards2[i]))
                {
                    return 1;
                }
                else if (GetCardValue(cards1[i]) < GetCardValue(cards2[i]))
                {
                    return -1;
                }
            }
        }

        throw new ArgumentException();
    }

    public static int GetCardsType(string cards)
    {
        Dictionary<char, int> chars = new Dictionary<char, int>();

        foreach (var card in cards)
        {
            if (chars.ContainsKey(card))
            {
                chars[card]++;
            }
            else
            {
                chars.Add(card, 1);
            }
        }

        int maxOccurs = chars.Max(x => x.Value);

        if (chars.Count is 1)
        {
            return 6;
        }
        else if (chars.Count is 2 && maxOccurs is 4)
        {
            return 5;
        }
        else if (chars.Count is 2 && maxOccurs is 3)
        {
            return 4;
        }
        else if (chars.Count is 3 && maxOccurs is 3)
        {
            return 3;
        }
        else if (chars.Count is 3 && maxOccurs is 2)
        {
            return 2;
        }
        else if (chars.Count is 4)
        {
            return 1;
        }
        return 0;
    }

    public static int GetCardValue(char card)
    {
        if (char.IsDigit(card))
            return card - '0';
        else if (card is 'K')
            return 13;
        else if (card is 'Q')
            return 12;
        else if (card is 'J')
            return 11;
        else if (card is 'A')
            return 14;
        else if (card is 'T')
            return 10;
        else
            throw new ArgumentException();
    }
}
