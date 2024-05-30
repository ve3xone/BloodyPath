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
        MediaPlayer.Play(MainMenuMusic);
        MediaPlayer.IsRepeating = true;
    }

    public void PlayBattlefieldMusic()
    {
        MediaPlayer.Stop();
        MediaPlayer.Play(GameMusic);
        MediaPlayer.IsRepeating = true;
    }

    public static void MuteMusic() => MediaPlayer.IsMuted = true;
}