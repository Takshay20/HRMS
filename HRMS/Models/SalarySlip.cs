using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace HRMS.Models
{
    public class SalarySlip
    {
        [Key]
        public int SalarySlipId { get; set; }
        [ForeignKey("PayRoll")]
        public int PayRollId { get; set; }
        public PayRoll? PayRoll { get; set; }
        [Required]
        [StringLength(100)]
        public String SlipNumber { get; set; } = string.Empty;
        [StringLength(100)]
        public string? PdfPath { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.Now;
    }
}
