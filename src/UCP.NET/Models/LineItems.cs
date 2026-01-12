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
/// Represents a line item in the checkout
/// </summary>
public class LineItem
{
    /// <summary>
    /// Product or item identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Quantity of the item
    /// </summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; set; }

    /// <summary>
    /// Item metadata
    /// </summary>
    [JsonPropertyName("item")]
    public ItemInfo? Item { get; set; }
}

/// <summary>
/// Update to a line item
/// </summary>
public class LineItemUpdate
{
    /// <summary>
    /// Line item identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// New quantity (omit to remove item)
    /// </summary>
    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }
}

/// <summary>
/// Line item in the response
/// </summary>
public class LineItemResponse
{
    /// <summary>
    /// Line item identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; set; }

    /// <summary>
    /// Item information
    /// </summary>
    [JsonPropertyName("item")]
    public ItemResponse? Item { get; set; }

    /// <summary>
    /// Price information for this line item
    /// </summary>
    [JsonPropertyName("price")]
    public Price? Price { get; set; }
}

/// <summary>
/// Item information
/// </summary>
public class ItemInfo
{
    /// <summary>
    /// Item name or title
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Item description
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Item URL
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Image URL
    /// </summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }
}

/// <summary>
/// Item information in response
/// </summary>
public class ItemResponse
{
    /// <summary>
    /// Item name or title
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Item description
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Item URL
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Image URL
    /// </summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// SKU or product code
    /// </summary>
    [JsonPropertyName("sku")]
    public string? Sku { get; set; }
}
