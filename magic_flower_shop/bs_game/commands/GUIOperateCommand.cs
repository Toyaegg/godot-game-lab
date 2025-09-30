using BS.Common.Events;
using BS.Common.UI;
using Godot;
using QFramework;

namespace BS.Common.Commands;

public class GUIOperateCommand : AbstractCommand
{
    private string UIName;
    private UIOperation Operation;
    private UILayer Layer;
    private bool CloseBefore;

    public GUIOperateCommand(string name, UIOperation operation, UILayer layer = UILayer.Common, bool closeBefore = true)
    {
        UIName = name;
        Layer = layer;
        Operation = operation;
        CloseBefore = closeBefore;
    }
    
    protected override void OnExecute()
    {
        this.SendEvent(new GUIOperateEvent(){Operation = Operation, Name = UIName, Layer = Layer, CloseBefore = CloseBefore});
    }
}