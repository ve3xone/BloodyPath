using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace BloodyPath.Models;

public class ClickableText
{
    public readonly string Text;
    public Vector2 textSize;
    public Vector2 Position;
    public Color DefaultColor;
    public Color HoverColor;
    public bool IsHovering;
    public MouseState PreviousMouseState;
    public readonly Action OnClickAction;

    public ClickableText(string text, 
                         Vector2 position, 
                         Color defaultColor, 
                         Color hoverColor, 
                         Action onClickAction)
    {
        Text = text;
        Position = position;
        DefaultColor = defaultColor;
        HoverColor = hoverColor;
        IsHovering = false;
        OnClickAction = onClickAction;
    }
}