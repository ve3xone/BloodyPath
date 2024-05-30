using Microsoft.Xna.Framework;

namespace BloodyPath.Models;

public class BattleFieldScreen
{
    public readonly Persona Persona1 = new();
    public readonly Persona Persona2 = new();
    public readonly Game Game;
    public Rectangle GroundRectangle;
    public VisibilityScreens VisibilityScreens;
    public MusicManager MusicManager;
    public bool IsResetDraw;
    public bool IsResetController;

    public BattleFieldScreen(Game game,
                             VisibilityScreens VisibilityScreens,
                             MusicManager musicManager)
    {
        Game = game;
        this.VisibilityScreens = VisibilityScreens;
        MusicManager = musicManager;
        Initialize();
    }

    private void Initialize()
    {
        GroundRectangle = new Rectangle(0, Game.GraphicsDevice.Viewport.Height - 50,
                                        Game.GraphicsDevice.Viewport.Width, 50);

        Persona1.Player = new(new Vector2(100, 444), true, 0);
        Persona2.Player = new(new Vector2(600, 444), false, 1);
    }

    public void ResetScreen()
    {
        Initialize();
        IsResetController = true;
        IsResetDraw = true;
    }
}