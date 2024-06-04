internal class KeyboardInputComponent : IInputComponent
{
    private Dictionary<ConsoleKey, Point> directions;
    public KeyboardInputComponent()
    {
        directions = new()
        {
            [ConsoleKey.A] = new Point(-1, 0),
            [ConsoleKey.D] = new Point(1, 0),
            [ConsoleKey.W] = new Point(0, -1),
            [ConsoleKey.S] = new Point(0, 1),
            [ConsoleKey.E] = new Point(1, -1)
        };
    }

    public Point GetDirection()
    {
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (directions.ContainsKey(pressedKey.Key))
        {
            return directions[pressedKey.Key];
        }
        else
        {
            return new Point(0, 0);
        }
    }
}
