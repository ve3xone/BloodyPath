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
        Animation.timeCounter += gameTime.ElapsedGameTime.TotalSeconds;

        if (Animation.timeCounter >= Animation.frameTime)
        {
            Animation.currentFrame++;
            if (Animation.currentFrame >= Animation.frames.Count)
            {
                Animation.currentFrame = 0;
            }
            Animation.timeCounter -= Animation.frameTime;
        }
    }
}