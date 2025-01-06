using System.ComponentModel.DataAnnotations;
namespace ORM.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }

        public required string Fullname { get; set; }
        public required string Phone { get; set; }
        public required string Job_title { get; set; }

        public List<Order>? Orders { get; set; }
 
    }
}