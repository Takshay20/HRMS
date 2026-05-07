using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Department
    {
        [Key]
        public int DepartmantId { get; set; }

        [Required]
        public string DepartpartName { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
