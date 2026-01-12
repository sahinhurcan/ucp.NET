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
/// Payment update request
/// </summary>
public class PaymentUpdate
{
    /// <summary>
    /// Payment handler information
    /// </summary>
    [JsonPropertyName("payment_handler")]
    public PaymentHandler? PaymentHandler { get; set; }

    /// <summary>
    /// Payment credentials
    /// </summary>
    [JsonPropertyName("credentials")]
    public PaymentCredentials? Credentials { get; set; }
}

/// <summary>
/// Payment response information
/// </summary>
public class PaymentResponse
{
    /// <summary>
    /// Available payment handlers
    /// </summary>
    [JsonPropertyName("payment_handlers")]
    public List<PaymentHandler>? PaymentHandlers { get; set; }

    /// <summary>
    /// Payment state
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Total amount
    /// </summary>
    [JsonPropertyName("total")]
    public Price? Total { get; set; }
}

/// <summary>
/// Payment handler information
/// </summary>
public class PaymentHandler
{
    /// <summary>
    /// Payment handler identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Payment handler name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Supported payment methods
    /// </summary>
    [JsonPropertyName("supported_methods")]
    public List<string>? SupportedMethods { get; set; }
}

/// <summary>
/// Payment credentials
/// </summary>
public class PaymentCredentials
{
    /// <summary>
    /// Payment method identifier
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Tokenized payment data
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }

    /// <summary>
    /// Additional payment data
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; set; }
}

/// <summary>
/// Price information
/// </summary>
public class Price
{
    /// <summary>
    /// Currency code (ISO 4217)
    /// </summary>
    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    /// <summary>
    /// Amount in smallest currency unit (e.g., cents)
    /// </summary>
    [JsonPropertyName("value")]
    public required long Value { get; set; }

    /// <summary>
    /// Formatted display value
    /// </summary>
    [JsonPropertyName("display")]
    public string? Display { get; set; }
}
