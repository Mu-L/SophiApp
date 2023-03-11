// <copyright file="RuntimeHelper.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Helpers;

using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// App runtime helper.
/// </summary>
public class RuntimeHelper
{
    public static bool IsMSIX
    {
        get
        {
            var length = 0;

            return GetCurrentPackageFullName(ref length, null) != 15700L;
        }
    }

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
#pragma warning disable CA1838
    private static extern int GetCurrentPackageFullName(ref int packageFullNameLength, StringBuilder? packageFullName);

#pragma warning restore CA1838
}