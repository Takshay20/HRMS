using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }
        [Required]
        public string ShiftName { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }

        public int LateGraceMinutes {  get; set; }
    }
}
