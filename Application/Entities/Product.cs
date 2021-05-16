namespace SuplementShop.Application.Entities
{
    using System.Collections.Generic;

    public class Product : Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public List<string> ImageUrls { get; set; }
        public string Manufacturer { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
