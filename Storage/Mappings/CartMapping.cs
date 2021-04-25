namespace SuplementShop.Persistence.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Newtonsoft.Json;
    using SuplementShop.Application.Entities;
    using System.Collections.Generic;

    

    public class CartMapping : IEntityTypeConfiguration<Cart>
    {
       public void Confgigure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId).IsRequired();

            //because this was a list im not sure its correct
            builder.Property(x => x.CartItems);

            builder.Property(x => x.CartStatus).IsRequired();
               
                           
        }
    }
}
