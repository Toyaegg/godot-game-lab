using System;
using BS.Common.UI;
using Godot;
using Godot.Collections;
using QFramework;

namespace BS.Common.Utilities;

public class ResourceLoadUtility : IUtility
{
    private string LoadingScenePath;
    
    public PackedScene LoadUI(string name, bool isSubPanel)
    {
        string guiPath = isSubPanel ? "subgui" : "gui";
        string path = $"res://{guiPath}/{name}/{name}.tscn";
        GD.Print("正在加载：", path);
        PackedScene gui = GD.Load<PackedScene>(path);
        return gui;
    }
    
    public void LoadScene(string name)
    {
        string path = $"res://world/{name}/{name}.tscn";
        GD.Print("正在加载：", path);
        LoadingScenePath = path;
        ResourceLoader.LoadThreadedRequest(path);
    }

    public string GetLoadingScenePath()
    {
        return LoadingScenePath;
    }
}