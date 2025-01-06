namespace Domain.DTO
{
    public class TechniqueOrderDto
    {
        public required string Title { get; set; }
        public string? Typetech { get; set; }
        public string? Description { get; set; }
        public int ClientId { get; set; }

    }
}
