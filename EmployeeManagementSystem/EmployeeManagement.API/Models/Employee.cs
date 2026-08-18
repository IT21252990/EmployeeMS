namespace EmployeeManagement.API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public decimal BasicSalary { get; set; }
        public string? UserId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ApplicationUser? User { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        public ICollection<Payslip> Payslips { get; set; } = new List<Payslip>();
    }
}