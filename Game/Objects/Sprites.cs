namespace Survivor.Objects;

public class Sprites(Texture2D tex, Vector2 pos)
{
    public Vector2 Position { get; protected set; } = pos;
    
    private readonly Vector2 _origin = new(tex.Width / 2, tex.Height / 2);
    private Texture2D Texture { get; set; } = tex;
    private readonly Vector2 _scale = Vector2.One;
    private readonly Color _color = Color.White;
    public float Scale { get; set; } = 1f;

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, null, _color, 0f, _origin, _scale, SpriteEffects.None, 1f);
    }
}