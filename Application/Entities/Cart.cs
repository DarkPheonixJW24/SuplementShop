namespace SuplementShop.Application.Entities
{
    using System.Collections.Generic;

    public class Cart
    {   
        public string Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
        public string CartStatus { get; set; }
    }
}
