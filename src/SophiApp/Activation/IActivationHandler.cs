// <copyright file="IActivationHandler.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

namespace SophiApp.Activation;

public interface IActivationHandler
{
    bool CanHandle(object args);

    Task HandleAsync(object args);
}