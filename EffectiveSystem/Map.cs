



class Map
{
    private string[] mapData;

    public Map()
    {
        mapData = new string[] {
            "###########",// 0
            "#.........#", // 1
            "#.........#", // 2
            "#.........#", // 3
            "#....#....#", // ...
            "#.........#",
            "#.........#",
            "#.........#",
            "#.........#",
            "###########",
        };
    }

    public void Display()
    {
        foreach (string row in mapData)
        {
            Console.WriteLine(row);
        }
    }

    internal char GetCellAt(Point point)
    {
        return mapData[point.Y][point.X];
    }

    internal bool IsPointValid(Point point)
    {
        if (point.Y >= 0 && point.Y < mapData.Length)
        {
            if (point.X >= 0 && point.X < mapData[point.Y].Length)
            {
                if (GetCellAt(point) != '#')
                {
                    return true;
                }
            }
        }

        return false;
    }
}