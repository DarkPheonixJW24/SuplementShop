namespace SuplementShop.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using System.Threading.Tasks;

    public class CartItemRepo : ICartItemRepo
    {
        private readonly MyDbContext context;

        private DbSet<CartItem> CartItems => context.Set<CartItem>();

        public CartItemRepo(MyDbContext ctx)
        {
            context = ctx;
        }

        public async Task<CartItem> GetCartItemById(int id)
        {
            return await CartItems.FindAsync(id);
        }

        public async Task<CartItem> CreateCartItem(CartItem cartItem)
        {
            EntityEntry<CartItem> newCartItem = await CartItems.AddAsync(cartItem);
            await context.SaveChangesAsync();
            return newCartItem.Entity;
        }

        public async Task UpdateCartItem(CartItem cartItem)
        {
            var entity = context.Entry(cartItem);

            entity.CurrentValues.SetValues(cartItem);

            await context.SaveChangesAsync();
        }

        public async Task DeleteCartItem(int id)
        {
            var e = await GetCartItemById(id);

            if (e != null)
            {
                CartItems.Remove(e);

                await context.SaveChangesAsync();
            }
        }
    }
}
