using Godot;
using QFramework;

namespace MagicaShop.Game.Commands;

public class ContinueGameCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        GD.Print("Continue Game");
    }
}