# Getting Started with UCP.NET

This guide will walk you through setting up and using UCP.NET in your .NET applications.

## Prerequisites

- .NET 8.0 SDK or later
- A UCP-compliant merchant endpoint (or use the example mock for testing)
- Visual Studio 2022, VS Code, or Rider (optional)

## Installation

### Option 1: NuGet Package (Coming Soon)

```bash
dotnet add package UCP.NET
```

### Option 2: Build from Source

```bash
git clone https://github.com/sahinhurcan/ucp.NET.git
cd ucp.NET
dotnet build src/UCP.NET/UCP.NET.csproj
```

Then reference the project in your application:

```xml
<ProjectReference Include="path/to/ucp.NET/src/UCP.NET/UCP.NET.csproj" />
```

## Quick Start

### 1. Configure the UCP Client

In your `appsettings.json`:

```json
{
  "UcpClient": {
    "BaseUrl": "https://your-merchant-endpoint.com/ucp",
    "ApiKey": "your-api-key-here",
    "ProtocolVersion": "2026-01-11",
    "TimeoutSeconds": 30
  }
}
```

### 2. Register Services in Dependency Injection

In `Program.cs` or `Startup.cs`:

```csharp
using UCP.NET.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add UCP client
builder.Services.AddUcpShoppingClient(builder.Configuration);

// Or configure inline
builder.Services.AddUcpShoppingClient(options =>
{
    options.BaseUrl = "https://merchant.example.com/ucp";
    options.ApiKey = "your-api-key";
    options.ProtocolVersion = "2026-01-11";
});

var app = builder.Build();
```

### 3. Use the Client

```csharp
using UCP.NET.Client;
using UCP.NET.Models;

public class CheckoutService
{
    private readonly IUcpShoppingClient _ucpClient;

    public CheckoutService(IUcpShoppingClient ucpClient)
    {
        _ucpClient = ucpClient;
    }

    public async Task<string> CreateAndCompleteCheckout()
    {
        // 1. Create checkout
        var createRequest = new CheckoutCreateRequest
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
                    Id = "product-123",
                    Quantity = 2,
                    Item = new ItemInfo
                    {
                        Name = "Example Product",
                        Description = "A sample product"
                    }
                }
            }
        };

        var checkout = await _ucpClient.CreateCheckoutAsync(createRequest);
        Console.WriteLine($"Checkout created: {checkout.Id}");

        // 2. Update checkout (e.g., add payment info)
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

        var updated = await _ucpClient.UpdateCheckoutAsync(
            checkout.Id, 
            updateRequest);

        // 3. Complete checkout
        var order = await _ucpClient.CompleteCheckoutAsync(checkout.Id);
        Console.WriteLine($"Order created: {order.Id}");

        return order.Id;
    }
}
```

## Example Scenarios

### Scenario 1: Simple Product Purchase

```csharp
// Create checkout with a single product
var request = new CheckoutCreateRequest
{
    Ucp = new UcpMetadata { Version = "2026-01-11" },
    LineItems = new List<LineItem>
    {
        new LineItem
        {
            Id = "SKU-001",
            Quantity = 1,
            Item = new ItemInfo
            {
                Name = "Laptop",
                Description = "15-inch Laptop",
                Url = "https://store.example.com/laptop",
                ImageUrl = "https://store.example.com/laptop.jpg"
            }
        }
    }
};

var checkout = await _ucpClient.CreateCheckoutAsync(request);
```

### Scenario 2: Adding Multiple Items

```csharp
var items = new List<LineItem>
{
    new LineItem
    {
        Id = "SKU-001",
        Quantity = 2,
        Item = new ItemInfo { Name = "Mouse" }
    },
    new LineItem
    {
        Id = "SKU-002",
        Quantity = 1,
        Item = new ItemInfo { Name = "Keyboard" }
    }
};

var request = new CheckoutCreateRequest
{
    Ucp = new UcpMetadata { Version = "2026-01-11" },
    LineItems = items
};

var checkout = await _ucpClient.CreateCheckoutAsync(request);
```

### Scenario 3: Retrieving Checkout Status

```csharp
var checkoutId = "checkout-session-123";
var checkout = await _ucpClient.GetCheckoutAsync(checkoutId);

Console.WriteLine($"Checkout State: {checkout.State}");
Console.WriteLine($"Total Items: {checkout.LineItems?.Count ?? 0}");

if (checkout.OrderSummary != null)
{
    Console.WriteLine($"Subtotal: {checkout.OrderSummary.Subtotal?.Display}");
    Console.WriteLine($"Tax: {checkout.OrderSummary.Tax?.Display}");
    Console.WriteLine($"Total: {checkout.OrderSummary.Total?.Display}");
}
```

## Clean Architecture Example

For a complete example showing Clean Architecture with MediatR, see:
`examples/UCP.CleanArchitecture/`

This example demonstrates:
- Domain-Driven Design
- CQRS with MediatR
- Dependency Injection
- Repository pattern
- RESTful API with Swagger

To run the example:

```bash
cd examples/UCP.CleanArchitecture/src/API
dotnet run
```

Then navigate to `https://localhost:5001/swagger` to explore the API.

## Error Handling

```csharp
try
{
    var checkout = await _ucpClient.GetCheckoutAsync("invalid-id");
}
catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
{
    Console.WriteLine("Checkout not found");
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"HTTP error: {ex.StatusCode} - {ex.Message}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Invalid operation: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
```

## Configuration Options

| Option | Type | Description | Default | Required |
|--------|------|-------------|---------|----------|
| `BaseUrl` | string | UCP endpoint base URL | - | ✅ Yes |
| `ApiKey` | string | API key for authentication | null | ❌ No |
| `BearerToken` | string | Bearer token for authorization | null | ❌ No |
| `ProtocolVersion` | string | UCP protocol version | "2026-01-11" | ❌ No |
| `TimeoutSeconds` | int | Request timeout | 30 | ❌ No |
| `IncludeDetailedErrors` | bool | Include detailed error messages | true | ❌ No |
| `CustomHeaders` | Dictionary | Additional HTTP headers | empty | ❌ No |

## Next Steps

1. **Explore the API**: Review the [complete API documentation](README_NUGET.md)
2. **Check the Example**: Study the [Clean Architecture example](examples/UCP.CleanArchitecture/)
3. **Read UCP Specification**: Understand the protocol at [ucp.dev](https://ucp.dev)
4. **Join the Community**: Participate in [GitHub Discussions](https://github.com/sahinhurcan/ucp.NET/discussions)

## Troubleshooting

### Issue: "Unable to connect to UCP endpoint"

**Solution**: Verify the `BaseUrl` in your configuration and ensure the endpoint is accessible.

### Issue: "Unauthorized" or "Forbidden" errors

**Solution**: Check your `ApiKey` or `BearerToken` configuration.

### Issue: "Package 'UCP.NET' could not be found"

**Solution**: The NuGet package is not yet published. Build from source for now.

### Issue: Model validation errors

**Solution**: Ensure all required properties are set. Check the UCP specification for required fields.

## Support

- 📝 [Report Issues](https://github.com/sahinhurcan/ucp.NET/issues)
- 💬 [Discussions](https://github.com/sahinhurcan/ucp.NET/discussions)
- 📧 Contact: via GitHub issues
