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
- `CancelCheckout` - Cancel checkout and release reserved inventory

### ProfileController
- `CreateProfile` - Create buyer profile with identity and saved data
- `GetProfile` - Retrieve buyer profile from database
- `UpdateProfile` - Update buyer identity, payment methods, addresses
- `DeleteProfile` - Delete buyer profile (comply with privacy regulations)
- `AddPaymentMethod` - Tokenize and save payment method
- `RemovePaymentMethod` - Remove saved payment method
- `AddAddress` - Save shipping/billing address
- `RemoveAddress` - Remove saved address

### OrderController
- `GetOrder` - Retrieve order details from database
- `UpdateOrder` - Update order status or fulfillment

## Implementation Options

The TODO sections in controllers can be implemented in many ways:

- **Database storage** - SQL Server, PostgreSQL, MongoDB, etc.
- **External API calls** - Call your existing backend services
- **In-memory storage** - For testing or simple scenarios
- **Microservices** - Integrate with your service architecture
- **Hybrid approach** - Combine multiple strategies

There are no dependencies or assumptions - implement it however fits your architecture!

## UCP Protocol

This template implements the Universal Commerce Protocol (UCP):
- https://ucp.dev/
- https://github.com/Universal-Commerce-Protocol

## Next Steps

1. Implement the TODO sections in Controllers with your business logic
2. Add your authentication/authorization if needed
3. Configure your app settings
4. Test with Swagger UI
5. Deploy to production!

Ready to build! 🚀
