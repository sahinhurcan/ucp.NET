# Repository Implementations

This folder is where you implement your data access layer.

## Quick Start

1. **Choose your data access technology:**
   - Entity Framework Core (SQL Server, PostgreSQL, MySQL, etc.)
   - Dapper
   - MongoDB
   - In-memory (for testing)
   - Any other data access library

2. **Implement the interfaces from Domain layer:**
   - `IShoppingCartRepository`
   - `IOrderRepository`

3. **Register your implementations in `DependencyInjection/ServiceCollectionExtensions.cs`**

## Example: Entity Framework Core

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

```csharp
public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly YourDbContext _context;
    
    public ShoppingCartRepository(YourDbContext context)
    {
        _context = context;
    }
    
    public async Task<ShoppingCart?> GetByIdAsync(string id, CancellationToken ct)
    {
        return await _context.ShoppingCarts.FindAsync(new object[] { id }, ct);
    }
    
    // Implement other methods...
}
```

## Example: Dapper

```bash
dotnet add package Dapper
dotnet add package Microsoft.Data.SqlClient
```

```csharp
public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly IDbConnection _connection;
    
    public async Task<ShoppingCart?> GetByIdAsync(string id, CancellationToken ct)
    {
        const string sql = "SELECT * FROM ShoppingCarts WHERE Id = @Id";
        return await _connection.QuerySingleOrDefaultAsync<ShoppingCart>(sql, new { Id = id });
    }
}
```

## Example: In-Memory (for development/testing)

```csharp
public class InMemoryShoppingCartRepository : IShoppingCartRepository
{
    private readonly ConcurrentDictionary<string, ShoppingCart> _store = new();
    
    public Task<ShoppingCart?> GetByIdAsync(string id, CancellationToken ct)
    {
        _store.TryGetValue(id, out var cart);
        return Task.FromResult(cart);
    }
    
    // Implement other methods...
}
```

Choose what works best for your project!
