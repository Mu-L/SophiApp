// <copyright file="LoadingPage.xaml.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.UIControls;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

/// <summary>
/// Busy page control.
/// </summary>
public sealed partial class BusyPage : UserControl
{
    /// <summary>
    /// <see cref="ProgressBarValue"/>
    /// </summary>
    public static readonly DependencyProperty ProgressBarValueProperty =
        DependencyProperty.Register("ProgressBarValue", typeof(double), typeof(BusyPage), new PropertyMetadata(default));

    /// <summary>
    /// <see cref="Text"/>
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(BusyPage), new PropertyMetadata(default));

    /// <summary>
    /// Initializes a new instance of the <see cref="BusyPage"/> class.
    /// </summary>
    public BusyPage() => InitializeComponent();

    /// <summary>
    /// Busy page progress bar value.
    /// </summary>
    public double ProgressBarValue
    {
        get => (double)GetValue(ProgressBarValueProperty);
        set => SetValue(ProgressBarValueProperty, value);
    }

    /// <summary>
    /// Busy page text.
    /// </summary>
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}