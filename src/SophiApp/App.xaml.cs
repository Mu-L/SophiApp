// <copyright file="App.xaml.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp;

using CSharpFunctionalExtensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using SophiApp.Contracts.Services;
using SophiApp.Models;
using SophiApp.Services;
using SophiApp.ViewModels;
using SophiApp.Views;

/// <summary>
/// <inheritdoc/>
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .UseContentRoot(AppContext.BaseDirectory)
            .ConfigureServices((context, services) =>
            {
                // Services
                _ = services.AddSingleton<IActivationService, ActivationService>();
                _ = services.AddSingleton<IAppService, AppService>();
                _ = services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
                _ = services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
                _ = services.AddSingleton<IFileService, FileService>();

                // Views and ViewModels
                _ = services.AddTransient<ShellPage>();
                _ = services.AddSingleton<ShellViewModel>();

                // Configuration
                _ = services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
            })
            .Build();

        UnhandledException += App_UnhandledException;
    }

    /// <summary>
    /// Gets MainWindow.
    /// </summary>
    public static WindowEx MainWindow { get; } = new MainWindow();

    /// <summary>
    /// Gets <see cref="IHost"/>.
    /// </summary>
    public IHost Host
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
        return (Current as App)!.Host.Services.GetService(typeof(T)) is not T service
            ? throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.")
            : service;
    }

    /// <inheritdoc/>
    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        // TODO: Launch single app instance.
        //// Get the activation args
        // var appArgs = AppInstance.GetCurrent().GetActivatedEventArgs();

        //// Get or register the main instance
        // var mainInstance = AppInstance.FindOrRegisterForKey("2e340960-5e58-4e2d-b0c1-0a1b54145345");

        //// If the main instance isn't this current instance
        // if (!mainInstance.IsCurrent)
        // {
        //    // Redirect activation to that instance
        //    await mainInstance.RedirectActivationToAsync(appArgs);

        // // And exit our instance and stop
        //    Current.Exit();
        //    return;
        // }

        await GetService<IActivationService>().ActivateAsync(args);

        // Initialize and run ShellViewModel
        _ = await GetService<ShellViewModel>()
            .BuildViewModelCommands()
            .Bind(vm => vm.RunOsComplianceReview())
            .Bind(vm => vm.UpdateCheck());
    }

    private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }
}