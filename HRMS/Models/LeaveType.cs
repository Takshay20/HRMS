using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }
        [Required]
        [StringLength(100)]
        public string LeaveTypeName { get; set; } = string.Empty;
        public int MaxDaysAllowed { get; set; }
    }
}
