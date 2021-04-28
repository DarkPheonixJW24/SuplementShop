namespace SuplementShop.Application.Services
{
    using SuplementShop.Application.Interfaces;

    public class SeedService
    {
        private readonly ICategoryRepo categoryRepo;
        private readonly IUserRepo userRepo;

        public SeedService(ICategoryRepo categoryRepo, IUserRepo userRepo)
        {
            this.categoryRepo = categoryRepo;
            this.userRepo = userRepo;
        }

        public void FillDb()
        {
            userRepo.FillDb();
            categoryRepo.FillDb();
        }
    }
}
