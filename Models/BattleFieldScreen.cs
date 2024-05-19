using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BloodyPath.Models;

public class BattleFieldScreen
{
    public readonly Persona Persona1 = new();
    public readonly Persona Persona2 = new();
    public Texture2D Background;
    public SpriteFont Font;
    public bool IsVisible;
    public Rectangle GroundRectangle;
    private ContentManager Content;
    public GraphicsDevice GraphicsDevice;
    public MainMenuScreen MainMenuScreen;

    public BattleFieldScreen(GraphicsDevice graphicsDevice ,SpriteFont battlefieldFont, Texture2D background, ContentManager content, MainMenuScreen mainMenuScreen)
    {
        this.Font = battlefieldFont;
        this.GraphicsDevice = graphicsDevice;
        this.IsVisible = !mainMenuScreen.IsVisible;
        this.MainMenuScreen = mainMenuScreen;
        this.Background = background;
        this.Content = content;
    }

    public void LoadContent()
    {
        GroundRectangle = new Rectangle(0, GraphicsDevice.Viewport.Height - 50,
                                                           GraphicsDevice.Viewport.Width, 50);

        Persona1.Player = new(new Vector2(100, 400));
        Persona2.Player = new(new Vector2(600, 400));

        Persona1.PlayerDrawer = new(Persona1.Player,
                                                    Content.Load<Texture2D>(@"Personas\Player1"),
                                                    Content.Load<Texture2D>(@"Personas\Player1Damaged"),
                                                    Content.Load<Texture2D>("HPRed"));

        Persona2.PlayerDrawer = new(Persona2.Player,
                                                    Content.Load<Texture2D>(@"Personas\Player2"),
                                                    Content.Load<Texture2D>(@"Personas\Player2Damaged"),
                                                    Content.Load<Texture2D>("HPRed"));

        Persona1.PlayerKeyMappings = new()
        {
            { "Left", Keys.A },
            { "Right", Keys.D },
            { "Down", Keys.S },
            { "Up", Keys.W },
            { "Attack", Keys.Space }
        };
        Persona2.PlayerKeyMappings = new()
        {
            { "Left", Keys.Left },
            { "Right", Keys.Right },
            { "Down", Keys.Down },
            { "Up", Keys.Up },
            { "Attack", Keys.Enter }
        };
        Persona1.PlayerController = new(Persona1.Player, Persona1.PlayerDrawer, Persona1.PlayerKeyMappings);
        Persona2.PlayerController = new(Persona2.Player, Persona2.PlayerDrawer, Persona2.PlayerKeyMappings);
    }

    public void ResetScreen() => LoadContent();
}