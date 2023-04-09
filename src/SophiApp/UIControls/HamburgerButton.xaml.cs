// <copyright file="HamburgerButton.xaml.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.UIControls;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Windows.Input;

/// <summary>
/// Hamburger button control.
/// </summary>
public sealed partial class HamburgerButton : UserControl
{
    /// <summary>
    /// <see cref="Icon"/>
    /// </summary>
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(object), typeof(HamburgerButton), new PropertyMetadata(default));

    /// <summary>
    /// <see cref="MarkerVisibility"/>
    /// </summary>
    public static readonly DependencyProperty MarkerVisibilityProperty =
        DependencyProperty.Register("MarkerVisibility", typeof(Visibility), typeof(HamburgerButton), new PropertyMetadata(Visibility.Collapsed));

    /// <summary>
    /// <see cref="PressedCommand"/>
    /// </summary>
    public static readonly DependencyProperty PressedCommandProperty =
        DependencyProperty.Register("PressedCommand", typeof(ICommand), typeof(HamburgerButton), new PropertyMetadata(default));

    /// <summary>
    /// <see cref="Text"/>
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(HamburgerButton), new PropertyMetadata(default));

    /// <summary>
    /// Initializes a new instance of the <see cref="HamburgerButton"/> class.
    /// </summary>
    public HamburgerButton() => InitializeComponent();

    /// <summary>
    /// Gets or sets icon in HamburgerButton.
    /// </summary>
    public object Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    /// <summary>
    /// Gets or sets HamburgerButton marker visibility.
    /// </summary>
    public Visibility MarkerVisibility
    {
        get => (Visibility)GetValue(MarkerVisibilityProperty);
        set => SetValue(MarkerVisibilityProperty, value);
    }

    /// <summary>
    /// Invoke HamburgerButton pressed command.
    /// </summary>
    public ICommand PressedCommand
    {
        get => (ICommand)GetValue(PressedCommandProperty);
        set => SetValue(PressedCommandProperty, value);
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