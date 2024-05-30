using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Views;

public class BattleFieldScreenDrawer
{
    private readonly BattleFieldScreen BattleFieldScreen;
    private readonly Texture2D Background;
    private readonly SpriteFont Font;

    public BattleFieldScreenDrawer(BattleFieldScreen battleFieldScreen,
                                   SpriteFont battlefieldFont,
                                   Texture2D background)
    {
        BattleFieldScreen = battleFieldScreen;
        Font = battlefieldFont;
        Background = background;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (BattleFieldScreen.VisibilityScreens.BattleFieldIsVisible)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(Background, Vector2.Zero, Color.White);

            BattleFieldScreen.Persona1.PlayerDrawer.Draw(spriteBatch);
            BattleFieldScreen.Persona1.PlayerDrawer.DrawHpPlayerBar(spriteBatch, 
                                                                    Font, 
                                                                    new Vector2(10, 25), 
                                                                    true);

            BattleFieldScreen.Persona2.PlayerDrawer.Draw(spriteBatch);
            BattleFieldScreen.Persona2.PlayerDrawer.DrawHpPlayerBar(spriteBatch, 
                                                                    Font, 
                                                                    new Vector2(480, 25), 
                                                                    false);

            spriteBatch.End();
        }
    }
}