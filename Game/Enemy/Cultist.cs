namespace Survivor.Enemy;

public class Cultist : GlobalObjects
{
    public Cultist(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        Speed = Speed;
        Hp = 10;
        Damage = 10;
        Cooldown = 1.9f;
        ShootTime = Cooldown;
    }
}