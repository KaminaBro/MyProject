using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using MyProject.Models;
using System.Linq;
using System;
namespace MyProject.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public event Action<bool>? CloseRequest;
    [ObservableProperty]
    public partial string Login { get; set; }
    [ObservableProperty]
    public partial string Password { get; set; }
    [RelayCommand]
    private async Task Enter(object param)
    {
        using (PostgresContext db = new PostgresContext())
        {
            User user = db.Users.FirstOrDefault(p => p.Login == Login && p.Password == Password)!;
            if (user != null) 
            {
                var tovarWindow = new WindowTovar();
                tovarWindow.Show();
                CloseRequest?.Invoke(true);
            }
            else
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Пользоввателя с данным логином или паролем не существует", ButtonEnum.Ok);
                await box.ShowAsync();
            }
        }
    }

}
