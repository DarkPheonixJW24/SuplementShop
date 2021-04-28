namespace SuplementShop.Persistence.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Newtonsoft.Json;
    using SuplementShop.Application.Entities;
    using System.Collections.Generic;

    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.ImagesUrls)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                               v => JsonConvert.DeserializeObject<List<string>>(v)
                               );
            builder.Property(x => x.Manufacturer);
            builder.Property(x => x.CategoryId).IsRequired();

            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
        }
    }
}
