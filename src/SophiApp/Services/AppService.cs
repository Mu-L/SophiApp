// <copyright file="AppService.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Services;

using SophiApp.Contracts.Services;
using System.Reflection;

/// <summary>
/// <inheritdoc/>
/// </summary>
internal class AppService : IAppService
{
    private readonly AssemblyName _assembly = Assembly.GetExecutingAssembly().GetName();

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string FullName => $"{_assembly.Name} {_assembly.Version!.Major}.{_assembly.Version!.Minor}.{_assembly.Version!.Build} | Community";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string Name => _assembly.Name!;
}