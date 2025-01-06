

namespace Domain.DTO
{
    public class TechniqueDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public required string Title { get; set; }
        public string? Typetech { get; set; }
        public string? Description { get; set; }
        public List<ServiceDto>? Services { get; set; }
        public List<Diagnostic_cardDto>? Diagnostic_cards { get; set; }
    }
}
