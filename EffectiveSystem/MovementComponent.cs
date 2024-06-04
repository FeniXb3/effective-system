internal class MovementComponent
{
    public Point PreviousPosition { get; set;}
    private readonly PositionComponent positionComponent;
    private readonly InputComponent inputComponent;

    public MovementComponent(PositionComponent positionComponent, InputComponent inputComponent, Point startingPosition)
    {
        PreviousPosition = new Point(startingPosition);
        this.positionComponent = positionComponent;
        this.inputComponent = inputComponent;
    }

    public void Move(Point targetPosition)
    {
        PreviousPosition.X = positionComponent.Position.X;
        PreviousPosition.Y = positionComponent.Position.Y;

        positionComponent.Position.X = targetPosition.X;
        positionComponent.Position.Y = targetPosition.Y;
    }

    internal Point GetNextPosition()
    {
        Point nextPosition = new Point(positionComponent.Position);
        Point direction = inputComponent.GetDirection();

        nextPosition.X += direction.X;
        nextPosition.Y += direction.Y;

        return nextPosition;
    }
}
