using Microsoft.Xna.Framework.Media;

namespace BloodyPath.Models;

public class MusicManager
{
    private Song MainMenuMusic;
    private Song GameMusic;

    public void LoadContent(Song mainMenuMusic,
                            Song gameMusic)
    {
        MainMenuMusic = mainMenuMusic;
        GameMusic = gameMusic;
    }

    public void PlayMainMenuMusic()
    {
        MediaPlayer.Stop();
        MediaPlayer.Volume = 0.05f;
        MediaPlayer.Play(MainMenuMusic);
        MediaPlayer.IsRepeating = true;
    }

    public void PlayBattlefieldMusic()
    {
        MediaPlayer.Stop();
        MediaPlayer.Volume = 0.05f;
        MediaPlayer.Play(GameMusic);
        MediaPlayer.IsRepeating = true;
    }

    public static void MuteMusic() => MediaPlayer.IsMuted = true;
}