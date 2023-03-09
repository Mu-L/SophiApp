// <copyright file="IThemeSelectorService.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using Microsoft.UI.Xaml;

namespace SophiApp.Contracts.Services;

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