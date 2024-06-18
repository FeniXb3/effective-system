Console.CursorVisible = false;
Point playerPosition = new Point(10, 3);

ComposedPlayer composedPlayer = new ComposedPlayer("@", playerPosition);
ComposedEnemy composedEnemy = new ComposedEnemy("T", new Point(4, 6));

Map map = new Map();

Console.Clear();

if (map.Size.X + map.Origin.X >= 0 && map.Size.X + map.Origin.X < Console.BufferWidth
    && map.Size.Y + map.Origin.Y >= 0 && map.Size.Y + map.Origin.Y < Console.BufferHeight)
{
    map.Display(new Point(15, 2));

    map.DrawSomethingAt(composedPlayer.VisualComponent.Visuals, composedPlayer.PositionComponent.Position);
    map.DrawSomethingAt(composedEnemy.VisualComponent.Visuals, composedEnemy.PositionComponent.Position);

    while (true)
    {
        Point nextPosition = composedPlayer.MovementComponent.GetNextPosition();
        if (map.IsPointValid(nextPosition))
        {
            composedPlayer.MovementComponent.Move(nextPosition);

            map.RedrawCellAt(composedPlayer.MovementComponent.PreviousPosition);
            map.DrawSomethingAt(composedPlayer.VisualComponent.Visuals, composedPlayer.PositionComponent.Position);
        }

        nextPosition = composedEnemy.MovementComponent.GetNextPosition();
        if (map.IsPointValid(nextPosition))
        {
            composedEnemy.MovementComponent.Move(nextPosition);

            map.RedrawCellAt(composedEnemy.MovementComponent.PreviousPosition);
            map.DrawSomethingAt(composedEnemy.VisualComponent.Visuals, composedEnemy.PositionComponent.Position);
        }
    }
}
else
{
    Console.WriteLine($"Terminal window is too small. Make it bigger (at least ({map.Size.X + map.Origin.X}, {map.Size.Y + map.Origin.Y})) to play");
}