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

namespace UCP.NET.Configuration;

/// <summary>
/// Configuration options for the UCP client
/// </summary>
public class UcpClientOptions
{
    /// <summary>
    /// Base URL of the UCP endpoint (e.g., "https://merchant.example.com/ucp")
    /// </summary>
    public required string BaseUrl { get; set; }

    /// <summary>
    /// API key for authentication (if required)
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// Bearer token for authorization (if required)
    /// </summary>
    public string? BearerToken { get; set; }

    /// <summary>
    /// UCP protocol version to use (default: latest)
    /// </summary>
    public string ProtocolVersion { get; set; } = "2026-01-11";

    /// <summary>
    /// Request timeout in seconds (default: 30)
    /// </summary>
    public int TimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// Whether to include detailed error messages
    /// </summary>
    public bool IncludeDetailedErrors { get; set; } = true;

    /// <summary>
    /// Custom headers to include in all requests
    /// </summary>
    public Dictionary<string, string> CustomHeaders { get; set; } = new();
}
