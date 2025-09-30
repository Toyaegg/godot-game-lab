using Godot;
using BS.Common.Commands;
using BS.Common.UI;
using BS.Common.Utilities;
using Godot.Collections;
using MagicaShop.Game.Commands;
using MagicaShop.Game.Events;
using QFramework;
using Range = Godot.Range;

public partial class Loading : UIPanel, IController
{
    [Export] private ProgressBar PgBar;
    private string LoadingScene;
    private Array Process = new Array();
    
    public override void _Ready()
    {
        this.RegisterEvent<SceneReadyEvent>(OnSceneReady);
        
        LoadingScene = this.GetUtility<ResourceLoadUtility>().GetLoadingScenePath();
        GD.Load(LoadingScene);
    }

    private void OnSceneReady(SceneReadyEvent e)
    {
        GD.Print("场景准备完成！");
        GUIOperateCommand command = new GUIOperateCommand("loading", UIOperation.Close);
        this.SendCommand(command);
    }

    public override void _Process(double delta)
    {
        ResourceLoader.ThreadLoadStatus status = ResourceLoader.LoadThreadedGetStatus(LoadingScene, Process);
        
        PgBar.Value = Process[0].AsDouble() * 100;
        
        if (status == ResourceLoader.ThreadLoadStatus.Loaded)
        {
            PackedScene scene = ResourceLoader.LoadThreadedGet(LoadingScene) as PackedScene;
            LoadFinishCommand command = new LoadFinishCommand(scene);
            this.SendCommand(command);
        }
    }

    public IArchitecture GetArchitecture()
    {
        return Application.Interface;
    }
}
