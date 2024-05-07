class Map
{
    public Point Origin { get; set; }
    private int[][] mapData;
    private Dictionary<int, char> cellVisuals = new Dictionary<int, char>() {
        { 0, '.'},
        { 1, '+'},
        { 2, '-'},
        { 3, '|'},
        { 9, ' '},
        { 4, '#'},
    };

    private Dictionary<int, ConsoleColor> colorMap = new Dictionary<int,ConsoleColor>() {
        { 0, ConsoleColor.Magenta },
        { 1, ConsoleColor.Blue },
        { 2, ConsoleColor.Blue },
        { 3, ConsoleColor.Blue },
        { 4, ConsoleColor.Green },
    };

    private int[] walkableCellTypes = new int[] { 0, 4};

    public Map()
    {
        mapData = new int[][] {
            new int[] {1,2,1,9,9,1,2,2,1,9,9,9,9,},
            new int[] {3,0,3,9,9,3,0,0,3,9,9,9,9,},
            new int[] {3,0,3,9,9,1,0,0,1,2,2,2,1,},
            new int[] {3,0,3,9,9,9,1,4,1,0,0,0,3,},
            new int[] {3,0,1,2,2,2,1,0,0,0,0,0,3,},
            new int[] {3,4,0,0,0,0,0,0,0,0,0,0,3,},
            new int[] {1,2,2,1,0,0,0,0,4,4,0,0,3,},
            new int[] {9,9,9,3,0,0,0,0,0,0,0,0,3,},
            new int[] {9,9,9,1,2,2,2,2,2,2,2,2,1,},
        };
        Origin = new Point(0, 0);
    }

    public void Display(Point origin)
    {
        Origin = origin;
        Console.CursorTop = origin.Y;
        for (int y = 0; y < mapData.Length; y++)
        {
            Console.CursorLeft = origin.X;
            for (int x = 0; x < mapData[y].Length; x++)
            {
                int cellValue = mapData[y][x];
                char cellVisual = cellVisuals.GetValueOrDefault(cellValue, '?');

                Console.ForegroundColor = GetColorByCellType(cellValue);
                Console.Write(cellVisual);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    private ConsoleColor GetColorByCellType(int value)
    {
        return colorMap.GetValueOrDefault(value, ConsoleColor.Gray);
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
                if (walkableCellTypes.Contains(GetCellAt(point)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    internal void DrawSomethingAt(char visual, Point position)
    {
        Console.SetCursorPosition(position.X + Origin.X, position.Y + Origin.Y);
        Console.Write(visual);
    }

    internal void RedrawCellAt(Point position)
    {
        Console.ForegroundColor = GetColorByCellType(GetCellAt(position));;
        DrawSomethingAt(GetCellVisualAt(position), position);
        Console.ResetColor();
    }
}