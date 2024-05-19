using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BloodyPath.Controllers;

public class ClickableTextController
{
    private ClickableText ClickableText { get; set; }
    public ClickableTextController(ClickableText clickableText)
    {
        this.ClickableText = clickableText;
    }

    public void Update()
    {
        MouseState mouseState = Mouse.GetState();
        Point mousePosition = new(mouseState.X, mouseState.Y);

        ClickableText.IsHovering = ClickableText.BoundingBox.Contains(mousePosition);

        if (ClickableText.IsHovering && mouseState.LeftButton == ButtonState.Pressed && ClickableText.PreviousMouseState.LeftButton == ButtonState.Released)
        {
            ClickableText.OnClickAction?.Invoke();
        }

        ClickableText.PreviousMouseState = mouseState;
    }
}