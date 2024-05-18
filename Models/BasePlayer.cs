﻿using Microsoft.Xna.Framework;

namespace BloodyPath.Models;

public class BasePlayer
{
    public bool IsAttacking { get; set; }

    public Vector2 Position = Vector2.Zero;
    public int HP = 100;
    public readonly int PlayerSpeed = 3;
    public readonly int AttackDamage = 6;

    public BasePlayer(Vector2 position)
    {
        Position = position;
        IsAttacking = true;
    }
}