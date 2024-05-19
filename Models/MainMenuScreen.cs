using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Models;

public class MainMenuScreen
{
    public readonly Button PlayButton = new();
    public readonly Button SettingsButton = new();
    public readonly Button ExitButton = new();
    public Rectangle Size;
    public Texture2D Texture;
    public GraphicsDevice GraphicsDevice;
    public Game Game;
    public SpriteFont Font;
    public Texture2D Background;
    public bool IsVisible;
    public BattleFieldScreen BattleFieldScreen;

    public MainMenuScreen(Game game, GraphicsDevice graphicsDevice,  SpriteFont font)
    {
        GraphicsDevice = graphicsDevice;
        Game = game;
        Font = font;
        IsVisible = true;
    }

    public void LoadContent(Texture2D background)
    {
        this.Background = background;
        Size = new(0, 0, (int)(GraphicsDevice.Viewport.Width / 2.5), GraphicsDevice.Viewport.Height);

        Texture = new(GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

        // Прозрачнность
        Color[] data = new Color[Texture.Width * Texture.Height];
        Texture.GetData(data);
        for (int i = 0; i < data.Length; i++)
            data[i] = new Color(255, 255, 255, 150); // Установляется альфа-канал на 150 для каждого пикселя
        Texture.SetData(data);

        PlayButton.ClickableText = new ClickableText(Font, "Play", new Vector2(25, 300), Color.White, Color.Blue, delegate
        {
            //Game.Exit();
            IsVisible = false;
            BattleFieldScreen.IsVisible = true;
        });
        PlayButton.ClickableTextDrawer = new(PlayButton.ClickableText);
        PlayButton.ClickableTextController = new(PlayButton.ClickableText);

        SettingsButton.ClickableText = new ClickableText(Font, "Settings", new Vector2(25, 325), Color.White, Color.Blue, delegate
        {
            Game.Exit();
        });
        SettingsButton.ClickableTextDrawer = new(SettingsButton.ClickableText);
        SettingsButton.ClickableTextController = new(SettingsButton.ClickableText);

        ExitButton.ClickableText = new ClickableText(Font, "Exit", new Vector2(25, 350), Color.White, Color.Blue, delegate
        {
            Game.Exit();
        });
        ExitButton.ClickableTextDrawer = new(ExitButton.ClickableText);
        ExitButton.ClickableTextController = new(ExitButton.ClickableText);
    }
}