using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BloodyPath
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        private Player _player1;
        private Player _player2;

        private Texture2D _groundTexture;
        private Rectangle _groundRectangle;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            _player1 = new(Content.Load<Texture2D>("Player1"), Content.Load<Texture2D>("Player1Damaged"), new Vector2(100, 100));
            
            _player2 = new(Content.Load<Texture2D>("Player2"), Content.Load<Texture2D>("Player2Damaged"), new Vector2(400, 100));

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

            //_player1Texture = Content.Load<Texture2D>("Player1");
            //_player2Texture = Content.Load<Texture2D>("Player2");

            //_player1DamagedTexture = Content.Load<Texture2D>("Player1Damaged");
            //_player2DamagedTexture = Content.Load<Texture2D>("Player2Damaged");


            _groundTexture = Content.Load<Texture2D>("Landscape");
            _groundRectangle = new Rectangle(0, GraphicsDevice.Viewport.Height - 50, GraphicsDevice.Viewport.Width, 50);
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
            //_spriteBatch.Draw(_landscapeTexture, Vector2.Zero, Color.White);
            // Draw ground
            _spriteBatch.Draw(_groundTexture, _groundRectangle, Color.White);

            // Draw players
            //_spriteBatch.Draw(_player1Texture, _player1Position, Color.White);
            //_spriteBatch.Draw(_player2Texture, _player2Position, Color.White);

            _player1.Draw(_spriteBatch);
            _player2.Draw(_spriteBatch);

            // Draw HP bars
            DrawHPBar(_spriteBatch, _player1.HP, new Vector2(10, 10), Color.Red, _player1.Texture);
            DrawHPBar(_spriteBatch, _player2.HP, new Vector2(500, 10), Color.Red, _player2.Texture);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private static void DrawHPBar(SpriteBatch spriteBatch, int hp, Vector2 position, Color color, Texture2D playerTexture)
        {
            // Draw HP bar background
            spriteBatch.Draw(playerTexture, new Rectangle((int)position.X, (int)position.Y, 100, 10), Color.Gray);

            // Draw filled portion of HP bar
            int fillWidth = (int)(hp / (float)100 * 100);
            spriteBatch.Draw(playerTexture, new Rectangle((int)position.X, (int)position.Y, fillWidth, 10), color);
        }
    }
}
