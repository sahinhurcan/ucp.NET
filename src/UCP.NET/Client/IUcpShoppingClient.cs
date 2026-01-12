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

using UCP.NET.Models;

namespace UCP.NET.Client;

/// <summary>
/// Interface for UCP Shopping service operations
/// </summary>
public interface IUcpShoppingClient
{
    /// <summary>
    /// Creates a new checkout session
    /// </summary>
    /// <param name="request">Checkout creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Checkout response</returns>
    Task<CheckoutResponse> CreateCheckoutAsync(
        CheckoutCreateRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets an existing checkout session
    /// </summary>
    /// <param name="checkoutId">Checkout session identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Checkout response</returns>
    Task<CheckoutResponse> GetCheckoutAsync(
        string checkoutId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing checkout session
    /// </summary>
    /// <param name="checkoutId">Checkout session identifier</param>
    /// <param name="request">Checkout update request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Updated checkout response</returns>
    Task<CheckoutResponse> UpdateCheckoutAsync(
        string checkoutId,
        CheckoutUpdateRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Completes a checkout session and creates an order
    /// </summary>
    /// <param name="checkoutId">Checkout session identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Order information</returns>
    Task<Order> CompleteCheckoutAsync(
        string checkoutId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets an order by its identifier
    /// </summary>
    /// <param name="orderId">Order identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Order information</returns>
    Task<Order> GetOrderAsync(
        string orderId,
        CancellationToken cancellationToken = default);
}
