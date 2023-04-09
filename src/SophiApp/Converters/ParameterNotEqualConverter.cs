// <copyright file="ParameterNotEqualConverter.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Converters;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

/// <summary>
/// Returns the inverted result of a comparison of a parameter and value.
/// </summary>
public class ParameterNotEqualConverter : IValueConverter
{
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, string language)
        => parameter.ToString() != value.ToString();

    /// <inheritdoc/>
    public object ConvertBack(object value, Type targetType, object parameter, string language)
        => DependencyProperty.UnsetValue;
}