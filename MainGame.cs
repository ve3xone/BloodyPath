using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BloodyPath.Models;

namespace BloodyPath;

public class MainGame : Game
{
    private readonly GraphicsDeviceManager Graphics;
    private SpriteBatch SpriteBatch;

    private readonly Persona Persona1 = new();
    private readonly Persona Persona2 = new();

    private Texture2D GroundTexture;
    private Rectangle GroundRectangle;

    public MainGame()
    {
        Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    protected override void Initialize() => base.Initialize();

    protected override void LoadContent()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);

        Persona1.Player = new(new Vector2(100, 100));
        Persona2.Player = new(new Vector2(600, 100));

        Persona1.PlayerDrawer = new(SpriteBatch, 
                                        Persona1.Player, 
                                        Content.Load<Texture2D>("Player1"),
                                        Content.Load<Texture2D>("Player1Damaged"),
                                        Content.Load<Texture2D>("HPRed"));

        Persona2.PlayerDrawer = new(SpriteBatch,
                                        Persona2.Player,
                                        Content.Load<Texture2D>("Player2"),
                                        Content.Load<Texture2D>("Player2Damaged"),
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
        
        // Comment for test (debug)
        // _landscapeTexture = Content.Load<Texture2D>("Landscape");

        GroundTexture = Content.Load<Texture2D>("Landscape");
        GroundRectangle = new Rectangle(0, 
                                                           GraphicsDevice.Viewport.Height - 50, 
                                                           GraphicsDevice.Viewport.Width, 
                                                           50);
    }

    protected override void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();

        Persona1.PlayerController.Update(keyboardState, Persona2.Player, GroundRectangle, GraphicsDevice);
        Persona2.PlayerController.Update(keyboardState, Persona1.Player, GroundRectangle, GraphicsDevice);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin();

        // Draw landscape
        SpriteBatch.Draw(GroundTexture, Vector2.Zero, Color.White);

        // Comment for test (debug)
        // Draw ground
        // SpriteBatch.Draw(GroundTexture, GroundRectangle, Color.White);

        Persona1.PlayerDrawer.Draw();
        Persona1.PlayerDrawer.DrawHpPlayerBar(new Vector2(10, 10));

        Persona2.PlayerDrawer.Draw();
        Persona2.PlayerDrawer.DrawHpPlayerBar(new Vector2(690, 10));

        SpriteBatch.End();

        base.Draw(gameTime);
    }
}