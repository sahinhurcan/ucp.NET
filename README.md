# UCP.NET - Universal Commerce Protocol .NET Implementation

🚀 **Production-ready .NET API template** implementing [Universal Commerce Protocol (UCP)](https://ucp.dev/) - Google's new standard for commerce integration.

## What is UCP?

Universal Commerce Protocol (UCP) is a new open standard developed by Google, Shopify, Target, Walmart, and other major e-commerce players to standardize commerce operations across platforms. This template provides a complete UCP REST API implementation for merchants.

## 🎯 Features

- ✅ **Complete UCP REST API** - All standard endpoints implemented
- ✅ **UCP Discovery** - `/.well-known/ucp` merchant profile endpoint
- ✅ **Checkout Sessions** - Create, get, update, complete, cancel
- ✅ **Order Management** - Get and update orders
- ✅ **Strongly-typed models** - Full C# models for all UCP types
- ✅ **TODO-based implementation** - Clear markers for your business logic
- ✅ **No database dependencies** - Use any database you want
- ✅ **Lightweight** - Minimal dependencies, maximum flexibility
- ✅ **Swagger/OpenAPI** - Interactive API documentation

## 🚀 Quick Start

```bash
git clone https://github.com/sahinhurcan/ucp.NET.git
cd ucp.NET/template/UCP.API
dotnet run
```

Navigate to `http://localhost:5000` to see Swagger documentation.

## 📋 Implemented Endpoints

All UCP REST API endpoints per the official specification:

### Discovery
- `GET /.well-known/ucp` - Merchant profile discovery

### Checkout Sessions (`/checkout-sessions`)
- `POST /checkout-sessions` - Create checkout session
- `GET /checkout-sessions/{id}` - Get checkout details
- `PUT /checkout-sessions/{id}` - Update checkout
- `POST /checkout-sessions/{id}/complete` - Complete checkout and create order
- `POST /checkout-sessions/{id}/cancel` - Cancel checkout session

### Orders (`/orders`)
- `GET /orders/{id}` - Get order details
- `PUT /orders/{id}` - Update order

## 💡 Implementation Guide

Each endpoint has clear TODO comments:

```csharp
[HttpPost]
public async Task<IActionResult> CreateCheckout([FromBody] CheckoutCreateRequest request)
{
    // TODO: Implement your business logic here
    // 1. Validate line items against your product catalog
    // 2. Check inventory availability
    // 3. Calculate totals, taxes, and shipping costs
    // 4. Save checkout session to your database
    // 5. Return checkout response with calculated values
    
    throw new NotImplementedException("Implement in your business layer");
}
```

## 🔧 Add Your Database

Choose any database technology:

**Entity Framework Core:**
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

**Dapper:**
```bash
dotnet add package Dapper
dotnet add package Microsoft.Data.SqlClient
```

**MongoDB:**
```bash
dotnet add package MongoDB.Driver
```

Then implement the TODO sections!

## 📚 UCP Models Included

All UCP protocol models in `UCP.NET` library:

- `CheckoutCreateRequest` / `CheckoutUpdateRequest` / `CheckoutResponse`
- `LineItem` / `LineItemResponse`
- `Payment` / `PaymentResponse`
- `Fulfillment` / `FulfillmentResponse`
- `Order` / `OrderSummary`
- `Buyer` / `BuyerInfo`
- `Discount` / `DiscountApplication`
- And many more...

## 🎓 Example Flow

1. **Platform discovers merchant capabilities**
   ```
   GET /.well-known/ucp
   → Merchant profile with capabilities
   ```

2. **Create checkout session**
   ```
   POST /checkout-sessions
   {
     "line_items": [...],
     "currency": "USD",
     "buyer": {...},
     "payment": {...}
   }
   → Checkout ID and details
   ```

3. **Update with payment/shipping**
   ```
   PUT /checkout-sessions/{id}
   {
     "payment": {...},
     "fulfillment": {...}
   }
   → Updated checkout
   ```

4. **Complete checkout**
   ```
   POST /checkout-sessions/{id}/complete
   → Order created
   ```

5. **Check order status**
   ```
   GET /orders/{id}
   → Order details with fulfillment status
   ```

## 🏗️ Project Structure

```
ucp.NET/
├── src/
│   └── UCP.NET/              # UCP Protocol Library
│       ├── Models/           # All UCP data models
│       ├── Client/           # HTTP client (for calling other UCP APIs)
│       └── Configuration/    # Configuration options
└── template/
    └── UCP.API/             # Your API Implementation
        ├── Controllers/
        │   ├── CheckoutController.cs   # Checkout endpoints
        │   ├── OrderController.cs      # Order endpoints
        │   └── DiscoveryController.cs  # UCP discovery
        ├── Program.cs                  # App configuration
        └── appsettings.json            # Your settings
```

## 🔗 Learn More

- **UCP Protocol**: https://ucp.dev/
- **UCP Specification**: https://github.com/Universal-Commerce-Protocol
- **Python SDK**: https://github.com/Universal-Commerce-Protocol/python-sdk
- **Sample Implementations**: https://github.com/Universal-Commerce-Protocol/samples

## 📄 License

Apache License 2.0

---

**Build UCP-compliant commerce APIs for the future!** 🚀
