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
/// Fulfillment update request
/// </summary>
public class FulfillmentUpdate
{
    /// <summary>
    /// Selected fulfillment method
    /// </summary>
    [JsonPropertyName("method")]
    public FulfillmentMethod? Method { get; set; }

    /// <summary>
    /// Shipping destination
    /// </summary>
    [JsonPropertyName("shipping_destination")]
    public ShippingDestination? ShippingDestination { get; set; }
}

/// <summary>
/// Fulfillment response information
/// </summary>
public class FulfillmentResponse
{
    /// <summary>
    /// Available fulfillment methods
    /// </summary>
    [JsonPropertyName("available_methods")]
    public List<FulfillmentMethod>? AvailableMethods { get; set; }

    /// <summary>
    /// Selected fulfillment method
    /// </summary>
    [JsonPropertyName("selected_method")]
    public FulfillmentMethod? SelectedMethod { get; set; }

    /// <summary>
    /// Fulfillment state
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }
}

/// <summary>
/// Fulfillment method
/// </summary>
public class FulfillmentMethod
{
    /// <summary>
    /// Method identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Method name (e.g., "Standard Shipping", "Express", "Pickup")
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Method type (e.g., "shipping", "pickup")
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Cost of this fulfillment method
    /// </summary>
    [JsonPropertyName("cost")]
    public Price? Cost { get; set; }

    /// <summary>
    /// Estimated delivery time
    /// </summary>
    [JsonPropertyName("estimated_delivery")]
    public string? EstimatedDelivery { get; set; }
}

/// <summary>
/// Shipping destination address
/// </summary>
public class ShippingDestination
{
    /// <summary>
    /// Recipient name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Address line 1
    /// </summary>
    [JsonPropertyName("address_line_1")]
    public string? AddressLine1 { get; set; }

    /// <summary>
    /// Address line 2
    /// </summary>
    [JsonPropertyName("address_line_2")]
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// City
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// State or province
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Postal code
    /// </summary>
    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// Country code (ISO 3166-1 alpha-2)
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Phone number
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }
}
