namespace Survivor.Base;

public class SpellParent
{
    protected Texture2D Texture { get; init; }
    protected Vector2 Position { get; set; }
    public Vector2 GigaPosition { get; protected set; }
    public int Damage { get; protected init; }
    
    public virtual void Update()
    {
        
    }

    public void Draw()
    {
        GigaPosition = new Vector2(PlayerSprite.Pos.X + 50, PlayerSprite.Pos.Y + 50);
        Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }
}