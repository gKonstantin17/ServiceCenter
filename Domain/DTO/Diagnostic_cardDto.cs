namespace Domain.DTO
{
    public class Diagnostic_cardDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate;
        public DateTime? CreateDate;


        public string? Desctription { get; set; }
        public required int Price { get; set; }
        public DateTime? Deadline { get; set; }

        public required int TechniqueId { get; set; }
    }
}
