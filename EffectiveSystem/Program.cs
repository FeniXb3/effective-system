Point playerPosition = new Point(10, 3);
Player hero = new Player(playerPosition);
Map map = new Map();

Console.Clear();
map.Display(new Point(15, 2));

while (true)
{
    var previousCell = map.GetCellVisualAt(hero.PreviousPosition);
    Console.SetCursorPosition(hero.PreviousPosition.X + map.Origin.X, hero.PreviousPosition.Y + map.Origin.Y);
    Console.Write(previousCell);

    Console.SetCursorPosition(hero.Position.X + map.Origin.X, hero.Position.Y + map.Origin.Y);
    Console.Write("@");
    
    Point nextPosition = hero.GetNextPosition();
    if (map.IsPointValid(nextPosition))
    {
        hero.Move(nextPosition);
    }
}