var almanac = File.ReadAllLines("input.txt");

Console.WriteLine($"Part one solution: {SolvePartOne()}");

long SolvePartOne()
{
    var items = almanac[0].Split(':')[1].Trim().Split(' ').Select(x => long.Parse(x)).ToList();

    var mapResults = new List<long>();

    List<MapRange> mappingList = new List<MapRange>();

    for(int i = 2; i < almanac.Length; i++)
    {
        i++;
        while (i < almanac.Length && !string.IsNullOrWhiteSpace(almanac[i]))
        {
            mappingList.Add( GetMapRange(almanac[i++]) );
        }

        foreach(var item in items)
        {
            mapResults.Add(GetMapResult(item, mappingList));
        }

        items.Clear();
        items.AddRange(mapResults);
        mapResults.Clear();
        mappingList.Clear();
    }

    return items.Min();
}



MapRange GetMapRange(string map)
{
    var elements = map.Split(" ").Select(x => long.Parse(x)).ToList();

    return new MapRange
    {
        DestinationRangeStart = elements[0],
        SourceRangeStart = elements[1],
        RangeLength = elements[2]
    };
}

long GetMapResult(long item, List<MapRange> ranges)
{
    foreach(MapRange range in ranges)
    {
        if(range.SourceRangeStart <= item && item < range.SourceRangeStart + range.RangeLength)
        {
            return range.DestinationRangeStart + (item - range.SourceRangeStart);
        }
    }
    return item;
}



class MapRange
{
    public long DestinationRangeStart { get; set; }
    public long SourceRangeStart { get; set; }
    public long RangeLength { get; set; }
}