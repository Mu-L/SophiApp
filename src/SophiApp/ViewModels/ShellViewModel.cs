// <copyright file="ShellViewModel.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using SophiApp.Contracts.Services;
using SophiApp.Helpers;

/// <summary>
/// Shell view model.
/// </summary>
public class ShellViewModel : ObservableRecipient
{
    private readonly IAppService _appService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
    /// </summary>
    public ShellViewModel(IAppService appService)
    {
        _appService = appService;
    }

    /// <summary>
    /// Gets app name and version.
    /// </summary>
    public string FullName => _appService.FullName;

    /// <summary>
    /// Gets localized string.
    /// </summary>
    public string LocalizedPrivacy => "Privacy".GetLocalized();
}