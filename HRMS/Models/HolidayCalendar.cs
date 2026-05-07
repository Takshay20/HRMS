using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class HolidayCalendar
    {
        [Key]
        public int HolidayCalendarId { get; set; }
        [Required]
        [StringLength(100)]
        public string HolidayName { get; set; } = string.Empty;

        public DateTime HolidayDate { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
    }
}
