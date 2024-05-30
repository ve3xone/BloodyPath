using BloodyPath.Models;
using Microsoft.Xna.Framework;

namespace BloodyPath.Controllers;

public class AnimationPictureController
{
    private readonly AnimationPicture Animation;

    public AnimationPictureController(AnimationPicture animation)
    {
        Animation = animation;
    }

    public void Update(GameTime gameTime)
    {
        Animation.TimeCounter += gameTime.ElapsedGameTime.TotalSeconds;

        if (Animation.TimeCounter >= Animation.FrameTime)
        {
            Animation.CurrentFrame++;
            if (Animation.CurrentFrame >= Animation.FrameCount)
            {
                Animation.CurrentFrame = 0;
            }
            Animation.TimeCounter -= Animation.FrameTime;
        }
    }
}