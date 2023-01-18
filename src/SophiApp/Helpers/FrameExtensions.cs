namespace SophiApp.Helpers;

using Microsoft.UI.Xaml.Controls;

/// <summary>
/// <see cref="Frame"/> class extension.
/// </summary>
public static class FrameExtensions
{
    /// <summary>
    /// Returns the value of the ViewModel property from <see cref="Frame"/>.
    /// </summary>
    /// <param name="frame"><see cref="Frame"/>.</param>
    public static object? GetPageViewModel(this Frame frame)
        => frame?.Content?.GetType().GetProperty("ViewModel")?.GetValue(frame.Content, null);
}
