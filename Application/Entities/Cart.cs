namespace SuplementShop.Application.Entities
{
    using System.Collections.Generic;

    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public CartStatus CartStatus { get; set; }
        public int PaymentId { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
        public virtual User User { get; set; }
    }
}
