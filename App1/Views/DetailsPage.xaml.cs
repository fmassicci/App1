using App1.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace App1.Views
{
    public sealed partial class DetailsPage : Page
    {
        public DetailsViewModel ViewModel { get; }
        public DetailsPage()
        {
            this.InitializeComponent();
            ViewModel = Ioc.Default.GetService<DetailsViewModel>();
        }
    }
}
