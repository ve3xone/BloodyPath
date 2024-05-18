using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BloodyPath.Models;

public class ClickableText
{
    public readonly SpriteFont Font;
    public readonly string Text;
    public Vector2 Position;
    public Color DefaultColor;
    public Color HoverColor;
    public Rectangle BoundingBox;
    public bool IsHovering;
    public MouseState PreviousMouseState;
    public readonly Action OnClickAction;

    public ClickableText(SpriteFont font, string text, Vector2 position, Color defaultColor, Color hoverColor, Action onClickAction)
    {
        Font = font;
        Text = text;
        Position = position;
        DefaultColor = defaultColor;
        HoverColor = hoverColor;
        IsHovering = false;
        OnClickAction = onClickAction;

        Vector2 textSize = Font.MeasureString(Text);
        BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, (int)textSize.X, (int)textSize.Y);
    }
}