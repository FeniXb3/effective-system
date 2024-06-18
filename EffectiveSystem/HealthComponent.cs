internal class HealthComponent
{
    public int Hp
    { 
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }
    private int hp = 100;

    public int MaxHp { get; private set; } = 100;

    public void Heal()
    {
        Hp += 10;
    }

    public void TakeDamage(int amount)
    {
        Hp -= amount;
    } 
}