Console.CursorVisible = false;
Point playerPosition = new Point(10, 3);

Player hero = new Player("@", playerPosition);
Player anotherHero = new Player("Q", new Point(1, 1));

Enemy troll = new Enemy("T", new Point(4, 6));

Map map = new Map();

Console.Clear();
map.Display(new Point(15, 2));

map.DrawSomethingAt(hero.Visuals, hero.Position);
map.DrawSomethingAt(anotherHero.Visuals, anotherHero.Position);
map.DrawSomethingAt(troll.Visuals, troll.Position);

while (true)
{
    Point nextPosition = hero.GetNextPosition();
    if (map.IsPointValid(nextPosition))
    {
        hero.Move(nextPosition);

        map.RedrawCellAt(hero.PreviousPosition);
        map.DrawSomethingAt(hero.Visuals, hero.Position);
    }

    Point anotherNextPosition = anotherHero.GetNextPosition();
    if (map.IsPointValid(anotherNextPosition))
    {
        anotherHero.Move(anotherNextPosition);

        map.RedrawCellAt(anotherHero.PreviousPosition);
        map.DrawSomethingAt(anotherHero.Visuals, anotherHero.Position);
    }

    Point trollNextPosition = troll.GetNextPosition();
    if (map.IsPointValid(trollNextPosition))
    {
        troll.Move(trollNextPosition);

        map.RedrawCellAt(troll.PreviousPosition);
        map.DrawSomethingAt(troll.Visuals, troll.Position);
    }
}