namespace SophiApp.Helpers;

using Microsoft.Windows.ApplicationModel.Resources;

/// <summary>
/// Resource class extensions.
/// </summary>
public static class ResourceExtensions
{
    private static readonly ResourceLoader ResourceLoader = new();

    /// <summary>
    /// Returns the value of the resource by the key.
    /// </summary>
    /// <param name="resourceKey">Resource key name.</param>
    public static string GetLocalized(this string resourceKey) => ResourceLoader.GetString(resourceKey);
}
