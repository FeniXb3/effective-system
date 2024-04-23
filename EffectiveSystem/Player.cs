class Player
{
    public int Hp
    { 
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }
    private int hp = 100;

    public int MaxHp { get; private set; } = 100;

    public Point Position { get; set; }
    public Point PreviousPosition { get; set;}

    private Dictionary<ConsoleKey, Point> directions = new()
    {
        { ConsoleKey.A, new Point(-1, 0)},
        { ConsoleKey.D, new Point(1, 0)},
    };

    public Player(int x, int y)
    {
        Position = new Point(x, y);
        PreviousPosition = new Point(x, y);
    }

    public Player(Point startingPosition)
    {
        // Position = startingPosition;
        // Position = new Point(startingPosition.X, startingPosition.Y);
        Position = new Point(startingPosition);
        PreviousPosition = new Point(startingPosition);
        // directions.Add(ConsoleKey.A, new Point(-1, 0));
        // directions.Add(ConsoleKey.A, new Point(1, 0));
        // directions[ConsoleKey.A] = new Point(-1, 0);
        // directions[ConsoleKey.A] = new Point(1, 0);
        // directions[ConsoleKey.D] = new Point(1, 0);
        directions[ConsoleKey.W] = new Point(0, -1);
        directions[ConsoleKey.S] = new Point(0, 1);
        directions[ConsoleKey.E] = new Point(1, -1);
        // directions.TryAdd
    }

    public void Heal()
    {
        Hp += 10;
    }

    public Point GetNextPosition()
    {
        Point nextPosition = new Point(Position);
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (directions.ContainsKey(pressedKey.Key))
        {
            Point direction = directions[pressedKey.Key];
            nextPosition.X += direction.X;
            nextPosition.Y += direction.Y;
        }

        return nextPosition;
    }

    public void Move(Point targetPosition)
    {
        PreviousPosition.X = Position.X;
        PreviousPosition.Y = Position.Y;

        Position.X = targetPosition.X;
        Position.Y = targetPosition.Y;
    }
}


/*
Player
    dane:
    - hp
    - maxhp
    - mana
    - maxmana
    - int
    - dex
    - str
    - inventory
        - item
        - item
        - ...
    - position
        - x
        - y

    akcje:
    - interact
    - use item
    - move
    - open inventory
    - take damage
    - heal
    - die/faint
    - attack
    - regenerate mana
*/