// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("Effective System");
Console.WriteLine("Bye!");

Player hero = new Player();
Console.WriteLine(hero.Hp);
hero.Hp = 90;
Console.WriteLine(hero.Hp);
hero.Heal();
hero.Heal();
hero.Heal();
Console.WriteLine(hero.Hp);
hero.Hp = 9001;

Console.WriteLine(hero.Hp);

while (true)
{
    Console.Clear();
    Console.SetCursorPosition(hero.X, hero.Y);
    Console.Write("@");
    //Console.WriteLine($"X: {hero.X} Y: {hero.Y}");
    hero.Move();
}