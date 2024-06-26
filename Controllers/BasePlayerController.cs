﻿using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BloodyPath.Controller;

public class BasePlayerController
{
    private readonly BasePlayer Player;
    private Dictionary<string, Keys> KeyMappings { get; set; }
    private const float MaxFallSpeed = 10f;
    private const float Gravity = 0.07f;
    private const float attackInterval = 0.35f;
    private const float attackAnimationDuration = 0.25f;
    private float VerticalVelocity = 0f;
    private float attackTimer;
    private bool previousKeyState = false;

    public BasePlayerController(BasePlayer player, 
                                Dictionary<string, Keys> keyMappings)
    {
        Player = player;
        KeyMappings = keyMappings;
    }

    public void Update(GameTime gameTime, 
                       KeyboardState keyboardState, 
                       BasePlayer otherPlayer, 
                       Rectangle groundRectangle, 
                       GraphicsDevice gd)
    {
        float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (Player.Number == 1)
        {
            bool currentKeyState = keyboardState.IsKeyDown(KeyMappings["BotEnableAndDisable"]);
            if (currentKeyState && !previousKeyState)
                Player.IsBot = !Player.IsBot;
            previousKeyState = currentKeyState;
        }

        if (!Player.IsBot)
        {
            HandlePlayerMovement(keyboardState, gd);
            HandlePlayerAttacks(keyboardState, otherPlayer);
        }
        else
        {
            HandleBotMovementAndAttack(elapsedSeconds, otherPlayer);
        }

        ApplyGravityAndCheckGroundCollision(groundRectangle, gd);
        ResetPlayerIfDead(otherPlayer);
    }

    private void HandlePlayerMovement(KeyboardState keyboardState, GraphicsDevice gd)
    {
        Vector2 newPosition = Player.Position;

        if (keyboardState.IsKeyDown(KeyMappings["Up"]) && CanMove(new Vector2(newPosition.X, newPosition.Y - Player.PlayerSpeed), gd))
            newPosition.Y -= Player.PlayerSpeed;
        if (keyboardState.IsKeyDown(KeyMappings["Down"]) && CanMove(new Vector2(newPosition.X, newPosition.Y + Player.PlayerSpeed), gd))
            newPosition.Y += Player.PlayerSpeed;
        if (keyboardState.IsKeyDown(KeyMappings["Left"]) && CanMove(new Vector2(newPosition.X - Player.PlayerSpeed, newPosition.Y), gd))
        {
            Player.IsLeftTexture = false;
            newPosition.X -= Player.PlayerSpeed;
        }
        if (keyboardState.IsKeyDown(KeyMappings["Right"]) && CanMove(new Vector2(newPosition.X + Player.PlayerSpeed, newPosition.Y), gd))
        {
            Player.IsLeftTexture = true;
            newPosition.X += Player.PlayerSpeed;
        }

        Player.Position = newPosition;
        Player.IsDucked = keyboardState.IsKeyDown(KeyMappings["Duck"]);
    }

    private void HandlePlayerAttacks(KeyboardState keyboardState, BasePlayer otherPlayer)
    {
        if (keyboardState.IsKeyDown(KeyMappings["AttackHands"]) && !Player.IsAttackingHands)
            PerformAttack(otherPlayer, false);

        if (keyboardState.IsKeyDown(KeyMappings["AttackFeet"]) && !Player.IsAttackingFeet)
            PerformAttack(otherPlayer, true);

        Player.IsAttackingHands = keyboardState.IsKeyDown(KeyMappings["AttackHands"]);
        Player.IsAttackingFeet = keyboardState.IsKeyDown(KeyMappings["AttackFeet"]);
    }

    private void PerformAttack(BasePlayer otherPlayer, bool isFeetAttack)
    {
        if (Vector2.Distance(Player.Position, otherPlayer.Position) < Player.TextureWidth)
        {
            bool isPlayerOnCorrectSide = Player.IsLeftTexture && Player.Position.X < otherPlayer.Position.X ||
                                         !Player.IsLeftTexture && Player.Position.X > otherPlayer.Position.X;
            if (isPlayerOnCorrectSide)
            {
                if (isFeetAttack)
                {
                    otherPlayer.HP -= Player.AttackDamage;
                    Player.IsAttackingFeet = true;
                }
                else if (!isFeetAttack && 
                         (!otherPlayer.IsDucked))
                {
                    otherPlayer.HP -= Player.AttackDamage;
                    Player.IsAttackingHands = true;
                }
            }
        }
    }

    private void HandleBotMovementAndAttack(float elapsedSeconds, BasePlayer otherPlayer)
    {
        if (Math.Abs(Player.Position.X - otherPlayer.Position.X) > Player.TextureWidth - 20)
        {
            MoveTowardsOtherPlayer(otherPlayer);
        }
        else
        {
            HandleBotAttack(elapsedSeconds, otherPlayer);
        }
    }

    private void MoveTowardsOtherPlayer(BasePlayer otherPlayer)
    {
        Player.IsAttackingFeet = false;
        Player.IsAttackingHands = false;
        Player.IsLeftTexture = otherPlayer.Position.X > Player.Position.X;
        Player.Position += new Vector2(Player.IsLeftTexture ? Player.PlayerSpeed : -Player.PlayerSpeed, 0);
    }

    private void HandleBotAttack(float elapsedSeconds, BasePlayer otherPlayer)
    {
        attackTimer += elapsedSeconds;
        if (attackTimer >= attackInterval)
        {
            attackTimer = 0f;
            PerformBotAttack(otherPlayer);
        }
        else if (attackTimer >= attackAnimationDuration)
        {
            Player.IsAttackingFeet = false;
            Player.IsAttackingHands = false;
        }
    }

    private void PerformBotAttack(BasePlayer otherPlayer)
    {
        bool isWithinReach = Vector2.Distance(Player.Position, otherPlayer.Position) < Player.TextureWidth;

        // Проверка на то, что бот находится в пределах атаки
        if (isWithinReach)
        {
            if (otherPlayer.Position.Y >= 443)
            {
                otherPlayer.HP -= Player.AttackDamage;
                Player.IsAttackingFeet = true;
            }
            else if (!otherPlayer.IsDucked)
            {
                otherPlayer.HP -= Player.AttackDamage;
                Player.IsAttackingHands = true;
            }
        }
    }

    private void ApplyGravityAndCheckGroundCollision(Rectangle groundRectangle, GraphicsDevice gd)
    {
        if (Player.Position.Y + Player.TextureHeight >= groundRectangle.Y)
        {
            Player.Position.Y = groundRectangle.Y - Player.TextureHeight;
            VerticalVelocity = 0f;
        }
        else
        {
            VerticalVelocity += Gravity;
        }

        Player.Position.Y = Math.Min(Player.Position.Y + VerticalVelocity, gd.Viewport.Height - Player.TextureHeight);
        VerticalVelocity = Math.Min(VerticalVelocity, MaxFallSpeed);
    }

    private void ResetPlayerIfDead(BasePlayer otherPlayer)
    {
        Player.HP = Math.Max(0, Player.HP);
        if (Player.HP <= 0)
            ResetPlayers(otherPlayer);
    }

    private void ResetPlayers(BasePlayer otherPlayer)
    {
        otherPlayer.Victories++;
        Player.HP = 100;
        otherPlayer.HP = 100;
        Player.Position = Player.DefalutPosition;
        otherPlayer.Position = otherPlayer.DefalutPosition;
    }

    private bool CanMove(Vector2 position, GraphicsDevice gd)
    {
        return position.X >= 0 && position.Y >= 0 &&
               position.X <= gd.Viewport.Width - Player.TextureWidth &&
               position.Y <= gd.Viewport.Height - Player.TextureHeight;
    }
}