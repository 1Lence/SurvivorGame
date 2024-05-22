namespace Survivor.Enemy;

public class Dog : SpriteSpeed
{
    public Dog(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        Speed = Speed;
        Hp = 10;
        Damage = 1;
        Cooldown = 1.9f;
        ShootTime = Cooldown;
    }
}