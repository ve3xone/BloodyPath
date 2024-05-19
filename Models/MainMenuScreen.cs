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
    public SpriteFont Font;
    public Texture2D Background;
    public VisibilityScreens VisibilityScreens;
    private readonly Game Game;

    public MainMenuScreen(Game game,  
                                       SpriteFont font, 
                                       Texture2D background, 
                                       VisibilityScreens visibilityScreens)
    {
        Game = game;
        Font = font;
        Background = background;
        VisibilityScreens = visibilityScreens;
    }

    public void LoadContent()
    {
        Size = new(0, 0, (int)(Game.GraphicsDevice.Viewport.Width / 2.5), Game.GraphicsDevice.Viewport.Height);

        Texture = new(Game.GraphicsDevice, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);

        // Прозрачнность
        Color[] data = new Color[Texture.Width * Texture.Height];
        Texture.GetData(data);
        for (int i = 0; i < data.Length; i++)
            data[i] = new Color(255, 255, 255, 150); // Установляется альфа-канал на 150 для каждого пикселя
        Texture.SetData(data);

        PlayButton.ClickableText = new ClickableText(Font, "Play", new Vector2(25, 300), Color.White, Color.Blue, delegate
        {
            //Game.Exit();
            VisibilityScreens.MainMenuIsVisible = false;
            VisibilityScreens.BattleFieldIsVisible = true;
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