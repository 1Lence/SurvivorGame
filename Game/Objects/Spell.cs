namespace Survivor.Objects;

public class Spell : SpriteSpeed
{
    public Vector2 Direction { get; set; }
    public float Lifespan { get; private set; }

    public Spell(Texture2D tex, SpellData data) : base(tex, data.Position)
    {
        Lifespan = data.Lifespan;
    }

    public void Destroy()
    {
        Lifespan = 0;
    }

    public void Update()
    {
        Position += Direction * Globals.TotalSeconds;
        Lifespan -= Globals.TotalSeconds;
    }
}