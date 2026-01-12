# UCP.NET - Universal Commerce Protocol for .NET

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](LICENSE)
[![NuGet](https://img.shields.io/nuget/v/UCP.NET.svg)](https://www.nuget.org/packages/UCP.NET/)

A .NET client library for [Universal Commerce Protocol (UCP)](https://ucp.dev) - enabling seamless commerce integrations with standardized APIs for checkout, payments, and order management.

## Overview

UCP.NET is a comprehensive .NET library that provides an easy-to-use client for integrating with UCP-compliant commerce platforms. It supports the full UCP specification including:

- ✅ **Checkout Sessions** - Create and manage shopping cart checkout flows
- ✅ **Payment Processing** - Handle payment methods and credentials securely  
- ✅ **Order Management** - Track orders from creation to fulfillment
- ✅ **Discovery** - Automatic capability discovery from merchant endpoints
- ✅ **Extensible** - Support for UCP extensions and custom capabilities

## Installation

Install the NuGet package:

```bash
dotnet add package UCP.NET
```

Or via Package Manager Console:

```powershell
Install-Package UCP.NET
```

## Quick Start

### Basic Setup

```csharp
using UCP.NET.Client;
using UCP.NET.Configuration;
using UCP.NET.Extensions;

// Configure services
services.AddUcpShoppingClient(options =>
{
    options.BaseUrl = "https://merchant.example.com/ucp";
    options.ApiKey = "your-api-key";
    options.ProtocolVersion = "2026-01-11";
});
```

### Using Configuration File

In `appsettings.json`:

```json
{
  "UcpClient": {
    "BaseUrl": "https://merchant.example.com/ucp",
    "ApiKey": "your-api-key",
    "ProtocolVersion": "2026-01-11",
    "TimeoutSeconds": 30
  }
}
```

Then register the client:

```csharp
services.AddUcpShoppingClient(configuration);
```

### Creating a Checkout Session

```csharp
public class CheckoutService
{
    private readonly IUcpShoppingClient _ucpClient;

    public CheckoutService(IUcpShoppingClient ucpClient)
    {
        _ucpClient = ucpClient;
    }

    public async Task<string> CreateCheckoutAsync()
    {
        var request = new CheckoutCreateRequest
        {
            Ucp = new UcpMetadata
            {
                Version = "2026-01-11",
                Capabilities = new List<Capability>
                {
                    new Capability { Name = "checkout" }
                }
            },
            LineItems = new List<LineItem>
            {
                new LineItem
                {
                    Id = "item-123",
                    Quantity = 2,
                    Item = new ItemInfo
                    {
                        Name = "Product Name",
                        Description = "Product Description",
                        ImageUrl = "https://example.com/image.jpg"
                    }
                }
            }
        };

        var response = await _ucpClient.CreateCheckoutAsync(request);
        return response.Id;
    }
}
```

### Updating a Checkout Session

```csharp
public async Task UpdatePaymentAsync(string checkoutId)
{
    var updateRequest = new CheckoutUpdateRequest
    {
        Ucp = new UcpMetadata { Version = "2026-01-11" },
        Payment = new PaymentUpdate
        {
            PaymentHandler = new PaymentHandler
            {
                Id = "payment-handler-123",
                Name = "Credit Card"
            }
        }
    };

    var response = await _ucpClient.UpdateCheckoutAsync(checkoutId, updateRequest);
}
```

### Completing a Checkout

```csharp
public async Task<Order> CompleteCheckoutAsync(string checkoutId)
{
    var order = await _ucpClient.CompleteCheckoutAsync(checkoutId);
    Console.WriteLine($"Order created: {order.Id}");
    return order;
}
```

## Clean Architecture Example

Check out the complete [Clean Architecture example](examples/UCP.CleanArchitecture/) demonstrating:

- **Domain Layer** - Core business entities and interfaces
- **Application Layer** - Use cases implemented with MediatR
- **Infrastructure Layer** - UCP client integration
- **API Layer** - ASP.NET Core Web API

### Example Structure

```
examples/UCP.CleanArchitecture/
├── src/
│   ├── Domain/              # Entities, Value Objects, Interfaces
│   ├── Application/         # Use Cases, DTOs, MediatR Commands/Queries
│   ├── Infrastructure/      # UCP Integration, Repositories
│   └── API/                 # ASP.NET Core Web API
└── tests/
    ├── Application.Tests/
    └── Infrastructure.Tests/
```

## Features

### Type-Safe Models

All UCP schema types are mapped to strongly-typed C# classes with proper JSON serialization:

```csharp
public class CheckoutResponse
{
    public required UcpMetadata Ucp { get; set; }
    public required string Id { get; set; }
    public required string State { get; set; }
    public List<LineItemResponse>? LineItems { get; set; }
    public PaymentResponse? Payment { get; set; }
    public FulfillmentResponse? Fulfillment { get; set; }
    public OrderSummary? OrderSummary { get; set; }
}
```

### Error Handling

The client throws detailed exceptions for error scenarios:

```csharp
try
{
    var checkout = await _ucpClient.GetCheckoutAsync("invalid-id");
}
catch (HttpRequestException ex)
{
    // Handle HTTP errors (4xx, 5xx)
    Console.WriteLine($"HTTP Error: {ex.Message}");
}
catch (InvalidOperationException ex)
{
    // Handle null responses
    Console.WriteLine($"Invalid response: {ex.Message}");
}
```

### Dependency Injection

Full support for .NET dependency injection:

```csharp
// Startup.cs or Program.cs
builder.Services.AddUcpShoppingClient(options =>
{
    options.BaseUrl = builder.Configuration["UcpClient:BaseUrl"]!;
    options.ApiKey = builder.Configuration["UcpClient:ApiKey"];
});

// Use in controllers
public class CheckoutController : ControllerBase
{
    private readonly IUcpShoppingClient _ucpClient;

    public CheckoutController(IUcpShoppingClient ucpClient)
    {
        _ucpClient = ucpClient;
    }
}
```

## Configuration Options

| Option | Type | Description | Default |
|--------|------|-------------|---------|
| `BaseUrl` | string | Base URL of the UCP endpoint | Required |
| `ApiKey` | string | API key for authentication | null |
| `BearerToken` | string | Bearer token for authorization | null |
| `ProtocolVersion` | string | UCP protocol version | "2026-01-11" |
| `TimeoutSeconds` | int | Request timeout in seconds | 30 |
| `IncludeDetailedErrors` | bool | Include detailed error messages | true |
| `CustomHeaders` | Dictionary | Custom headers for all requests | {} |

## Contributing

Contributions are welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.

## About UCP

Universal Commerce Protocol (UCP) is an open standard enabling interoperability between various commerce entities. Learn more at [ucp.dev](https://ucp.dev).

## Resources

- 📚 [UCP Documentation](https://ucp.dev)
- 📋 [UCP Specification](https://ucp.dev/specification/overview)
- 💬 [GitHub Discussions](https://github.com/Universal-Commerce-Protocol/ucp/discussions)
- 🔧 [Report Issues](https://github.com/sahinhurcan/ucp.NET/issues)
