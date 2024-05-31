using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BloodyPath.Controllers;

public class BattleFieldScreenController
{
    private readonly BattleFieldScreen BattleFieldScreen;

    public BattleFieldScreenController(BattleFieldScreen battleFieldScreen)
    {
        BattleFieldScreen = battleFieldScreen;
        Initialize();
    }

    private void Initialize()
    {
        BattleFieldScreen.IsResetController = false;

        BattleFieldScreen.Persona1.PlayerKeyMappings = new()
        {
            { "Left", Keys.A },
            { "Right", Keys.D },
            { "Down", Keys.S },
            { "Up", Keys.W },
            { "AttackHands", Keys.C },
            { "AttackFeet", Keys.LeftShift },
            { "Duck", Keys.X }
        };
        BattleFieldScreen.Persona2.PlayerKeyMappings = new()
        {
            { "Left", Keys.Left },
            { "Right", Keys.Right },
            { "Down", Keys.Down },
            { "Up", Keys.Up },
            { "AttackHands", Keys.Enter },
            { "AttackFeet", Keys.RightShift },
            { "Duck", Keys.RightControl },
            { "BotEnableAndDisable", Keys.Delete }
        };
        BattleFieldScreen.Persona1.PlayerController = new(BattleFieldScreen.Persona1.Player, BattleFieldScreen.Persona1.PlayerKeyMappings);
        BattleFieldScreen.Persona2.PlayerController = new(BattleFieldScreen.Persona2.Player, BattleFieldScreen.Persona2.PlayerKeyMappings);
    }

    public void Update(GameTime gameTime, KeyboardState keyboardState)
    {
        if (BattleFieldScreen.VisibilityScreens.BattleFieldIsVisible)
        {
            if (BattleFieldScreen.IsResetController) Initialize();
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