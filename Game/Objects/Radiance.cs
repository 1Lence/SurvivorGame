namespace Survivor.Objects;

public class Radiance : SpellParent
{
    public Radiance()
    {
        Texture = Globals.Content.Load<Texture2D>("Radik");
        Damage = 0;
    }

    public override void Update()
    {
        GigaPosition = new Vector2(PlayerSprite.Pos.X + 50, PlayerSprite.Pos.Y + 50);
        Position = new Vector2(PlayerSprite.Pos.X , PlayerSprite.Pos.Y);
    }
}