class StaticEnemy : Enemy
{
    public StaticEnemy(string visuals, Point startingPosition) : base(visuals, startingPosition)
    {
    }

    public override Point GetNextPosition()
    {
        return Position;
    }
}