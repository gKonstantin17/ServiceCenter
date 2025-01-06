using System.ComponentModel.DataAnnotations;
namespace ORM.Models
{
    public class Technique
    {
        [Key]
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public required string Title { get; set; }
        public string? Typetech { get; set; }
        public string? Description { get; set; }

        public List<Service>? Services { get; set; }
        public List<Diagnostic_card>? Diagnostic_cards { get; set; }
    }
}