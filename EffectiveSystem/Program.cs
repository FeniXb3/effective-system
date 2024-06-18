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

            int distanceX = Math.Abs(composedPlayer.PositionComponent.Position.X - composedEnemy.PositionComponent.Position.X);
            int distanceY = Math.Abs(composedPlayer.PositionComponent.Position.Y - composedEnemy.PositionComponent.Position.Y);

            if ((distanceX == 1 && distanceY == 0) || (distanceX == 0 && distanceY == 1))
            {
                Console.SetCursorPosition(2, 0);
                Console.WriteLine("Enemy is nerby! Attacking! Press any key to continue");
                Console.ReadKey(true);
                
                Console.SetCursorPosition(2, 0);
                Console.WriteLine("Enemy is nerby! Attacked!                             ");
            }
            else
            {
                Console.SetCursorPosition(2, 0);
                Console.WriteLine("                          ");
            }
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