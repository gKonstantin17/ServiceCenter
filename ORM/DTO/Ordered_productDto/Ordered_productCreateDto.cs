namespace ORM.DTO.Ordered_productDto
{
    public class Ordered_productCreateDto
    {
        public required string Title { get; set; }
        public required int Price { get; set; }
        public required int Quantity { get; set; }
        public required int SupplyId { get; set; }
    }
}
