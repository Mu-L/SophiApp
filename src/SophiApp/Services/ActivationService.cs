// <copyright file="ActivationService.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using SophiApp.Activation;
using SophiApp.Contracts.Services;
using SophiApp.Views;

namespace SophiApp.Services;

public class ActivationService : IActivationService
{
    private readonly IEnumerable<IActivationHandler> activationHandlers;
    private readonly IThemeSelectorService themeSelectorService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ActivationService"/> class.
    /// </summary>
    /// <param name="defaultHandler"><see cref="ActivationHandler{T}"/>.</param>
    /// <param name="activationHandlers"><see cref="IActivationHandler"/> collections.</param>
    /// <param name="themeSelectorService"><see cref="IThemeSelectorService"/>.</param>
    public ActivationService(IEnumerable<IActivationHandler> activationHandlers, IThemeSelectorService themeSelectorService)
    {
        this.activationHandlers = activationHandlers;
        this.themeSelectorService = themeSelectorService;
    }

    public async Task ActivateAsync(object activationArgs)
    {
        // Execute tasks before activation.
        await InitializeAsync();

        // Set the MainWindow Content.
        if (App.MainWindow.Content == null)
            App.MainWindow.Content = App.GetService<ShellPage>();

        // Handle activation via ActivationHandlers.
        await HandleActivationAsync(activationArgs);

        // Activate the MainWindow.
        App.MainWindow.Activate();

        // Execute tasks after activation.
        await StartupAsync();
    }

    private async Task HandleActivationAsync(object activationArgs)
    {
        var activationHandler = activationHandlers.FirstOrDefault(h => h.CanHandle(activationArgs));

        if (activationHandler != null)
        {
            await activationHandler.HandleAsync(activationArgs);
        }
    }

    private async Task InitializeAsync()
    {
        await themeSelectorService.InitializeAsync().ConfigureAwait(false);
        await Task.CompletedTask;
    }

    private async Task StartupAsync()
    {
        await themeSelectorService.SetRequestedThemeAsync();
        await Task.CompletedTask;
    }
}