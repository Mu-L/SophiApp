// <copyright file="MainWindow.xaml.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp;

using SophiApp.Helpers;

/// <summary>
/// <inheritdoc/>
/// </summary>
public sealed partial class MainWindow : WindowEx
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();

        AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Assets/SophiApp.ico"));
        Content = null;
        Title = "AppDisplayName".GetLocalized();
    }
}