using Godot;
using System;
using System.Collections.Generic;
using BS.Common.Events;
using BS.Common.Utilities;
using MagicaShop.Game.Events;
using QFramework;

namespace BS.Common.UI;

public partial class UIManager : Node, ICanRegisterEvent, ICanSendEvent, ICanGetUtility
{
    private Dictionary<string, Node> Layers = new Dictionary<string, Node>();
    private Dictionary<string, PackedScene> CachedGUI = new Dictionary<string, PackedScene>();
    private Dictionary<string, PackedScene> CachedSubGUI = new Dictionary<string, PackedScene>();
    private Stack<UIPanel> OpenedGUI = new Stack<UIPanel>();
    private Stack<SubSubGuiPanel> OpenedSubGUI = new Stack<SubSubGuiPanel>();
    private UIPanel CurPanel;
    private SubSubGuiPanel CurSubPanel;
    public override void _Ready()
    {
        Init();

        this.RegisterEvent<GUIOperateEvent>(OnUIOperation).UnRegisterWhenNodeExitTree(this);
        this.RegisterEvent<SubGUIOperateEvent>(OnSubUIOperation).UnRegisterWhenNodeExitTree(this);
    }

    private void Init()
    {
        for (int i = 0; i < (int)UILayer.Max; i++)
        {
            string layerName = ((UILayer)i).ToString();
            CreateChildLayer(layerName);
            GD.Print($"UILayer {layerName} Created");
        }

        PreLoadCommonGUI();
        PreLoadCommonSubGUI();
        
        GD.Print("UIManger Init...");
    }

    private void PreLoadCommonGUI()
    {
        PackedScene gui = LoadGUI("loading");
        CachedGUI.Add("loading", gui);
    }

    private void PreLoadCommonSubGUI()
    {
        PackedScene gui = LoadGUI("tip", true);
        CachedSubGUI.Add("tip", gui);
    }

    void OnUIOperation(GUIOperateEvent operation)
    {
        GD.Print($"进行 ui 操作 {operation.Operation}");
        GD.Print($"当前 ui {CurPanel?.Name}");
        switch (operation.Operation)
        {
            case UIOperation.Show:
                if (operation.CloseBefore)
                {
                    GD.Print($"{CurPanel?.Name} queue free");
                    CurPanel?.QueueFree();
                }
                else
                {
                    OpenedGUI.Peek().Hide();
                }
                
                if (!CachedGUI.ContainsKey(operation.Name))
                {
                    PackedScene gui = LoadGUI(operation.Name);
                    CachedGUI.Add(operation.Name, gui);
                    CurPanel = gui.Instantiate<UIPanel>();
                    OpenedGUI.Push(CurPanel);
                    Layers[operation.Layer.ToString()].AddChild(CurPanel);
                }
                else
                {
                    CurPanel = CachedGUI[operation.Name].Instantiate<UIPanel>();
                    OpenedGUI.Push(CurPanel);
                    Layers[operation.Layer.ToString()].AddChild(CurPanel);
                }
                break;
            case UIOperation.Back:
                break;
            case UIOperation.Close:
                UIPanel panel = OpenedGUI.Pop();
                panel?.QueueFree();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    void OnSubUIOperation(SubGUIOperateEvent operation)
    {
        GD.Print($"进行 sub ui 操作 {operation.Operation}");
        GD.Print($"当前 sub ui {CurSubPanel?.Name}");
        switch (operation.Operation)
        {
            case UIOperation.Show:
                if (operation.CloseBefore)
                {
                    GD.Print($"{CurSubPanel?.Name} queue free");
                    CurSubPanel?.QueueFree();
                }
                else
                {
                    OpenedSubGUI.Peek().Hide();
                }
                CurSubPanel = CachedSubGUI[operation.Name].Instantiate<SubSubGuiPanel>();
                CurSubPanel.SetOptions(operation.Options);
                OpenedSubGUI.Push(CurSubPanel);
                Layers[UILayer.Popup.ToString()].AddChild(CurSubPanel);
                break;
            case UIOperation.Back:
                break;
            case UIOperation.Close:
                SubSubGuiPanel panel = OpenedSubGUI.Pop();
                panel?.QueueFree();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    void CreateChildLayer(string layerName)
    {
        Node layer = new Node();
        layer.Name = layerName;
        if (!Layers.ContainsKey(layerName))
        {
            Layers.Add(layerName, layer);
        }
        GD.Print($"Create {layerName} Layer");
        AddChild(layer);
    }

    PackedScene LoadGUI(string name, bool siSbu = false)
    {
        return this.GetUtility<ResourceLoadUtility>().LoadUI(name, siSbu);
    }

    public IArchitecture GetArchitecture()
    {
        return Application.Interface;
    }
}
