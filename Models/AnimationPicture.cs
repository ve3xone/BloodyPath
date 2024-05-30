using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BloodyPath.Models;

public class AnimationPicture
{
    public int CurrentFrame;
    public int FrameCount;
    public double FrameTime; // Time per frame in seconds
    public double TimeCounter;

    public AnimationPicture(double frameTime)
    {
        FrameTime = frameTime;
        CurrentFrame = 0;
        TimeCounter = 0.0;
    }
}