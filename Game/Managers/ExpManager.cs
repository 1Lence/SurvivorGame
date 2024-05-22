namespace Survivor.Managers;

public class ExpManager
{
    private static Texture2D _texture;
    public static List<Exp> Experience { get; } = [];
    private static Vector2 _position;

    public static void Init()
    {
        _texture = Globals.Content.Load<Texture2D>("Exp");
        _position = new(Globals.Bounds.X - (2 * _texture.Width), 0);
    }

    public static void Reset()
    {
        Experience.Clear();
    }

    public static void AddExperience(Vector2 pos)
    {
        Experience.Add(new(_texture, pos));
    }

    public static void Update(PlayerSprite player)
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

        Experience.RemoveAll((e) => e.Lifespan <= 0);
    }

    public static void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, _position, null,
            Color.White * 0.75f, 0f, Vector2.Zero, 2f,
            SpriteEffects.None, 1f);

        foreach (var e in Experience)
        {
            e.Draw();
        }
    }
}