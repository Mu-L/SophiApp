namespace SophiApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Setting options.
    /// </summary>
    internal class LocalSettingsOptions
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
