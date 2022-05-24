namespace ShopOnline.Api.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int productId { get; set; }
        public int Qty { get; set; }

    }
}
