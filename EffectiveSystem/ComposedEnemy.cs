class ComposedEnemy
{
    public VisualComponent VisualComponent { get; }
    public HealthComponent HealthComponent { get; }
    public IInputComponent InputComponent { get; }
    public PositionComponent PositionComponent { get; private set; }
    public MovementComponent MovementComponent { get; }

    public ComposedEnemy(string visuals, Point startingPosition)
    {
        VisualComponent = new VisualComponent(visuals);
        HealthComponent = new HealthComponent();
        InputComponent = new RandomInputComponent();
        PositionComponent = new PositionComponent(startingPosition);
        MovementComponent = new MovementComponent(PositionComponent, InputComponent, startingPosition);
    }
}
