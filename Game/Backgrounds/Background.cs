using System.Drawing;

namespace Survivor.Backgrounds;

public abstract class WindowSize
{
    private static readonly Size Resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
    
    public static int Widht = Resolution.Width;
    public static int Height = Resolution.Height;
}

public abstract class Background
{
    public static int Widht = 3000;
    public static int Height = 3000;
}