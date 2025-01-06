namespace Domain.DTO
{
    public class SupplyDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        public List<Ordered_productDto>? Ordered_products { get; set; }
    }
}
