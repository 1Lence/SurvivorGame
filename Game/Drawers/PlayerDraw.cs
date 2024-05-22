namespace Survivor.Drawers;
public class PlayerDraw
{
    private readonly Texture2D _foreground;
    private Vector2 _position;
    
    public PlayerDraw(Texture2D fg, float max, Vector2 pos)
    {
        _foreground = fg;
        _position = pos;
    }

    public virtual void Update()
    {
        _position = new Vector2(PlayerSprite.Pos.X, PlayerSprite.Pos.Y);
    }
    
    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(_foreground, _position, Color.White);
    }
}