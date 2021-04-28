namespace SuplementShop.Application.Entities
{
    public class CartItem : Entity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public int Count { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
