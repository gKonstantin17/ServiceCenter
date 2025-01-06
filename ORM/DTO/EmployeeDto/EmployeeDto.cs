namespace ORM.DTO.EmployeeDto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }

        public string? Fullname { get; set; }
        public string? Phone { get; set; }
        public string? Job_title { get; set; }
    }
}
