using Microsoft.Xna.Framework.Input;
using BloodyPath.Models;
using Microsoft.Xna.Framework;

namespace BloodyPath.Controllers;

public class BattleFieldScreenController
{
    private readonly BattleFieldScreen BattleFieldScreen;

    public BattleFieldScreenController(BattleFieldScreen battleFieldScreen)
    {
        BattleFieldScreen = battleFieldScreen;
    }

    public void Update(GameTime gameTime, KeyboardState keyboardState)
    {
        if (BattleFieldScreen.VisibilityScreens.BattleFieldIsVisible)
        {
            BattleFieldScreen.Persona1.PlayerController.Update(gameTime, keyboardState,
                                                               BattleFieldScreen.Persona2.Player,
                                                               BattleFieldScreen.GroundRectangle,
                                                               BattleFieldScreen.Game.GraphicsDevice);

            BattleFieldScreen.Persona2.PlayerController.Update(gameTime, keyboardState,
                                                               BattleFieldScreen.Persona1.Player,
                                                               BattleFieldScreen.GroundRectangle,
                                                               BattleFieldScreen.Game.GraphicsDevice);

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                BattleFieldScreen.VisibilityScreens.MainMenuIsVisible = true;
                BattleFieldScreen.ResetScreen();
                BattleFieldScreen.MusicManager.PlayMainMenuMusic();
                BattleFieldScreen.VisibilityScreens.BattleFieldIsVisible = false;
            }
        }
    }
}