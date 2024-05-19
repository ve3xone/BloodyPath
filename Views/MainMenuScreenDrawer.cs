using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Views;

public class MainMenuScreenDrawer
{
    private readonly MainMenuScreen MainMenuScreen;

    public MainMenuScreenDrawer (MainMenuScreen mainMenu)
    {
        MainMenuScreen = mainMenu;
    }

    public void Draw (SpriteBatch spriteBatch)
    {
        if (!MainMenuScreen.VisibilityScreens.BattleFieldIsVisible)
        {
            spriteBatch.Begin();

            MainMenuScreen.AnimationBackground.AnimationPictureDrawer.Draw(spriteBatch, Vector2.Zero);

            spriteBatch.Draw(MainMenuScreen.Texture, MainMenuScreen.Size, Color.Black);

            MainMenuScreen.PlayButton.ClickableTextDrawer.Draw(spriteBatch);
            MainMenuScreen.SettingsButton.ClickableTextDrawer.Draw(spriteBatch);
            MainMenuScreen.ExitButton.ClickableTextDrawer.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}