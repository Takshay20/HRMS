using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; } = string.Empty;

        [Required]
        public string? Description { get; set; }
    }
}
