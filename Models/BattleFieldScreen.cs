using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BloodyPath.Models;

public class BattleFieldScreen
{
    public readonly Persona Persona1 = new();
    public readonly Persona Persona2 = new();
    public Texture2D Background;
    public SpriteFont Font;
    public Rectangle GroundRectangle;
    public VisibilityScreens VisibilityScreens;
    public readonly Game Game;
    public MusicManager MusicManager;

    public BattleFieldScreen(Game game,
                             SpriteFont battlefieldFont, 
                             Texture2D background,
                             VisibilityScreens VisibilityScreens,
                             MusicManager musicManager)
    {
        this.Font = battlefieldFont;
        this.Game = game;
        this.Background = background;
        this.VisibilityScreens = VisibilityScreens;
        this.MusicManager = musicManager;
    }

    public void LoadContent()
    {
        GroundRectangle = new Rectangle(0, Game.GraphicsDevice.Viewport.Height - 50,
                                        Game.GraphicsDevice.Viewport.Width, 50);

        Persona1.Player = new(new Vector2(100, 444), true, 0);
        Persona2.Player = new(new Vector2(600, 444), false, 1);

        Persona1.PlayerDrawer = new(Persona1.Player,
                                    Game.Content.Load<Texture2D>(@"Personas\Player1"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player1Reversed"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player1Ducked"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player1DamageHands"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player1DamageHandsReversed"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player1DamageFeet"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player1DamageFeetReversed"),
                                    Game.Content.Load<Texture2D>("HPRed"));
        Persona2.PlayerDrawer = new(Persona2.Player,
                                    Game.Content.Load<Texture2D>(@"Personas\Player2"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player2Reversed"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player2Ducked"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player2DamageHands"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player2DamageHandsReversed"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player2DamageFeet"),
                                    Game.Content.Load<Texture2D>(@"Personas\Player2DamageFeetReversed"),
                                    Game.Content.Load<Texture2D>("HPRed"));

        Persona1.PlayerKeyMappings = new()
        {
            { "Left", Keys.A },
            { "Right", Keys.D },
            { "Down", Keys.S },
            { "Up", Keys.W },
            { "AttackHands", Keys.C },
            { "AttackFeet", Keys.LeftShift },
            { "Duck", Keys.X }
        };
        Persona2.PlayerKeyMappings = new()
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

        Persona1.PlayerController = new(Persona1.Player, Persona1.PlayerKeyMappings);
        Persona2.PlayerController = new(Persona2.Player, Persona2.PlayerKeyMappings);
    }

    public void ResetScreen() => LoadContent();
}