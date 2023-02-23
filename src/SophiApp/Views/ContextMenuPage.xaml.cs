// <copyright file="ContextMenuPage.xaml.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using Microsoft.UI.Xaml.Controls;
using SophiApp.ViewModels;

namespace SophiApp.Views;

public sealed partial class ContextMenuPage : Page
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContextMenuPage"/> class.
    /// </summary>
    public ContextMenuPage()
    {
        ViewModel = App.GetService<ContextMenuViewModel>();
        InitializeComponent();
    }

    public ContextMenuViewModel ViewModel
    {
        get;
    }
}
