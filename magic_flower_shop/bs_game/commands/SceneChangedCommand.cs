using BS.Common.Models;
using Godot;
using QFramework;

namespace BS.Common.Commands;

public class SceneChangedCommand : AbstractCommand
{
    private Node curScene;

    public SceneChangedCommand(Node scene)
    {
        curScene = scene;
    }
    
    protected override void OnExecute()
    {
        GlobalModel gm = this.GetModel<GlobalModel>();
        gm.CurrentSceneRoot = curScene;
        GD.Print(gm.CurrentSceneRoot.Name);
    }
}