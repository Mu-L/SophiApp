namespace SophiApp.Contracts.Services
{
    using System;
    using System.Collections.Generic;
    using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Performs navigation for view in app.
    /// </summary>
    public interface INavigationViewService
    {
        /// <summary>
        /// Gets menu items.
        /// </summary>
        IList<object>? MenuItems
        {
            get;
        }

        /// <summary>
        /// Gets settings.
        /// </summary>
        object? SettingsItem
        {
            get;
        }

        /// <summary>
        /// Get selected item.
        /// </summary>
        /// <param name="pageType">type of page.</param>
        NavigationViewItem? GetSelectedItem(Type pageType);

        /// <summary>
        /// Initialize navigation view service.
        /// </summary>
        /// <param name="navigationView"><see cref="NavigationView"/>.</param>
        void Initialize(NavigationView navigationView);

        /// <summary>
        /// Unregister events.
        /// </summary>
        void UnregisterEvents();
    }
}