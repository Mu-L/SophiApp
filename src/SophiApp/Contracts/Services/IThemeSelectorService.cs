// <copyright file="IThemeSelectorService.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Contracts.Services;

using Microsoft.UI.Xaml;

/// <summary>
/// Theme selection service.
/// </summary>
public interface IThemeSelectorService
{
    /// <summary>
    /// Gets <see cref="ElementTheme"/>.
    /// </summary>
    ElementTheme Theme
    {
        get;
    }

    /// <summary>
    /// Service initialization.
    /// </summary>
    Task InitializeAsync();

    /// <summary>
    /// Set app requested theme.
    /// </summary>
    Task SetRequestedThemeAsync();

    /// <summary>
    /// Set app theme.
    /// </summary>
    /// <param name="theme"><see cref="ElementTheme"/>.</param>
    Task SetThemeAsync(ElementTheme theme);
}