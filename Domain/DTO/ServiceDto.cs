namespace Domain.DTO
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public required string Title { get; set; }
        public required int Price { get; set; }

        public required int TechniqueId { get; set; }
        public List<OrderDto>? Orders { get; set; }
    }
}
