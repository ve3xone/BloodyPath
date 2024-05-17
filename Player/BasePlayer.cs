using Microsoft.Xna.Framework;

public class BasePlayer
{
    public bool IsAttacking { get; set; }

    public Vector2 Position = Vector2.Zero;
    public int HP = 100;
    public readonly int PlayerSpeed = 3;
    public readonly int AttackDamage = 10;

    public BasePlayer(Vector2 position)
    {
        Position = position;
        IsAttacking = true;
    }
}