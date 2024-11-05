// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.Json;

namespace Aspire.Hosting.Utils;

/// <summary>
/// Extensions to the <see cref="Utf8JsonWriter"/> type.
/// </summary>
internal static class Utf8JsonWriterExtensions
{
    /// <summary>
    /// Writes a string value to the JSON writer, if the value is not null.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="name">The property name for the string.</param>
    /// <param name="value">The string value to write.</param>
    /// <returns>True if the value was written, otherwise, false.</returns>
    public static bool TryWriteString(this Utf8JsonWriter writer, string name, string? value)
    {
        if (value is not null)
        {
            writer.WriteString(name, value);

            return true;
        }

        return false;
    }
}
