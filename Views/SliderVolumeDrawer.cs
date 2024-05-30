using BloodyPath.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BloodyPath.Views;

public class SliderVolumeDrawer
{
    private readonly SliderVolume SliderVolume;
    private readonly Texture2D SliderBarTexture;
    private readonly Texture2D SliderButtonTexture;
    private readonly Texture2D MuteTexture;
    private readonly Texture2D UnmuteTexture;

    public SliderVolumeDrawer(SliderVolume sliderVolume,
                              Texture2D sliderBarTexture,
                              Texture2D sliderButtonTexture,
                              Texture2D muteTexture,
                              Texture2D unmuteTexture)
    {
        SliderVolume = sliderVolume;
        SliderBarTexture = sliderBarTexture;
        SliderButtonTexture = sliderButtonTexture;
        MuteTexture = muteTexture;
        UnmuteTexture = unmuteTexture;
        LoadContent();
    }

    public void LoadContent()
    {
        // Установка начальной позиции
        SliderVolume.SliderPosition = new Vector2(100, 488);

        // Определение размеров и положения ползунка
        SliderVolume.SliderBarRect = new Rectangle((int)SliderVolume.SliderPosition.X,
                                                   (int)SliderVolume.SliderPosition.Y, 200, 20);

        // Установка начальной позиции ручки ползунка на основе MediaPlayer.Volume
        int knobX = (int)(SliderVolume.SliderPosition.X + (SliderVolume.Volume * 
                         (SliderVolume.SliderBarRect.Width - SliderButtonTexture.Width)));
        // Центрирование ручки по высоте полосы
        SliderVolume.SliderButtonRect = new Rectangle(knobX, (int)SliderVolume.SliderPosition.Y - 10, 20, 40);

        // Установка положения кнопки mute
        // Положение и размер кнопки
        SliderVolume.MuteButtonRect = new Rectangle(25, 480, MuteTexture.Width, MuteTexture.Height);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Отрисовка полосы и ручки ползунка
        spriteBatch.Draw(SliderBarTexture, SliderVolume.SliderBarRect, Color.White);
        spriteBatch.Draw(SliderButtonTexture, SliderVolume.SliderButtonRect, Color.White);

        // Отрисовка кнопки mute/unmute
        if (SliderVolume.IsMuted)
            spriteBatch.Draw(MuteTexture, SliderVolume.MuteButtonRect, Color.White);
        else
            spriteBatch.Draw(UnmuteTexture, SliderVolume.MuteButtonRect, Color.White);
    }
}