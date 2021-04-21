namespace SuplementShop.Application.Entities
{
    using System.Collections.Generic;

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public List<string> ImagesUrls { get; set; }
        public string Manufacturer { get; set; }
    }
}
