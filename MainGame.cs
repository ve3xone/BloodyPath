using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BloodyPath.Models;
using BloodyPath.Views;
using BloodyPath.Controllers;

namespace BloodyPath;

public class MainGame : Game
{
    private readonly GraphicsDeviceManager Graphics;
    private SpriteBatch SpriteBatch;

    private readonly MainMenu MainMenu = new();
    private readonly BattleField BattleField = new();

    private Texture2D BackgroundTexture;

    public MainGame()
    {
        Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        //Graphics.IsFullScreen = true;

        // Пока что нету настроек
        // Поэтому я оставлю эти параметры сдесь
        Graphics.PreferredBackBufferWidth = 800;
        Graphics.PreferredBackBufferHeight = 600;
        Graphics.ApplyChanges();
        IsMouseVisible = true;
    }

    protected override void Initialize() => base.Initialize();

    protected override void LoadContent()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);

        BackgroundTexture = Content.Load<Texture2D>(@"Backgrounds\Landscape_800_600");

        MainMenu.Screen = new MainMenuScreen(this, GraphicsDevice, 
                                                                              Content.Load<SpriteFont>(@"Fonts\FontMainMenu"));
        MainMenu.Screen.LoadContent(BackgroundTexture);

        MainMenu.ScreenDrawer = new(MainMenu.Screen);
        MainMenu.ScreenController = new(MainMenu.Screen);

        BattleField.Screen = new(GraphicsDevice, 
                                            Content.Load<SpriteFont>(@"Fonts\FontBattleField"),
                                            BackgroundTexture,
                                            Content, MainMenu.Screen);
        MainMenu.Screen.BattleFieldScreen = BattleField.Screen;
        BattleField.Screen.LoadContent();

        BattleField.ScreenDrawer = new(BattleField.Screen);
        BattleField.ScreenController = new(BattleField.Screen);

        // Comment for test (debug)
        // _landscapeTexture = Content.Load<Texture2D>("Landscape");
    }

    protected override void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();

        MainMenu.ScreenController.Update();

        BattleField.ScreenController.Update(keyboardState);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        MainMenu.ScreenDrawer.Draw(SpriteBatch);

        BattleField.ScreenDrawer.Draw(SpriteBatch);

        base.Draw(gameTime);
    }
}