using System.Threading.Tasks;
using BS.Common.Commands;
using BS.Common.UI;
using Godot;
using Godot.Collections;
using QFramework;

namespace MagicaShop.Game.GUI;

public partial class Init : UIPanel, IController
{
    [Export] private bool Skip;
    [Export] private Array<Texture2D> Splashes;
    [Export] private TextureRect Splash;
    
    public override async void _Ready()
    {
        PlaySplash(0);
        for (int i = 1; i <= Splashes.Count; i++)
        {
            await ToSignal(GetTree().CreateTimer(2), Timer.SignalName.Timeout);
            PlaySplash(i);
        }
    }

    void PlaySplash(int index)
    {
        GD.Print($"播放 {index}");
        if (index >= Splashes.Count)
        {
            GD.Print($"播放完毕");
            LoadMenu();
            return;
        }
        
        Splash.Texture = Splashes[index];
        Tween splashTween = GetTree().CreateTween();
        splashTween.TweenProperty(Splash, "self_modulate", Color.Color8(255, 255, 255, 255), 0.5f);
        splashTween.Chain().TweenProperty(Splash, "self_modulate", Color.Color8(255, 255, 255, 255), 1f);
        splashTween.Chain().TweenProperty(Splash, "self_modulate", Color.Color8(255, 255, 255, 0), 0.5f);
    }

    void LoadMenu()
    {
        GD.Print($"转到菜单");
        GUIOperateCommand command = new GUIOperateCommand("menu", UIOperation.Show);
        this.SendCommand(command);
    }

    public IArchitecture GetArchitecture()
    {
        return Application.Interface;
    }
}
