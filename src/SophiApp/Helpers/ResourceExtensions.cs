// <copyright file="ResourceExtensions.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using Microsoft.Windows.ApplicationModel.Resources;

namespace SophiApp.Helpers;

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