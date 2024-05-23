namespace Survivor.Objects;

public class Spell : GlobalObjects
{
    public Vector2 Direction { get; set; }
    public float Lifespan { get; private set; }

    public Spell(Texture2D tex, FireExploseData data) : base(tex, data.Position)
    {
        Lifespan = data.Lifespan;
    }
    
    public void Update()
    {
        Position += Direction * Globals.TotalSeconds;
        Lifespan -= Globals.TotalSeconds;
    }
}