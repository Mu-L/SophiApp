namespace SophiApp.Services
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using Microsoft.UI.Xaml.Controls;
    using SophiApp.Contracts.Services;
    using SophiApp.ViewModels;
    using SophiApp.Views;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <inheritdoc/>
    public class PageService : IPageService
    {
        private readonly Dictionary<string, Type> pages = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="PageService"/> class.
        /// </summary>
        public PageService()
        {
            // TODO: Configure this !
            // Configure<MainViewModel, MainPage>();
            // Configure<BlankViewModel, BlankPage>();
            // Configure<ContentGridViewModel, ContentGridPage>();
            // Configure<ContentGridDetailViewModel, ContentGridDetailPage>();
            Configure<SettingsViewModel, SettingsPage>();
        }

        /// <inheritdoc/>
        public Type GetPageType(string key)
        {
            Type? pageType;
            lock (pages)
            {
                if (!pages.TryGetValue(key, out pageType))
                {
                    throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
                }
            }

            return pageType;
        }

        private void Configure<TVM, TV>()
            where TVM : ObservableObject
            where TV : Page
        {
            lock (pages)
            {
                var key = typeof(TVM).FullName!;
                if (pages.ContainsKey(key))
                {
                    throw new ArgumentException($"The key {key} is already configured in PageService");
                }

                var type = typeof(TV);
                if (pages.Any(p => p.Value == type))
                {
                    throw new ArgumentException($"This type is already configured with key {pages.First(p => p.Value == type).Key}");
                }

                pages.Add(key, type);
            }
        }
    }
}