namespace Survivor.Objects;

public abstract class Globals
{
    public static float TotalSeconds { get; private set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static Point Bounds { get; set; }
    public static bool IsGameActive { get; set; } = false;
    
    public static void Update(GameTime gt)
    {
        TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}