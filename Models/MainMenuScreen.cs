using Microsoft.Xna.Framework;

namespace BloodyPath.Models;

public class MainMenuScreen
{
    public Button PlayButton { get; set; } = new Button();
    public Button ExitButton { get; set; } = new Button();
    public Rectangle Size { get; set; }
    public VisibilityScreens VisibilityScreens { get; set; }
    public Game Game { get; set; }
    public MusicManager MusicManager { get; set; }
    public Animation AnimationBackground { get; set; } = new Animation();
    public VolumeManager VolumeManager { get; set; } = new VolumeManager();

    public MainMenuScreen(Game game, VisibilityScreens visibilityScreens, MusicManager musicManager)
    {
        Game = game;
        VisibilityScreens = visibilityScreens;
        MusicManager = musicManager;
        AnimationBackground.AnimationPicture = new AnimationPicture(0.155);
        Size = new Rectangle(0, 0, 
                             (int)(Game.GraphicsDevice.Viewport.Width / 2.5), 
                             Game.GraphicsDevice.Viewport.Height);
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        PlayButton.ClickableText = new ClickableText("Play", 
                                                     new Vector2(25, 300), 
                                                     Color.White, 
                                                     Color.Blue, 
                                                     delegate
                                                     {
                                                         VisibilityScreens.MainMenuIsVisible = false;
                                                         MusicManager.PlayBattlefieldMusic();
                                                         VisibilityScreens.BattleFieldIsVisible = true;
                                                     });

        ExitButton.ClickableText = new ClickableText("Exit", 
                                                     new Vector2(25, 325), 
                                                     Color.White, 
                                                     Color.Blue, 
                                                     delegate
                                                     {
                                                         Game.Exit();
                                                     });
    }
}
