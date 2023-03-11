// <copyright file="ThemeSelectorService.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Services;

using Microsoft.UI.Xaml;
using SophiApp.Contracts.Services;

/// <summary>
/// <inheritdoc/>
/// </summary>
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

    /// <summary>
    /// Specifies a UI theme that should be used for individual UIElement parts of an app UI.
    /// </summary>
    public ElementTheme Theme { get; set; } = ElementTheme.Default;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task InitializeAsync()
    {
        Theme = await LoadThemeFromSettingsAsync();
        await Task.CompletedTask;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task SetRequestedThemeAsync()
    {
        if (App.MainWindow.Content is FrameworkElement rootElement)
            rootElement.RequestedTheme = Theme;

        await Task.CompletedTask;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="theme"></param>
    public async Task SetThemeAsync(ElementTheme theme)
    {
        Theme = theme;
        await SetRequestedThemeAsync();
        await SaveThemeInSettingsAsync(Theme);
    }

    private async Task<ElementTheme> LoadThemeFromSettingsAsync()
    {
        var themeName = await localSettingsService.ReadSettingAsync<string>(SettingsKey);
        return Enum.TryParse(themeName, out ElementTheme cacheTheme) ? cacheTheme : ElementTheme.Default;
    }

    private async Task SaveThemeInSettingsAsync(ElementTheme theme) => await localSettingsService.SaveSettingAsync(SettingsKey, theme.ToString());
}