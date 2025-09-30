using System;
using System.Collections.Generic;
using BS.Common.Commands;
using BS.Common.UI;
using Godot;
using MagicaShop.Game.SubGUI;
using QFramework;

namespace MagicaShop.Game.Commands;

public class ExitGameCommand : AbstractCommand
{
    SceneTree SceneTree;

    public ExitGameCommand(SceneTree sceneTree)
    {
        SceneTree = sceneTree;
    }
    
    protected override void OnExecute()
    {
        SubGUIOperateCommand command = new SubGUIOperateCommand("tip", UIOperation.Show, CreateSubGUIOptions());
        this.SendCommand(command);
    }

    SubGUIOptions CreateSubGUIOptions()
    {
        SubGUIOptions options = new SubGUIOptions();
        options.actions = new List<Action>();
        options.actions.Add(ExitGame);
        options.actions.Add(CancelExitGame);
        options.Title = "退出游戏";
        options.Content = "确实要退出游戏吗？";
        options.TipType = Tip.TipType.Alert;
        return options;
    }

    void ExitGame()
    {
        GD.Print("Exit Game");
        SceneTree.Quit();
    }

    void CancelExitGame()
    {
        GD.Print("Cancel Exit Game");
        SubGUIOperateCommand command = new SubGUIOperateCommand("tip", UIOperation.Close);
        this.SendCommand(command);
    }
}