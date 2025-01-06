using System.ComponentModel.DataAnnotations;
namespace ORM.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public required string Title { get; set; }
        public required int Price { get; set; }
        public int TechniqueId { get; set; }
        public Technique? Technique { get; set; } //fk
        public List<Order>? Orders { get; set; }
    }
}