namespace SophiApp
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.UI.Xaml;
    using SophiApp.Contracts.Services;
    using SophiApp.Models;
    using SophiApp.Services;
    using SophiApp.ViewModels;
    using SophiApp.Views;
    using System;
    using WinUIEx;
    using LaunchActivatedEventArgs = Microsoft.UI.Xaml.LaunchActivatedEventArgs;

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Host = Microsoft.Extensions.Hosting.Host.
                CreateDefaultBuilder().
                UseContentRoot(AppContext.BaseDirectory).
                ConfigureServices((context, services) =>
                {
                    // Default Activation Handler
                    // services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

                    // Other Activation Handlers
                    // services.AddTransient<IActivationHandler, AppNotificationActivationHandler>();

                    // Services
                    // services.AddSingleton<IAppNotificationService, AppNotificationService>();
                    services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
                    services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
                    services.AddTransient<INavigationViewService, NavigationViewService>();
                    services.AddSingleton<IActivationService, ActivationService>();
                    services.AddSingleton<IPageService, PageService>();
                    services.AddSingleton<INavigationService, NavigationService>();
                    // services.AddSingleton<ISampleDataService, SampleDataService>();
                    services.AddSingleton<IFileService, FileService>();

                    // Views and ViewModels
                    services.AddTransient<SettingsPage>();
                    services.AddTransient<SettingsViewModel>();
                    // services.AddTransient<ContentGridDetailViewModel>();
                    // services.AddTransient<ContentGridDetailPage>();
                    // services.AddTransient<ContentGridViewModel>();
                    // services.AddTransient<ContentGridPage>();
                    // services.AddTransient<BlankViewModel>();
                    // services.AddTransient<BlankPage>();
                    // services.AddTransient<MainViewModel>();
                    // services.AddTransient<MainPage>();
                    services.AddTransient<NavigationPage>();
                    services.AddTransient<NavigationViewModel>();

                    // Configuration
                    services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
                })
                .Build();

            UnhandledException += App_UnhandledException;
        }

        /// <summary>
        /// Gets or sets <see cref="MainWindow"/>.
        /// </summary>
        public static WindowEx MainWindow { get; set; } = new MainWindow();

        // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging

        /// <summary>
        /// Gets <see cref="IHost"/>.
        /// </summary>
        public IHost? Host
        {
            get;
        }

        /// <summary>
        /// Get <see cref="IHost"/> service.
        /// </summary>
        /// <typeparam name="T">service type.</typeparam>
        public static T GetService<T>()
        where T : class
        {
            if ((Current as App)?.Host?.Services.GetService(typeof(T)) is not T service)
            {
                throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
            }

            return service;
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            await App.GetService<IActivationService>().ActivateAsync(args);
        }

        private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            // TODO: Log and handle exceptions as appropriate.
            // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
        }
    }
}