using Godot;
using System;
using System.Collections.Generic;
using BS.Common.UI;

namespace MagicaShop.Game.SubGUI;

public partial class Tip : SubSubGuiPanel
{
    [Export] private Label Title;
    [Export] private Label Content;
    [Export] private Button ConfirmBtn;
    [Export] private Button CancelBtn;
    
    public enum TipType
    {
        Confirm,
        Alert,
    }

    public void SetTitle(string title)
    {
        if (title != String.Empty)
        {
            Title.Text = title;
        }
    }

    public void SetContent(string content)
    {
        if (content != String.Empty)
        {
            Content.Text = content;
        }
    }
    
    public override void SetOptions(SubGUIOptions options)
    {
        switch (options.TipType)
        {
            case TipType.Confirm:
                SetTitle(options.Title);
                SetContent(options.Content);
                ConfirmBtn.Pressed += options.actions[0];
                CancelBtn.Pressed += options.actions[1];
                break;
            case TipType.Alert:
                SetTitle(options.Title);
                SetContent(options.Content);
                CancelBtn.Hide();
                ConfirmBtn.Pressed += options.actions[0];
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
