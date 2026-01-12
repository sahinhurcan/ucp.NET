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
/// Request to create a new checkout session
/// </summary>
public class CheckoutCreateRequest
{
    /// <summary>
    /// UCP protocol metadata
    /// </summary>
    [JsonPropertyName("ucp")]
    public required UcpMetadata Ucp { get; set; }

    /// <summary>
    /// Line items in the cart
    /// </summary>
    [JsonPropertyName("line_items")]
    public List<LineItem>? LineItems { get; set; }

    /// <summary>
    /// Account information if user is authenticated
    /// </summary>
    [JsonPropertyName("account_info")]
    public AccountInfo? AccountInfo { get; set; }
}

/// <summary>
/// Request to update an existing checkout session
/// </summary>
public class CheckoutUpdateRequest
{
    /// <summary>
    /// UCP protocol metadata
    /// </summary>
    [JsonPropertyName("ucp")]
    public required UcpMetadata Ucp { get; set; }

    /// <summary>
    /// Line items to update
    /// </summary>
    [JsonPropertyName("line_items")]
    public List<LineItemUpdate>? LineItems { get; set; }

    /// <summary>
    /// Payment information to update
    /// </summary>
    [JsonPropertyName("payment")]
    public PaymentUpdate? Payment { get; set; }

    /// <summary>
    /// Fulfillment information to update
    /// </summary>
    [JsonPropertyName("fulfillment")]
    public FulfillmentUpdate? Fulfillment { get; set; }
}

/// <summary>
/// Checkout session response
/// </summary>
public class CheckoutResponse
{
    /// <summary>
    /// UCP protocol metadata
    /// </summary>
    [JsonPropertyName("ucp")]
    public required UcpMetadata Ucp { get; set; }

    /// <summary>
    /// Unique identifier for the checkout session
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Current state of the checkout session
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; set; }

    /// <summary>
    /// Line items in the checkout
    /// </summary>
    [JsonPropertyName("line_items")]
    public List<LineItemResponse>? LineItems { get; set; }

    /// <summary>
    /// Payment information
    /// </summary>
    [JsonPropertyName("payment")]
    public PaymentResponse? Payment { get; set; }

    /// <summary>
    /// Fulfillment information
    /// </summary>
    [JsonPropertyName("fulfillment")]
    public FulfillmentResponse? Fulfillment { get; set; }

    /// <summary>
    /// Order summary
    /// </summary>
    [JsonPropertyName("order_summary")]
    public OrderSummary? OrderSummary { get; set; }
}
