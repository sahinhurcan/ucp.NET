# UCP.NET - .NET Clean Architecture Template

A production-ready .NET solution template implementing Clean Architecture with CQRS pattern using MediatR. Perfect for building scalable, maintainable APIs and microservices.

## 🎯 What's Inside

This template provides a complete Clean Architecture structure:

- **Domain Layer** - Business entities and repository interfaces
- **Application Layer** - Use cases with MediatR CQRS pattern
- **Infrastructure Layer** - Data access and external service integrations
- **API Layer** - ASP.NET Core Web API with Swagger

## 🚀 Quick Start

### Option 1: Use the Template

```bash
git clone https://github.com/sahinhurcan/ucp.NET.git
cd ucp.NET/template
dotnet restore
dotnet build
```

### Option 2: Copy to Your Project

Copy the `template` folder to your desired location and rename it:

```bash
cp -r template/ ../MyAwesomeProject/
cd ../MyAwesomeProject
```

## 📁 Project Structure

```
template/
├── src/
│   ├── Domain/              # Core business logic
│   │   ├── Entities/        # Business entities
│   │   ├── Interfaces/      # Repository interfaces
│   │   └── Common/          # Shared domain types
│   ├── Application/         # Use cases & business rules
│   │   ├── UseCases/        # CQRS Commands & Queries
│   │   └── DTOs/            # Data Transfer Objects
│   ├── Infrastructure/      # External concerns
│   │   ├── Repositories/    # Data access implementations
│   │   └── DependencyInjection/
│   └── API/                 # Web API
│       ├── Controllers/     # API endpoints
│       └── Program.cs       # App configuration
└── UCP.Template.sln
```

## 🔧 Getting Started

### 1. Implement Your Database Layer

The template comes with TODO markers for database implementation. Choose your preferred technology:

#### Entity Framework Core (SQL Server)
```bash
cd src/Infrastructure
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Then implement repositories in `Infrastructure/Repositories/`. See `Infrastructure/Repositories/README.md` for examples.

#### Dapper
```bash
cd src/Infrastructure
dotnet add package Dapper
dotnet add package Microsoft.Data.SqlClient
```

#### MongoDB
```bash
cd src/Infrastructure
dotnet add package MongoDB.Driver
```

### 2. Configure Dependency Injection

Update `Infrastructure/DependencyInjection/ServiceCollectionExtensions.cs`:

```csharp
public static IServiceCollection AddInfrastructure(this IServiceCollection services)
{
    // Register your DbContext
    services.AddDbContext<YourDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    // Register repositories
    services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
    services.AddScoped<IOrderRepository, OrderRepository>();

    return services;
}
```

### 3. Run the Application

```bash
cd src/API
dotnet run
```

Navigate to `https://localhost:5001/swagger` to see the API documentation.

## 📝 Core Features

### ✅ Clean Architecture
- Clear separation of concerns
- Independence from frameworks
- Testable business logic
- Flexible and maintainable

### ✅ CQRS Pattern with MediatR
- Separate read and write operations
- Decoupled command/query handlers
- Easy to test and extend

### ✅ Domain-Driven Design
- Rich domain entities
- Repository pattern
- Clear business rules

### ✅ RESTful API
- ASP.NET Core Web API
- Swagger/OpenAPI documentation
- Proper HTTP status codes

## 🎓 Example Use Cases Included

The template includes example implementations:

1. **Create Checkout** - Initialize a shopping cart
2. **Get Cart** - Retrieve cart details
3. **Add Item to Cart** - Add products with automatic calculation

Extend or replace these with your own business logic!

## 🛠️ Customization

### Add New Use Case

1. Create command/query in `Application/UseCases/`
2. Create handler implementing `IRequestHandler<TRequest, TResponse>`
3. Add endpoint in `API/Controllers/`

Example:

```csharp
// Application/UseCases/Products/Commands/CreateProductCommand.cs
public record CreateProductCommand(string Name, decimal Price) : IRequest<ProductDto>;

// Application/UseCases/Products/Commands/CreateProductCommandHandler.cs
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken ct)
    {
        // Your business logic here
    }
}
```

### Add External API Integration

1. Create interface in `Application/`
2. Implement in `Infrastructure/`
3. Register in DI container

## 📚 Technology Stack

- .NET 8.0
- ASP.NET Core Web API
- MediatR (CQRS)
- Swagger/OpenAPI
- No database dependencies (bring your own!)

## 🤝 Contributing

Feel free to fork and customize for your needs. This is a template - make it yours!

## 📄 License

Apache License 2.0 - See [LICENSE](LICENSE) file

## 🙏 Credits

Built with Clean Architecture principles by Robert C. Martin and CQRS pattern.

---

**Ready to build something awesome?** Start coding! 🚀
