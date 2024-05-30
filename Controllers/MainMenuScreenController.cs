using BloodyPath.Models;
using Microsoft.Xna.Framework;

namespace BloodyPath.Controllers;

public class MainMenuScreenController
{
    private MainMenuScreen MainMenuScreen { get; set; }

    public MainMenuScreenController(MainMenuScreen mainMenuScreen) 
    { 
        MainMenuScreen = mainMenuScreen;
        Initialize();
    }

    private void Initialize()
    {
        MainMenuScreen.PlayButton.ClickableTextController = new(MainMenuScreen.PlayButton.ClickableText);
        MainMenuScreen.ExitButton.ClickableTextController = new(MainMenuScreen.ExitButton.ClickableText);
        MainMenuScreen.AnimationBackground.AnimationPictureController = 
            new AnimationPictureController(MainMenuScreen.AnimationBackground.AnimationPicture);
        MainMenuScreen.VolumeManager.SliderVolumeController = 
            new SliderVolumeController(MainMenuScreen.VolumeManager.SliderVolume);
    }

    public void Update(GameTime gameTime)
    {
        MainMenuScreen.PlayButton.ClickableTextController.Update();
        MainMenuScreen.ExitButton.ClickableTextController.Update();
        MainMenuScreen.VolumeManager.SliderVolumeController.Update();
        MainMenuScreen.AnimationBackground.AnimationPictureController.Update(gameTime);
    }
}