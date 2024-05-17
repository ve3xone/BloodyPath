using BloodyPath.Controller;
using BloodyPath.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BloodyPath;

public class MainGame : Game
{
    private readonly GraphicsDeviceManager Graphics;
    private SpriteBatch SpriteBatch;

    private BasePlayer Player1;
    private BasePlayerDrawer Player1Drawer;
    private Dictionary<string, Keys> Player1KeyMappings;
    private BasePlayerController Player1Controller;

    private BasePlayer Player2;
    private BasePlayerDrawer Player2Drawer;
    private Dictionary<string, Keys> Player2KeyMappings;
    private BasePlayerController Player2Controller;

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
        
        Player1 = new( new Vector2(100, 100));
        Player2 = new(new Vector2(600, 100));


        Player1Drawer = new(SpriteBatch,
                                        Player1, 
                                        Content.Load<Texture2D>("Player1"),
                                        Content.Load<Texture2D>("Player1Damaged"),
                                        Content.Load<Texture2D>("HPRed"));
        
        Player2Drawer = new(SpriteBatch,
                                        Player2,
                                        Content.Load<Texture2D>("Player2"),
                                        Content.Load<Texture2D>("Player2Damaged"),
                                        Content.Load<Texture2D>("HPRed"));

        Player1KeyMappings = new()
        {
            { "Left", Keys.A },
            { "Right", Keys.D },
            { "Down", Keys.S },
            { "Up", Keys.W },
            { "Attack", Keys.Space }
        };
        Player2KeyMappings = new()
        {
            { "Left", Keys.Left },
            { "Right", Keys.Right },
            { "Down", Keys.Down },
            { "Up", Keys.Up },
            { "Attack", Keys.Enter }
        };
        Player1Controller = new(Player1, Player1Drawer, Player1KeyMappings);
        Player2Controller = new(Player2, Player2Drawer, Player2KeyMappings);
        
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

        Player1Controller.Update(keyboardState, Player2, GroundRectangle, GraphicsDevice);
        Player2Controller.Update(keyboardState, Player1, GroundRectangle, GraphicsDevice);

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

        Player1Drawer.Draw();
        Player1Drawer.DrawHpPlayerBar(new Vector2(10, 10));

        Player2Drawer.Draw();
        Player2Drawer.DrawHpPlayerBar(new Vector2(690, 10));

        SpriteBatch.End();

        base.Draw(gameTime);
    }
}