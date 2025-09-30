using Godot;
using MagicaShop.Game.Events;
using QFramework;

namespace MagicaShop.Game.Commands;

public class LoadFinishCommand : AbstractCommand
{
    private PackedScene Scene;

    public LoadFinishCommand(PackedScene scene)
    {
        Scene = scene;
    }
    
    protected override void OnExecute()
    {
        this.SendEvent<LoadFinishEvent>(new LoadFinishEvent(){Scene = Scene});
    }
}