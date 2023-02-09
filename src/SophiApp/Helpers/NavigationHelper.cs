namespace SophiApp.Helpers;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

/// <summary>
/// Helper class to set the navigation target for a NavigationViewItem.
///
/// Usage in XAML:
/// NavigationViewItem x:Uid="Shell_Main" Icon="Document" helpers:NavigationHelper.NavigateTo="AppName.ViewModels.MainViewModel"
///
/// Usage in code:
/// NavigationHelper.SetNavigateTo(navigationViewItem, typeof(MainViewModel).FullName);.
///
/// </summary>
public class NavigationHelper
{
    /// <summary>
    /// <see cref="DependencyProperty"/> NavigateToProperty.
    /// </summary>
    public static readonly DependencyProperty NavigateToProperty =
        DependencyProperty.RegisterAttached("NavigateTo", typeof(string), typeof(NavigationHelper), new PropertyMetadata(null));

    /// <summary>
    /// Sets the value of the NavigateTo property for the <see cref="NavigationViewItem"/> item.
    /// </summary>
    /// <param name="item"><see cref="NavigationViewItem"/>.</param>
    public static string GetNavigateTo(NavigationViewItem item) => (string)item.GetValue(NavigateToProperty);

    /// <summary>
    /// Gets the value of the NavigateTo property from the item.
    /// </summary>
    /// <param name="item"><see cref="NavigationViewItem"/>.</param>
    /// <param name="value"><see cref="string"/>.</param>
    public static void SetNavigateTo(NavigationViewItem item, string value) => item.SetValue(NavigateToProperty, value);
}