// <copyright file="IActivationService.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Contracts.Services;

/// <summary>
/// App activation service.
/// </summary>
public interface IActivationService
{
    /// <summary>
    /// Activate tasks.
    /// </summary>
    /// <param name="activationArgs">Activate args</param>
    Task ActivateAsync(object activationArgs);
}