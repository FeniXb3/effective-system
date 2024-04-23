



class Map
{
    private char[][] mapData;

    public Map()
    {
        mapData = new char[][] {
            new char[] {'#','#','#','#','#','#','#','#','#','#','#',},
            new char[] {'#','.','.','.','.','.','.','.','.','.','#',},
            new char[] {'#','.','.','.','.','.','.','.','.','.','#',},
            new char[] {'#','.','.','.','.','.','.','.','.','.','#',},
            new char[] {'#','.','.','.','.','.','.','.','.','.','#',},
            new char[] {'#','.','.','.','.','.','.','.','.','.','#',},
            new char[] {'#','.','.','.','.','.','.','.','.','.','#',},
            new char[] {'#','.','.','.','.','.','.','.','.','.','#',},
            new char[] {'#','#','#','#','#','#','#','#','#','#','#',},
        };
    }

    public void Display()
    {
        // foreach (char[] row in mapData)
        // {
        //     Console.WriteLine(row);
        // }
        for (int y = 0; y < mapData.Length; y++)
        {
            for (int x = 0; x < mapData[y].Length; x++)
            {
                Console.Write(mapData[y][x]);
            }
            Console.WriteLine();
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