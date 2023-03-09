// <copyright file="MainWindow.xaml.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using SophiApp.Helpers;

namespace SophiApp;

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