class ComposedPlayer
{
    public VisualComponent VisualComponent { get; }
    public HealthComponent HealthComponent { get; }
    public InputComponent InputComponent { get; }
    public PositionComponent PositionComponent { get; private set; }
    public MovementComponent MovementComponent { get; }

    public ComposedPlayer(string visuals, Point startingPosition)
    {
        VisualComponent = new VisualComponent(visuals);
        HealthComponent = new HealthComponent();
        InputComponent = new InputComponent();
        PositionComponent = new PositionComponent(startingPosition);
        MovementComponent = new MovementComponent(PositionComponent, InputComponent, startingPosition);
    }
}
