namespace Survivor.Managers;

public class DroppedObjectManager
{
    private static Texture2D _textureExp;
    private static Texture2D _textureFlask;
    private static List<Exp> Experience { get; } = [];
    private static List<Flask> Flasks { get; } = [];
    private static Vector2 _position;
    private static Random _random;
    public static int RandomSpawn;
    public static void Init()
    {
        _textureExp = Globals.Content.Load<Texture2D>("Exp");
        _position = new Vector2(Globals.Bounds.X - (2 * _textureExp.Width), 0);
        
        _textureFlask = Globals.Content.Load<Texture2D>("Flask");
        _position = new Vector2(Globals.Bounds.X - (2 * _textureFlask.Width), 0);
        _random = new Random();
    }

    public static void Reset()
    {
        Experience.Clear();
    }

    public static void AddObject(Vector2 pos)
    {
        RandomSpawn = _random.Next(1, 10);
        
        Experience.Add(new Exp(_textureExp, pos));
        if (RandomSpawn > 6)
        {
            Flasks.Add(new Flask(_textureFlask, pos));
        }
    }

    public static void Update(PlayerSprite player, PlayerObject playerObject)
    {
        foreach (var e in Experience)
        {
            e.Update();

            if ((e.Position - player.Position).Length() < 150)
            {
                e.Collect();
                player.GetExperience(1);
            }
        }
        
        foreach (var flask in Flasks)
        {
            flask.Update();

            if ((flask.Position - player.Position).Length() < 150)
            {
                flask.Collect();
                playerObject.Heal(10);
                playerObject._isToHeal = true;
            }
        }
        
        Experience.RemoveAll((exp) => exp.Lifespan <= 0);
        Flasks.RemoveAll((flaks) => flaks.Lifespan <= 0);
    }

    public static void Draw()
    {
        Globals.SpriteBatch.Draw(_textureExp, _position, null,
            Color.White * 0.75f, 0f, Vector2.Zero, 2f,
            SpriteEffects.None, 1f);

        foreach (var e in Experience)
        {
            e.Draw();
        }
        
        Globals.SpriteBatch.Draw(_textureFlask, _position, null,
            Color.White * 0.75f, 0f, Vector2.Zero, 2f,
            SpriteEffects.None, 1f);

        foreach (var flask in Flasks)
        {
            flask.Draw();
        }
    }
}