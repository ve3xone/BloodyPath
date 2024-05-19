using Microsoft.Xna.Framework.Input;
using BloodyPath.Models;

namespace BloodyPath.Controllers;

public class BattleFieldScreenController
{
    private readonly BattleFieldScreen BattleFieldScreen;

    public BattleFieldScreenController(BattleFieldScreen battleFieldScreen)
    {
        BattleFieldScreen = battleFieldScreen;
    }

    public void Update(KeyboardState keyboardState)
    {
        BattleFieldScreen.Persona1.PlayerController.Update(keyboardState, 
                                                                                   BattleFieldScreen.Persona2.Player, 
                                                                                   BattleFieldScreen.GroundRectangle, 
                                                                                   BattleFieldScreen.Game.GraphicsDevice);

        BattleFieldScreen.Persona2.PlayerController.Update(keyboardState, 
                                                                                   BattleFieldScreen.Persona1.Player, 
                                                                                   BattleFieldScreen.GroundRectangle, 
                                                                                   BattleFieldScreen.Game.GraphicsDevice);

        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            BattleFieldScreen.VisibilityScreens.MainMenuIsVisible = true;
            BattleFieldScreen.ResetScreen();

            BattleFieldScreen.VisibilityScreens.BattleFieldIsVisible = false;
        }
    }
}