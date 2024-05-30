using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace BloodyPath.Models;

public class SliderVolume
{
    public float Volume { get; set; } = MediaPlayer.Volume;
    public bool IsMuted { get; set; } = MediaPlayer.IsMuted;
    public Texture2D SliderBarTexture;
    public Texture2D SliderButtonTexture;
    public Texture2D MuteTexture;
    public Texture2D UnmuteTexture;
    public Vector2 SliderPosition;
    public Rectangle SliderBarRect;
    public Rectangle SliderButtonRect;
    public Rectangle MuteButtonRect;

    public SliderVolume(float volume,
                        Texture2D sliderBarTexture, 
                        Texture2D sliderButtonTexture, 
                        Texture2D muteTexture, 
                        Texture2D unmuteTexture)
    {
        Volume = volume;
        this.SliderBarTexture = sliderBarTexture;
        this.SliderButtonTexture = sliderButtonTexture;
        this.MuteTexture = muteTexture;
        this.UnmuteTexture = unmuteTexture;
    }

    public void LoadContent()
    {
        // Установка начальной позиции
        SliderPosition = new Vector2(100, 488);

        // Определение размеров и положения ползунка
        SliderBarRect = new Rectangle((int)SliderPosition.X, 
                                      (int)SliderPosition.Y, 200, 20);

        // Установка начальной позиции ручки ползунка на основе MediaPlayer.Volume
        int knobX = (int)(SliderPosition.X + (Volume * (SliderBarRect.Width - SliderButtonTexture.Width)));
        // Центрирование ручки по высоте полосы
        SliderButtonRect = new Rectangle(knobX, (int)SliderPosition.Y - 10, 20, 40);

        // Установка положения кнопки mute
        // Положение и размер кнопки
        MuteButtonRect = new Rectangle(25, 480, MuteTexture.Width, MuteTexture.Height);
    }
}