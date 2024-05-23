namespace Survivor.Enemy;

public class Dog : GlobalObjects
{
    public Dog(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        Speed = Speed;
        Hp = 10;
        Damage = 20;
        Cooldown = 1.9f;
        ShootTime = Cooldown;
    }
}