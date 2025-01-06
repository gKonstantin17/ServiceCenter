namespace Domain.DTO
{
    public class Ordered_productDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public required string Title { get; set; }
        public required int Price { get; set; }
        public required int Quantity { get; set; }

        public int? SupplyId { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
}
