using BloodyPath.Models;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Views;

public class ClickableTextDrawer
{
    private ClickableText ClickableText { get; set; }
    private readonly SpriteFont Font;

    public ClickableTextDrawer(ClickableText clickableText, SpriteFont font)
    {
        ClickableText = clickableText;
        Font = font;
        ClickableText.textSize = Font.MeasureString(ClickableText.Text);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(Font,
                               ClickableText.Text,
                               ClickableText.Position,
                               ClickableText.IsHovering ? 
                               ClickableText.HoverColor : ClickableText.DefaultColor);
    }
}