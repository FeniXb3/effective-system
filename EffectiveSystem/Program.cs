Point playerPosition = new Point(10, 3);
Player hero = new Player(playerPosition);
Map map = new Map();

Console.Clear();
map.Display();

while (true)
{
    var previousCell = map.GetCellVisualAt(hero.PreviousPosition);
    Console.SetCursorPosition(hero.PreviousPosition.X, hero.PreviousPosition.Y);
    Console.WriteLine(previousCell);

    Console.SetCursorPosition(hero.Position.X, hero.Position.Y);
    Console.Write("@");
    
    Point nextPosition = hero.GetNextPosition();
    if (map.IsPointValid(nextPosition))
    {
        hero.Move(nextPosition);
    }
}