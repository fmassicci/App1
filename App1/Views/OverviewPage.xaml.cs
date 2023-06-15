using App1.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml.Controls;
using System;

namespace App1.Views;
public sealed partial class OverviewPage : Page
{
    public OverviewViewModel ViewModel { get; }
    public OverviewPage()
    {
        this.InitializeComponent();
        ViewModel = Ioc.Default.GetService<OverviewViewModel>();
    }

    private void DataGrid_Sorting(object sender, DataGridColumnEventArgs e)
    {
        throw new NotImplementedException();
    }
}
