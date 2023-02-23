// <copyright file="SystemPage.xaml.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using Microsoft.UI.Xaml.Controls;
using SophiApp.ViewModels;

namespace SophiApp.Views;

public sealed partial class SystemPage : Page
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SystemPage"/> class.
    /// </summary>
    public SystemPage()
    {
        ViewModel = App.GetService<SystemViewModel>();
        InitializeComponent();
    }

    public SystemViewModel ViewModel
    {
        get;
    }
}
