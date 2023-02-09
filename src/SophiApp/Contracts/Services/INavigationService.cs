namespace SophiApp.Contracts.Services;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

/// <summary>
/// Performs navigation service in app.
/// </summary>
public interface INavigationService
{
    /// <summary>
    /// Navigated event
    /// </summary>
    event NavigatedEventHandler Navigated;

    /// <summary>
    /// Gets a value indicating whether gets go back.
    /// </summary>
    bool CanGoBack
    {
        get;
    }

    /// <summary>
    /// Gets or sets <see cref="Frame"/>.
    /// </summary>
    Frame? Frame
    {
        get; set;
    }

    /// <summary>
    /// Go to back state.
    /// </summary>
    bool GoBack();

    /// <summary>
    /// Performs navigate to page.
    /// </summary>
    /// <param name="pageKey">page key.</param>
    /// <param name="parameter">page parameter.</param>
    /// <param name="clearNavigation">allow clean navigation history.</param>
    bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false);

    /// <summary>
    /// Sets list item animation.
    /// </summary>
    /// <param name="item">list item.</param>
    void SetListDataItemForNextConnectedAnimation(object item);
}