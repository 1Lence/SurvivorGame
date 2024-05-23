namespace Survivor;

public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background;
    private Texture2D _mainMenu;
    private GameManager _gameManager;
    private readonly Timer _tm = new(1000);
    private bool _timeGone = true;
    private Song _soundEffect;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _tm.Elapsed += TmElapsed;
        _tm.Enabled = true;
        _tm.AutoReset = true;
        _tm.Start();
    }

    private void TmElapsed(object sender, ElapsedEventArgs e)
    {
        _timeGone = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = WindowSize.Widht;
        _graphics.PreferredBackBufferHeight = WindowSize.Height;
        _graphics.IsFullScreen = false; //FullScring or not
        _graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _background = Content.Load<Texture2D>("Trava");
        _mainMenu = Content.Load<Texture2D>("MainMenu");
        Globals.SpriteBatch = _spriteBatch;
        Globals.Content = Content;
        _gameManager = new GameManager();
        _soundEffect = Content.Load<Song>("Music");
        MediaPlayer.Play(_soundEffect);
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Volume = 0.1f;
    }

    protected override void Update(GameTime gameTime)
    {
        if (Globals.IsGameActive)
        {
            _gameManager.Update();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.W) && !Keyboard.GetState().IsKeyDown(Keys.E)) PlayerController.Up();

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.E) && _timeGone)
            {
                PlayerController.WUp();
                _timeGone = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) && !Keyboard.GetState().IsKeyDown(Keys.E))
                PlayerController.Right();

            if (Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.E) && _timeGone)
            {
                PlayerController.ERight();
                _timeGone = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) && !Keyboard.GetState().IsKeyDown(Keys.E))
                PlayerController.Down();

            if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.E) && _timeGone)
            {
                PlayerController.SDown();
                _timeGone = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && !Keyboard.GetState().IsKeyDown(Keys.E))
                PlayerController.Left();

            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.E) && _timeGone)
            {
                PlayerController.Eleft();
                _timeGone = false;
            }
        }
        else
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Globals.IsGameActive = true;
            }
        }

        TranslationManager.CalculateTranslation();
        Globals.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(transformMatrix: TranslationManager.Translation);
        _spriteBatch.Draw(_mainMenu, new Vector2(500, 1000), Color.Red);
        if (Globals.IsGameActive)
        {
            _spriteBatch.Draw(_background, new Rectangle(1, 0, Background.Widht, Background.Height), Color.White);
            _gameManager.Draw();
        }

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}