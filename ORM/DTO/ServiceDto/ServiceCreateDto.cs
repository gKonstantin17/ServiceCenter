namespace ORM.DTO.ServiceDto
{
    public class ServiceCreateDto
    {
        public required string Title { get; set; }
        public required int Price { get; set; }
        public required int TechniqueId { get; set; }
    }
}
