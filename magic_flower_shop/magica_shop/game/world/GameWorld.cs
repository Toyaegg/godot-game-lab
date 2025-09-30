using BS.Common.Commands;
using BS.Common.UI;
using Godot;
using MagicaShop.Game.Events;
using QFramework;

namespace MagicaShop;

public partial class GameWorld : Node, ICanRegisterEvent, ICanSendCommand
{
    private Node2D CurrentScene;
    
    public GameWorld()
    {
        Init();
    }
    
    public void Init()
    {
        GD.Print("GameWorld initialized");
        this.RegisterEvent<LoadFinishEvent>(SceneLoaded);
    }

    private void SceneLoaded(LoadFinishEvent e)
    {
        GD.Print("SceneLoaded");
        GUIOperateCommand command = new GUIOperateCommand("hud", UIOperation.Show);
        this.SendCommand(command);

        CurrentScene = e.Scene.Instantiate<Node2D>();
        AddChild(CurrentScene);
    }

    public IArchitecture GetArchitecture()
    {
        return Application.Interface;
    }
}