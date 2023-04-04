// <copyright file="Page.xaml.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.UIControls;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SophiApp.Helpers;

/// <summary>
/// Initializes a new instance of the <see cref="Page"/> class.
/// </summary>
public sealed partial class Page : UserControl
{
    /// <summary>
    /// <see cref="Title"/>
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(Page), new PropertyMetadata(default));

    /// <summary>
    /// <see cref="Tag"/>
    /// </summary>
    public static new readonly DependencyProperty TagProperty =
        DependencyProperty.Register("Tag", typeof(PageTag), typeof(Page), new PropertyMetadata(null));

    /// <summary>
    /// Initializes a new instance of the <see cref="Page"/> class.
    /// </summary>
    public Page() => InitializeComponent();

    /// <summary>
    /// Gets or sets Page title.
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// Gets or sets Page tag.
    /// </summary>
    public new PageTag Tag
    {
        get => (PageTag)GetValue(TagProperty);
        set => SetValue(TagProperty, value);
    }
}
