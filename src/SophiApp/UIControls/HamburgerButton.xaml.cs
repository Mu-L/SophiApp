// <copyright file="HamburgerButton.xaml.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.UIControls;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

public sealed partial class HamburgerButton : UserControl
{
    /// <summary>
    /// <see cref="Icon"/>
    /// </summary>
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(object), typeof(HamburgerButton), new PropertyMetadata(default));

    /// <summary>
    /// <see cref="Text"/>
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(HamburgerButton), new PropertyMetadata(default));

    public HamburgerButton()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gets or sets icon in HamburgerButton.
    /// </summary>
    public object Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    /// <summary>
    /// Gets or sets text in <see cref="HamburgerButton"/>.
    /// </summary>
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}