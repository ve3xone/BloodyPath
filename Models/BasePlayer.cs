using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Models;

public class BasePlayer
{
    public bool IsAttacking { get; set; }
    public bool IsAttackingHands { get; set; }
    public bool IsAttackingFeet { get; set; }
    public bool IsDucked { get; set; }
    public bool IsBot { get; set; } = false;
    public bool IsLeftTexture { get; set; }
    public Texture2D PlayerTexture { get; private set; }
    public Texture2D PlayerTextureReversed { get; private set; }
    public Texture2D PlayerTextureDucked { get; private set; }
    public Texture2D PlayerDamageHandsTexture { get; private set; }
    public Texture2D PlayerDamageHandsTextureReversed { get; private set; }
    public Texture2D PlayerDamageFeetTexture { get; private set; }
    public Texture2D PlayerDamageFeetTextureReversed { get; private set; }
    public Texture2D PlayerHpTexture { get; private set; }
    public int Number { get; set; }
    public int HP = 100;
    public int Victories = 0;
    public Vector2 Position = Vector2.Zero;
    public Vector2 DefalutPosition = Vector2.Zero;
    public readonly int PlayerSpeed = 3;
    public readonly int AttackDamage = 6;

    public BasePlayer(Vector2 position, 
                      bool isLeftTexture, 
                      int number,
                      Texture2D playerTexture,
                      Texture2D playerTextureReversed,
                      Texture2D playerTextureDucked,
                      Texture2D playerDamageHandsTexture,
                      Texture2D playerDamageHandsTextureReversed,
                      Texture2D playerDamageFeetTexture,
                      Texture2D playerDamageFeetTextureReversed,
                      Texture2D playerHpTexture)
    {
        Position = position;
        IsAttackingHands = false;
        IsAttackingFeet = false;
        IsDucked = false;
        IsLeftTexture = isLeftTexture;
        DefalutPosition = position;
        Number = number;
        PlayerTexture = playerTexture;
        PlayerTextureReversed = playerTextureReversed;
        PlayerTextureDucked = playerTextureDucked;
        PlayerDamageHandsTexture = playerDamageHandsTexture;
        PlayerDamageHandsTextureReversed = playerDamageHandsTextureReversed;
        PlayerDamageFeetTexture = playerDamageFeetTexture;
        PlayerDamageFeetTextureReversed = playerDamageFeetTextureReversed;
        PlayerHpTexture = playerHpTexture;
    }
}