using App1.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace App1.Views;
public sealed partial class EmployeeDetails : UserControl
{
    public DetailsViewModel ViewModel { get; }

    public EmployeeDetails()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetService<DetailsViewModel>();
    }

    #region ViewModel
    //public DetailsViewModel ViewModel
    //{
    //    get { return (DetailsViewModel)GetValue(ViewModelProperty); }
    //    set { SetValue(ViewModelProperty, value); }
    //}

    //public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(DetailsViewModel), typeof(EmployeeDetails), new PropertyMetadata(null));
    #endregion

    public void SetFocus()
    {
        //DetailsViewModel.SetFocus();
    }
}
