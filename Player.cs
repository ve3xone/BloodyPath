using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class Player
{
    public Texture2D Texture { get; set; }
    public Texture2D DamagedTexture { get; set; }

    public Vector2 Position = Vector2.Zero;
    public int HP = 100;
    private const int PlayerSpeed = 3;
    private const int AttackDamage = 10;

    private const float MaxFallSpeed = 10f; // Максимальная скорость падения
    private const float Gravity = 0.5f; // Ускорение свободного падения
    private float _verticalVelocity1 = 0f; // Вертикальная скорость игрока
    private bool IsAttacking;
    public Dictionary<string, Keys> KeyMappings { get; set; }

    public Player(Texture2D texture, Texture2D damagedTexture, Vector2 position)
    {
        Texture = texture;
        DamagedTexture = damagedTexture;
        Position = position;
        //HP = PlayerMaxHP;
        IsAttacking = false;
    }

    public void Update(GameTime gameTime, KeyboardState keyboardState,
                                Player otherPlayer, Rectangle groundRectangle, GraphicsDevice gd)
    {
        // Move player based on keyboard input
        // Player movement
        if (keyboardState.IsKeyDown(KeyMappings["Up"]) && CanMove(new Vector2(Position.X, Position.Y - PlayerSpeed), gd))
            Position.Y -= PlayerSpeed;

        if (keyboardState.IsKeyDown(KeyMappings["Down"]) && CanMove(new Vector2(Position.X, Position.Y + PlayerSpeed), gd))
            Position.Y += PlayerSpeed;

        if (keyboardState.IsKeyDown(KeyMappings["Left"]) && CanMove(new Vector2(Position.X - PlayerSpeed, Position.Y), gd))
            Position.X -= PlayerSpeed;

        if (keyboardState.IsKeyDown(KeyMappings["Right"]) && CanMove(new Vector2(Position.X + PlayerSpeed, Position.Y), gd))
            Position.X += PlayerSpeed;

        // Check collision with ground
        if(Position.Y + Texture.Height >= groundRectangle.Y)
            {
            Position.Y = groundRectangle.Y - Texture.Height;
            _verticalVelocity1 = 0f;
        }

        // Apply gravity
        if (Position.Y < groundRectangle.Y - Texture.Height)
            _verticalVelocity1 += Gravity;

        Position.Y = Math.Min(Position.Y + _verticalVelocity1, gd.Viewport.Height - Texture.Height);
        _verticalVelocity1 = Math.Min(_verticalVelocity1, MaxFallSpeed);

        // Attack logic
        if (keyboardState.IsKeyDown(KeyMappings["Attack"]) && !IsAttacking)
        {
            IsAttacking = true;
            if (Vector2.Distance(this.Position, otherPlayer.Position) < 50) // If players are close enough
                otherPlayer.HP -= AttackDamage;
        }
        else if (keyboardState.IsKeyUp(Keys.Space))
        {
            this.IsAttacking = false;
        }

        this.HP = Math.Max(0, this.HP);
    }

    private bool CanMove(Vector2 position, GraphicsDevice gd)
    {
        // Простой пример проверки на ландшафт: позиция является допустимой, если она находится в пределах экрана
        return position.X >= 0 && position.Y >= 0 &&
                  position.X <= gd.Viewport.Width - Texture.Width &&
                  position.Y <= gd.Viewport.Height - Texture.Height;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw player
        if (IsAttacking)
        {
            spriteBatch.Draw(DamagedTexture, Position, Color.White);
        }
        else
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}