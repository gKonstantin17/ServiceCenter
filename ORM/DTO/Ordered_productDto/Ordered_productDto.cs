using ORM.Models;

namespace ORM.DTO.Ordered_productDto
{
    public class Ordered_productDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public string? Title { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int? SupplyId { get; set; }
    }
}
