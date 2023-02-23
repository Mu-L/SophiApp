// <copyright file="SecurityPage.xaml.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using Microsoft.UI.Xaml.Controls;
using SophiApp.ViewModels;

namespace SophiApp.Views;

public sealed partial class SecurityPage : Page
{
    public SecurityPage()
    {
        ViewModel = App.GetService<SecurityViewModel>();
        InitializeComponent();
    }

    public SecurityViewModel ViewModel
    {
        get;
    }
}
