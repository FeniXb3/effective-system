class Player : Character
{
    private Dictionary<ConsoleKey, Point> directions = new()
    {
        { ConsoleKey.A, new Point(-1, 0)},
        { ConsoleKey.D, new Point(1, 0)},
    };

    public Player(string visuals, Point startingPosition) : base(visuals, startingPosition)
    {
        directions[ConsoleKey.W] = new Point(0, -1);
        directions[ConsoleKey.S] = new Point(0, 1);
        directions[ConsoleKey.E] = new Point(1, -1);
    }


    public override Point GetNextPosition()
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
}
