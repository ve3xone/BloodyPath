using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BloodyPath
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _player1Texture;
        private Texture2D _player2Texture;
        private Texture2D _landscapeTexture;

        private Vector2 _player1Position;
        private Vector2 _player2Position;

        private Texture2D _player1DamagedTexture;
        private Texture2D _player2DamagedTexture;

        private const int PlayerSpeed = 3;
        private const int PlayerMaxHP = 100;
        private int _player1HP = PlayerMaxHP;
        private int _player2HP = PlayerMaxHP;

        private const int AttackDamage = 10;
        private bool _player1Attacking = false;
        private bool _player2Attacking = false;

        private const float Gravity = 0.5f; // Ускорение свободного падения
        private const float MaxFallSpeed = 10f; // Максимальная скорость падения
        private float _verticalVelocity1 = 0f; // Вертикальная скорость игрока 1
        private float _verticalVelocity2 = 0f; // Вертикальная скорость игрока 2

        private Texture2D _groundTexture;
        private Rectangle _groundRectangle;


        public Game1()
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

            _player1Texture = Content.Load<Texture2D>("Player1");
            _player2Texture = Content.Load<Texture2D>("Player2");

            _player1DamagedTexture = Content.Load<Texture2D>("Player1Damaged");
            _player2DamagedTexture = Content.Load<Texture2D>("Player2Damaged");


            _groundTexture = Content.Load<Texture2D>("Landscape");
            _groundRectangle = new Rectangle(0, GraphicsDevice.Viewport.Height - 50, GraphicsDevice.Viewport.Width, 50);


            _player1Position = new Vector2(100, 100);
            _player2Position = new Vector2(400, 100);
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            // Player 1 movement
            if (keyboardState.IsKeyDown(Keys.W) && CanMove(new Vector2(_player1Position.X, _player1Position.Y - PlayerSpeed)))
                _player1Position.Y -= PlayerSpeed;

            if (keyboardState.IsKeyDown(Keys.S) && CanMove(new Vector2(_player1Position.X, _player1Position.Y + PlayerSpeed)))
                _player1Position.Y += PlayerSpeed;

            if (keyboardState.IsKeyDown(Keys.A) && CanMove(new Vector2(_player1Position.X - PlayerSpeed, _player1Position.Y)))
                _player1Position.X -= PlayerSpeed;

            if (keyboardState.IsKeyDown(Keys.D) && CanMove(new Vector2(_player1Position.X + PlayerSpeed, _player1Position.Y)))
                _player1Position.X += PlayerSpeed;

            // Player 2 movement
            if (keyboardState.IsKeyDown(Keys.Up) && CanMove(new Vector2(_player2Position.X, _player2Position.Y - PlayerSpeed)))
                _player2Position.Y -= PlayerSpeed;

            if (keyboardState.IsKeyDown(Keys.Down) && CanMove(new Vector2(_player2Position.X, _player2Position.Y + PlayerSpeed)))
                _player2Position.Y += PlayerSpeed;

            if (keyboardState.IsKeyDown(Keys.Left) && CanMove(new Vector2(_player2Position.X - PlayerSpeed, _player2Position.Y)))
                _player2Position.X -= PlayerSpeed;

            if (keyboardState.IsKeyDown(Keys.Right) && CanMove(new Vector2(_player2Position.X + PlayerSpeed, _player2Position.Y)))
                _player2Position.X += PlayerSpeed;

            // Check collision with ground
            if (_player1Position.Y + _player1Texture.Height >= _groundRectangle.Y)
            {
                _player1Position.Y = _groundRectangle.Y - _player1Texture.Height;
                _verticalVelocity1 = 0f;
            }

            if (_player2Position.Y + _player2Texture.Height >= _groundRectangle.Y)
            {
                _player2Position.Y = _groundRectangle.Y - _player2Texture.Height;
                _verticalVelocity2 = 0f;
            }

            // Apply gravity
            if (_player1Position.Y < _groundRectangle.Y - _player1Texture.Height)
                _verticalVelocity1 += Gravity;

            if (_player2Position.Y < _groundRectangle.Y - _player2Texture.Height)
                _verticalVelocity2 += Gravity;

            _player1Position.Y = Math.Min(_player1Position.Y + _verticalVelocity1, GraphicsDevice.Viewport.Height - _player1Texture.Height);
            _verticalVelocity1 = Math.Min(_verticalVelocity1, MaxFallSpeed);

            _player2Position.Y = Math.Min(_player2Position.Y + _verticalVelocity2, GraphicsDevice.Viewport.Height - _player2Texture.Height);
            _verticalVelocity2 = Math.Min(_verticalVelocity2, MaxFallSpeed);

            // Player 1 attack
            if (keyboardState.IsKeyDown(Keys.Space) && !_player1Attacking)
            {
                _player1Attacking = true;
                if (Vector2.Distance(_player1Position, _player2Position) < 50) // If players are close enough
                    _player2HP -= AttackDamage;
            }
            else if (keyboardState.IsKeyUp(Keys.Space))
            {
                _player1Attacking = false;
            }

            // Player 2 attack
            if (keyboardState.IsKeyDown(Keys.Enter) && !_player2Attacking)
            {
                _player2Attacking = true;
                if (Vector2.Distance(_player1Position, _player2Position) < 50) // If players are close enough
                    _player1HP -= AttackDamage;
            }
            else if (keyboardState.IsKeyUp(Keys.Enter))
            {
                _player2Attacking = false;
            }

            // Ensure HP doesn't go negative
            _player1HP = Math.Max(0, _player1HP);
            _player2HP = Math.Max(0, _player2HP);

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

            // Draw player 1
            if (_player1Attacking)
            {
                _spriteBatch.Draw(_player1DamagedTexture, _player1Position, Color.White);
            }
            else
            {
                _spriteBatch.Draw(_player1Texture, _player1Position, Color.White);
            }

            // Аналогично для player 2
            if (_player2Attacking)
            {
                _spriteBatch.Draw(_player2DamagedTexture, _player2Position, Color.White);
            }
            else
            {
                _spriteBatch.Draw(_player2Texture, _player2Position, Color.White);
            }

            // Draw HP bars
            DrawHPBar(_spriteBatch, _player1HP, new Vector2(10, 10), Color.Red);
            DrawHPBar(_spriteBatch, _player2HP, new Vector2(500, 10), Color.Red);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawHPBar(SpriteBatch spriteBatch, int hp, Vector2 position, Color color)
        {
            // Draw HP bar background
            spriteBatch.Draw(_player1Texture, new Rectangle((int)position.X, (int)position.Y, 100, 10), Color.Gray);

            // Draw filled portion of HP bar
            int fillWidth = (int)(hp / (float)PlayerMaxHP * 100);
            spriteBatch.Draw(_player1Texture, new Rectangle((int)position.X, (int)position.Y, fillWidth, 10), color);
        }

        private bool CanMove(Vector2 position)
        {
            // Простой пример проверки на ландшафт: позиция является допустимой, если она находится в пределах экрана
            return position.X >= 0 && position.Y >= 0 &&
                   position.X <= GraphicsDevice.Viewport.Width - _player1Texture.Width &&
                   position.Y <= GraphicsDevice.Viewport.Height - _player1Texture.Height;
        }
    }
}
