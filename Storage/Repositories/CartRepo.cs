namespace SuplementShop.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CartRepo : ICartRepo
    {
        private readonly MyDbContext context;

        private DbSet<Cart> Cart => context.Set<Cart>();

        public CartRepo(MyDbContext ctx)
        {
            context = ctx;
        }

        public async Task<Cart> GetCart(int id)
        {
            return await Cart.Include(x => x.CartItems).FirstAsync(x => x.Id == id);
        }

        public Task<Cart> GetActiveCartForUser(int userId)
        {
            return Cart.Include(x => x.CartItems).FirstAsync(x => x.UserId == userId && x.CartStatus == CartStatus.Active);
        }

        public Task<List<Cart>> GetAllCartsForUser(int userId)
        {
            return Cart.Include(x => x.CartItems).ToListAsync();
        }

        public async Task CreateCart(Cart cart)
        {
            await Cart.AddAsync(cart);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCart(Cart cart)
        {
            var entity = context.Entry(cart);

            entity.CurrentValues.SetValues(cart);

            await context.SaveChangesAsync();
        }

        public async Task DeleteCart(int cartId)
        {
            var e = await GetCart(cartId);

            if (e != null)
            {
                Cart.Remove(e);

                await context.SaveChangesAsync();
            }
        }
    }
}
