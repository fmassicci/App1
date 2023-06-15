using App1.Contracts;
using App1.Data;
using App1.Services;
using App1.ViewModels;
using App1.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace App1
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            var serviceProvider = ConfigureServices();
            Ioc.Default.ConfigureServices(serviceProvider);
            this.InitializeComponent();
        }

        /// <summary>
        /// Configures the current <see cref="App"/> instance in use.
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        /// <returns></returns>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .AddUserSecrets<App>(optional: true)
                .Build();

            services.AddDbContext<EmployeeContext>(options => options.UseInMemoryDatabase("employees"));
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IDataService, EFDataService>();
            services.AddTransient<IDialogService, DialogService>();
            services.AddTransient<OverviewViewModel>();
            services.AddTransient<DetailsViewModel>();
            return services.BuildServiceProvider();
        }

        public static Window MainWindow { get; } = new Window() { Title = "MainWindow" };

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            var shellFrame = new Frame
            {
                Content = new MainPage()
            };

            MainWindow.Content = shellFrame;
            MainWindow.Activate();
        }
    }
}
