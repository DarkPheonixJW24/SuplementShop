namespace SuplementShop.Application.Requests
{
    public class BuyCartRequest
    {
        public string Token { get; set; }

        public int CartId { get; set; }
    }
}
