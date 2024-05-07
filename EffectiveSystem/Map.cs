class Map
{
    public Point Origin { get; set; }
    private int[][] mapData;
    private Dictionary<CellType, char> cellVisuals = new Dictionary<CellType, char>() {
        { CellType.Floor, '.'},
        { CellType.WallCorner, '+'},
        { CellType.WallHorizontal, '-'},
        { CellType.WallVertical, '|'},
        { CellType.Empty, ' '},
        { CellType.Grass, '#'},
    };

    private Dictionary<CellType, ConsoleColor> colorMap = new Dictionary<CellType, ConsoleColor>() {
        { CellType.Floor, ConsoleColor.Magenta },
        { CellType.WallCorner, ConsoleColor.Blue },
        { CellType.WallHorizontal, ConsoleColor.Blue },
        { CellType.WallVertical, ConsoleColor.Blue },
        { CellType.Grass, ConsoleColor.Green },
    };

    private CellType[] walkableCellTypes = new CellType[] {
        CellType.Floor,
        CellType.Grass,
    };

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
                var cellValue = GetCellAt(x, y);
                char cellVisual = cellVisuals.GetValueOrDefault(cellValue, '?');

                Console.ForegroundColor = GetColorByCellType(cellValue);
                Console.Write(cellVisual);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }


    private ConsoleColor GetColorByCellType(CellType cellType)
    {
        return colorMap.GetValueOrDefault(cellType, ConsoleColor.Gray);
    }

    internal CellType GetCellAt(Point point)
    {
        return GetCellAt(point.X, point.Y);
    }

    private CellType GetCellAt(int x, int y)
    {
        return (CellType)mapData[y][x];
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