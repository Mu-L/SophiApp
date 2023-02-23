using Microsoft.UI.Xaml;

using SophiApp.Contracts.Services;
using SophiApp.ViewModels;

namespace SophiApp.Activation;

public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly INavigationService navigationService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultActivationHandler"/> class.
    /// </summary>
    /// <param name="navigationService"><see cref="INavigationService"/>.</param>
    public DefaultActivationHandler(INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    /// <inheritdoc/>
    protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
    {
        // TODO: None of the ActivationHandlers has handled the activation.
        return navigationService.Frame?.Content == null;
    }

    /// <inheritdoc/>
    protected async override Task HandleInternalAsync(LaunchActivatedEventArgs args)
    {
        navigationService.NavigateTo(typeof(PrivacyViewModel).FullName!, args.Arguments);
        await Task.CompletedTask;
    }
}
