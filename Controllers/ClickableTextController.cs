using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BloodyPath.Controllers;

public class ClickableTextController
{
    private ClickableText ClickableText { get; set; }
    private Rectangle BoundingBox;
    private MouseState PreviousMouseState;

    public ClickableTextController(ClickableText clickableText)
    {
        ClickableText = clickableText;
        BoundingBox = new Rectangle((int)ClickableText.Position.X,
                                    (int)ClickableText.Position.Y,
                                    (int)ClickableText.textSize.X,
                                    (int)ClickableText.textSize.Y);
    }

    public void Update()
    {
        MouseState mouseState = Mouse.GetState();
        Point mousePosition = new(mouseState.X, mouseState.Y);

        ClickableText.IsHovering = BoundingBox.Contains(mousePosition);

        if (ClickableText.IsHovering &&
            mouseState.LeftButton == ButtonState.Pressed &&
            PreviousMouseState.LeftButton == ButtonState.Released)
        {
            ClickableText.OnClickAction?.Invoke();
        }

        PreviousMouseState = mouseState;
    }
}