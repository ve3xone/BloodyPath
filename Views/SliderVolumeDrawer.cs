using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Views;

public class SliderVolumeDrawer
{
    private readonly SliderVolume SliderVolume;

    public SliderVolumeDrawer(SliderVolume sliderVolume)
    {
        SliderVolume = sliderVolume;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Отрисовка полосы и ручки ползунка
        spriteBatch.Draw(SliderVolume.SliderBarTexture, SliderVolume.SliderBarRect, Color.White);
        spriteBatch.Draw(SliderVolume.SliderButtonTexture, SliderVolume.SliderButtonRect, Color.White);

        // Отрисовка кнопки mute/unmute
        if (SliderVolume.IsMuted)
            spriteBatch.Draw(SliderVolume.MuteTexture, SliderVolume.MuteButtonRect, Color.White);
        else
            spriteBatch.Draw(SliderVolume.UnmuteTexture, SliderVolume.MuteButtonRect, Color.White);
    }
}