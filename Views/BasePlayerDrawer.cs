using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BloodyPath.Models;

namespace BloodyPath.View;

public class BasePlayerDrawer
{
    private readonly SpriteBatch SpriteBatch;
    private readonly BasePlayer Player;
    public Texture2D PlayerTexture { get; private set; }
    public Texture2D PlayerDamagedTexture { get; private set; }
    public Texture2D PlayerHpTexture { get; private set; }

    public BasePlayerDrawer(SpriteBatch spriteBatch,
                                         BasePlayer player,
                                         Texture2D playerTexture,
                                         Texture2D playerDamagedTexture,
                                         Texture2D playerHpTexture)
    {
        Player = player;
        SpriteBatch = spriteBatch;
        PlayerTexture = playerTexture;
        PlayerDamagedTexture = playerDamagedTexture;
        PlayerHpTexture = playerHpTexture;
    }

    public void Draw()
    {
        if (Player.IsAttacking)
        {
            SpriteBatch.Draw(PlayerDamagedTexture, Player.Position, Color.White);
        }
        else
        {
            SpriteBatch.Draw(PlayerTexture, Player.Position, Color.White);
        }
    }

    public void DrawHpPlayerBar(Vector2 Pos, bool Reverse, SpriteFont font)
    {
        // Draw HP bar background
        SpriteBatch.Draw(PlayerHpTexture, new Rectangle((int)Pos.X, (int)Pos.Y, 300, 15), Color.Gray);

        // Draw filled portion of HP bar
        int maxWidth = 300;
        int fillWidth = (int)(Player.HP / (float)100 * maxWidth);

        // Позиция текста "Player 1"
        Vector2 playerTextPos = new(Pos.X, Pos.Y - 28);

        if (Reverse)
        {
            SpriteBatch.DrawString(font, "Player 1", playerTextPos, Color.White);
            SpriteBatch.Draw(PlayerHpTexture, 
                                      new Rectangle((int)Pos.X, (int)Pos.Y, fillWidth, 25), 
                                      Color.Red);
        }
        else
        {
            fillWidth = (int)((1 - (Player.HP / (float)100)) * maxWidth);

            // Размер текста
            Vector2 playerTextSize = font.MeasureString("Player 2");

            // Позиция текста "Player 2"
            playerTextPos = new Vector2(Pos.X + maxWidth - playerTextSize.X + 3, Pos.Y - 28);

            SpriteBatch.DrawString(font, "Player 2", playerTextPos, Color.White);
            SpriteBatch.Draw(PlayerHpTexture, 
                                      new Rectangle((int)Pos.X + fillWidth, (int)Pos.Y, maxWidth - fillWidth, 25), 
                                      Color.Red);
        }
    }
}