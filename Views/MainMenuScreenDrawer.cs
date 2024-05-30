using BloodyPath.Controllers;
using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BloodyPath.Views;

public class MainMenuScreenDrawer
{
    private readonly MainMenuScreen MainMenuScreen;
    private Texture2D Texture;
    private SpriteFont FontNameGame;
    private SpriteFont FontButton;
    private SpriteFont FontCopyright;

    public MainMenuScreenDrawer(MainMenuScreen mainMenu)
    {
        MainMenuScreen = mainMenu;
        LoadContent(MainMenuScreen.Game);
    }

    private void LoadContent(Game game)
    {
        FontNameGame = game.Content.Load<SpriteFont>(@"Fonts\FontMainMenuNameGame");
        FontButton = game.Content.Load<SpriteFont>(@"Fonts\FontMainMenuButtons");
        FontCopyright = game.Content.Load<SpriteFont>(@"Fonts\FontMainMenuCopyright");

        MainMenuScreen.PlayButton.ClickableTextDrawer = new(MainMenuScreen.PlayButton.ClickableText, FontButton);
        MainMenuScreen.PlayButton.ClickableTextController = new(MainMenuScreen.PlayButton.ClickableText);
        MainMenuScreen.ExitButton.ClickableTextDrawer = new(MainMenuScreen.ExitButton.ClickableText, FontButton);
        MainMenuScreen.ExitButton.ClickableTextController = new(MainMenuScreen.ExitButton.ClickableText);

        Texture = new Texture2D(game.GraphicsDevice, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);

        // Прозрачность
        Color[] data = new Color[Texture.Width * Texture.Height];
        Texture.GetData(data);
        for (int i = 0; i < data.Length; i++)
            data[i] = new Color(255, 255, 255, 150);
        Texture.SetData(data);

        List<Texture2D> frames = new();
        for (int i = 0; i <= 55; i++)
            frames.Add(game.Content.Load<Texture2D>($"Backgrounds/Animated_Back_800_600/{i}"));

        MainMenuScreen.AnimationBackground.AnimationPicture = new AnimationPicture(0.155);
        MainMenuScreen.AnimationBackground.AnimationPictureDrawer = 
            new AnimationPictureDrawer(MainMenuScreen.AnimationBackground.AnimationPicture, frames);
        MainMenuScreen.AnimationBackground.AnimationPictureController = 
            new AnimationPictureController(MainMenuScreen.AnimationBackground.AnimationPicture);

        MainMenuScreen.VolumeManager.SliderVolume = 
            new SliderVolume(0.5f,
                             game.Content.Load<Texture2D>("VolumeManager/SliderBar"),
                             game.Content.Load<Texture2D>("VolumeManager/SliderButton"),
                             game.Content.Load<Texture2D>("VolumeManager/MutedButton"),
                             game.Content.Load<Texture2D>("VolumeManager/UnmutedButton"));

        MainMenuScreen.VolumeManager.SliderVolume.LoadContent();

        MainMenuScreen.VolumeManager.SliderVolumeDrawer = 
            new SliderVolumeDrawer(MainMenuScreen.VolumeManager.SliderVolume);
        MainMenuScreen.VolumeManager.SliderVolumeController = 
            new SliderVolumeController(MainMenuScreen.VolumeManager.SliderVolume);

        MainMenuScreen.MusicManager.PlayMainMenuMusic();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (!MainMenuScreen.VisibilityScreens.BattleFieldIsVisible)
        {
            spriteBatch.Begin();

            MainMenuScreen.AnimationBackground.AnimationPictureDrawer.Draw(spriteBatch, Vector2.Zero);
            spriteBatch.Draw(Texture, MainMenuScreen.Size, Color.Black);
            spriteBatch.DrawString(FontNameGame, "BloodyPath", new Vector2(53, 152), Color.White);
            spriteBatch.DrawString(FontCopyright, "Demo game", new Vector2(116, 200), Color.White);
            spriteBatch.DrawString(FontCopyright, "by ve3xone 2024", new Vector2(25, 550), Color.White);

            MainMenuScreen.PlayButton.ClickableTextDrawer.Draw(spriteBatch);
            MainMenuScreen.ExitButton.ClickableTextDrawer.Draw(spriteBatch);
            MainMenuScreen.VolumeManager.SliderVolumeDrawer.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
