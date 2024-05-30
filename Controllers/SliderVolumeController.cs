using BloodyPath.Models;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace BloodyPath.Controllers;

public class SliderVolumeController
{
    private readonly SliderVolume SliderVolume;
    private MouseState CurrentMouseState;
    private MouseState PreviousMouseState;
    private bool isDragging = false;

    public SliderVolumeController(SliderVolume sliderVolume)
    {
        SliderVolume = sliderVolume;
    }

    public void Update()
    {
        CurrentMouseState = Mouse.GetState();

        // Проверка нажатия на кнопку mute
        if (SliderVolume.MuteButtonRect.Contains(CurrentMouseState.Position) && 
            CurrentMouseState.LeftButton == ButtonState.Pressed && 
            PreviousMouseState.LeftButton == ButtonState.Released)
        {
            SliderVolume.IsMuted = !SliderVolume.IsMuted;
            MediaPlayer.IsMuted = SliderVolume.IsMuted;
        }

        // Проверка нажатия на ручку ползунка
        if (SliderVolume.SliderButtonRect.Contains(CurrentMouseState.Position) && 
            CurrentMouseState.LeftButton == ButtonState.Pressed && 
            PreviousMouseState.LeftButton == ButtonState.Released)
        {
            isDragging = true;
        }

        // Перемещение ручки ползунка
        if (isDragging)
        {
            if (CurrentMouseState.LeftButton == ButtonState.Released) isDragging = false;
            else
            {
                int newKnobX = CurrentMouseState.X - SliderVolume.SliderButtonRect.Width / 2;
                newKnobX = Math.Clamp(newKnobX, SliderVolume.SliderBarRect.Left, 
                                      SliderVolume.SliderBarRect.Right - SliderVolume.SliderButtonRect.Width);
                SliderVolume.SliderButtonRect.X = newKnobX;

                // Обновление громкости
                float knobPosition = SliderVolume.SliderButtonRect.X - SliderVolume.SliderBarRect.Left;
                float barWidth = SliderVolume.SliderBarRect.Width - SliderVolume.SliderButtonRect.Width;

                // Установка громкости MediaPlayer
                MediaPlayer.Volume = knobPosition / barWidth;
            }
        }

        PreviousMouseState = CurrentMouseState;
    }
}