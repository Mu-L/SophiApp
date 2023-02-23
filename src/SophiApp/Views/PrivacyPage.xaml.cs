// <copyright file="PrivacyPage.xaml.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using Microsoft.UI.Xaml.Controls;
using SophiApp.ViewModels;

namespace SophiApp.Views;

public sealed partial class PrivacyPage : Page
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PrivacyPage"/> class.
    /// </summary>
    public PrivacyPage()
    {
        ViewModel = App.GetService<PrivacyViewModel>();
        InitializeComponent();
    }

    public PrivacyViewModel ViewModel
    {
        get;
    }
}
