// <copyright file="ShellPage.xaml.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Views;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using SophiApp.ViewModels;

/// <summary>
/// <inheritdoc/>
/// </summary>
public sealed partial class ShellPage : Page
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ShellPage"/> class.
    /// </summary>
    /// <param name="viewModel"><see cref="ShellViewModel"/>.</param>
    public ShellPage(ShellViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
        App.MainWindow.ExtendsContentIntoTitleBar = true;
        App.MainWindow.SetTitleBar(AppTitleBar);
        App.MainWindow.Activated += MainWindow_Activated;
    }

    /// <summary>
    /// Gets <see cref="ShellViewModel"/>.
    /// </summary>
    public ShellViewModel ViewModel
    {
        get;
    }

    private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
    {
        var resource = args.WindowActivationState == WindowActivationState.Deactivated ? "WindowCaptionForegroundDisabled" : "WindowCaptionForeground";
        AppTitleBarText.Foreground = Application.Current.Resources[resource] as SolidColorBrush;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
    }
}