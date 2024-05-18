using BloodyPath.Controller;
using BloodyPath.View;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BloodyPath.Models;

public class Persona
{
    public BasePlayer Player;
    public BasePlayerDrawer PlayerDrawer;
    public Dictionary<string, Keys> PlayerKeyMappings;
    public BasePlayerController PlayerController;
}