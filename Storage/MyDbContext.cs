namespace SuplementShop.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using SuplementShop.Persistence.Mappings;

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}
