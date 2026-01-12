# UCP.NET API Template

This is a ready-to-use Universal Commerce Protocol (UCP) API implementation template.

## What You Get

- ✅ Complete UCP REST API endpoints
- ✅ Strongly-typed request/response models  
- ✅ Swagger/OpenAPI documentation
- ✅ Clear TODO markers for your business logic
- ✅ No database dependencies (use any DB you want)

## Quick Start

```bash
dotnet run
```

Open your browser to `http://localhost:5000` to see the Swagger documentation.

## Implementing Your Business Logic

All controllers have clear TODO comments showing what needs to be implemented:

### CheckoutController
- `CreateCheckout` - Validate products, calculate totals, save to database
- `GetCheckout` - Retrieve checkout from your database
- `UpdateCheckout` - Update line items, payment, or shipping info
- `CompleteCheckout` - Process payment, create order, update inventory

### OrderController
- `GetOrder` - Retrieve order details from database
- `UpdateOrder` - Update order status or fulfillment
- `CancelOrder` - Process refund and restore inventory

## Adding Your Database

Choose your preferred database:

**SQL Server (Entity Framework Core):**
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

**PostgreSQL:**
```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

**MongoDB:**
```bash
dotnet add package MongoDB.Driver
```

**Dapper (lightweight):**
```bash
dotnet add package Dapper
dotnet add package Microsoft.Data.SqlClient
```

Then implement your data access logic in the TODO sections of each controller!

## UCP Protocol

This template implements the Universal Commerce Protocol (UCP):
- https://ucp.dev/
- https://github.com/Universal-Commerce-Protocol

## Next Steps

1. Choose your database and add the NuGet package
2. Implement the TODO sections in Controllers
3. Add your authentication/authorization
4. Configure your app settings
5. Deploy to production!

Ready to build! 🚀
