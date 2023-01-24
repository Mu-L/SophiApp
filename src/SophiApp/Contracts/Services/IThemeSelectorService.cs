namespace SophiApp.Contracts.Services
{
    using Microsoft.UI.Xaml;
    using System.Threading.Tasks;

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
        /// Sets app theme.
        /// </summary>
        /// <param name="theme"><see cref="ElementTheme"/></param>
        Task SetThemeAsync(ElementTheme theme);

        /// <summary>
        /// Sets requested app theme.
        /// </summary>
        Task SetRequestedThemeAsync();
    }
}