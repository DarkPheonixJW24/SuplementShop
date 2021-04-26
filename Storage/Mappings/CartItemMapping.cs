namespace SuplementShop.Persistence.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SuplementShop.Application.Entities;

    public class CartItemMapping : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("Cart");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductName);
            builder.Property(x => x.Price);
            builder.Property(x => x.Count);
            builder.Property(x => x.CartId);
            builder.Property(x => x.ProductId);

            builder.HasOne(x => x.Cart).WithMany(x => x.CartItems).HasForeignKey(x => x.CartId);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
        }
    }
}
