namespace Survivor.Base;

public class SpriteSpeed(Texture2D tex, Vector2 pos) : Sprites(tex, pos)
{
    protected int Speed { get; init; } = 100;
    public int Hp { get; protected set; }

    public int Damage { get; protected init; }

    private protected static float Cooldown;
    private protected static float ShootTime;

    public void TakeDamage(int dmg)
    {
        Hp -= dmg;
        if (Hp <= 0) ExpManager.AddExperience(Position);
    }

    private void Fire()
    {
        SpellData pd = new()
        {
            Position = Position,
            Lifespan = 2
        };
        SpellManager.AddProjectile(pd);
    }

    public void Update(PlayerSprite player)
    {
        ShootTime -= Globals.TotalSeconds;
        var toPlayer = player.Position - Position;

        while (ShootTime <= 0)
        {
            ShootTime += Cooldown;
            Fire();
        }

        if (toPlayer.Length() > 4)
        {
            var dir = Vector2.Normalize(toPlayer);
            Position += dir * Speed * Globals.TotalSeconds;
        }
    }
}