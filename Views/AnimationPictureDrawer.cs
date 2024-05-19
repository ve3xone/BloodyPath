using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Views;

public class AnimationPictureDrawer
{
    private readonly AnimationPicture Animation;

    public AnimationPictureDrawer(AnimationPicture animation)
    {
        Animation = animation;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(Animation.frames[Animation.currentFrame], position, Color.White);
    }
}