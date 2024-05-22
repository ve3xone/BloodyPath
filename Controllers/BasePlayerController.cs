using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BloodyPath.Models;
using BloodyPath.View;

namespace BloodyPath.Controller;

public class BasePlayerController
{
    private readonly BasePlayer Player;
    private readonly BasePlayerDrawer PlayerDrawer;

    private const float MaxFallSpeed = 10f; // Максимальная скорость падения
    private const float Gravity = 0.5f; // Ускорение свободного падения
    private float VerticalVelocity = 0f; // Вертикальная скорость игрока

    public Dictionary<string, Keys> KeyMappings { private get; set; }

    public BasePlayerController(BasePlayer player,
                                BasePlayerDrawer playerDrawer,
                                Dictionary<string, Keys> keyMappings)
    {
        Player = player;
        PlayerDrawer = playerDrawer;
        KeyMappings = keyMappings;
    }

    public void Update(KeyboardState keyboardState,
                       BasePlayer otherPlayer,
                       Rectangle groundRectangle,
                       GraphicsDevice gd)
    {
        // Move player based on keyboard input
        // Player movement
        if (keyboardState.IsKeyDown(KeyMappings["Up"]) &&
            CanMove(new Vector2(Player.Position.X, Player.Position.Y - Player.PlayerSpeed), gd))
            Player.Position.Y -= Player.PlayerSpeed;

        if (keyboardState.IsKeyDown(KeyMappings["Down"]) &&
            CanMove(new Vector2(Player.Position.X, Player.Position.Y + Player.PlayerSpeed), gd))
            Player.Position.Y += Player.PlayerSpeed;

        if (keyboardState.IsKeyDown(KeyMappings["Left"]) &&
            CanMove(new Vector2(Player.Position.X - Player.PlayerSpeed, Player.Position.Y), gd))
        {
            Player.IsLeftTexture = false;
            Player.Position.X -= Player.PlayerSpeed;
        }
            

        if (keyboardState.IsKeyDown(KeyMappings["Right"]) &&
            CanMove(new Vector2(Player.Position.X + Player.PlayerSpeed, Player.Position.Y), gd))
        {
            Player.IsLeftTexture = true;
            Player.Position.X += Player.PlayerSpeed;
        }

        if (keyboardState.IsKeyDown(KeyMappings["Duck"]))
            Player.IsDucked = true;
        else if (keyboardState.IsKeyUp(KeyMappings["Duck"]))
            Player.IsDucked = false;

        // Check collision with ground
        if (Player.Position.Y + PlayerDrawer.PlayerTexture.Height >= groundRectangle.Y)
        {
            Player.Position.Y = groundRectangle.Y - PlayerDrawer.PlayerTexture.Height;
            VerticalVelocity = 0f;
        }

        // Apply gravity
        if (Player.Position.Y < groundRectangle.Y - PlayerDrawer.PlayerTexture.Height)
            VerticalVelocity += Gravity;

        Player.Position.Y = Math.Min(Player.Position.Y + VerticalVelocity,
                                     gd.Viewport.Height - PlayerDrawer.PlayerTexture.Height);
        VerticalVelocity = Math.Min(VerticalVelocity, MaxFallSpeed);

        // Attack logic
        if (keyboardState.IsKeyDown(KeyMappings["AttackHands"]) && 
            !Player.IsAttackingHands)
        {
            Player.IsAttackingHands = true;
            if (Vector2.Distance(Player.Position, otherPlayer.Position) < PlayerDrawer.PlayerTexture.Width &&
                !otherPlayer.IsDucked)
                if (Player.IsLeftTexture && Player.Position.X < otherPlayer.Position.X ||
                    !Player.IsLeftTexture && Player.Position.X > otherPlayer.Position.X)
                    otherPlayer.HP -= Player.AttackDamage;
        }
        else if (keyboardState.IsKeyUp(KeyMappings["AttackHands"]))
            Player.IsAttackingHands = false;

        if (keyboardState.IsKeyDown(KeyMappings["AttackFeet"]) &&
            !Player.IsAttackingFeet)
        {
            Player.IsAttackingFeet = true;

            if (Vector2.Distance(Player.Position, otherPlayer.Position) < PlayerDrawer.PlayerTexture.Width)
            {
                if (Player.IsLeftTexture && Player.Position.X < otherPlayer.Position.X ||
                    !Player.IsLeftTexture && Player.Position.X > otherPlayer.Position.X)
                    otherPlayer.HP -= Player.AttackDamage;
            }
        }
        else if (keyboardState.IsKeyUp(KeyMappings["AttackFeet"]))
            Player.IsAttackingFeet = false;

        Player.HP = Math.Max(0, Player.HP);
    }

    private bool CanMove(Vector2 position, GraphicsDevice gd)
    {
        // Простой пример проверки на ландшафт: позиция является допустимой,
        // если она находится в пределах экрана
        return position.X >= 0 && position.Y >= 0 &&
               position.X <= gd.Viewport.Width - PlayerDrawer.PlayerTexture.Width &&
               position.Y <= gd.Viewport.Height - PlayerDrawer.PlayerTexture.Height;
    }
}