namespace Survivor.Objects;

public class PlayerObject
{
    private readonly float _maxHealth;
    private float _health;
    private readonly HpBar _healthBar;
    private bool _hit;
    private bool _timeGone = true;
    public bool IsToHeal; 
    private readonly Timer _tm = new(1000);
    public PlayerSprite _Player;

    public PlayerObject(float health = 100f)
    {
        var front = Globals.Content.Load<Texture2D>("Health");

        _maxHealth = health;
        _health = health;
        _healthBar = new HpBar(front, _maxHealth, PlayerSprite.Pos);

        _tm.Elapsed += TmElapsed;
        _tm.Enabled = true;
        _tm.AutoReset = true;
        _tm.Start();
    }

    private void TmElapsed(object sender, ElapsedEventArgs e)
    {
        _timeGone = true;
    }

    private void TakeDamage(float dmg)
    {
        _health -= dmg;
        if (_health < 0) _health = 0;
    }

    private GlobalObjects CheckDeath(List<GlobalObjects> dogs)
    {
        foreach (var dog in dogs)
        {
            if (dog.Hp <= 0) continue;
            if ((PlayerSprite.Pos - dog.Position).Length() < 100 && _timeGone)
            {
                _hit = true;
                _timeGone = false;
                return dog;
            }
            
            if (_health == 0)
            {
                _Player.Dead = true;
                break;
            }
        }
        return null;
    }

    public void Heal(float heal)
    {
        _health += heal;
        if (_health > _maxHealth) _health = _maxHealth;
        IsToHeal = false;
    }

    public virtual void Update(List<GlobalObjects> enemies)
    {
        var enemy = CheckDeath(enemies);
        if (_hit && enemy != null)
        {
            TakeDamage(enemy.Damage);
            _hit = false;
        }

        if (IsToHeal)
        {
            Heal(10);
        }
        
        _healthBar.Update(_health);
    }

    public void Draw()
    {
        _healthBar.Draw();
    }
}