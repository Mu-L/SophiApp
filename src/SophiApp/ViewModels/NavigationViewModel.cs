namespace SophiApp.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Navigation;
using SophiApp.Contracts.Services;
using SophiApp.Views;

/// <inheritdoc/>
public class NavigationViewModel : ObservableRecipient
{
    private bool isBackEnabled;
    private object? selected;

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationViewModel"/> class.
    /// </summary>
    /// <param name="navigationService"><see cref="INavigationService"/>.</param>
    /// <param name="navigationViewService"><see cref="INavigationViewService"/>.</param>
    public NavigationViewModel(INavigationService navigationService, INavigationViewService navigationViewService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
    }

    /// <summary>
    /// Gets <see cref="INavigationService"/>.
    /// </summary>
    public INavigationService NavigationService
    {
        get;
    }

    /// <summary>
    /// Gets <see cref="INavigationViewService"/>.
    /// </summary>
    public INavigationViewService NavigationViewService
    {
        get;
    }

    /// <summary>
    /// Gets or sets a value indicating whether get or set back property.
    /// </summary>
    public bool IsBackEnabled
    {
        get => isBackEnabled;
        set => SetProperty(ref isBackEnabled, value);
    }

    /// <summary>
    /// Gets or sets selected value.
    /// </summary>
    public object? Selected
    {
        get => selected;
        set => SetProperty(ref selected, value);
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        IsBackEnabled = NavigationService.CanGoBack;

        if (e.SourcePageType == typeof(SettingsPage))
        {
            Selected = NavigationViewService.SettingsItem;
            return;
        }

        var selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
        if (selectedItem != null)
        {
            Selected = selectedItem;
        }
    }
}