namespace Survivor.Objects;

public class Exp(Texture2D tex, Vector2 pos) : GlobalObjects(tex, pos)
{
    public new float Lifespan { get; private set; } = Life;
    private const float Life = 5f;

    public void Update()
    {
        Lifespan -= Globals.TotalSeconds;
        Scale = 0.33f + (Lifespan / Life * 0.66f);
    }

    public void Collect()
    {
        Lifespan = 0;
    }
}