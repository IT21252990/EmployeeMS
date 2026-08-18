using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}