using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
namespace MyProject.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Login { get; set; }
    [ObservableProperty]
    public partial string Password { get; set; }
    [RelayCommand]
    private async Task Enter(object param)
    {
        var box=MessageBoxManager.GetMessageBoxStandard("Jello","First",ButtonEnum.OkCancel);
        await box.ShowAsync();
    }

}
