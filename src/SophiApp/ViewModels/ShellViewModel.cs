// <copyright file="ShellViewModel.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSharpFunctionalExtensions;
using SophiApp.Contracts.Services;
using SophiApp.Helpers;
using SophiApp.UIControls;
using System.Threading.Tasks;

/// <summary>
/// Shell view model.
/// </summary>
public class ShellViewModel : ObservableRecipient
{
    private readonly IAppService appService;
    private PageTag activePage = PageTag.Busy;
    private double busyPageProgressBarValue;
    private string busyPageText = "BusyPageReadCurrentSettings".GetLocalized();

    /// <summary>
    /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
    /// </summary>
    public ShellViewModel(IAppService appService)
    {
        this.appService = appService;
    }

    /// <summary>
    /// The page that is currently visible.
    /// </summary>
    public PageTag ActivePage
    {
        get => activePage;
        private set => SetProperty(ref activePage, value);
    }

    /// <summary>
    /// Filling the <see cref="BusyPage"/> progress bar.
    /// Progress bar minimum value 0.0, maximum value 1.0
    /// </summary>
    public double BusyPageProgressBarValue
    {
        get => busyPageProgressBarValue;
        private set => SetProperty(ref busyPageProgressBarValue, value);
    }

    /// <summary>
    /// Text for <see cref="BusyPage"/>
    /// </summary>
    public string BusyPageText
    {
        get => busyPageText;
        private set => SetProperty(ref busyPageText, value);
    }

    /// <summary>
    /// Gets app name and version.
    /// </summary>
    public string FullName => appService.FullName;

    /// <summary>
    /// Invoke HamburgerButton pressed command.
    /// </summary>
    public RelayCommand<PageTag>? HamburgerButtonPressed { get; private set; }

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

    /// <summary>
    /// Create and set <see cref="RelayCommand"/> to view model.
    /// </summary>
    public async Task<Result<ShellViewModel>> BuildViewModelCommands()
    {
        return await Task.Run(() =>
        {
            HamburgerButtonPressed = new RelayCommand<PageTag>(tag => ActivePage = tag);
            BusyPageProgressBarValue = 0.2;
            return Result.Success(this);
        });
    }

    /// <summary>
    /// Checks that the application can be run on this operating system.
    /// </summary>
    public Result<ShellViewModel> RunOsComplianceReview()
    {
        //TODO: Not implemented!
        _ = Task.Delay(4000);
        BusyPageProgressBarValue = 0.4;
        return Result.Success(this);
    }

    /// <summary>
    /// Check for updates.
    /// </summary>
    public Result<ShellViewModel> UpdateCheck()
    {
        //TODO: Not implemented!
        _ = Task.Delay(4000);
        BusyPageProgressBarValue = 0.6;
        return Result.Success(this);
    }
}