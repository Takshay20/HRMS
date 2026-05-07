using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [Required]
        public DateTime AttendanceDate { get; set; } = DateTime.Today;
        
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        [StringLength(100)]
        public string? Status { get; set; } = "Present";

        public decimal WorkingHours
        {
            get
            {
                if (CheckInTime.HasValue && CheckOutTime.HasValue)
                {
                    return (decimal)(CheckOutTime.Value - CheckInTime.Value).TotalHours;
                }
                return 0;
            }
        }
    }
}
