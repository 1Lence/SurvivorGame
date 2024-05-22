namespace Survivor.Managers;

public class GameManager
{
    private readonly PlayerObject _playerObject;
    private readonly PlayerSprite _player;

    public GameManager()
    {
        _playerObject = new PlayerObject();
        _player = new PlayerSprite();
        EnemyManager.Init();
        EnemyManager.AddEnemy();
        SpellManager.Init();
        ExpManager.Init();
    }

    private void Restart()
    {
        EnemyManager.Reset();
        _player.Reset();
        ExpManager.Reset();
    }

    public void Update()
    {
        MouseTestInputManager.Update();
        EnemyManager.Update(_player);
        
        _playerObject.Update(EnemyManager.Enemies);
        _player.Update();
        SpellManager.Update(EnemyManager.Enemies);
        if (_player.Dead) Restart();
        ExpManager.Update(_player);
    }

    public void Draw()
    {
        SpellManager.Draw();
        EnemyManager.Draw();
        ExpManager.Draw();
        _playerObject.Draw();
        _player.Draw();
    }
}