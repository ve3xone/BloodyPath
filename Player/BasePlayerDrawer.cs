using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Player;

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
        this.Player = player;
        this.SpriteBatch = spriteBatch;
        this.PlayerTexture = playerTexture;
        this.PlayerDamagedTexture = playerDamagedTexture;
        this.PlayerHpTexture = playerHpTexture;
    }

    public void Draw()
    {
        if (player.IsAttacking)
        {
            spriteBatch.Draw(PlayerDamagedTexture, player.Position, Color.White);
        }
        else
        {
            spriteBatch.Draw(PlayerTexture, player.Position, Color.White);
        }
    }

    public void DrawHpPlayerBar(Vector2 Pos)
    {
        // Draw HP bar background
        spriteBatch.Draw(PlayerHpTexture, new Rectangle((int)Pos.X, (int)Pos.Y, 100, 10), Color.Gray);

        // Draw filled portion of HP bar
        int fillWidth = (int)(player.HP / (float)100 * 100);
        spriteBatch.Draw(PlayerHpTexture, new Rectangle((int)Pos.X, (int)Pos.Y, fillWidth, 10), Color.Red);
    }
}