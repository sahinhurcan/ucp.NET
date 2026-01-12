namespace Infrastructure.Repositories;

using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Concurrent;

public class InMemoryOrderRepository : IOrderRepository
{
    private static readonly ConcurrentDictionary<string, Order> _orders = new();

    public Task<Order?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        _orders.TryGetValue(id, out var order);
        return Task.FromResult(order);
    }

    public Task<List<Order>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        var orders = _orders.Values.Where(o => o.UserId == userId).ToList();
        return Task.FromResult(orders);
    }

    public Task<Order> CreateAsync(Order order, CancellationToken cancellationToken = default)
    {
        _orders[order.Id] = order;
        return Task.FromResult(order);
    }

    public Task UpdateAsync(Order order, CancellationToken cancellationToken = default)
    {
        order.UpdatedAt = DateTime.UtcNow;
        _orders[order.Id] = order;
        return Task.CompletedTask;
    }
}
