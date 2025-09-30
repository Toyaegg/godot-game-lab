using System;
using BS.Common.UI;

namespace BS.Common.Events;

public struct GUIOperateEvent
{
    public UIOperation Operation;
    public UILayer Layer;
    public string Name;
    public bool CloseBefore;
}