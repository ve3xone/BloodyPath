using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace BloodyPath
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont textBlock;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            // Start fullscreen
            //_graphics.PreferredBackBufferWidth = 1920; // remove later
            //_graphics.PreferredBackBufferHeight = 1080; // remove later
            //_graphics.IsFullScreen = true; // set true to default later

            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            textBlock = Content.Load< SpriteFont>("TestText");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            string text = "Hello World";
            //Vector2 textSize = textBlock.MeasureString(text);
            //Vector2 position = new Vector2((GraphicsDevice.Viewport.Width - textSize.X) / 2, (GraphicsDevice.Viewport.Height - textSize.Y) / 2); //center

           // Microsoft.Xna.Framework.Color color = new Microsoft.Xna.Framework.Color(255, 255, 0);// color yellow
            _spriteBatch.DrawString(textBlock, text, new Vector2(0,0), Color.White); // draw text
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}