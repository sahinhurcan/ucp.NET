# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2026-01-12

### Added
- Initial release of UCP.NET
- Core library with strongly-typed models for UCP protocol
  - `UcpMetadata` - Protocol metadata
  - `CheckoutCreateRequest`, `CheckoutUpdateRequest`, `CheckoutResponse` - Checkout models
  - `LineItem`, `LineItemUpdate`, `LineItemResponse` - Line item models
  - `PaymentUpdate`, `PaymentResponse`, `PaymentHandler` - Payment models
  - `FulfillmentUpdate`, `FulfillmentResponse`, `FulfillmentMethod` - Fulfillment models
  - `Order`, `OrderSummary` - Order models
  - `Price`, `AccountInfo`, `ShippingDestination` - Common models
- HTTP client implementation
  - `IUcpShoppingClient` - Client interface
  - `UcpShoppingClient` - Full implementation with async support
- Configuration system
  - `UcpClientOptions` - Configurable options
  - Support for appsettings.json configuration
  - Support for inline configuration
- Dependency Injection extensions
  - `AddUcpShoppingClient()` extension methods
  - Full integration with .NET DI container
- Clean Architecture example application
  - Domain layer with entities and interfaces
  - Application layer with MediatR CQRS implementation
  - Infrastructure layer with repositories and UCP integration
  - API layer with ASP.NET Core Web API and Swagger
- Comprehensive documentation
  - Main README with overview and quick start
  - Detailed NuGet package documentation
  - Clean Architecture example guide
  - Getting Started tutorial
- Build and deployment infrastructure
  - NuGet package build script
  - GitHub Actions CI/CD workflows
  - Automated package creation

### Features
- ✅ Full UCP protocol version 2026-01-11 support
- ✅ Type-safe models with XML documentation
- ✅ Async/await pattern throughout
- ✅ Configurable HTTP client with custom headers
- ✅ Error handling and detailed exceptions
- ✅ JSON serialization with System.Text.Json
- ✅ .NET 8.0 target framework
- ✅ Apache 2.0 license

### Documentation
- Complete API documentation with examples
- Clean Architecture tutorial
- Getting started guide
- Inline XML documentation for IntelliSense

## [Unreleased]

### Planned
- Unit tests for core library
- Integration tests
- Additional UCP capabilities (Identity Linking, Payment Token Exchange)
- Support for webhooks
- Additional transport implementations (MCP, A2A)
- Performance optimizations
- NuGet package publication
