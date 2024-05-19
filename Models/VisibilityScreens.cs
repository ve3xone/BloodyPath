namespace BloodyPath.Models;

public class VisibilityScreens
{
    public bool MainMenuIsVisible;
    public bool BattleFieldIsVisible;

    public VisibilityScreens()
    {
        this.MainMenuIsVisible = true;
        this.BattleFieldIsVisible = false;
    }
}