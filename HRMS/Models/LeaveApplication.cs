using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class LeaveApplication
    {
        [Key]
        public int LeaveApplicationId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [ForeignKey("LeaveType")]
        public int LeaveTypeId { get; set; }
        public LeaveType? LeaveType { get; set; }

        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        [StringLength(500)]
        public string Reason { get; set; } = string.Empty;
        [StringLength(100)]
        public string Status { get; set; } = "Pending";

        public DateTime AppliedAt { get; set; } = DateTime.Now;

    }
}
