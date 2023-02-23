// <copyright file="UwpPage.xaml.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using Microsoft.UI.Xaml.Controls;
using SophiApp.ViewModels;

namespace SophiApp.Views;

/// <summary>
/// <inheritdoc/>
/// </summary>
public sealed partial class UwpPage : Page
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UwpPage"/> class.
    /// </summary>
    public UwpPage()
    {
        ViewModel = App.GetService<UwpViewModel>();
        InitializeComponent();
    }

    /// <summary>
    /// Gets <see cref="UwpViewModel"/>.
    /// </summary>
    public UwpViewModel ViewModel
    {
        get;
    }
}
