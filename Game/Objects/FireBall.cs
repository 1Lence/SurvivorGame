namespace Survivor.Objects;

public class FireBall : SpellParent
{
    private readonly float _radius = 500;
    private readonly float _speed = 5;
    private float _angle;

    public FireBall()
    {
        Texture = Globals.Content.Load<Texture2D>("Fire");
        Damage = 0; //TODO: Настроить урон
    }

    public override void Update()
    {
        _angle += _speed * Globals.TotalSeconds;
        var x = PlayerSprite.Pos.X + _radius * (float)Math.Cos(_angle);
        var y = PlayerSprite.Pos.Y + _radius * (float)Math.Sin(_angle);

        Position = new Vector2(x, y);
    }
}