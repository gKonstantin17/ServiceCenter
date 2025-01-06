using ORM.Models;

namespace ORM.DTO.OrderDto
{
    public class OrderCreateDto
    {
        public DateTime? OrderDate { get; set; }
        public DateTime? Deadline { get; set; }
        public required string Status { get; set; }
        public int? ProductQty { get; set; }

        public int? ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProductId { get; set; }
        public int? ServiceId { get; set; }
    }
}
