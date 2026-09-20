using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MyProject;

public partial class WindowTovar : Window
{
    public WindowTovar()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}