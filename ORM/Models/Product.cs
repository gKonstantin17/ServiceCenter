using System.ComponentModel.DataAnnotations;
namespace ORM.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }

        public required string Title { get; set; }
        public required int Price { get; set; }
        public required int Quantity { get; set; }
        public string? ImgLink { get; set; }
        public int Ordered_productId { get; set; }
        public Ordered_product? Ordered_product { get; set; } // fk
        public List<Order>? Orders { get; set; }
    }
}