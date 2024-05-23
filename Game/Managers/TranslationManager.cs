using Survivor.Backgrounds;
using Survivor.Objects;

namespace Survivor.Managers;

public class TranslationManager
{
    public static Matrix Translation;

    public static void CalculateTranslation()
    {
        var dx = (WindowSize.Widht / 2) - PlayerSprite.Pos.X;
        dx = MathHelper.Clamp(dx, -Background.Widht + WindowSize.Widht, 0);
        var dy = (WindowSize.Height / 2) - PlayerSprite.Pos.Y;
        dy = MathHelper.Clamp(dy, -Background.Height + WindowSize.Height, 0);
        Translation = Matrix.CreateTranslation(dx, dy, 0f);
    }
}