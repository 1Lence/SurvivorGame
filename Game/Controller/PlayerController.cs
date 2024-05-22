using Survivor.Backgrounds;
using Survivor.Objects;

namespace Survivor.Controller;

public class PlayerController
{
    private static int Speed { get; set; } = 10;
    public static void Up()
    {
        if (PlayerSprite.Pos.Y > -10)
            PlayerSprite.Pos.Y -= Speed;
    }
    public static void Down()
    {
        if (PlayerSprite.Pos.Y < Background.Height - 100)
            PlayerSprite.Pos.Y += Speed;
    }
    public static void Right()
    {
        if (PlayerSprite.Pos.X < Background.Widht - 100) 
            PlayerSprite.Pos.X += Speed;
    }
    public static void Left()
    {
        if (PlayerSprite.Pos.X > -30) 
            PlayerSprite.Pos.X -= Speed;
    }
    public static void Eleft()
    {
        if (PlayerSprite.Pos.X > -30) 
            PlayerSprite.Pos.X -= 300;
    }
    public static void ERight()
    {
        if (PlayerSprite.Pos.X < Background.Widht - 100) 
            PlayerSprite.Pos.X += 300;
    }
    public static void SDown()
    {
        if (PlayerSprite.Pos.Y < Background.Height - 100)
            PlayerSprite.Pos.Y += 300;
    }
    public static void WUp()
    {
        if (PlayerSprite.Pos.Y > -10)
            PlayerSprite.Pos.Y -= 300;
    }
}