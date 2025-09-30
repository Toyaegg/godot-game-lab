using Godot;
using System;
using BS.Common.Commands;
using BS.Common.UI;
using MagicaShop;
using MagicaShop.Game.Systems;
using QFramework;

public partial class Initialize : Node, IController
{
    TimeSystem timeSystem;
    
    public override void _Ready()
    {
        GD.Print("Application Initialized");
        CreateUIManager();

        CreateWorld();
        
        GUIOperateCommand command = new GUIOperateCommand("init", UIOperation.Show);
        this.SendCommand(command);

        timeSystem = this.GetSystem<TimeSystem>();

        Timer timer = new Timer();
        timer.WaitTime = 1f;
        timer.Autostart = true;
        timer.OneShot = false;
        timer.Timeout += UpdateTimeSystem;
        AddChild(timer);
        timer.Start();
    }

    void CreateUIManager()
    {
        UIManager UIManager = new UIManager();
        UIManager.Name = "UIManager";
        AddChild(UIManager);
    }

    void CreateWorld()
    {
        GameWorld World = new GameWorld();
        World.Name = "World";
        AddChild(World);
    }

    public void UpdateTimeSystem()
    {
        timeSystem.UpdateTime();
        timeSystem.PrintCurrentTime();
    }

    public IArchitecture GetArchitecture()
    {
        return Application.Interface;
    }
}
