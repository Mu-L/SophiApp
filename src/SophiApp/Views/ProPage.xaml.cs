// <copyright file="ProPage.xaml.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using Microsoft.UI.Xaml.Controls;
using SophiApp.ViewModels;

namespace SophiApp.Views;

public sealed partial class ProPage : Page
{
    public ProPage()
    {
        ViewModel = App.GetService<ProViewModel>();
        InitializeComponent();
    }

    public ProViewModel ViewModel
    {
        get;
    }
}
