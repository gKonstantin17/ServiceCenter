using System.ComponentModel.DataAnnotations;
namespace ORM.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        
        public DateTime? OrderDate { get; set; }
        public DateTime? Deadline { get; set; }
        public required string Status { get; set; }
        public int? ProductQty { get; set; }

        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}