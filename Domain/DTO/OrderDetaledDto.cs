namespace Domain.DTO
{
    public class OrderDetaledDto
    {
        //order
        public required OrderDto Order { get; set; }
        public required EmployeeDto Employee { get; set; }
        public ProductDto? Product { get; set; }
        public ServiceDto? Service { get; set; }
        public TechniqueDto? Technique { get; set; }
       
    }
}
