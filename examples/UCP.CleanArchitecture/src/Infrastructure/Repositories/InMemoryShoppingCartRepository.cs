namespace Infrastructure.Repositories;

using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Concurrent;

public class InMemoryShoppingCartRepository : IShoppingCartRepository
{
    private static readonly ConcurrentDictionary<string, ShoppingCart> _carts = new();

    public Task<ShoppingCart?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        _carts.TryGetValue(id, out var cart);
        return Task.FromResult(cart);
    }

    public Task<ShoppingCart?> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        var cart = _carts.Values.FirstOrDefault(c => c.UserId == userId && c.State == "active");
        return Task.FromResult(cart);
    }

    public Task<ShoppingCart> CreateAsync(ShoppingCart cart, CancellationToken cancellationToken = default)
    {
        _carts[cart.Id] = cart;
        return Task.FromResult(cart);
    }

    public Task UpdateAsync(ShoppingCart cart, CancellationToken cancellationToken = default)
    {
        cart.UpdatedAt = DateTime.UtcNow;
        _carts[cart.Id] = cart;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        _carts.TryRemove(id, out _);
        return Task.CompletedTask;
    }
}
