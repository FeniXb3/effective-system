class Enemy : Character
{
    private Random rng;

    public Enemy(string visuals, Point startingPosition) : base(visuals, startingPosition)
    {
        rng = new Random();
    }

    public override Point GetNextPosition()
    {
        Point nextPosition = new Point(Position);

        nextPosition.X += rng.Next(-1, 2);
        nextPosition.Y += rng.Next(-1, 2);

        return nextPosition;
    }
}

