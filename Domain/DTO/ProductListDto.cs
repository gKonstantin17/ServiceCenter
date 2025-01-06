namespace Domain.DTO
{
    public class ProductListDto
    {
        public int ClientId { get; set; }
        public required List<ProductBuyDto> Products { get; set; }
        

    }
}
