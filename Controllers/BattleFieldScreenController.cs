using BloodyPath.Models;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
                                                                                   BattleFieldScreen.GraphicsDevice);

        BattleFieldScreen.Persona2.PlayerController.Update(keyboardState, 
                                                                                   BattleFieldScreen.Persona1.Player, 
                                                                                   BattleFieldScreen.GroundRectangle, 
                                                                                   BattleFieldScreen.GraphicsDevice);

        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            BattleFieldScreen.MainMenuScreen.IsVisible = true;
            BattleFieldScreen.ResetScreen();

            BattleFieldScreen.IsVisible = false;
        }
    }
}