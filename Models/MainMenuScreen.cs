using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BloodyPath.Models;

public class MainMenuScreen
{
    public readonly Button PlayButton = new();
    public readonly Button ExitButton = new();
    public Rectangle Size;
    public Texture2D Texture;
    public readonly SpriteFont FontNameGame;
    public readonly SpriteFont FontButton;
    public readonly SpriteFont FontCopyright;
    public VisibilityScreens VisibilityScreens;
    public readonly Game Game;
    public Animation AnimationBackground = new();
    public readonly MusicManager MusicManager;
    public VolumeManager VolumeManager = new();

    public MainMenuScreen(Game game,
                          SpriteFont fontNameGame,
                          SpriteFont fontButton,
                          SpriteFont fontCopyright,
                          VisibilityScreens visibilityScreens,
                          MusicManager musicManager)
    {
        Game = game;
        FontNameGame = fontNameGame;
        FontButton = fontButton;
        FontCopyright = fontCopyright;
        VisibilityScreens = visibilityScreens;
        MusicManager = musicManager;
    }

    public void LoadContent()
    {
        Size = new(0, 0,
                   (int)(Game.GraphicsDevice.Viewport.Width / 2.5),
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

        AnimationBackground.AnimationPicture = new AnimationPicture(0.155);
        AnimationBackground.AnimationPictureDrawer = new(AnimationBackground.AnimationPicture, frames);
        AnimationBackground.AnimationPictureController = new(AnimationBackground.AnimationPicture);

        VolumeManager.SliderVolume = new(0.5f,
                                         Game.Content.Load<Texture2D>(@"VolumeManager\SliderBar"),
                                         Game.Content.Load<Texture2D>(@"VolumeManager\SliderButton"),
                                         Game.Content.Load<Texture2D>(@"VolumeManager\MutedButton"),
                                         Game.Content.Load<Texture2D>(@"VolumeManager\UnmutedButton"));
        VolumeManager.SliderVolume.LoadContent();
        VolumeManager.SliderVolumeDrawer = new(VolumeManager.SliderVolume);
        VolumeManager.SliderVolumeController = new(VolumeManager.SliderVolume);

        MusicManager.PlayMainMenuMusic();
    }

    private void LoadButtons()
    {
        PlayButton.ClickableText = new("Play",
                                       new Vector2(25, 300),
                                       Color.White, Color.Blue, delegate
                                       {
                                           VisibilityScreens.MainMenuIsVisible = false;
                                           MusicManager.PlayBattlefieldMusic();
                                           VisibilityScreens.BattleFieldIsVisible = true;
                                       });
        PlayButton.ClickableTextDrawer = new(PlayButton.ClickableText, FontButton);
        PlayButton.ClickableTextController = new(PlayButton.ClickableText);

        ExitButton.ClickableText = new("Exit",
                                       new Vector2(25, 325),
                                       Color.White, Color.Blue, delegate
                                       {
                                           Game.Exit();
                                       });
        ExitButton.ClickableTextDrawer = new(ExitButton.ClickableText, FontButton);
        ExitButton.ClickableTextController = new(ExitButton.ClickableText);
    }
}