abstract class Character
{
    public string Visuals { get; set; }  = "@";
    public int Hp
    { 
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }
    private int hp = 100;

    public int MaxHp { get; private set; } = 100;

    public Point Position { get; set; }
    public Point PreviousPosition { get; set;}


    public Character(string visuals, Point startingPosition)
    {
        Visuals = visuals;
        Position = new Point(startingPosition);
        PreviousPosition = new Point(startingPosition);
    }

    public void Heal()
    {
        Hp += 10;
    }

    public abstract Point GetNextPosition();

    public void Move(Point targetPosition)
    {
        PreviousPosition.X = Position.X;
        PreviousPosition.Y = Position.Y;

        Position.X = targetPosition.X;
        Position.Y = targetPosition.Y;
    }
}

