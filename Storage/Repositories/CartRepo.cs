namespace SuplementShop.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using System;
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

       
    }
}
