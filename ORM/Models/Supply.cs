using System.ComponentModel.DataAnnotations;
namespace ORM.Models
{
    public class Supply
    {
        [Key]
        public int Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }

        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        public List<Ordered_product>? Ordered_products { get; set; }

    }
}