using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

    public void DrawHpPlayerBar(Vector2 Pos)
    {
        // Draw HP bar background
        SpriteBatch.Draw(PlayerHpTexture, new Rectangle((int)Pos.X, (int)Pos.Y, 100, 10), Color.Gray);

        // Draw filled portion of HP bar
        int fillWidth = (int)(Player.HP / (float)100 * 100);
        SpriteBatch.Draw(PlayerHpTexture, new Rectangle((int)Pos.X, (int)Pos.Y, fillWidth, 10), Color.Red);
    }
}