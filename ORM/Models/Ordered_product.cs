using System.ComponentModel.DataAnnotations;
namespace ORM.Models
{
    public class Ordered_product
    {
        [Key]
        public int Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }

        public required string Title { get; set; }
        public required int Price { get; set; }
        public required int Quantity { get; set; }
        public int SupplyId { get; set; }
        public Supply? Supply { get; set; } // fk
        public List<Product>? Products { get; set; }
    }
}