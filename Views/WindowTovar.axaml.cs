using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MyProject.ViewModels;
using System;

namespace MyProject;

public partial class WindowTovar : Window
{
    public WindowTovar()
    {
        InitializeComponent();
        DataContext=new TovarViewModel();
        DataContextChanged += DetailsWindow_DataContextChanged;
    }
    private void DetailsWindow_DataContextChanged(object? sender, EventArgs e)
    {
        if (DataContext is TovarViewModel vm)
        {
            vm.CloseRequest += result =>
            {
                // Закрываем окно и возвращаем результат в ShowDialog
                Close(result);
            };
        }
    }

}