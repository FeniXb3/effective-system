class Player
{
    public int Hp
    { 
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }
    private int hp = 100;
    public int MaxHp { get; private set; } = 100;

    public int X { get; set; }
    public int Y { get; set; }
 
    public void Heal()
    {
        Hp += 10;
    }

    public void Move()
    {
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);

        if (pressedKey.Key == ConsoleKey.A)
        {
            X -= 1;
        }
        else if (pressedKey.Key == ConsoleKey.D)
        {
            X += 1;
        }
    }
}


/*
Player
    dane:
    - hp
    - maxhp
    - mana
    - maxmana
    - int
    - dex
    - str
    - inventory
        - item
        - item
        - ...
    - position
        - x
        - y

    akcje:
    - interact
    - use item
    - move
    - open inventory
    - take damage
    - heal
    - die/faint
    - attack
    - regenerate mana
*/