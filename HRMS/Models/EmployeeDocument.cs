using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace HRMS.Models
{
    public class EmployeeDocument
    {
        [Key]
        public int EmployeeDocumentId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee? Employee { get; set; }
        [Required]
        public string DocumentName { get; set; } = string.Empty;
        [Required]
        public String FilePath { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; } = DateTime.Now;

    }
}
