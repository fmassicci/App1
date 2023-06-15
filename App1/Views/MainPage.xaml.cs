using App1.Contracts;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace App1.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MainMenu_OnLoaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new OverviewPage();
        }

        private void MainMenu_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            if (item == null)
            {
                ContentFrame.Content = new OverviewPage();
                return;
            }
            else if (item == Create)
            {
                var nav = Ioc.Default.GetService<INavigationService>();
                nav.NavigateTo(typeof(DetailsPage));
            }
            else return;
        }
    }
}
