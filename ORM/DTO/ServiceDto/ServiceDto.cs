namespace ORM.DTO.ServiceDto
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public string? Title { get; set; }
        public int? Price { get; set; }
        public int? TechniqueId { get; set; }
    }
}
