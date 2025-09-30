using BS.Common.Commands;
using BS.Common.UI;
using BS.Common.Utilities;
using Godot;
using QFramework;

namespace MagicaShop.Game.Commands;

public class StartGameCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        GD.Print("Start Game");
        this.GetUtility<ResourceLoadUtility>().LoadScene("shop");
        
        GUIOperateCommand command = new GUIOperateCommand("loading", UIOperation.Show);
        this.SendCommand(command);

        // GD.Print("转到商店");
        // GUIOperateCommand command = new GUIOperateCommand("menu", UIOperation.Show);
        // this.SendCommand(command);
    }
}