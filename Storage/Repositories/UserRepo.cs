namespace SuplementShop.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using SuplementShop.Application.Entities;
    using SuplementShop.Application.Interfaces;
    using System.Threading.Tasks;

    public class UserRepo : IUserRepo
    {
        private readonly MyDbContext context;

        private DbSet<User> Users => context.Set<User>();

        public UserRepo(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateUserAsync(User user)
        {
            EntityEntry<User> result = await Users.AddAsync(user);

            await context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email == email);
        }

        public void FillDb()
        {
            Users.AddOrUpdate(new User
            {
                Id = 1,
                Email = "admin@mail.com",
                FullName = "IceAdmin",
                Password = "password",
                Role = Role.Admin
            });

            Users.AddOrUpdate(new User
            {
                Id = 2,
                Email = "user@mail.com",
                FullName = "IceMan",
                Password = "password",
                Role = Role.Admin
            });

            context.SaveChanges();
        }
    }
}
