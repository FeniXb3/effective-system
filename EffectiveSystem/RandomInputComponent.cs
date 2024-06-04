internal class RandomInputComponent : InputComponent
{
    Random rng;

    public RandomInputComponent()
    {
        rng = new Random();
    }

    public override Point GetDirection()
    {
        return new Point(rng.Next(-1, 2), rng.Next(-1, 2));
    }
}