namespace SophiApp.Contracts.Services
{
    using System;

    /// <summary>
    /// Performs page servise in app.
    /// </summary>
    public interface IPageService
    {
        /// <summary>
        /// Get page type.
        /// </summary>
        /// <param name="key">page key.</param>
        Type GetPageType(string key);
    }
}