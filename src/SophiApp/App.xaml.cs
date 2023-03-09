// <copyright file="App.xaml.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using SophiApp.Contracts.Services;
using SophiApp.Models;
using SophiApp.Services;
using SophiApp.ViewModels;
using SophiApp.Views;

namespace SophiApp;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.

/// <summary>
/// <inheritdoc/>
/// </summary>
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging

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
                services.AddSingleton<IActivationService, ActivationService>();
                services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
                services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
                services.AddSingleton<IFileService, FileService>();

                // Views and ViewModels
                services.AddTransient<ShellPage>();
                services.AddTransient<ShellViewModel>();

                // Configuration
                services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
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
    /// Get <see cref="IHost"/> servise.
    /// </summary>
    /// <typeparam name="T">service type.</typeparam>
    public static T GetService<T>()
        where T : class
    {
        if ((Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    /// <inheritdoc/>
    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        // TODO: Launch single app instance.
        //// Get the activation args
        // var appArgs = AppInstance.GetCurrent().GetActivatedEventArgs();

        //// Get or register the main instance
        // var mainInstance = AppInstance.FindOrRegisterForKey("SophiApp");

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
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }
}