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

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;
using UCP.NET.Configuration;
using UCP.NET.Models;

namespace UCP.NET.Client;

/// <summary>
/// Implementation of the UCP Shopping client
/// </summary>
public class UcpShoppingClient : IUcpShoppingClient
{
    private readonly HttpClient _httpClient;
    private readonly UcpClientOptions _options;
    private readonly JsonSerializerOptions _jsonOptions;

    /// <summary>
    /// Creates a new instance of the UCP Shopping client
    /// </summary>
    /// <param name="httpClient">HTTP client for making requests</param>
    /// <param name="options">Client configuration options</param>
    public UcpShoppingClient(HttpClient httpClient, IOptions<UcpClientOptions> options)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));

        // Configure HttpClient
        _httpClient.BaseAddress = new Uri(_options.BaseUrl);
        _httpClient.Timeout = TimeSpan.FromSeconds(_options.TimeoutSeconds);

        // Set default headers
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "UCP.NET/1.0.0");

        // Add authentication headers
        if (!string.IsNullOrEmpty(_options.ApiKey))
        {
            _httpClient.DefaultRequestHeaders.Add("X-API-Key", _options.ApiKey);
        }

        if (!string.IsNullOrEmpty(_options.BearerToken))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _options.BearerToken);
        }

        // Add custom headers
        foreach (var header in _options.CustomHeaders)
        {
            _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        // Configure JSON serialization options
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = false
        };
    }

    /// <inheritdoc />
    public async Task<CheckoutResponse> CreateCheckoutAsync(
        CheckoutCreateRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "/checkout-sessions",
            request,
            _jsonOptions,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<CheckoutResponse>(
            _jsonOptions,
            cancellationToken);

        return result ?? throw new InvalidOperationException("Response was null");
    }

    /// <inheritdoc />
    public async Task<CheckoutResponse> GetCheckoutAsync(
        string checkoutId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(checkoutId))
            throw new ArgumentException("Checkout ID cannot be null or empty", nameof(checkoutId));

        var response = await _httpClient.GetAsync(
            $"/checkout-sessions/{checkoutId}",
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<CheckoutResponse>(
            _jsonOptions,
            cancellationToken);

        return result ?? throw new InvalidOperationException("Response was null");
    }

    /// <inheritdoc />
    public async Task<CheckoutResponse> UpdateCheckoutAsync(
        string checkoutId,
        CheckoutUpdateRequest request,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(checkoutId))
            throw new ArgumentException("Checkout ID cannot be null or empty", nameof(checkoutId));

        var response = await _httpClient.PatchAsJsonAsync(
            $"/checkout-sessions/{checkoutId}",
            request,
            _jsonOptions,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<CheckoutResponse>(
            _jsonOptions,
            cancellationToken);

        return result ?? throw new InvalidOperationException("Response was null");
    }

    /// <inheritdoc />
    public async Task<Order> CompleteCheckoutAsync(
        string checkoutId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(checkoutId))
            throw new ArgumentException("Checkout ID cannot be null or empty", nameof(checkoutId));

        var response = await _httpClient.PostAsync(
            $"/checkout-sessions/{checkoutId}/complete",
            null,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<Order>(
            _jsonOptions,
            cancellationToken);

        return result ?? throw new InvalidOperationException("Response was null");
    }

    /// <inheritdoc />
    public async Task<Order> GetOrderAsync(
        string orderId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(orderId))
            throw new ArgumentException("Order ID cannot be null or empty", nameof(orderId));

        var response = await _httpClient.GetAsync(
            $"/orders/{orderId}",
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<Order>(
            _jsonOptions,
            cancellationToken);

        return result ?? throw new InvalidOperationException("Response was null");
    }
}
