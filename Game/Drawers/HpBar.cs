using Survivor.Objects;

namespace Survivor.PlayerObjects;

public class HpBar
{
    private readonly Texture2D _foreground;
    private Vector2 _position;
    private readonly float _maxValue;
    private float _currentValue;
    private Rectangle _part;
    
    public HpBar(Texture2D fg, float max, Vector2 pos)
    {
        _foreground = fg;
        _maxValue = max;
        _currentValue = max;
        _position = pos;
        _part = new(0, 0, _foreground.Width, _foreground.Height);
    }

    public virtual void Update(float value)
    {
        _currentValue = value;
        _part.Width = (int)(_currentValue / _maxValue * _foreground.Width);
        _position = new Vector2(PlayerSprite.Pos.X, PlayerSprite.Pos.Y);
    }
    
    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(_foreground, _position, _part, Color.White, 0, Vector2.Zero, 0.2f, SpriteEffects.None, 0.2f);
    }
}