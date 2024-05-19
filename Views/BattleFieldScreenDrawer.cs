using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Views;

public class BattleFieldScreenDrawer
{
    private BattleFieldScreen BattleFieldScreen;

    public BattleFieldScreenDrawer(BattleFieldScreen battleFieldScreen)
    {
        BattleFieldScreen = battleFieldScreen;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (BattleFieldScreen.IsVisible)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(BattleFieldScreen.Background, Vector2.Zero, Color.White);
            BattleFieldScreen.Persona1.PlayerDrawer.Draw(spriteBatch);
            BattleFieldScreen.Persona1.PlayerDrawer.DrawHpPlayerBar(spriteBatch, 
                                                                                                  BattleFieldScreen.Font, 
                                                                                                  new Vector2(10, 25), 
                                                                                                  true);

            BattleFieldScreen.Persona2.PlayerDrawer.Draw(spriteBatch);
            BattleFieldScreen.Persona2.PlayerDrawer.DrawHpPlayerBar(spriteBatch, 
                                                                                                  BattleFieldScreen.Font, 
                                                                                                  new Vector2(480, 25), 
                                                                                                  false);
            spriteBatch.End();
        }
    }
}