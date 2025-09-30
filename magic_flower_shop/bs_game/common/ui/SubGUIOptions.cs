using System;
using System.Collections.Generic;
using MagicaShop.Game.SubGUI;

namespace BS.Common.UI;

public struct SubGUIOptions
{
    public string Title;
    public string SubTitle;
    public string Content;
    public Tip.TipType TipType;
    public List<Action> actions;
}