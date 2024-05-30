using BloodyPath.Models;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Views;

public class ClickableTextDrawer
{
    private ClickableText ClickableText { get; set; }
    public ClickableTextDrawer(ClickableText clickableText)
    {
        ClickableText = clickableText;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(ClickableText.Font,
                               ClickableText.Text,
                               ClickableText.Position,
                               ClickableText.IsHovering ? ClickableText.HoverColor : ClickableText.DefaultColor);
    }
}