namespace Survivor.Objects;

public class Radiance : SpellParent
{
    public Radiance()
    {
        Texture = Globals.Content.Load<Texture2D>("Radik");
        Damage = 2;
    }

    public override void Update()
    {
        if (PlayerSprite.SecondLevel)
        {
            //Для получения мобами корректного урона, необходимо было изменить позицию фактического нахождения спелла
            GigaPosition = new Vector2(PlayerSprite.Pos.X + 50, PlayerSprite.Pos.Y + 50); 
            //Позиуия отрисовки
            Position = new Vector2(PlayerSprite.Pos.X , PlayerSprite.Pos.Y);
        }
    }
}