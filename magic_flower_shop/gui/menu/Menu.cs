using Godot;
using BS.Common.Commands;
using BS.Common.UI;
using MagicaShop.Game.Commands;
using QFramework;

namespace MagicaShop.Game.GUI;

public partial class Menu : UIPanel, IController
{
    [Export] Button StartBtn;
    [Export] Button ContinueBtn;
    [Export] Button LoadBtn;
    [Export] Button SettingBtn;
    [Export] Button CreditsBtn;
    [Export] Button ExitBtn;
    [Export] VBoxContainer Content;
    [Export] Label News;
    [Export] Label Version;
    
    public override void _Ready()
    {
        BindButtonsEvent();
        SetNews();
        SetGameVersion();
    
        ArchTest archTest = new ArchTest();
        
        this.AddChild(archTest);
        archTest.Init();
    }

    private void BindButtonsEvent()
    {
        StartBtn.Pressed += () =>
        {
            this.SendCommand<StartGameCommand>();
        };
        ContinueBtn.Pressed += () =>
        {
            this.SendCommand<ContinueGameCommand>();
        };
        LoadBtn.Pressed += () =>
        {
            GUIOperateCommand operate = new GUIOperateCommand("load", UIOperation.Show);
            this.SendCommand(operate);
        };
        SettingBtn.Pressed += () =>
        {
            GUIOperateCommand operate = new GUIOperateCommand("setting", UIOperation.Show);
            this.SendCommand(operate);
        };
        CreditsBtn.Pressed += () =>
        {
            GUIOperateCommand operate = new GUIOperateCommand("credits", UIOperation.Show);
            this.SendCommand(operate);
        };
        ExitBtn.Pressed += () =>
        {
            ExitGameCommand command = new ExitGameCommand(GetTree());
            this.SendCommand(command);
        };
    }

    private void SetNews()
    {
        string news = "daksljasdjalk\nkdkopawkdoa\ndjhwagdjhg\nppdpdp";
        for (int i = 0; i < 3; i++)
        {
            GD.Print($"SetNews {i} <> {news}");
            Label newsLabel = News.Duplicate() as Label;
            newsLabel.Text = news;
            newsLabel.Show();
            Content.AddChild(newsLabel);
        }
    }

    private void SetGameVersion()
    {
        GD.Print("SetGameVersion");
        string version = ProjectSettings.GetSetting("application/config/version").AsString();
        Version.Text = $"v{version}";
    }

    public IArchitecture GetArchitecture()
    {
        return Application.Interface;
    }
}
