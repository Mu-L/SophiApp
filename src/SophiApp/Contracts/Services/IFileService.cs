// <copyright file="IFileService.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Contracts.Services;

/// <summary>
/// Service for working with files.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Delete file.
    /// </summary>
    /// <param name="folderPath">path to file folder.</param>
    /// <param name="fileName">file name.</param>
    void Delete(string folderPath, string fileName);

    /// <summary>
    /// Read file.
    /// </summary>
    /// <typeparam name="T">returns type.</typeparam>
    /// <param name="folderPath">path to file folder.</param>
    /// <param name="fileName">file name.</param>
    T Read<T>(string folderPath, string fileName);

    /// <summary>
    /// Save file.
    /// </summary>
    /// <typeparam name="T">saved file type.</typeparam>
    /// <param name="folderPath">path to file folder.</param>
    /// <param name="fileName">file name.</param>
    /// <param name="content">content file.</param>
    void Save<T>(string folderPath, string fileName, T content);
}