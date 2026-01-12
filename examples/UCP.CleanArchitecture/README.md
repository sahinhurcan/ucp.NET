# UCP Clean Architecture Example

This example demonstrates how to integrate UCP.NET into a Clean Architecture application using MediatR for CQRS pattern implementation.

## Architecture

The solution follows Clean Architecture principles with clear separation of concerns:

```
├── Domain/              # Core business entities and interfaces
├── Application/         # Use cases, DTOs, and MediatR commands/queries
├── Infrastructure/      # UCP client integration and repositories
└── API/                 # ASP.NET Core Web API
```

## Layers

### Domain Layer
Contains the core business entities and repository interfaces:
- `ShoppingCart` - Shopping cart entity
- `Order` - Order entity
- `IShoppingCartRepository` - Repository interface for shopping carts
- `IOrderRepository` - Repository interface for orders

### Application Layer
Contains the business logic implemented as MediatR commands and queries:
- **Commands:**
  - `CreateCheckoutCommand` - Create a new checkout session
  - `AddItemToCartCommand` - Add items to cart
  - `SyncCheckoutWithUcpCommand` - Sync local cart with UCP
  - `CompleteOrderCommand` - Complete checkout and create order
- **Queries:**
  - `GetCartQuery` - Retrieve cart by ID

### Infrastructure Layer
Implements repository interfaces and integrates with UCP:
- `InMemoryShoppingCartRepository` - In-memory storage for carts
- `InMemoryOrderRepository` - In-memory storage for orders
- UCP.NET client configuration

### API Layer
Provides RESTful endpoints:
- `POST /api/checkout` - Create new checkout
- `GET /api/checkout/{id}` - Get checkout by ID
- `POST /api/checkout/{id}/items` - Add item to cart
- `POST /api/checkout/{id}/sync-ucp` - Sync with UCP
- `POST /api/orders/complete?cartId={id}` - Complete order

## Running the Example

1. Configure UCP endpoint in `appsettings.json`:

```json
{
  "UcpClient": {
    "BaseUrl": "https://your-merchant-endpoint.com/ucp",
    "ApiKey": "your-api-key",
    "ProtocolVersion": "2026-01-11"
  }
}
```

2. Run the API:

```bash
cd src/API
dotnet run
```

3. Open Swagger UI at `https://localhost:5001/swagger`

## Example Workflow

1. **Create Checkout:**
```bash
curl -X POST "https://localhost:5001/api/checkout?userId=user123"
```

2. **Add Items to Cart:**
```bash
curl -X POST "https://localhost:5001/api/checkout/{cartId}/items" \
  -H "Content-Type: application/json" \
  -d '{
    "productId": "product-123",
    "name": "Example Product",
    "quantity": 2,
    "unitPrice": 29.99
  }'
```

3. **Sync with UCP:**
```bash
curl -X POST "https://localhost:5001/api/checkout/{cartId}/sync-ucp"
```

4. **Complete Order:**
```bash
curl -X POST "https://localhost:5001/api/orders/complete?cartId={cartId}"
```

## Key Features

### Clean Architecture Benefits
- ✅ **Testability** - Each layer can be tested independently
- ✅ **Maintainability** - Clear separation of concerns
- ✅ **Flexibility** - Easy to swap implementations (e.g., use real database instead of in-memory)

### MediatR Integration
- ✅ **CQRS Pattern** - Separate commands and queries
- ✅ **Decoupling** - Controllers don't depend on concrete implementations
- ✅ **Pipeline Behaviors** - Easy to add cross-cutting concerns

### UCP Integration
- ✅ **Seamless Integration** - UCP client injected via DI
- ✅ **Type Safety** - Strongly-typed models
- ✅ **Async/Await** - Full async support

## Technology Stack

- .NET 8.0
- ASP.NET Core Web API
- MediatR 12.4.1
- UCP.NET (local reference)
- Swagger/OpenAPI

## Next Steps

To use this as a starting point for your own application:

1. Replace in-memory repositories with real database (e.g., Entity Framework Core)
2. Add authentication and authorization
3. Implement validation using FluentValidation
4. Add logging and error handling middleware
5. Implement additional UCP capabilities (payments, fulfillment, etc.)
