using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace BloodyPath.Models;

public class SliderVolume
{
    public float Volume { get; set; } = MediaPlayer.Volume;
    public bool IsMuted { get; set; } = MediaPlayer.IsMuted;
    public Vector2 SliderPosition;
    public Rectangle SliderBarRect;
    public Rectangle SliderButtonRect;
    public Rectangle MuteButtonRect;

    public SliderVolume(float volume)
    {
        Volume = volume;
    }
}