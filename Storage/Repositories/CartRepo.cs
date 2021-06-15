namespace SuplementShop.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartRepo : ICartRepo
    {
        private readonly MyDbContext context;

        private DbSet<Cart> Cart => context.Set<Cart>();

        public CartRepo(MyDbContext ctx)
        {
            context = ctx;
        }

        public async Task<Cart> GetCart(int userId, int id)
        {
            return await Cart.Include(x => x.CartItems)
                             .FirstAsync(x => x.Id == id && x.UserId == userId);
        }

        public async Task<Cart> GetCartWithProducts(int userId, int id)
        {
            return await Cart.Include(x => x.CartItems)
                             .ThenInclude(x => x.Product)
                             .FirstAsync(x => x.Id == id && x.UserId == userId);
        }

        public Task<Cart> GetActiveCartForUser(int userId)
        {
            return Cart.Include(x => x.CartItems)
                       .FirstOrDefaultAsync(x => x.UserId == userId && x.CartStatus == CartStatus.Active);
        }

        public Task<List<Cart>> GetAllCartsForUser(int userId)
        {
            return Cart.Include(x => x.CartItems).ToListAsync();
        }

        public async Task<Cart> CreateCart(Cart cart)
        {
            EntityEntry<Cart> newCart = await Cart.AddAsync(cart);
            await context.SaveChangesAsync();
            return newCart.Entity;
        }

        public async Task UpdateCart(Cart cart)
        {
            var entity = context.Entry(cart);

            entity.CurrentValues.SetValues(cart);

            await context.SaveChangesAsync();
        }

        public async Task DeleteCart(int userId, int cartId)
        {
            var e = await GetCart(userId, cartId);

            if (e != null)
            {
                Cart.Remove(e);

                await context.SaveChangesAsync();
            }
        }

        public Task<List<Cart>> GetProcessingCartsForUser(int userId)
        {
            return Cart.Include(x => x.CartItems).Where(x => x.CartStatus == CartStatus.Processing).ToListAsync();
        }
    }
}
