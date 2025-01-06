namespace ORM.DTO.Diagnostic_cardDto
{
    public class Diagnostic_cardCreateDto
    {
        public string? Desctription { get; set; }
        public int Price { get; set; }
        public DateTime Deadline { get; set; }
        public int? TechniqueId { get; set; }
    }
}
