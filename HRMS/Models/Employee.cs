using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(100)]
        public string EmployeeCode { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now;
        [Required]
        [StringLength(250)]
        public string Address { get; set; } = String.Empty;
        [ForeignKey("Department")]
        public int DepartmentId   { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("Designation")]
        public int DesignationId { get; set; }
        public Designation? Designation { get; set; }
        [ForeignKey("Shift")]
        public int ShiftId { get; set; }
        public Shift? Shift { get; set; }
        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }
        public UserAccount? UserAccount { get; set; }

        public decimal BasicSalary { get; set; }
        [Required]
        public string ProfileImage { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
