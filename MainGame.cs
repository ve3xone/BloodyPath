using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BloodyPath
{
    public class MainGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        private BasePlayer _player1;
        private BasePlayer _player2;

        private Texture2D _groundTexture;
        private Rectangle _groundRectangle;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            _player1 = new(Content.Load<Texture2D>("Player1"), 
                                    Content.Load<Texture2D>("Player1Damaged"),
                                    Content.Load<Texture2D>("HPRed"),
                                    new Vector2(100, 100));
            
            _player2 = new(Content.Load<Texture2D>("Player2"), 
                                    Content.Load<Texture2D>("Player2Damaged"),
                                    Content.Load<Texture2D>("HPRed"),
                                    new Vector2(600, 100));

            _player1.KeyMappings = new()
            {
                { "Left", Keys.A },
                { "Right", Keys.D },
                { "Down", Keys.S },
                { "Up", Keys.W },
                { "Attack", Keys.Space }
            };

            _player2.KeyMappings = new()
            {
                { "Left", Keys.Left },
                { "Right", Keys.Right },
                { "Down", Keys.Down },
                { "Up", Keys.Up },
                { "Attack", Keys.Enter }
            };

            //_landscapeTexture = Content.Load<Texture2D>("Landscape");

            _groundTexture = Content.Load<Texture2D>("Landscape");
            _groundRectangle = new Rectangle(0, 
                                                                GraphicsDevice.Viewport.Height - 50, 
                                                                GraphicsDevice.Viewport.Width, 
                                                                50);
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            _player1.Update(gameTime, keyboardState, _player2, _groundRectangle, GraphicsDevice);
            _player2.Update(gameTime, keyboardState, _player1, _groundRectangle, GraphicsDevice);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Draw landscape
            _spriteBatch.Draw(_groundTexture, Vector2.Zero, Color.White);
            // Draw ground
            //_spriteBatch.Draw(_groundTexture, _groundRectangle, Color.White);

            var _player1Drawer = new Player.BasePlayerDrawer(_spriteBatch, _player1);
            _player1Drawer.Draw();
            _player1Drawer.DrawHpPlayerBar(new Vector2(10, 10));

            var _player2Drawer = new Player.BasePlayerDrawer(_spriteBatch, _player2);
            _player2Drawer.Draw();
            _player2Drawer.DrawHpPlayerBar(new Vector2(690, 10));

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
