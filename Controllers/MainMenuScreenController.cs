using BloodyPath.Models;

namespace BloodyPath.Controllers;

public class MainMenuScreenController
{
    private MainMenuScreen MainMenuScreen { get; set; }
    public MainMenuScreenController(MainMenuScreen mainMenuScreen) 
    { 
        this.MainMenuScreen = mainMenuScreen;
    }

    public void Update()
    {
        MainMenuScreen.PlayButton.ClickableTextController.Update();
        MainMenuScreen.SettingsButton.ClickableTextController.Update();
        MainMenuScreen.ExitButton.ClickableTextController.Update();
    }
}