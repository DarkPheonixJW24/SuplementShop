namespace SuplementShop.Application.Services
{
    using SuplementShop.Application.Interfaces;

    public class SeedService
    {
        private readonly ICategoryRepo categoryRepo;
        private readonly IUserRepo userRepo;
        private readonly IProductRepo productRepo;

        public SeedService(ICategoryRepo categoryRepo, IUserRepo userRepo, IProductRepo productRepo)
        {
            this.categoryRepo = categoryRepo;
            this.userRepo = userRepo;
            this.productRepo = productRepo;
        }

        public void FillDb()
        {
            userRepo.FillDb();
            categoryRepo.FillDb();
            productRepo.FillDb();
        }
    }
}
