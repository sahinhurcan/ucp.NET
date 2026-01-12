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
/// Account information for authenticated users
/// </summary>
public class AccountInfo
{
    /// <summary>
    /// Account identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// User's email address
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// User's display name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

/// <summary>
/// Order summary in the checkout response
/// </summary>
public class OrderSummary
{
    /// <summary>
    /// Subtotal before taxes and fees
    /// </summary>
    [JsonPropertyName("subtotal")]
    public Price? Subtotal { get; set; }

    /// <summary>
    /// Tax amount
    /// </summary>
    [JsonPropertyName("tax")]
    public Price? Tax { get; set; }

    /// <summary>
    /// Shipping or fulfillment cost
    /// </summary>
    [JsonPropertyName("shipping")]
    public Price? Shipping { get; set; }

    /// <summary>
    /// Discounts applied
    /// </summary>
    [JsonPropertyName("discounts")]
    public Price? Discounts { get; set; }

    /// <summary>
    /// Total amount
    /// </summary>
    [JsonPropertyName("total")]
    public Price? Total { get; set; }
}

/// <summary>
/// Order update request
/// </summary>
public class OrderUpdateRequest
{
    /// <summary>
    /// UCP protocol metadata
    /// </summary>
    [JsonPropertyName("ucp")]
    public UcpMetadata? Ucp { get; set; }

    /// <summary>
    /// Order state update
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Fulfillment information update
    /// </summary>
    [JsonPropertyName("fulfillment")]
    public FulfillmentUpdate? Fulfillment { get; set; }
}

/// <summary>
/// Order information
/// </summary>
public class Order
{
    /// <summary>
    /// UCP protocol metadata
    /// </summary>
    [JsonPropertyName("ucp")]
    public required UcpMetadata Ucp { get; set; }

    /// <summary>
    /// Order identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Order state
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; set; }

    /// <summary>
    /// Order creation timestamp
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// Order update timestamp
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Line items in the order
    /// </summary>
    [JsonPropertyName("line_items")]
    public List<LineItemResponse>? LineItems { get; set; }

    /// <summary>
    /// Order summary
    /// </summary>
    [JsonPropertyName("order_summary")]
    public OrderSummary? OrderSummary { get; set; }

    /// <summary>
    /// Fulfillment information
    /// </summary>
    [JsonPropertyName("fulfillment")]
    public FulfillmentResponse? Fulfillment { get; set; }
}
