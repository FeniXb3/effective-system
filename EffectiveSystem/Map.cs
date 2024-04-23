




class Map
{
    private int[][] mapData;
    private Dictionary<int, char> cellVisuals = new Dictionary<int, char>() {
        { 0, '.'},
        { 1, '#'},
    };

    public Map()
    {
        mapData = new int[][] {
            new int[] {1,1,1,1,1,1,1,1,1,1,1,},
            new int[] {1,0,0,0,0,0,0,0,0,0,1,},
            new int[] {1,0,0,0,0,0,0,0,0,0,1,},
            new int[] {1,0,0,0,0,0,0,0,0,0,1,},
            new int[] {1,0,0,0,0,1,0,0,0,0,1,},
            new int[] {1,0,0,0,0,0,0,0,0,0,1,},
            new int[] {1,0,0,1,0,0,0,0,0,0,1,},
            new int[] {1,0,0,0,0,0,0,0,0,0,1,},
            new int[] {1,1,1,1,1,1,1,1,1,1,1,},
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
                int cellValue = mapData[y][x];
                char cellVisual = cellVisuals[cellValue];
                Console.Write(cellVisual);
            }
            Console.WriteLine();
        }
    }

    internal int GetCellAt(Point point)
    {
        return mapData[point.Y][point.X];
    }

    internal char GetCellVisualAt(Point point)
    {
        return cellVisuals[GetCellAt(point)];
    }

    internal bool IsPointValid(Point point)
    {
        if (point.Y >= 0 && point.Y < mapData.Length)
        {
            if (point.X >= 0 && point.X < mapData[point.Y].Length)
            {
                if (GetCellAt(point) != 1)
                {
                    return true;
                }
            }
        }

        return false;
    }
}