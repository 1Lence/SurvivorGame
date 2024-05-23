namespace Survivor.Base;

public class GlobalObjects(Texture2D tex, Vector2 pos) : Sprites(tex, pos)
{
    protected int Speed { get; init; } = 100;
    public int Hp { get; protected set; }
    public int Damage { get; protected init; }

    private protected static float Cooldown;
    private protected static float ShootTime;

    public void TakeDamage(int dmg)
    {
        Hp -= dmg;
        if (Hp <= 0) DroppedObjectManager.AddObject(Position);
    }

    private void FireExplosion()
    {
        FireExploseData fireExploseData = new()
        {
            Position = Position,
            Lifespan = 2
        };
        SpellManager.AddProjectile(fireExploseData);
    }

    public void Update(PlayerSprite player)
    {
        ShootTime -= Globals.TotalSeconds;
        var toPlayer = player.Position - Position;

        while (ShootTime <= 0)
        {
            ShootTime += Cooldown;
            FireExplosion();
        }

        if (toPlayer.Length() > 4)
        {
            var dir = Vector2.Normalize(toPlayer);
            Position += dir * Speed * Globals.TotalSeconds;
        }
    }
    
    
}