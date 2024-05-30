using BloodyPath.Models;
using Microsoft.Xna.Framework;

namespace BloodyPath.Controllers;

public class MainMenuScreenController
{
    private MainMenuScreen MainMenuScreen { get; set; }

    public MainMenuScreenController(MainMenuScreen mainMenuScreen) 
    { 
        this.MainMenuScreen = mainMenuScreen;
    }

    public void Update(GameTime gameTime)
    {
        MainMenuScreen.PlayButton.ClickableTextController.Update();
        MainMenuScreen.ExitButton.ClickableTextController.Update();
        MainMenuScreen.VolumeManager.SliderVolumeController.Update();
        MainMenuScreen.AnimationBackground.AnimationPictureController.Update(gameTime);
    }
}