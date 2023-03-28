// <copyright file="Json.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Helpers;

using Newtonsoft.Json;

/// <summary>
/// Json operations helper.
/// </summary>
public static class Json
{
    /// <summary>
    /// Deserializes the JSON to the specified .NET type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
    /// <param name="value">The JSON to deserialize.</param>
    public static async Task<T?> DeserializeAsync<T>(string value) => await Task.Run(() => JsonConvert.DeserializeObject<T?>(value));

    /// <summary>
    /// Serializes the specified object to a JSON string.
    /// </summary>
    /// <param name="value">The object to serialize.</param>
    public static async Task<string> SerializeAsync(object value) => await Task.Run(() => JsonConvert.SerializeObject(value));
}