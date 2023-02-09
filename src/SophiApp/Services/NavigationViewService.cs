namespace SophiApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Microsoft.UI.Xaml.Controls;
    using SophiApp.Contracts.Services;
    using SophiApp.Helpers;
    using SophiApp.ViewModels;

    /// <inheritdoc/>
    public class NavigationViewService : INavigationViewService
    {
        private readonly INavigationService navigationService;

        private readonly IPageService pageService;

        private NavigationView? navigationView;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationViewService"/> class.
        /// </summary>
        /// <param name="navigationService"><see cref="INavigationService"/>.</param>
        /// <param name="pageService"><see cref="IPageService"/>.</param>
        public NavigationViewService(INavigationService navigationService, IPageService pageService)
        {
            this.navigationService = navigationService;
            this.pageService = pageService;
        }

        /// <inheritdoc/>
        public IList<object>? MenuItems => navigationView?.MenuItems;

        /// <inheritdoc/>
        public object? SettingsItem => navigationView?.SettingsItem;

        /// <inheritdoc/>
        public NavigationViewItem? GetSelectedItem(Type pageType)
        {
            if (navigationView != null)
            {
                return GetSelectedItem(navigationView.MenuItems, pageType) ?? GetSelectedItem(navigationView.FooterMenuItems, pageType);
            }

            return null;
        }

        /// <inheritdoc/>
        [MemberNotNull(nameof(NavigationViewService.navigationView))]
        public void Initialize(NavigationView navigationView)
        {
            this.navigationView = navigationView;
            this.navigationView.BackRequested += OnBackRequested;
            this.navigationView.ItemInvoked += OnItemInvoked;
        }

        /// <inheritdoc/>
        public void UnregisterEvents()
        {
            if (navigationView != null)
            {
                navigationView.BackRequested -= OnBackRequested;
                navigationView.ItemInvoked -= OnItemInvoked;
            }
        }

        private NavigationViewItem? GetSelectedItem(IEnumerable<object> menuItems, Type pageType)
        {
            foreach (var item in menuItems.OfType<NavigationViewItem>())
            {
                if (IsMenuItemForPageType(item, pageType))
                {
                    return item;
                }

                var selectedChild = GetSelectedItem(item.MenuItems, pageType);
                if (selectedChild != null)
                {
                    return selectedChild;
                }
            }

            return null;
        }

        private bool IsMenuItemForPageType(NavigationViewItem menuItem, Type sourcePageType)
        {
            if (menuItem.GetValue(NavigationHelper.NavigateToProperty) is string pageKey)
            {
                return pageService.GetPageType(pageKey) == sourcePageType;
            }

            return false;
        }

        private void OnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args) => navigationService.GoBack();

        private void OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                navigationService.NavigateTo(typeof(SettingsViewModel).FullName!);
            }
            else
            {
                var selectedItem = args.InvokedItemContainer as NavigationViewItem;

                if (selectedItem?.GetValue(NavigationHelper.NavigateToProperty) is string pageKey)
                {
                    navigationService.NavigateTo(pageKey);
                }
            }
        }
    }
}