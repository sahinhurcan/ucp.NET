# UCP.NET - Universal Commerce Protocol .NET Implementation

🚀 **Ready-to-use .NET API template** for implementing [Universal Commerce Protocol (UCP)](https://ucp.dev/) in your e-commerce applications.

## What is This?

This is a **production-ready API template** that implements the complete UCP REST API specification. All endpoints are ready with proper request/response models - you just need to implement your own business logic.

## 🎯 Features

- ✅ **Complete UCP REST API** - All checkout and order endpoints
- ✅ **Strongly-typed models** - Full C# models for all UCP types
- ✅ **TODO-based implementation** - Clear markers where you add your business logic
- ✅ **Swagger/OpenAPI** - Interactive API documentation
- ✅ **No database dependencies** - Use any database you want
- ✅ **Lightweight** - Minimal dependencies, maximum flexibility

## 🚀 Quick Start

### Option 1: Clone and Use

```bash
git clone https://github.com/sahinhurcan/ucp.NET.git
cd ucp.NET/template/UCP.API
dotnet run
```

Navigate to `http://localhost:5000` to see Swagger documentation.

### Option 2: Use as Template

```bash
# Copy the template folder to your project
cp -r template/UCP.API ./MyUcpApi
cd MyUcpApi
dotnet run
```

## 📋 Implemented Endpoints

All UCP REST API endpoints are ready:

### Checkout API (`/ucp/v1/checkout`)
- `POST /ucp/v1/checkout` - Create checkout session
- `GET /ucp/v1/checkout/{id}` - Get checkout details
- `PATCH /ucp/v1/checkout/{id}` - Update checkout
- `POST /ucp/v1/checkout/{id}/complete` - Complete checkout and create order

### Order API (`/ucp/v1/orders`)
- `GET /ucp/v1/orders/{id}` - Get order details
- `PATCH /ucp/v1/orders/{id}` - Update order
- `POST /ucp/v1/orders/{id}/cancel` - Cancel order

## 💡 How to Implement Your Business Logic

Each endpoint has clear TODO comments showing what you need to implement:

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

The template is database-agnostic. Add whatever you need:

### Entity Framework Core
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

### Dapper
```bash
dotnet add package Dapper
dotnet add package Microsoft.Data.SqlClient
```

### MongoDB
```bash
dotnet add package MongoDB.Driver
```

Then implement your data access in the TODO sections!

## 📚 UCP Models Included

All UCP protocol models are included in the `UCP.NET` library:

- `CheckoutCreateRequest` / `CheckoutUpdateRequest` / `CheckoutResponse`
- `LineItem` / `LineItemResponse`
- `Payment` / `PaymentResponse`
- `Fulfillment` / `FulfillmentResponse`
- `Order` / `OrderSummary`
- `UcpMetadata`
- And many more...

## 🏗️ Project Structure

```
ucp.NET/
├── src/
│   └── UCP.NET/              # UCP protocol models and types
│       ├── Models/           # All UCP data models
│       ├── Client/           # HTTP client (for calling other UCP APIs)
│       └── Configuration/    # Configuration options
└── template/
    └── UCP.API/             # Your API implementation
        ├── Controllers/      # UCP REST endpoints
        ├── Program.cs        # App configuration
        └── appsettings.json  # Configuration
```

## 🎓 Example Implementation Flow

1. **Customer creates checkout**
   ```
   POST /ucp/v1/checkout
   → You: Validate products, calculate totals, save to DB
   → Return: Checkout ID and details
   ```

2. **Customer updates payment/shipping**
   ```
   PATCH /ucp/v1/checkout/{id}
   → You: Update checkout, recalculate, save to DB
   → Return: Updated checkout
   ```

3. **Customer completes checkout**
   ```
   POST /ucp/v1/checkout/{id}/complete
   → You: Process payment, create order, update inventory
   → Return: Order details
   ```

4. **Retrieve order**
   ```
   GET /ucp/v1/orders/{id}
   → You: Fetch from DB
   → Return: Order with status
   ```

## 🔗 Learn More

- **UCP Protocol**: https://ucp.dev/
- **UCP Spec**: https://github.com/Universal-Commerce-Protocol
- **Python SDK**: https://github.com/Universal-Commerce-Protocol/python-sdk

## 📄 License

Apache License 2.0

---

**Ready to build your UCP-compliant e-commerce API?** Start implementing your business logic now! 🚀
