using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BloodyPath.Models;

namespace BloodyPath;

public class MainGame : Game
{
    private readonly MainMenu MainMenu = new();
    private readonly BattleField BattleField = new();
    private readonly VisibilityScreens VisibilityScreens = new();

    private readonly GraphicsDeviceManager Graphics;
    private SpriteBatch SpriteBatch;

    private Texture2D BackgroundTexture;

    public MainGame()
    {
        Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        // Пока что нету настроек
        // Поэтому я оставлю эти параметры сдесь
        // Graphics.IsFullScreen = true;
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

        MainMenu.Screen = new (this, 
                               Content.Load<SpriteFont>(@"Fonts\FontMainMenu"),
                               VisibilityScreens);

        MainMenu.Screen.LoadContent();

        MainMenu.ScreenDrawer = new(MainMenu.Screen);
        MainMenu.ScreenController = new(MainMenu.Screen);

        BattleField.Screen = new (this, 
                                 Content.Load<SpriteFont>(@"Fonts\FontBattleField"),
                                 BackgroundTexture,
                                 VisibilityScreens);

        BattleField.Screen.LoadContent();

        BattleField.ScreenDrawer = new(BattleField.Screen);
        BattleField.ScreenController = new(BattleField.Screen);
    }

    protected override void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();

        MainMenu.ScreenController.Update(gameTime);

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