namespace Domain.Interfaces;

using Domain.Entities;

public interface IShoppingCartRepository
{
    Task<ShoppingCart?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<ShoppingCart?> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<ShoppingCart> CreateAsync(ShoppingCart cart, CancellationToken cancellationToken = default);
    Task UpdateAsync(ShoppingCart cart, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}
