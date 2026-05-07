using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class PayRoll
    {
        [Key]
        public int PayRollId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.Now;
    }
}
