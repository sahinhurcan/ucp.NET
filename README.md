# UCP.NET - Universal Commerce Protocol for .NET

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](LICENSE)

A comprehensive .NET implementation of the [Universal Commerce Protocol (UCP)](https://ucp.dev) - enabling seamless commerce integrations for .NET developers.

## 🎯 Overview

This repository provides both a NuGet package and a Clean Architecture example for integrating UCP into .NET applications. UCP is forked from Google's Universal Commerce Protocol specification and adapted for the .NET ecosystem.

**What is UCP?**
Universal Commerce Protocol (UCP) is an open standard that enables interoperability between various commerce entities, providing a standardized way to handle checkout, payments, orders, and fulfillment.

## 📦 UCP.NET Library

The core `UCP.NET` library provides:
- ✅ **Strongly-typed models** for all UCP types (Checkout, Payment, Order, Fulfillment)
- ✅ **HTTP client** for UCP REST APIs
- ✅ **Dependency injection** extensions
- ✅ **Async/await** support throughout
- ✅ **Configuration** via appsettings.json or code

### Installation

```bash
dotnet add package UCP.NET
```

### Quick Start

```csharp
// Configure in Startup.cs or Program.cs
builder.Services.AddUcpShoppingClient(options =>
{
    options.BaseUrl = "https://merchant.example.com/ucp";
    options.ApiKey = "your-api-key";
});

// Inject and use
public class CheckoutService
{
    private readonly IUcpShoppingClient _ucpClient;

    public CheckoutService(IUcpShoppingClient ucpClient)
    {
        _ucpClient = ucpClient;
    }

    public async Task<CheckoutResponse> CreateCheckout()
    {
        var request = new CheckoutCreateRequest
        {
            Ucp = new UcpMetadata { Version = "2026-01-11" },
            LineItems = new List<LineItem>
            {
                new LineItem
                {
                    Id = "product-123",
                    Quantity = 2
                }
            }
        };

        return await _ucpClient.CreateCheckoutAsync(request);
    }
}
```

For complete API documentation, see [README_NUGET.md](README_NUGET.md).

## 🏗️ Clean Architecture Example

The `examples/UCP.CleanArchitecture` folder contains a complete example demonstrating:
- **Clean Architecture** with proper layer separation
- **MediatR** for CQRS pattern implementation
- **Domain-Driven Design** principles
- **Dependency Injection** best practices
- **ASP.NET Core Web API** with Swagger

### Example Structure

```
examples/UCP.CleanArchitecture/
├── Domain/              # Entities, Value Objects, Interfaces
│   ├── Entities/        # ShoppingCart, Order
│   └── Interfaces/      # Repository interfaces
├── Application/         # Use Cases with MediatR
│   ├── UseCases/
│   │   ├── Checkout/    # Checkout commands and queries
│   │   └── Orders/      # Order commands
│   └── DTOs/            # Data transfer objects
├── Infrastructure/      # UCP Integration, Repositories
│   └── Repositories/    # In-memory implementations
└── API/                 # ASP.NET Core Web API
    └── Controllers/     # REST endpoints
```

### Running the Example

```bash
cd examples/UCP.CleanArchitecture/src/API
dotnet run
```

Then open `https://localhost:5001/swagger` to see the API documentation.

For detailed information, see [examples/UCP.CleanArchitecture/README.md](examples/UCP.CleanArchitecture/README.md).

## 🚀 Features

### Core Library Features
- **Type-safe Models**: All UCP schema types mapped to C# classes
- **HTTP Client**: Full REST API client implementation
- **Configuration**: Flexible configuration via appsettings or code
- **Error Handling**: Proper exception handling and error messages
- **Async Support**: Full async/await pattern support
- **Extensibility**: Easy to extend with custom capabilities

### Example Application Features
- **Clean Architecture**: Proper separation of concerns
- **CQRS with MediatR**: Command Query Responsibility Segregation
- **RESTful API**: Standard REST endpoints
- **Swagger/OpenAPI**: Interactive API documentation
- **In-Memory Storage**: Easy to run and test

## 📚 Documentation

- [NuGet Package Documentation](README_NUGET.md) - Complete API reference
- [Example Application Guide](examples/UCP.CleanArchitecture/README.md) - Clean Architecture tutorial
- [UCP Specification](https://ucp.dev/specification/overview) - Protocol specification
- [UCP Documentation](https://ucp.dev) - Official UCP docs

## 🛠️ Development

### Building from Source

```bash
# Clone the repository
git clone https://github.com/sahinhurcan/ucp.NET.git
cd ucp.NET

# Build the library
dotnet build src/UCP.NET/UCP.NET.csproj

# Build the example
dotnet build examples/UCP.CleanArchitecture.sln

# Run tests (when available)
dotnet test
```

### Project Structure

```
ucp.NET/
├── src/
│   └── UCP.NET/           # Core library
│       ├── Models/        # UCP models
│       ├── Client/        # HTTP client
│       ├── Configuration/ # Options
│       └── Extensions/    # DI extensions
├── examples/
│   └── UCP.CleanArchitecture/  # Full example app
├── tests/                 # Unit and integration tests
├── spec/                  # UCP specification (JSON schemas)
└── docs/                  # Documentation
```

## 🤝 Contributing

Contributions are welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## 📄 License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.

## 🌟 About UCP

Universal Commerce Protocol (UCP) is forked from Google's Universal Commerce Protocol and adapted for the .NET ecosystem. UCP is an open standard enabling interoperability between various commerce entities.

### Original UCP Resources
- 📚 [UCP Documentation](https://ucp.dev)
- 📋 [UCP Specification](https://ucp.dev/specification/overview)
- 💬 [UCP Discussions](https://github.com/Universal-Commerce-Protocol/ucp/discussions)

### This Repository
- 🔧 [Report Issues](https://github.com/sahinhurcan/ucp.NET/issues)
- 💡 [Feature Requests](https://github.com/sahinhurcan/ucp.NET/issues)
- 🌐 [NuGet Package](https://www.nuget.org/packages/UCP.NET/) (coming soon)

## 🙏 Acknowledgments

- Original UCP specification by Google and the UCP community
- Clean Architecture principles by Robert C. Martin
- MediatR library by Jimmy Bogard

---

Made with ❤️ for the .NET community