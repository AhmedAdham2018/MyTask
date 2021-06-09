namespace Core.Entities
{
    public class ProductItem : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        
    }
}
