using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Views;

public class BattleFieldScreenDrawer
{
    private readonly BattleFieldScreen BattleFieldScreen;
    private Texture2D Background;
    private SpriteFont Font;

    public BattleFieldScreenDrawer(BattleFieldScreen battleFieldScreen)
    {
        BattleFieldScreen = battleFieldScreen;
        LoadContent();
    }

    private void LoadContent()
    {
        BattleFieldScreen.IsResetDraw = false;

        Font = BattleFieldScreen.Game.Content.Load<SpriteFont>(@"Fonts\FontBattleField");
        Background = BattleFieldScreen.Game.Content.Load<Texture2D>(@"Backgrounds\Landscape_800_600");

        BattleFieldScreen.Persona1.PlayerDrawer = new(BattleFieldScreen.Persona1.Player,
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player1"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player1Reversed"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player1Ducked"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player1DamageHands"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player1DamageHandsReversed"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player1DamageFeet"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player1DamageFeetReversed"),
            BattleFieldScreen.Game.Content.Load<Texture2D>("HPRed"));
        BattleFieldScreen.Persona2.PlayerDrawer = new(BattleFieldScreen.Persona2.Player,
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player2"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player2Reversed"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player2Ducked"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player2DamageHands"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player2DamageHandsReversed"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player2DamageFeet"),
            BattleFieldScreen.Game.Content.Load<Texture2D>(@"Personas\Player2DamageFeetReversed"),
            BattleFieldScreen.Game.Content.Load<Texture2D>("HPRed"));
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (BattleFieldScreen.VisibilityScreens.BattleFieldIsVisible)
        {
            if (BattleFieldScreen.IsResetDraw) LoadContent();

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