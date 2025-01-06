using ORM.Models;

namespace ORM.DTO.ProductDto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public string? Title { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string? ImgLink { get; set; }
        public int? Ordered_productId { get; set; }
    }
}
