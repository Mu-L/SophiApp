// <copyright file="IAppService.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Contracts.Services;

/// <summary>
/// App data service
/// </summary>
public interface IAppService
{
    /// <summary>
    /// Gets app name and version.
    /// </summary>
    public string FullName { get; }

    /// <summary>
    /// Gets app name without version.
    /// </summary>
    public string Name { get; }
}