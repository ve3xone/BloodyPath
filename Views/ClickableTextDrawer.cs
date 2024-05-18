using Microsoft.Xna.Framework.Graphics;
using BloodyPath.Models;

namespace BloodyPath.Views;

public class ClickableTextDrawer
{
    private ClickableText ClickableText { get; set; }
    public ClickableTextDrawer(ClickableText clickableText)
    {
        this.ClickableText = clickableText;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(ClickableText.Font,
                                          ClickableText.Text,
                                          ClickableText.Position,
                                          ClickableText.IsHovering ?
                                          ClickableText.HoverColor : ClickableText.DefaultColor);
    }
}