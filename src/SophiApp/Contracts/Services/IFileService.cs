namespace SophiApp.Contracts.Services
{
    /// <summary>
    /// Performs file operations in app.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Reads from file.
        /// </summary>
        /// <typeparam name="T"><typeparamref name="T"/>.</typeparam>
        /// <param name="folderPath">path to folder.</param>
        /// <param name="fileName">file name.</param>
        T? Read<T>(string folderPath, string fileName);

        /// <summary>
        /// Save to file.
        /// </summary>
        /// <typeparam name="T"><typeparamref name="T"/>.</typeparam>
        /// <param name="folderPath">path to folder.</param>
        /// <param name="fileName">file name.</param>
        /// <param name="content">content to save.</param>
        void Save<T>(string folderPath, string fileName, T content);

        /// <summary>
        /// Delete file.
        /// </summary>
        /// <param name="folderPath">path to folder.</param>
        /// <param name="fileName">deletable file.</param>
        void Delete(string folderPath, string fileName);
    }
}