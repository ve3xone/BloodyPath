using BloodyPath.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BloodyPath.Models;

public class MainMenuScreen
{
    public readonly Button PlayButton = new();
    public readonly Button SettingsButton = new();
    public readonly Button ExitButton = new();
    public Rectangle Size;
    public Texture2D Texture;
    public SpriteFont Font;
    public VisibilityScreens VisibilityScreens;
    public readonly Game Game;
    public Animation AnimationBackground = new();

    public MainMenuScreen(Game game,
                          SpriteFont font,
                          VisibilityScreens visibilityScreens)
    {
        Game = game;
        Font = font;
        VisibilityScreens = visibilityScreens;
    }

    public void LoadContent()
    {
        Size = new(0, 0, (int)(Game.GraphicsDevice.Viewport.Width / 2.5), 
                               Game.GraphicsDevice.Viewport.Height);

        Texture = new(Game.GraphicsDevice, 
                      Game.GraphicsDevice.Viewport.Width, 
                      Game.GraphicsDevice.Viewport.Height);

        // Прозрачнность
        Color[] data = new Color[Texture.Width * Texture.Height];
        Texture.GetData(data);
        for (int i = 0; i < data.Length; i++)
            // Установляется альфа-канал на 150 для каждого пикселя
            data[i] = new Color(255, 255, 255, 150);
        Texture.SetData(data);

        LoadButtons(); // Очень много все перенес в отдельный метод

        List<Texture2D> frames = new();
        for (int i = 0; i <= 55; i++)
            frames.Add(Game.Content.Load<Texture2D>(@$"Backgrounds\Animated_Back_800_600\{i}"));

        AnimationBackground.AnimationPicture = new AnimationPicture(frames, 0.155);
        AnimationBackground.AnimationPictureDrawer = new(AnimationBackground.AnimationPicture);
        AnimationBackground.AnimationPictureController = new(AnimationBackground.AnimationPicture);
    }

    private void LoadButtons() 
    {
        PlayButton.ClickableText = new(Font,
                                "Play",
                                new Vector2(25, 300),
                                Color.White, Color.Blue, delegate
        {
            VisibilityScreens.MainMenuIsVisible = false;
            VisibilityScreens.BattleFieldIsVisible = true;
        });
        PlayButton.ClickableTextDrawer = new(PlayButton.ClickableText);
        PlayButton.ClickableTextController = new(PlayButton.ClickableText);

        SettingsButton.ClickableText = new(Font,
                                           "Settings",
                                           new Vector2(25, 325),
                                           Color.White, Color.Blue, delegate
        {
            Game.Exit(); //Заглушка либо уберу
        });
        SettingsButton.ClickableTextDrawer = new(SettingsButton.ClickableText);
        SettingsButton.ClickableTextController = new(SettingsButton.ClickableText);

        ExitButton.ClickableText = new(Font,
                                       "Exit",
                                       new Vector2(25, 350),
                                       Color.White, Color.Blue, delegate
        {
            Game.Exit();
        });
        ExitButton.ClickableTextDrawer = new(ExitButton.ClickableText);
        ExitButton.ClickableTextController = new(ExitButton.ClickableText);
    }
}