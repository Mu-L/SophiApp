namespace SophiApp.Contracts.Services
{
    using System.Threading.Tasks;
    using Microsoft.UI.Xaml;

    /// <summary>
    /// Performs theme selection service in app.
    /// </summary>
    public interface IThemeSelectorService
    {
        /// <summary>
        /// Gets current app theme.
        /// </summary>
        ElementTheme Theme
        {
            get;
        }

        /// <summary>
        /// Initialize service.
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        /// Sets requested app theme.
        /// </summary>
        Task SetRequestedThemeAsync();

        /// <summary>
        /// Sets app theme.
        /// </summary>
        /// <param name="theme"><see cref="ElementTheme"/>.</param>
        Task SetThemeAsync(ElementTheme theme);
    }
}