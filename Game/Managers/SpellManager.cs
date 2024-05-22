namespace Survivor.Managers;

public class SpellManager
{
    private static Texture2D _texture;
    private static List<Spell> Projectiles { get; } = [];
    private static FireBall _projectile;

    public static void Init()
    {
        _projectile = new FireBall();
        _texture = Globals.Content.Load<Texture2D>("FireBall");
    }

    public static void Reset()
    {
        Projectiles.Clear();
    }

    public static void AddProjectile(SpellData data)
    {
        Projectiles.Add(new(_texture, data));
    }

    public static void Update(List<SpriteSpeed> dogs)
    {
        foreach (var p in Projectiles)
        {
            p.Update();
            foreach (var dog in dogs)
            {
                if ((p.Position - dog.Position).Length() < 50)
                {
                    dog.TakeDamage(1);
                    break;
                }
            }
        }

        Projectiles.RemoveAll((p) => p.Lifespan <= 0);

        if (PlayerSprite.LevelUp)
        {
            _projectile.Update();

            foreach (var dog in dogs)
            {
                if ((_projectile.Position - dog.Position).Length() < 100)
                {
                    dog.TakeDamage(_projectile.Damage);
                    break;
                }
            }
        }
    }

    public static void Draw()
    {
        foreach (var p in Projectiles)
        {
            p.Draw();
        }

        if (PlayerSprite.LevelUp)
        {
            _projectile.Draw();
        }
    }
}