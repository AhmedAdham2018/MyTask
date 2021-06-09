namespace Core.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
            
        }
        public ProductItemOrdered(int productItemId, string productName, string imageUrl)
        {
            this.ProductItemId = productItemId;
            this.ProductName = productName;
            this.ImageUrl = imageUrl;

        }
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
    }
}
