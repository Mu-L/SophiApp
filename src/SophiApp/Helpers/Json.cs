// <copyright file="Json.cs" company="Sophia Community">
// Copyright (c) Sophia Community. All rights reserved.
// </copyright>

using Newtonsoft.Json;

namespace SophiApp.Helpers;

public static class Json
{
    public static async Task<T> DeserializeAsync<T>(string value)
    {
        return await Task.Run<T>(() =>
        {
            return JsonConvert.DeserializeObject<T>(value);
        });
    }

    public static async Task<string> SerializeAsync(object value)
    {
        return await Task.Run<string>(() =>
        {
            return JsonConvert.SerializeObject(value);
        });
    }
}
