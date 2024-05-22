namespace Survivor.Managers;

public class EnemyManager
{
    public static List<Dog> Dogs { get; } = [];
    public static List<Cultist> Cultist { get; } = [];
    public static List<SpriteSpeed> Enemies { get; } = [];
    private static Texture2D _dogTexture;
    private static Texture2D _cultistTexture;
    private static float _spawnCooldown;
    private static float _spawnTime;
    private static Random _random;

    public static void Init()
    {
        _dogTexture = Globals.Content.Load<Texture2D>("Dog");
        _cultistTexture = Globals.Content.Load<Texture2D>("Cultist");
        _spawnCooldown = 0.33f;
        _spawnTime = _spawnCooldown;
        _random = new Random();
    }

    public static void Reset()
    {
        Dogs.Clear();
        _spawnTime = _spawnCooldown;
    }

    private static Vector2 RandomPosition()
    {
        Vector2 pos = new()
        {
            X = _random.Next(100, 3000),
            Y = _random.Next(100, 3000)
        };

        return pos;
    }

    public static void AddEnemy()
    {
        Enemies.Add(new Dog(_dogTexture, RandomPosition()));
        if (PlayerSprite.Experience == 2)
        {
            Enemies.Add(new Cultist(_cultistTexture, RandomPosition()));
        }
    }

    public static void Update(PlayerSprite player)
    {
        _spawnTime -= Globals.TotalSeconds;
        while (_spawnTime <= 0)
        {
            _spawnTime += _spawnCooldown;
            AddEnemy();
        }

        foreach (var dog in Enemies)
        {
            dog.Update(player);
        }
        
        /*foreach (var c in Cultist)
        {
            c.Update(player);
        }*/

        Enemies.RemoveAll((dog) => dog.Hp <= 0);
        Enemies.RemoveAll((cultist) => cultist.Hp <= 0);
    }

    public static void Draw()
    {
        foreach (var dog in Enemies)
        {
            dog.Draw();
        }
    }
}