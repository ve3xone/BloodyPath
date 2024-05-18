using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Views
{
    public class MainMenuScreenDrawer
    {
        private readonly MainMenuScreen MainMenuScreen;

        public MainMenuScreenDrawer (MainMenuScreen mainMenu)
        {
            MainMenuScreen = mainMenu;
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            MainMenuScreen.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(MainMenuScreen.Background, Vector2.Zero, Color.White);
            spriteBatch.Draw(MainMenuScreen.Texture, MainMenuScreen.Size, Color.Black);
            MainMenuScreen.PlayButton.ClickableTextDrawer.Draw(spriteBatch);
            MainMenuScreen.SettingsButton.ClickableTextDrawer.Draw(spriteBatch);
            MainMenuScreen.ExitButton.ClickableTextDrawer.Draw(spriteBatch);
        }
    }
}
