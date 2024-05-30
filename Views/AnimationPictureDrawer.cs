using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BloodyPath.Views;

public class AnimationPictureDrawer
{
    private readonly AnimationPicture Animation;
    private readonly List<Texture2D> Frames;

    public AnimationPictureDrawer(AnimationPicture animation, List<Texture2D> frames)
    {
        Animation = animation;
        Frames = frames;
        Animation.FrameCount = Frames.Count;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(Frames[Animation.CurrentFrame], position, Color.White);
    }
}