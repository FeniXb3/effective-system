Console.CursorVisible = false;
Point playerPosition = new Point(10, 3);

ComposedPlayer composedPlayer = new ComposedPlayer("@", playerPosition);
ComposedEnemy composedEnemy = new ComposedEnemy("T", new Point(4, 6));

Player hero = new Player("@", playerPosition);
Player anotherHero = new Player("Q", new Point(1, 1));

Enemy troll = new Enemy("T", new Point(4, 6));

StaticEnemy whipingWillow = new StaticEnemy("W", new Point(5, 6));

Character[] characters = new Character[] 
{
    hero,
    anotherHero,
    troll,
    whipingWillow,
};

MovementComponent[] movements = new MovementComponent[]
{
    composedPlayer.MovementComponent,
    composedEnemy.MovementComponent,
};



Map map = new Map();

Console.Clear();

if (map.Size.X + map.Origin.X >= 0 && map.Size.X + map.Origin.X < Console.BufferWidth
    && map.Size.Y + map.Origin.Y >= 0 && map.Size.Y + map.Origin.Y < Console.BufferHeight)
{
    map.Display(new Point(15, 2));

    map.DrawSomethingAt(composedPlayer.VisualComponent.Visuals, composedPlayer.PositionComponent.Position);
    map.DrawSomethingAt(composedEnemy.VisualComponent.Visuals, composedEnemy.PositionComponent.Position);

    // foreach (Character character in characters)
    // {
    //     map.DrawSomethingAt(character.Visuals, character.Position);
    // }
    

    while (true)
    {
        foreach (var movementComponent in movements)
        {
            var position = movementComponent.GetNextPosition();
            if (map.IsPointValid(position))
            {
                movementComponent.Move(position);
            }
            map.RedrawCellAt(movementComponent.PreviousPosition);
        }

        map.DrawSomethingAt(composedPlayer.VisualComponent.Visuals, composedPlayer.PositionComponent.Position);
        map.DrawSomethingAt(composedEnemy.VisualComponent.Visuals, composedEnemy.PositionComponent.Position);
        // foreach (Character character in characters)
        // {
        //     Point nextPosition = character.GetNextPosition();
        //     if (map.IsPointValid(nextPosition))
        //     {
        //         character.Move(nextPosition);

        //         map.RedrawCellAt(character.PreviousPosition);
        //         map.DrawSomethingAt(character.Visuals, character.Position);
        //     }
        // }
    }

}
else
{
    Console.WriteLine($"Terminal window is too small. Make it bigger (at least ({map.Size.X + map.Origin.X}, {map.Size.Y + map.Origin.Y})) to play");
}