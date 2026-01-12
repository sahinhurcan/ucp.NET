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

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UCP.NET.Client;
using UCP.NET.Configuration;

namespace UCP.NET.Extensions;

/// <summary>
/// Extension methods for registering UCP services in dependency injection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds UCP Shopping client to the service collection
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="configuration">Configuration instance</param>
    /// <param name="sectionName">Configuration section name (default: "UcpClient")</param>
    /// <returns>Service collection for chaining</returns>
    public static IServiceCollection AddUcpShoppingClient(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName = "UcpClient")
    {
        services.Configure<UcpClientOptions>(
            configuration.GetSection(sectionName));

        services.AddHttpClient<IUcpShoppingClient, UcpShoppingClient>();

        return services;
    }

    /// <summary>
    /// Adds UCP Shopping client to the service collection with inline configuration
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="configureOptions">Configuration action</param>
    /// <returns>Service collection for chaining</returns>
    public static IServiceCollection AddUcpShoppingClient(
        this IServiceCollection services,
        Action<UcpClientOptions> configureOptions)
    {
        services.Configure(configureOptions);

        services.AddHttpClient<IUcpShoppingClient, UcpShoppingClient>();

        return services;
    }
}
