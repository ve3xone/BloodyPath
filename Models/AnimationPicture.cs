using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BloodyPath.Models;

public class AnimationPicture
{
    public List<Texture2D> frames;
    public int currentFrame;
    public double frameTime; // Time per frame in seconds
    public double timeCounter;

    public AnimationPicture(List<Texture2D> frames, double frameTime)
    {
        this.frames = frames;
        this.frameTime = frameTime;
        this.currentFrame = 0;
        this.timeCounter = 0.0;
    }
}