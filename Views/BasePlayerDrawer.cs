using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.View;

public class BasePlayerDrawer
{
    private readonly BasePlayer Player;
    public Texture2D PlayerTexture { get; private set; }
    public Texture2D PlayerTextureReversed { get; private set; }
    public Texture2D PlayerTextureDucked { get; private set; }
    public Texture2D PlayerDamageHandsTexture { get; private set; }
    public Texture2D PlayerDamageHandsTextureReversed { get; private set; }
    public Texture2D PlayerDamageFeetTexture { get; private set; }
    public Texture2D PlayerDamageFeetTextureReversed { get; private set; }
    public Texture2D PlayerHpTexture { get; private set; }

    public BasePlayerDrawer(BasePlayer player,
                            Texture2D playerTexture,
                            Texture2D playerTextureReversed,
                            Texture2D playerTextureDucked,
                            Texture2D playerDamageHandsTexture,
                            Texture2D playerDamageHandsTextureReversed,
                            Texture2D playerDamageFeetTexture,
                            Texture2D playerDamageFeetTextureReversed,
                            Texture2D playerHpTexture)
    {
        Player = player;
        PlayerTexture = playerTexture;
        PlayerTextureReversed = playerTextureReversed;
        PlayerTextureDucked = playerTextureDucked;
        PlayerDamageHandsTexture = playerDamageHandsTexture;
        PlayerDamageHandsTextureReversed = playerDamageHandsTextureReversed;
        PlayerDamageFeetTexture = playerDamageFeetTexture;
        PlayerDamageFeetTextureReversed = playerDamageFeetTextureReversed;
        PlayerHpTexture = playerHpTexture;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D textureToDraw;

        if (Player.IsAttackingHands)
        {
            textureToDraw = Player.IsLeftTexture ? PlayerDamageHandsTexture : PlayerDamageHandsTextureReversed;
        }
        else if (Player.IsAttackingFeet)
        {
            textureToDraw = Player.IsLeftTexture ? PlayerDamageFeetTexture : PlayerDamageFeetTextureReversed;
        }
        else if (Player.IsDucked)
        {
            textureToDraw = PlayerTextureDucked;
        }
        else
        {
            textureToDraw = Player.IsLeftTexture ? PlayerTexture : PlayerTextureReversed;
        }

        spriteBatch.Draw(textureToDraw, Player.Position, Color.White);
    }

    public void DrawHpPlayerBar(SpriteBatch spriteBatch, SpriteFont font, Vector2 Pos, bool Reverse)
    {
        // Draw HP bar background
        spriteBatch.Draw(PlayerHpTexture, new Rectangle((int)Pos.X, (int)Pos.Y, 300, 25), Color.Gray);

        // Draw filled portion of HP bar
        int maxWidth = 300;
        int fillWidth = (int)(Player.HP / (float)100 * maxWidth);

        // Позиция текста "Player 1"
        Vector2 playerTextPos = new(Pos.X, Pos.Y - 26);
        // Отображение побед Player 1
        Vector2 playerVictoriesPos = new(Pos.X + 305, Pos.Y + 1);

        if (Reverse)
        {
            spriteBatch.DrawString(font, "Player 1", playerTextPos, Color.White);
            spriteBatch.DrawString(font, Player.Victories.ToString(), playerVictoriesPos, Color.White);
            spriteBatch.Draw(PlayerHpTexture, 
                             new Rectangle((int)Pos.X, (int)Pos.Y, fillWidth, 25), 
                             Color.Red);
        }
        else
        {
            fillWidth = (int)((1 - (Player.HP / (float)100)) * maxWidth);

            // Размер текста
            Vector2 playerTextSize = font.MeasureString("Player 2");

            // Позиция текста "Player 2"
            playerTextPos = new Vector2(Pos.X + maxWidth - playerTextSize.X + 3, Pos.Y - 26);
            spriteBatch.DrawString(font, "Player 2", playerTextPos, Color.White);

            // Отображение побед Player 2
            playerVictoriesPos = new(Pos.X - 14, Pos.Y + 1);
            spriteBatch.DrawString(font, Player.Victories.ToString(), playerVictoriesPos, Color.White);
            spriteBatch.Draw(PlayerHpTexture, 
                             new Rectangle((int)Pos.X + fillWidth, (int)Pos.Y, maxWidth - fillWidth, 25), 
                             Color.Red);
        }
    }
}