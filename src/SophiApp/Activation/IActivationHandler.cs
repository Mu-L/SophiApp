// <copyright file="IActivationHandler.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Activation;

/// <summary>
/// Application activation handler.
/// </summary>
public interface IActivationHandler
{
    /// <summary>
    /// Handle predicate.
    /// </summary>
    /// <param name="args">Handle args.</param>
    bool CanHandle(object args);

    /// <summary>
    /// Handle activation.
    /// </summary>
    /// <param name="args">Handle args.</param>
    Task HandleAsync(object args);
}