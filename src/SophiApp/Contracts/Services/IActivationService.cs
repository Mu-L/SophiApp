// <copyright file="IActivationService.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

namespace SophiApp.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}