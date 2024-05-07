Point playerPosition = new Point(10, 3);
Player hero = new Player(playerPosition);
Map map = new Map();

Console.Clear();
map.Display(new Point(15, 2));

while (true)
{
    var previousCell = map.GetCellVisualAt(hero.PreviousPosition);
    map.DrawSomethingAt(previousCell, hero.PreviousPosition);
    map.DrawSomethingAt('@', hero.Position);
    
    Point nextPosition = hero.GetNextPosition();
    if (map.IsPointValid(nextPosition))
    {
        hero.Move(nextPosition);
    }
}