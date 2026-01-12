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
/// Buyer profile create request
/// </summary>
public class ProfileCreateRequest
{
    /// <summary>
    /// UCP metadata
    /// </summary>
    [JsonPropertyName("ucp")]
    public required UcpMetadata Ucp { get; set; }

    /// <summary>
    /// Buyer identity information
    /// </summary>
    [JsonPropertyName("identity")]
    public BuyerIdentity? Identity { get; set; }

    /// <summary>
    /// Saved payment methods
    /// </summary>
    [JsonPropertyName("payment_methods")]
    public List<SavedPaymentMethod>? PaymentMethods { get; set; }

    /// <summary>
    /// Saved addresses
    /// </summary>
    [JsonPropertyName("addresses")]
    public List<SavedAddress>? Addresses { get; set; }
}

/// <summary>
/// Buyer profile update request
/// </summary>
public class ProfileUpdateRequest
{
    /// <summary>
    /// UCP metadata
    /// </summary>
    [JsonPropertyName("ucp")]
    public UcpMetadata? Ucp { get; set; }

    /// <summary>
    /// Buyer identity information
    /// </summary>
    [JsonPropertyName("identity")]
    public BuyerIdentity? Identity { get; set; }

    /// <summary>
    /// Saved payment methods
    /// </summary>
    [JsonPropertyName("payment_methods")]
    public List<SavedPaymentMethod>? PaymentMethods { get; set; }

    /// <summary>
    /// Saved addresses
    /// </summary>
    [JsonPropertyName("addresses")]
    public List<SavedAddress>? Addresses { get; set; }
}

/// <summary>
/// Buyer profile response
/// </summary>
public class ProfileResponse
{
    /// <summary>
    /// Profile identifier
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// UCP metadata
    /// </summary>
    [JsonPropertyName("ucp")]
    public required UcpMetadata Ucp { get; set; }

    /// <summary>
    /// Buyer identity information
    /// </summary>
    [JsonPropertyName("identity")]
    public BuyerIdentity? Identity { get; set; }

    /// <summary>
    /// Saved payment methods
    /// </summary>
    [JsonPropertyName("payment_methods")]
    public List<SavedPaymentMethod>? PaymentMethods { get; set; }

    /// <summary>
    /// Saved addresses
    /// </summary>
    [JsonPropertyName("addresses")]
    public List<SavedAddress>? Addresses { get; set; }

    /// <summary>
    /// Profile state
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }
}

/// <summary>
/// Buyer identity information
/// </summary>
public class BuyerIdentity
{
    /// <summary>
    /// Buyer email address
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Buyer phone number
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Buyer full name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Given name (first name)
    /// </summary>
    [JsonPropertyName("given_name")]
    public string? GivenName { get; set; }

    /// <summary>
    /// Family name (last name)
    /// </summary>
    [JsonPropertyName("family_name")]
    public string? FamilyName { get; set; }
}

/// <summary>
/// Saved payment method
/// </summary>
public class SavedPaymentMethod
{
    /// <summary>
    /// Payment method identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Payment method type
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Display name for the payment method
    /// </summary>
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Last 4 digits of card (if applicable)
    /// </summary>
    [JsonPropertyName("last_four")]
    public string? LastFour { get; set; }

    /// <summary>
    /// Expiry date (if applicable)
    /// </summary>
    [JsonPropertyName("expiry")]
    public string? Expiry { get; set; }

    /// <summary>
    /// Payment token
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }
}

/// <summary>
/// Saved address
/// </summary>
public class SavedAddress
{
    /// <summary>
    /// Address identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Address type (shipping, billing, etc.)
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Recipient name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Address line 1
    /// </summary>
    [JsonPropertyName("address_line1")]
    public string? AddressLine1 { get; set; }

    /// <summary>
    /// Address line 2
    /// </summary>
    [JsonPropertyName("address_line2")]
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
}
