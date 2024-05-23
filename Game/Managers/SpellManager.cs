namespace Survivor.Managers;

public class SpellManager
{
    private static Texture2D _texture;
    private static List<Spell> Projectiles { get; } = [];
    private static List<SpellParent> Spells { get; } = [];

    public static void Init()
    {
        Spells.Add(new FireBall());
        Spells.Add(new Radiance());
        _texture = Globals.Content.Load<Texture2D>("FireBall");
    }

    public static void Reset()
    {
        Projectiles.Clear(); //TODO: Ресет настроить
    }

    public static void AddProjectile(FireExploseData data)
    {
        Projectiles.Add(new Spell(_texture, data));
    }

    public static void Update(List<GlobalObjects> enemies)
    {
        foreach (var p in Projectiles)
        {
            p.Update();
            foreach (var enemy in enemies.Where(enemy 
                         => (p.Position - enemy.Position).Length() < 50))
            {
                enemy.TakeDamage(10); //TODO: Настроить урон
                break;
            }
        }

        Projectiles.RemoveAll((p) => p.Lifespan <= 0);

        if (PlayerSprite.LevelUp)
        {
            foreach (var spells in Spells)
            {
                spells.Update();
                foreach (var enemy in enemies.Where(enemy => Vector2.Distance(spells.GigaPosition, enemy.Position) <= 150))
                {
                    enemy.TakeDamage(spells.Damage);
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

        foreach (var spells in Spells.Where(spells => PlayerSprite.LevelUp))
        {
            spells.Draw();
        }
    }
}