namespace ORM.DTO.OrderDto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? Deadline { get; set; }
        public string? Status { get; set; }
        public int? ProductQty { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int? ProductId { get; set; }
        public int? ServiceId { get; set; }
    }
}
