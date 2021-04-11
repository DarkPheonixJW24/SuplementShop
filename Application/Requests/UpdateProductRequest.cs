namespace SuplementShop.Application.Requests
{
    using System.Collections.Generic;

    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public List<string> Images { get; set; }
    }
}
