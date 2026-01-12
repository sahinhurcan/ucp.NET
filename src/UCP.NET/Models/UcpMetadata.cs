// Copyright 2026 UCP Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Text.Json.Serialization;

namespace UCP.NET.Models;

/// <summary>
/// UCP protocol metadata
/// </summary>
public class UcpMetadata
{
    /// <summary>
    /// UCP protocol version in YYYY-MM-DD format
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; set; }

    /// <summary>
    /// Supported capabilities and extensions
    /// </summary>
    [JsonPropertyName("capabilities")]
    public List<Capability>? Capabilities { get; set; }
}

/// <summary>
/// Represents a UCP capability
/// </summary>
public class Capability
{
    /// <summary>
    /// Capability name (e.g., "checkout", "payment", "order")
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Capability version
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// Supported extensions for this capability
    /// </summary>
    [JsonPropertyName("extensions")]
    public List<string>? Extensions { get; set; }
}
