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

string[] map = {
    "###########",
    "#.........#",
    "#.........#",
    "#.........#",
    "#.........#",
    "#.........#",
    "#.........#",
    "#.........#",
    "#.........#",
    "###########",
};

while (true)
{
    Console.Clear();
    foreach (string row in map)
    {
        Console.WriteLine(row);
    }

    Console.SetCursorPosition(hero.Position.X, hero.Position.Y);
    Console.Write("@");
    //Console.WriteLine($"X: {hero.X} Y: {hero.Y}");
    hero.Move();
}