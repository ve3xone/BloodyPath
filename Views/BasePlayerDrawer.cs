using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.View;

public class BasePlayerDrawer
{
    private readonly BasePlayer Player;

    public BasePlayerDrawer(BasePlayer player)
    {
        Player = player;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D textureToDraw;

        if (Player.IsAttackingHands)
        {
            textureToDraw = Player.IsLeftTexture ? Player.PlayerDamageHandsTexture : Player.PlayerDamageHandsTextureReversed;
        }
        else if (Player.IsAttackingFeet)
        {
            textureToDraw = Player.IsLeftTexture ? Player.PlayerDamageFeetTexture : Player.PlayerDamageFeetTextureReversed;
        }
        else if (Player.IsDucked)
        {
            textureToDraw = Player.PlayerTextureDucked;
        }
        else
        {
            textureToDraw = Player.IsLeftTexture ? Player.PlayerTexture : Player.PlayerTextureReversed;
        }

        spriteBatch.Draw(textureToDraw, Player.Position, Color.White);
    }

    public void DrawHpPlayerBar(SpriteBatch spriteBatch, SpriteFont font, Vector2 Pos, bool Reverse)
    {
        // Draw HP bar background
        spriteBatch.Draw(Player.PlayerHpTexture, new Rectangle((int)Pos.X, (int)Pos.Y, 300, 25), Color.Gray);

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
            spriteBatch.Draw(Player.PlayerHpTexture, 
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
            spriteBatch.Draw(Player.PlayerHpTexture, 
                             new Rectangle((int)Pos.X + fillWidth, (int)Pos.Y, maxWidth - fillWidth, 25), 
                             Color.Red);
        }
    }
}