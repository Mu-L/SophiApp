namespace SophiApp.Contracts.ViewModels
{
    /// <summary>
    /// Performs navigation aware in app.
    /// </summary>
    public interface INavigationAware
    {
        /// <summary>
        /// Executes the navigation from.
        /// </summary>
        void OnNavigatedFrom();

        /// <summary>
        /// Executes the navigation to.
        /// </summary>
        /// <param name="parameter">Navigated to parameter.</param>
        void OnNavigatedTo(object parameter);
    }
}