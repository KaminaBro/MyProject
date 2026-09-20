using Avalonia.Controls;
using MyProject.ViewModels;
using System;

namespace MyProject.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContextChanged += DetailsWindow_DataContextChanged;
    }
    private void DetailsWindow_DataContextChanged(object? sender, EventArgs e)
    {
        if (DataContext is MainViewModel vm)
        {
            vm.CloseRequest+= result =>
            {
                // Закрываем окно и возвращаем результат в ShowDialog
                Close(result);
            };
        }
    }
}