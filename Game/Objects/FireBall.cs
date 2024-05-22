namespace Survivor.Objects;

public class FireBall
{
    public Vector2 Position;
    public int Damage { get; set; }
    private readonly float _radius = 500;
    private readonly float _speed = 5;
    private float _angle;

    public FireBall()
    {
        Damage = 1;
    }

    public void Update()
    {
        _angle += _speed * Globals.TotalSeconds;
        float x = PlayerSprite.Pos.X + _radius * (float)Math.Cos(_angle);
        float y = PlayerSprite.Pos.Y + _radius * (float)Math.Sin(_angle);

        Position = new Vector2(x, y);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Globals.Content.Load<Texture2D>("Fire"), Position, Color.White);
    }
}