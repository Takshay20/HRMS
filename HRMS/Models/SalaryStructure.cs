using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class SalaryStructure
    {
        [Key]
        public int SalaryStructureId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HRA { get; set; }
        public decimal DA { get; set; }
        public decimal TA { get; set; }
        public decimal Bonus { get; set; }
        public decimal PF { get; set; }
        public decimal Tax { get; set; }
    

    }
}
