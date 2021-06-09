namespace Api.Dtos
{
    public class ProductItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SubCategory { get; set; }  
        public string ImageUrl { get; set; }
    }
}