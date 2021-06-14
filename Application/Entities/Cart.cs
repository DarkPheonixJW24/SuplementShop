namespace SuplementShop.Application.Entities
{
    using System.Collections.Generic;

    public class Cart: Entity
    {
        public int UserId { get; set; }
        public CartStatus CartStatus { get; set; }
        public string SessionId { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
        public virtual User User { get; set; }
    }
}
