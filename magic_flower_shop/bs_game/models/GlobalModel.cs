using Godot;
using QFramework;

namespace BS.Common.Models;

public class GlobalModel : AbstractModel
{
    public Node CurrentSceneRoot;
    public CanvasLayer CurrentGUIRoot;
    public Control CurrentGUI;
    
    protected override void OnInit()
    {
        GD.Print("On Global Model Init");
    }
}