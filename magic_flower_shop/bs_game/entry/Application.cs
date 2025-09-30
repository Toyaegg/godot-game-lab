using Godot;
using System;
using BS.Common.Models;
using BS.Common.Utilities;
using MagicaShop.Game.Systems;
using QFramework;

public class Application : Architecture<Application>
{
    protected override void Init()
    {
        //注册数据类
        this.RegisterModel(new GlobalModel());
        
        //注册系统类
        this.RegisterSystem(new TimeSystem());
        
        //注册工具类
        this.RegisterUtility(new ResourceLoadUtility());
        this.RegisterUtility(new GameSaveUtility());
    }
}
