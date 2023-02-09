namespace SophiApp.Helpers;

using System.Threading.Tasks;
using Newtonsoft.Json;

/// <summary>
/// <see cref="Json"/> class extension.
/// </summary>
public static class Json
{
    /// <summary>
    /// Serializes the specified object to a JSON string.
    /// </summary>
    /// <param name="value">The object to serialize.</param>
    public static async Task<string> SerializeAsync(object? value)
    {
        return await Task.Run(() =>
        {
            return JsonConvert.SerializeObject(value);
        });
    }

    /// <summary>
    /// Deserializes the JSON to the specified .NET type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
    /// <param name="value">The JSON to deserialize.</param>
    public static async Task<T> ToObjectAsync<T>(string value)
    {
        return await Task.Run(() =>
        {
            return JsonConvert.DeserializeObject<T>(value)!;
        });
    }
}