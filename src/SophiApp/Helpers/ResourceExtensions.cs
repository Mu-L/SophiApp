// <copyright file="ResourceExtensions.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Helpers;

using Microsoft.Windows.ApplicationModel.Resources;

/// <summary>
/// Extensions for apps resources.
/// </summary>
public static class ResourceExtensions
{
    private static readonly ResourceLoader ResourceLoader = new();

    /// <summary>
    /// Gets localized string from resource.
    /// </summary>
    /// <param name="resourceKey">resource key.</param>
    public static string GetLocalized(this string resourceKey) => ResourceLoader.GetString(resourceKey);
}