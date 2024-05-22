using Microsoft.Xna.Framework;

namespace BloodyPath.Models;

public class BasePlayer
{
    public bool IsAttacking { get; set; }
    public bool IsAttackingHands { get; set; }
    public bool IsAttackingFeet { get; set; }
    public bool IsDucked { get; set; }
    public bool IsBot { get; set; } = false;
    public bool IsLeftTexture { get; set; }

    public int Number { get; set; }
    public Vector2 Position = Vector2.Zero;
    public Vector2 DefalutPosition = Vector2.Zero;
    public int HP = 100;
    public int Victories = 0;
    public readonly int PlayerSpeed = 3;
    public readonly int AttackDamage = 6;

    public BasePlayer(Vector2 position, bool isLeftTexture, int number)
    {
        Position = position;
        IsAttackingHands = false;
        IsAttackingFeet = false;
        IsDucked = false;
        IsLeftTexture = isLeftTexture;
        DefalutPosition = position;
        Number = number;
    }
}