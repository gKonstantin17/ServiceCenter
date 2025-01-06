using System.ComponentModel.DataAnnotations;
namespace ORM.Models
{
    public class Diagnostic_card
    {
        [Key]
        public int Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }

        public string? Desctription { get; set; }
        public required int Price { get; set; }
        public required DateTime Deadline { get; set; }
        public int TechniqueId { get; set; }
        public required Technique? Technique { get; set; } // fk
    }
}