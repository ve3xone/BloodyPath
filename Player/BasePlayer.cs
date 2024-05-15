using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class BasePlayer
{
    public Texture2D Texture { get; private set; }
    public Texture2D DamagedTexture { get; private set; }
    public Texture2D HpTexture { get; private set; }
    public bool IsAttacking { get; private set; }

    public Vector2 Position = Vector2.Zero;
    public int HP = 100;
    private const int PlayerSpeed = 3;
    private const int AttackDamage = 10;

    private const float MaxFallSpeed = 10f; // Максимальная скорость падения
    private const float Gravity = 0.5f; // Ускорение свободного падения
    private float VerticalVelocity = 0f; // Вертикальная скорость игрока
    
    public Dictionary<string, Keys> KeyMappings { get; set; }

    public BasePlayer(Texture2D texture, 
                              Texture2D damagedTexture,
                              Texture2D hpTexture,
                              Vector2 position)
    {
        Texture = texture;
        DamagedTexture = damagedTexture;
        Position = position;
        HpTexture = hpTexture;
        IsAttacking = true; // For debug
    }

    public void Update(GameTime gameTime, KeyboardState keyboardState,
                                BasePlayer otherPlayer, Rectangle groundRectangle, GraphicsDevice gd)
    {
        // Move player based on keyboard input
        // Player movement
        if (keyboardState.IsKeyDown(KeyMappings["Up"]) && 
            CanMove(new Vector2(Position.X, Position.Y - PlayerSpeed), gd))
            Position.Y -= PlayerSpeed;

        if (keyboardState.IsKeyDown(KeyMappings["Down"]) && 
            CanMove(new Vector2(Position.X, Position.Y + PlayerSpeed), gd))
            Position.Y += PlayerSpeed;

        if (keyboardState.IsKeyDown(KeyMappings["Left"]) && 
            CanMove(new Vector2(Position.X - PlayerSpeed, Position.Y), gd))
            Position.X -= PlayerSpeed;

        if (keyboardState.IsKeyDown(KeyMappings["Right"]) && 
            CanMove(new Vector2(Position.X + PlayerSpeed, Position.Y), gd))
            Position.X += PlayerSpeed;

        // Check collision with ground
        if(Position.Y + Texture.Height >= groundRectangle.Y)
            {
            Position.Y = groundRectangle.Y - Texture.Height;
            VerticalVelocity = 0f;
        }

        // Apply gravity
        if (Position.Y < groundRectangle.Y - Texture.Height)
            VerticalVelocity += Gravity;

        Position.Y = Math.Min(Position.Y + VerticalVelocity, 
                                        gd.Viewport.Height - Texture.Height);
        VerticalVelocity = Math.Min(VerticalVelocity, MaxFallSpeed);

        // Attack logic
        if (keyboardState.IsKeyDown(KeyMappings["Attack"]) && !IsAttacking)
        {
            IsAttacking = true;
            if (Vector2.Distance(this.Position, otherPlayer.Position) < this.Texture.Width) // Ширина player'a и другого player'a 
                otherPlayer.HP -= AttackDamage;
        }
        else if (keyboardState.IsKeyUp(KeyMappings["Attack"]))
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
}