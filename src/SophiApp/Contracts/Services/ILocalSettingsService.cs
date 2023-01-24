namespace SophiApp.Contracts.Services
{
    using System.Threading.Tasks;

    /// <summary>
    /// Save or read settings.
    /// </summary>
    public interface ILocalSettingsService
    {
        /// <summary>
        /// Performs read setting.
        /// </summary>
        /// <typeparam name="T"><typeparamref name="T"/>.</typeparam>
        /// <param name="key">setting key.</param>
        Task<T?> ReadSettingAsync<T>(string key);

        /// <summary>
        /// Performs save setting.
        /// </summary>
        /// <typeparam name="T"><typeparamref name="T"/>.</typeparam>
        /// <param name="key">setting key.</param>
        /// <param name="value">value to save.</param>
        Task SaveSettingAsync<T>(string key, T value);
    }
}