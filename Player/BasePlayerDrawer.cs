using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Player
{
    public class BasePlayerDrawer
    {
        private BasePlayer player;
        private SpriteBatch spriteBatch;

        public BasePlayerDrawer(SpriteBatch spriteBatch, BasePlayer player)
        {
            this.player = player;
            this.spriteBatch = spriteBatch;
        }

        public void Draw()
        {
            // Draw player
            if (player.IsAttacking)
            {
                spriteBatch.Draw(player.DamagedTexture, player.Position, Color.White);
            }
            else
            {
                spriteBatch.Draw(player.Texture, player.Position, Color.White);
            }
        }

        public void DrawHpPlayerBar(Vector2 Pos)
        {
            // Draw HP bar background
            spriteBatch.Draw(player.HpTexture, new Rectangle((int)Pos.X, (int)Pos.Y, 100, 10), Color.Gray);

            // Draw filled portion of HP bar
            int fillWidth = (int)(player.HP / (float)100 * 100);
            spriteBatch.Draw(player.HpTexture, new Rectangle((int)Pos.X, (int)Pos.Y, fillWidth, 10), Color.Red);
        }
    }
}
