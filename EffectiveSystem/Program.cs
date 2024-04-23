// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("Effective System");
Console.WriteLine("Bye!");

// Player hero = new Player(10, 3);
Point playerPosition = new Point(10, 3);
Player hero = new Player(playerPosition);
playerPosition.X = 0;
// hero.X = 10;
// hero.Y = 3;
Console.WriteLine(hero.Hp);
hero.Hp = 90;
Console.WriteLine(hero.Hp);
hero.Heal();
hero.Heal();
hero.Heal();
Console.WriteLine(hero.Hp);
hero.Hp = 9001;

Console.WriteLine(hero.Hp);


/*

###########
#.........#
#.........#
#.........#
#.........#
#.........#
#.........#
############

*/
Map map = new Map();

Console.Clear();
map.Display();



while (true)
{
    char previousCell = map.GetCellAt(hero.PreviousPosition);
    Console.SetCursorPosition(hero.PreviousPosition.X, hero.PreviousPosition.Y);
    Console.WriteLine(previousCell);

    Console.SetCursorPosition(hero.Position.X, hero.Position.Y);
    Console.Write("@");
    //Console.WriteLine($"X: {hero.X} Y: {hero.Y}");
    Point nextPosition = hero.GetNextPosition();
    if (map.IsPointValid(nextPosition))
    {
        hero.Move(nextPosition);
    }
}