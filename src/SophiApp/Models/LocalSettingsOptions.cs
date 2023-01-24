namespace SophiApp.Models
{
    /// <summary>
    /// Setting options.
    /// </summary>
    public class LocalSettingsOptions
    {
        /// <summary>
        /// Gets or sets App data folder path.
        /// </summary>
        public string? ApplicationDataFolder
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets setting file path.
        /// </summary>
        public string? LocalSettingsFile
        {
            get; set;
        }
    }
}