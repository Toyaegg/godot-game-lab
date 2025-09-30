using Godot;
using System;
using MagicaShop.Game.Events;
using QFramework;

public partial class Shop : Node2D, ICanSendEvent
{
    public override void _Ready()
    {
        this.SendEvent<SceneReadyEvent>();
    }

    public IArchitecture GetArchitecture()
    {
        return Application.Interface;
    }
}
