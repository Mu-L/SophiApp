using Microsoft.UI.Xaml;
using SophiApp.Contracts.Services;
using SophiApp.Helpers;
using System;
using System.Threading.Tasks;

namespace SophiApp.Services
{
    /// <inheritdoc/>
    public class ThemeSelectorService : IThemeSelectorService
    {
        private const string SettingsKey = "AppBackgroundRequestedTheme";
        private readonly ILocalSettingsService localSettingsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeSelectorService"/> class.
        /// </summary>
        /// <param name="localSettingsService"><see cref="ILocalSettingsService"/>.</param>
        public ThemeSelectorService(ILocalSettingsService localSettingsService)
        {
            this.localSettingsService = localSettingsService;
        }

        /// <inheritdoc/>
        public ElementTheme Theme { get; set; } = ElementTheme.Default;

        /// <inheritdoc/>
        public async Task InitializeAsync()
        {
            Theme = await LoadThemeFromSettingsAsync();
            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        public async Task SetThemeAsync(ElementTheme theme)
        {
            Theme = theme;
            await SetRequestedThemeAsync();
            await SaveThemeInSettingsAsync(Theme);
        }

        /// <inheritdoc/>
        public async Task SetRequestedThemeAsync()
        {
            if (App.MainWindow.Content is FrameworkElement rootElement)
            {
                rootElement.RequestedTheme = Theme;
                TitleBarHelper.UpdateTitleBar(Theme);
            }

            await Task.CompletedTask;
        }

        private async Task<ElementTheme> LoadThemeFromSettingsAsync()
        {
            var themeName = await localSettingsService.ReadSettingAsync<string>(SettingsKey);

            if (Enum.TryParse(themeName, out ElementTheme cacheTheme))
            {
                return cacheTheme;
            }

            return ElementTheme.Default;
        }

        private async Task SaveThemeInSettingsAsync(ElementTheme theme)
        {
            await localSettingsService.SaveSettingAsync(SettingsKey, theme.ToString());
        }
    }
}