// <copyright file="ILocalSettingsService.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Contracts.Services;

/// <summary>
/// App settings service.
/// </summary>
public interface ILocalSettingsService
{
    /// <summary>
    /// Read setting.
    /// </summary>
    /// <typeparam name="T">setting type.</typeparam>
    /// <param name="key">read key.</param>
    Task<T?> ReadSettingAsync<T>(string key);

    /// <summary>
    /// Save setting.
    /// </summary>
    /// <typeparam name="T">setting type.</typeparam>
    /// <param name="key">Saved key.</param>
    /// <param name="value">Saved value.</param>
    Task SaveSettingAsync<T>(string key, T value);
}