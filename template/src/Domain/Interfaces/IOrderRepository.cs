namespace Domain.Interfaces;

using Domain.Entities;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<List<Order>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<Order> CreateAsync(Order order, CancellationToken cancellationToken = default);
    Task UpdateAsync(Order order, CancellationToken cancellationToken = default);
}
