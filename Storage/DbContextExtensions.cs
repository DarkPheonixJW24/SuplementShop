namespace SuplementShop.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using SuplementShop.Application.Entities;
    using System.Linq;

    public static class DbContextExtensions
    {
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, T record) where T : Entity
        {
            bool exists = dbSet.AsNoTracking().Any(x => x.Id == record.Id);

            if (exists)
            {
                dbSet.Update(record);
            }
            else
            {
                dbSet.Add(record);
            }
        }
    }
}
