namespace ORM.DTO.ProductDto
{
    public class ProductCreateDto
    {
        public required string Title { get; set; }
        public required int Price { get; set; }
        public required int Quantity { get; set; }
        public string? ImgLink { get; set; }
        public int Ordered_productId { get; set; }
    }
}
