// <copyright file="LocalSettingsOptions.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

namespace SophiApp.Models;

public class LocalSettingsOptions
{
    public string? ApplicationDataFolder
    {
        get; set;
    }

    public string? LocalSettingsFile
    {
        get; set;
    }
}