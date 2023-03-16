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
    private PageTag currentlyPage;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
    /// </summary>
    public ShellViewModel(IAppService appService)
    {
        _appService = appService;
    }

    /// <summary>
    /// The page that is currently visible.
    /// </summary>
    public PageTag CurrentlyPage
    {
        get => currentlyPage;
        set => SetProperty(ref currentlyPage, value);
    }

    /// <summary>
    /// Gets app name and version.
    /// </summary>
    public string FullName => _appService.FullName;

    /// <summary>
    /// Gets localized context menu string.
    /// </summary>
    public string LocalizedContextMenu => "ContextMenu".GetLocalized();

    /// <summary>
    /// Gets localized personalization string.
    /// </summary>
    public string LocalizedPersonalization => "Personalization".GetLocalized();

    /// <summary>
    /// Gets localized privacy string.
    /// </summary>
    public string LocalizedPrivacy => "Privacy".GetLocalized();

    /// <summary>
    /// Gets localized pro version string.
    /// </summary>
    public string LocalizedProVersion => "ProVersion".GetLocalized();

    /// <summary>
    /// Gets localized security string.
    /// </summary>
    public string LocalizedSecurity => "Security".GetLocalized();

    /// <summary>
    /// Gets localized settings string.
    /// </summary>
    public string LocalizedSettings => "Settings".GetLocalized();

    /// <summary>
    /// Gets localized system string.
    /// </summary>
    public string LocalizedSystem => "System".GetLocalized();

    /// <summary>
    /// Gets localized task scheduler string.
    /// </summary>
    public string LocalizedTaskScheduler => "TaskScheduler".GetLocalized();

    /// <summary>
    /// Gets localized uwp string.
    /// </summary>
    public string LocalizedUwp => "Uwp".GetLocalized();
}