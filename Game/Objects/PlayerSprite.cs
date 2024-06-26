namespace Survivor.Objects;

public class PlayerSprite
{
    public static Vector2 Pos = new(1500, 1500);
    private readonly PlayerDraw _sprite;
    public Vector2 Position;
    public bool Dead { get; set; }
    public static int Experience { get; private set; }

    public static bool FirstLevel;
    
    public static bool SecondLevel;

    public PlayerSprite()
    {
        var sprite = Globals.Content.Load<Texture2D>("Player");
        _sprite = new PlayerDraw(sprite, 0, Position);
    }

    public void Reset()
    {
        Dead = false;
        Pos.X = 1500;
        Pos.Y = 1500;
    }

    public void GetExperience(int exp)
    {
        Experience += exp;
    }

    public void Update()
    {
        if (Experience == 10)
        {
            FirstLevel = true;
        }
        if (Experience == 20)
        {
            SecondLevel = true;
        }

        Position = new Vector2(Pos.X, Pos.Y);
        _sprite.Update();
    }

    public void Draw()
    {
        _sprite.Draw();
    }
}