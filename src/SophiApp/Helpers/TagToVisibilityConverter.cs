// <copyright file="TagToVisibilityConverter.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Helpers
{
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Data;
    using System;

    /// <summary>
    /// Converted the visibility of the button marker by the active tag.
    /// </summary>
    public class TagToVisibilityConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, string language)
            => value.ToString() == parameter.ToString() ? Visibility.Visible : Visibility.Collapsed;

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
            => DependencyProperty.UnsetValue;
    }
}