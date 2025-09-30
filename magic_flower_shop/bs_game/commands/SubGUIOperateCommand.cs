using BS.Common.Events;
using BS.Common.UI;
using QFramework;

namespace BS.Common.Commands;

public class SubGUIOperateCommand : AbstractCommand
{
    private string UIName;
    private UIOperation Operation;
    private SubGUIOptions Options;
    private bool CloseBefore;

    public SubGUIOperateCommand(string name, UIOperation operation, SubGUIOptions options = default, bool closeBefore = true)
    {
        UIName = name;
        Operation = operation;
        Options = options;
        CloseBefore = closeBefore;
    }
    
    protected override void OnExecute()
    {
        this.SendEvent(new SubGUIOperateEvent(){Name = UIName, Operation = Operation, Options = Options, CloseBefore = CloseBefore});
    }
}