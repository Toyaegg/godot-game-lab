using BS.Common.UI;

namespace BS.Common.Events;

public struct SubGUIOperateEvent
{
    public UIOperation Operation;
    public string Name;
    public SubGUIOptions Options;
    public bool CloseBefore;
}