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

            spriteBatch.DrawString(MainMenuScreen.FontNameGame, "BloodyPath", new Vector2(53, 152), Color.White);
            spriteBatch.DrawString(MainMenuScreen.FontCopyright, "Demo game", new Vector2(116, 200), Color.White);
            spriteBatch.DrawString(MainMenuScreen.FontCopyright, "by ve3xone 2024", new Vector2(25, 550), Color.White);

            MainMenuScreen.PlayButton.ClickableTextDrawer.Draw(spriteBatch);
            MainMenuScreen.ExitButton.ClickableTextDrawer.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}