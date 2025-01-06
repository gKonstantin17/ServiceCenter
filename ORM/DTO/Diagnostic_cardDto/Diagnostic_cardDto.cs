using ORM.Models;
using System.ComponentModel.DataAnnotations;

namespace ORM.DTO.Diagnostic_cardDto
{
    public class Diagnostic_cardDto
    {
        [Key]
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public string? Desctription { get; set; }
        public int? Price { get; set; }
        public DateTime? Deadline { get; set; }
        public int? TechniqueId { get; set; }
    }
}
