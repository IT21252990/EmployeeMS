using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.API.Models;

namespace EmployeeManagement.API.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAllAsync(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Seed in order (dependencies)
            await SeedRolesAsync(roleManager);
            await SeedUsersAsync(userManager, context);
            await SeedDepartmentsAsync(context);
            await SeedEmployeesAsync(context, userManager);
            await SeedLeaveTypesAsync(context);
            await SeedLeaveRequestsAsync(context);
            await SeedPayslipsAsync(context);
            await SeedNotificationsAsync(context);
        }

        #region Roles Seeding
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "HR", "Employee" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        #endregion

        #region Users Seeding
        public static async Task SeedUsersAsync(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            var users = new List<(ApplicationUser user, string password, string role)>
            {
                // Admin User
                (
                    new ApplicationUser
                    {
                        Id = "admin-user-id-001",
                        UserName = "admin@employeemanagement.com",
                        Email = "admin@employeemanagement.com",
                        FullName = "System Administrator",
                        EmailConfirmed = true,
                        NormalizedEmail = "ADMIN@EMPLOYEEMANAGEMENT.COM",
                        NormalizedUserName = "ADMIN@EMPLOYEEMANAGEMENT.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Admin@123456",
                    "Admin"
                ),
                // HR Users
                (
                    new ApplicationUser
                    {
                        Id = "hr-user-id-001",
                        UserName = "hr@employeemanagement.com",
                        Email = "hr@employeemanagement.com",
                        FullName = "HR Manager",
                        EmailConfirmed = true,
                        NormalizedEmail = "HR@EMPLOYEEMANAGEMENT.COM",
                        NormalizedUserName = "HR@EMPLOYEEMANAGEMENT.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "HR@123456",
                    "HR"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "hr-user-id-002",
                        UserName = "hr2@employeemanagement.com",
                        Email = "hr2@employeemanagement.com",
                        FullName = "HR Specialist",
                        EmailConfirmed = true,
                        NormalizedEmail = "HR2@EMPLOYEEMANAGEMENT.COM",
                        NormalizedUserName = "HR2@EMPLOYEEMANAGEMENT.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "HR@123456",
                    "HR"
                ),
                // Employee Users (will be linked to Employee records later)
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-001",
                        UserName = "john.smith@company.com",
                        Email = "john.smith@company.com",
                        FullName = "John Smith",
                        EmailConfirmed = true,
                        NormalizedEmail = "JOHN.SMITH@COMPANY.COM",
                        NormalizedUserName = "JOHN.SMITH@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-002",
                        UserName = "sarah.lee@company.com",
                        Email = "sarah.lee@company.com",
                        FullName = "Sarah Lee",
                        EmailConfirmed = true,
                        NormalizedEmail = "SARAH.LEE@COMPANY.COM",
                        NormalizedUserName = "SARAH.LEE@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-003",
                        UserName = "david.kim@company.com",
                        Email = "david.kim@company.com",
                        FullName = "David Kim",
                        EmailConfirmed = true,
                        NormalizedEmail = "DAVID.KIM@COMPANY.COM",
                        NormalizedUserName = "DAVID.KIM@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-004",
                        UserName = "emma.wilson@company.com",
                        Email = "emma.wilson@company.com",
                        FullName = "Emma Wilson",
                        EmailConfirmed = true,
                        NormalizedEmail = "EMMA.WILSON@COMPANY.COM",
                        NormalizedUserName = "EMMA.WILSON@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-005",
                        UserName = "michael.brown@company.com",
                        Email = "michael.brown@company.com",
                        FullName = "Michael Brown",
                        EmailConfirmed = true,
                        NormalizedEmail = "MICHAEL.BROWN@COMPANY.COM",
                        NormalizedUserName = "MICHAEL.BROWN@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-006",
                        UserName = "jessica.taylor@company.com",
                        Email = "jessica.taylor@company.com",
                        FullName = "Jessica Taylor",
                        EmailConfirmed = true,
                        NormalizedEmail = "JESSICA.TAYLOR@COMPANY.COM",
                        NormalizedUserName = "JESSICA.TAYLOR@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-007",
                        UserName = "robert.davis@company.com",
                        Email = "robert.davis@company.com",
                        FullName = "Robert Davis",
                        EmailConfirmed = true,
                        NormalizedEmail = "ROBERT.DAVIS@COMPANY.COM",
                        NormalizedUserName = "ROBERT.DAVIS@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-008",
                        UserName = "lisa.chen@company.com",
                        Email = "lisa.chen@company.com",
                        FullName = "Lisa Chen",
                        EmailConfirmed = true,
                        NormalizedEmail = "LISA.CHEN@COMPANY.COM",
                        NormalizedUserName = "LISA.CHEN@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-009",
                        UserName = "james.martinez@company.com",
                        Email = "james.martinez@company.com",
                        FullName = "James Martinez",
                        EmailConfirmed = true,
                        NormalizedEmail = "JAMES.MARTINEZ@COMPANY.COM",
                        NormalizedUserName = "JAMES.MARTINEZ@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-010",
                        UserName = "maria.garcia@company.com",
                        Email = "maria.garcia@company.com",
                        FullName = "Maria Garcia",
                        EmailConfirmed = true,
                        NormalizedEmail = "MARIA.GARCIA@COMPANY.COM",
                        NormalizedUserName = "MARIA.GARCIA@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-011",
                        UserName = "thomas.anderson@company.com",
                        Email = "thomas.anderson@company.com",
                        FullName = "Thomas Anderson",
                        EmailConfirmed = true,
                        NormalizedEmail = "THOMAS.ANDERSON@COMPANY.COM",
                        NormalizedUserName = "THOMAS.ANDERSON@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                ),
                (
                    new ApplicationUser
                    {
                        Id = "emp-user-id-012",
                        UserName = "patricia.jackson@company.com",
                        Email = "patricia.jackson@company.com",
                        FullName = "Patricia Jackson",
                        EmailConfirmed = true,
                        NormalizedEmail = "PATRICIA.JACKSON@COMPANY.COM",
                        NormalizedUserName = "PATRICIA.JACKSON@COMPANY.COM",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    "Employee@123",
                    "Employee"
                )
            };

            foreach (var (user, password, role) in users)
            {
                var existingUser = await userManager.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                    else
                    {
                        Console.WriteLine($"Failed to create user {user.Email}: {string.Join(", ", result.Errors)}");
                    }
                }
            }
        }
        #endregion

        #region Departments Seeding
        public static async Task SeedDepartmentsAsync(ApplicationDbContext context)
        {
            if (!await context.Departments.AnyAsync())
            {
                var departments = new[]
                {
                    new Department 
                    { 
                        Id = 1,
                        Name = "Human Resources", 
                        Description = "HR Department - Manages employee relations, recruitment, and benefits",
                        IsActive = true,
                        CreatedAt = new DateTime(2026, 1, 1)
                    },
                    new Department 
                    { 
                        Id = 2,
                        Name = "Finance", 
                        Description = "Finance Department - Handles accounting, payroll, and budgeting",
                        IsActive = true,
                        CreatedAt = new DateTime(2026, 1, 1)
                    },
                    new Department 
                    { 
                        Id = 3,
                        Name = "IT", 
                        Description = "Information Technology - Manages systems, infrastructure, and development",
                        IsActive = true,
                        CreatedAt = new DateTime(2026, 1, 1)
                    },
                    new Department 
                    { 
                        Id = 4,
                        Name = "Marketing", 
                        Description = "Marketing Department - Handles campaigns, branding, and communications",
                        IsActive = true,
                        CreatedAt = new DateTime(2026, 1, 1)
                    },
                    new Department 
                    { 
                        Id = 5,
                        Name = "Sales", 
                        Description = "Sales Department - Manages client relationships and revenue generation",
                        IsActive = true,
                        CreatedAt = new DateTime(2026, 1, 1)
                    },
                    new Department 
                    { 
                        Id = 6,
                        Name = "Operations", 
                        Description = "Operations Department - Manages day-to-day business operations",
                        IsActive = true,
                        CreatedAt = new DateTime(2026, 1, 1)
                    },
                    new Department 
                    { 
                        Id = 7,
                        Name = "Management", 
                        Description = "Executive Management - C-level executives and senior leadership",
                        IsActive = true,
                        CreatedAt = new DateTime(2026, 1, 1)
                    }
                };

                await context.Departments.AddRangeAsync(departments);
                await context.SaveChangesAsync();
            }
        }
        #endregion

        #region Employees Seeding
        public static async Task SeedEmployeesAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            if (!await context.Employees.AnyAsync())
            {
                var employees = new[]
                {
                    new Employee
                    {
                        Id = 1,
                        EmployeeNumber = "EMP202601001",
                        FirstName = "John",
                        LastName = "Smith",
                        Email = "john.smith@company.com",
                        PhoneNumber = "+1-555-0101",
                        DateOfBirth = new DateTime(1990, 5, 15),
                        JoiningDate = new DateTime(2020, 1, 1),
                        JobTitle = "Senior Software Engineer",
                        BasicSalary = 85000.00m,
                        DepartmentId = 3,
                        UserId = "emp-user-id-001",
                        IsActive = true,
                        CreatedAt = new DateTime(2020, 1, 1)
                    },
                    new Employee
                    {
                        Id = 2,
                        EmployeeNumber = "EMP202601002",
                        FirstName = "Sarah",
                        LastName = "Lee",
                        Email = "sarah.lee@company.com",
                        PhoneNumber = "+1-555-0102",
                        DateOfBirth = new DateTime(1988, 8, 22),
                        JoiningDate = new DateTime(2019, 6, 15),
                        JobTitle = "HR Manager",
                        BasicSalary = 75000.00m,
                        DepartmentId = 1,
                        UserId = "emp-user-id-002",
                        IsActive = true,
                        CreatedAt = new DateTime(2019, 6, 15)
                    },
                    new Employee
                    {
                        Id = 3,
                        EmployeeNumber = "EMP202601003",
                        FirstName = "David",
                        LastName = "Kim",
                        Email = "david.kim@company.com",
                        PhoneNumber = "+1-555-0103",
                        DateOfBirth = new DateTime(1992, 3, 10),
                        JoiningDate = new DateTime(2021, 2, 1),
                        JobTitle = "Financial Analyst",
                        BasicSalary = 65000.00m,
                        DepartmentId = 2,
                        UserId = "emp-user-id-003",
                        IsActive = true,
                        CreatedAt = new DateTime(2021, 2, 1)
                    },
                    new Employee
                    {
                        Id = 4,
                        EmployeeNumber = "EMP202601004",
                        FirstName = "Emma",
                        LastName = "Wilson",
                        Email = "emma.wilson@company.com",
                        PhoneNumber = "+1-555-0104",
                        DateOfBirth = new DateTime(1991, 11, 28),
                        JoiningDate = new DateTime(2020, 7, 1),
                        JobTitle = "Marketing Specialist",
                        BasicSalary = 60000.00m,
                        DepartmentId = 4,
                        UserId = "emp-user-id-004",
                        IsActive = true,
                        CreatedAt = new DateTime(2020, 7, 1)
                    },
                    new Employee
                    {
                        Id = 5,
                        EmployeeNumber = "EMP202601005",
                        FirstName = "Michael",
                        LastName = "Brown",
                        Email = "michael.brown@company.com",
                        PhoneNumber = "+1-555-0105",
                        DateOfBirth = new DateTime(1987, 6, 18),
                        JoiningDate = new DateTime(2018, 10, 1),
                        JobTitle = "Sales Director",
                        BasicSalary = 95000.00m,
                        DepartmentId = 5,
                        UserId = "emp-user-id-005",
                        IsActive = true,
                        CreatedAt = new DateTime(2018, 10, 1)
                    },
                    new Employee
                    {
                        Id = 6,
                        EmployeeNumber = "EMP202601006",
                        FirstName = "Jessica",
                        LastName = "Taylor",
                        Email = "jessica.taylor@company.com",
                        PhoneNumber = "+1-555-0106",
                        DateOfBirth = new DateTime(1993, 9, 5),
                        JoiningDate = new DateTime(2021, 8, 15),
                        JobTitle = "DevOps Engineer",
                        BasicSalary = 72000.00m,
                        DepartmentId = 3,
                        UserId = "emp-user-id-006",
                        IsActive = true,
                        CreatedAt = new DateTime(2021, 8, 15)
                    },
                    new Employee
                    {
                        Id = 7,
                        EmployeeNumber = "EMP202601007",
                        FirstName = "Robert",
                        LastName = "Davis",
                        Email = "robert.davis@company.com",
                        PhoneNumber = "+1-555-0107",
                        DateOfBirth = new DateTime(1985, 12, 12),
                        JoiningDate = new DateTime(2017, 4, 1),
                        JobTitle = "Operations Manager",
                        BasicSalary = 82000.00m,
                        DepartmentId = 6,
                        UserId = "emp-user-id-007",
                        IsActive = true,
                        CreatedAt = new DateTime(2017, 4, 1)
                    },
                    new Employee
                    {
                        Id = 8,
                        EmployeeNumber = "EMP202601008",
                        FirstName = "Lisa",
                        LastName = "Chen",
                        Email = "lisa.chen@company.com",
                        PhoneNumber = "+1-555-0108",
                        DateOfBirth = new DateTime(1990, 7, 20),
                        JoiningDate = new DateTime(2020, 9, 1),
                        JobTitle = "UI/UX Designer",
                        BasicSalary = 68000.00m,
                        DepartmentId = 4,
                        UserId = "emp-user-id-008",
                        IsActive = true,
                        CreatedAt = new DateTime(2020, 9, 1)
                    },
                    new Employee
                    {
                        Id = 9,
                        EmployeeNumber = "EMP202601009",
                        FirstName = "James",
                        LastName = "Martinez",
                        Email = "james.martinez@company.com",
                        PhoneNumber = "+1-555-0109",
                        DateOfBirth = new DateTime(1989, 4, 25),
                        JoiningDate = new DateTime(2019, 11, 1),
                        JobTitle = "Accountant",
                        BasicSalary = 58000.00m,
                        DepartmentId = 2,
                        UserId = "emp-user-id-009",
                        IsActive = true,
                        CreatedAt = new DateTime(2019, 11, 1)
                    },
                    new Employee
                    {
                        Id = 10,
                        EmployeeNumber = "EMP202601010",
                        FirstName = "Maria",
                        LastName = "Garcia",
                        Email = "maria.garcia@company.com",
                        PhoneNumber = "+1-555-0110",
                        DateOfBirth = new DateTime(1994, 2, 14),
                        JoiningDate = new DateTime(2022, 1, 1),
                        JobTitle = "Junior Developer",
                        BasicSalary = 55000.00m,
                        DepartmentId = 3,
                        UserId = "emp-user-id-010",
                        IsActive = true,
                        CreatedAt = new DateTime(2022, 1, 1)
                    },
                    new Employee
                    {
                        Id = 11,
                        EmployeeNumber = "EMP202601011",
                        FirstName = "Thomas",
                        LastName = "Anderson",
                        Email = "thomas.anderson@company.com",
                        PhoneNumber = "+1-555-0111",
                        DateOfBirth = new DateTime(1986, 10, 8),
                        JoiningDate = new DateTime(2018, 3, 1),
                        JobTitle = "Sales Representative",
                        BasicSalary = 52000.00m,
                        DepartmentId = 5,
                        UserId = "emp-user-id-011",
                        IsActive = false,
                        CreatedAt = new DateTime(2018, 3, 1)
                    },
                    new Employee
                    {
                        Id = 12,
                        EmployeeNumber = "EMP202601012",
                        FirstName = "Patricia",
                        LastName = "Jackson",
                        Email = "patricia.jackson@company.com",
                        PhoneNumber = "+1-555-0112",
                        DateOfBirth = new DateTime(1992, 12, 1),
                        JoiningDate = new DateTime(2021, 6, 1),
                        JobTitle = "HR Coordinator",
                        BasicSalary = 48000.00m,
                        DepartmentId = 1,
                        UserId = "emp-user-id-012",
                        IsActive = true,
                        CreatedAt = new DateTime(2021, 6, 1)
                    }
                };

                await context.Employees.AddRangeAsync(employees);
                await context.SaveChangesAsync();

                // Update ApplicationUser with EmployeeId
                foreach (var employee in employees)
                {
                    if (!string.IsNullOrEmpty(employee.UserId))
                    {
                        var user = await userManager.FindByIdAsync(employee.UserId);
                        if (user != null)
                        {
                            user.EmployeeId = employee.Id;
                            await userManager.UpdateAsync(user);
                        }
                    }
                }
            }
        }
        #endregion

        #region Leave Types Seeding
        public static async Task SeedLeaveTypesAsync(ApplicationDbContext context)
        {
            if (!await context.LeaveTypes.AnyAsync())
            {
                var leaveTypes = new[]
                {
                    new LeaveType { Id = 1, Name = "Annual Leave", DefaultDays = 14, IsActive = true, CreatedAt = new DateTime(2026, 1, 1) },
                    new LeaveType { Id = 2, Name = "Sick Leave", DefaultDays = 10, IsActive = true, CreatedAt = new DateTime(2026, 1, 1) },
                    new LeaveType { Id = 3, Name = "Casual Leave", DefaultDays = 7, IsActive = true, CreatedAt = new DateTime(2026, 1, 1) },
                    new LeaveType { Id = 4, Name = "Maternity Leave", DefaultDays = 90, IsActive = true, CreatedAt = new DateTime(2026, 1, 1) },
                    new LeaveType { Id = 5, Name = "Paternity Leave", DefaultDays = 14, IsActive = true, CreatedAt = new DateTime(2026, 1, 1) },
                    new LeaveType { Id = 6, Name = "Study Leave", DefaultDays = 5, IsActive = true, CreatedAt = new DateTime(2026, 1, 1) },
                    new LeaveType { Id = 7, Name = "No Pay Leave", DefaultDays = 0, IsActive = true, CreatedAt = new DateTime(2026, 1, 1) }
                };

                await context.LeaveTypes.AddRangeAsync(leaveTypes);
                await context.SaveChangesAsync();
            }
        }
        #endregion

        #region Leave Requests Seeding
        public static async Task SeedLeaveRequestsAsync(ApplicationDbContext context)
        {
            if (!await context.LeaveRequests.AnyAsync())
            {
                var hrUser = await context.Users.FirstOrDefaultAsync(u => u.Email == "hr@employeemanagement.com");
                var hrUserId = hrUser?.Id ?? "hr-user-id-001";

                var leaveRequests = new[]
                {
                    new LeaveRequest
                    {
                        EmployeeId = 1,
                        LeaveTypeId = 1,
                        StartDate = new DateTime(2026, 1, 15),
                        EndDate = new DateTime(2026, 1, 17),
                        Reason = "Family vacation",
                        Status = LeaveStatus.Approved,
                        ReviewedBy = hrUserId,
                        ReviewedAt = new DateTime(2026, 1, 10, 10, 0, 0, DateTimeKind.Utc),
                        ReviewComment = "Approved",
                        CreatedAt = new DateTime(2026, 1, 5, 9, 0, 0, DateTimeKind.Utc)
                    },
                    new LeaveRequest
                    {
                        EmployeeId = 2,
                        LeaveTypeId = 2,
                        StartDate = new DateTime(2026, 1, 20),
                        EndDate = new DateTime(2026, 1, 21),
                        Reason = "Flu symptoms",
                        Status = LeaveStatus.Pending,
                        ReviewedBy = null,
                        ReviewedAt = null,
                        ReviewComment = null,
                        CreatedAt = new DateTime(2026, 1, 19, 9, 0, 0, DateTimeKind.Utc)
                    },
                    new LeaveRequest
                    {
                        EmployeeId = 3,
                        LeaveTypeId = 1,
                        StartDate = new DateTime(2026, 2, 1),
                        EndDate = new DateTime(2026, 2, 5),
                        Reason = "Travel abroad",
                        Status = LeaveStatus.Pending,
                        ReviewedBy = null,
                        ReviewedAt = null,
                        ReviewComment = null,
                        CreatedAt = new DateTime(2026, 1, 25, 14, 30, 0, DateTimeKind.Utc)
                    },
                    new LeaveRequest
                    {
                        EmployeeId = 4,
                        LeaveTypeId = 3,
                        StartDate = new DateTime(2026, 1, 25),
                        EndDate = new DateTime(2026, 1, 25),
                        Reason = "Personal appointment",
                        Status = LeaveStatus.Approved,
                        ReviewedBy = hrUserId,
                        ReviewedAt = new DateTime(2026, 1, 23, 14, 30, 0, DateTimeKind.Utc),
                        ReviewComment = "Approved",
                        CreatedAt = new DateTime(2026, 1, 20, 10, 0, 0, DateTimeKind.Utc)
                    },
                    new LeaveRequest
                    {
                        EmployeeId = 5,
                        LeaveTypeId = 1,
                        StartDate = new DateTime(2026, 2, 10),
                        EndDate = new DateTime(2026, 2, 12),
                        Reason = "Family event",
                        Status = LeaveStatus.Rejected,
                        ReviewedBy = hrUserId,
                        ReviewedAt = new DateTime(2026, 2, 5, 9, 0, 0, DateTimeKind.Utc),
                        ReviewComment = "Too many staff on leave during this period",
                        CreatedAt = new DateTime(2026, 2, 1, 11, 0, 0, DateTimeKind.Utc)
                    },
                    new LeaveRequest
                    {
                        EmployeeId = 6,
                        LeaveTypeId = 2,
                        StartDate = new DateTime(2026, 1, 18),
                        EndDate = new DateTime(2026, 1, 19),
                        Reason = "Doctor's appointment",
                        Status = LeaveStatus.Approved,
                        ReviewedBy = hrUserId,
                        ReviewedAt = new DateTime(2026, 1, 17, 16, 0, 0, DateTimeKind.Utc),
                        ReviewComment = "Approved",
                        CreatedAt = new DateTime(2026, 1, 15, 8, 30, 0, DateTimeKind.Utc)
                    },
                    new LeaveRequest
                    {
                        EmployeeId = 7,
                        LeaveTypeId = 4,
                        StartDate = new DateTime(2026, 3, 1),
                        EndDate = new DateTime(2026, 5, 30),
                        Reason = "Maternity leave",
                        Status = LeaveStatus.Pending,
                        ReviewedBy = null,
                        ReviewedAt = null,
                        ReviewComment = null,
                        CreatedAt = new DateTime(2026, 2, 1, 13, 0, 0, DateTimeKind.Utc)
                    },
                    new LeaveRequest
                    {
                        EmployeeId = 8,
                        LeaveTypeId = 3,
                        StartDate = new DateTime(2026, 2, 15),
                        EndDate = new DateTime(2026, 2, 15),
                        Reason = "Personal day",
                        Status = LeaveStatus.Pending,
                        ReviewedBy = null,
                        ReviewedAt = null,
                        ReviewComment = null,
                        CreatedAt = new DateTime(2026, 2, 10, 9, 15, 0, DateTimeKind.Utc)
                    }
                };

                await context.LeaveRequests.AddRangeAsync(leaveRequests);
                await context.SaveChangesAsync();
            }
        }
        #endregion

        #region Payslips Seeding
        public static async Task SeedPayslipsAsync(ApplicationDbContext context)
        {
            if (!await context.Payslips.AnyAsync())
            {
                var payslips = new[]
                {
                    new Payslip
                    {
                        EmployeeId = 1,
                        Year = 2026,
                        Month = 1,
                        BasicSalary = 85000.00m,
                        Allowances = 5000.00m,
                        Deductions = 8500.00m,
                        NetSalary = 81500.00m,
                        GeneratedAt = new DateTime(2026, 1, 31, 10, 0, 0, DateTimeKind.Utc)
                    },
                    new Payslip
                    {
                        EmployeeId = 2,
                        Year = 2026,
                        Month = 1,
                        BasicSalary = 75000.00m,
                        Allowances = 4000.00m,
                        Deductions = 7500.00m,
                        NetSalary = 71500.00m,
                        GeneratedAt = new DateTime(2026, 1, 31, 10, 0, 0, DateTimeKind.Utc)
                    },
                    new Payslip
                    {
                        EmployeeId = 3,
                        Year = 2026,
                        Month = 1,
                        BasicSalary = 65000.00m,
                        Allowances = 3000.00m,
                        Deductions = 6500.00m,
                        NetSalary = 61500.00m,
                        GeneratedAt = new DateTime(2026, 1, 31, 10, 0, 0, DateTimeKind.Utc)
                    },
                    new Payslip
                    {
                        EmployeeId = 4,
                        Year = 2026,
                        Month = 1,
                        BasicSalary = 60000.00m,
                        Allowances = 2500.00m,
                        Deductions = 6000.00m,
                        NetSalary = 56500.00m,
                        GeneratedAt = new DateTime(2026, 1, 31, 10, 0, 0, DateTimeKind.Utc)
                    },
                    new Payslip
                    {
                        EmployeeId = 5,
                        Year = 2026,
                        Month = 1,
                        BasicSalary = 95000.00m,
                        Allowances = 6000.00m,
                        Deductions = 9500.00m,
                        NetSalary = 91500.00m,
                        GeneratedAt = new DateTime(2026, 1, 31, 10, 0, 0, DateTimeKind.Utc)
                    }
                };

                await context.Payslips.AddRangeAsync(payslips);
                await context.SaveChangesAsync();
            }
        }
        #endregion

        #region Notifications Seeding
        public static async Task SeedNotificationsAsync(ApplicationDbContext context)
        {
            if (!await context.Notifications.AnyAsync())
            {
                var notifications = new[]
                {
                    new Notification
                    {
                        UserId = "emp-user-id-001",
                        Title = "Leave Request Approved",
                        Message = "Your annual leave request for January 15-17 has been approved.",
                        IsRead = true,
                        CreatedAt = new DateTime(2026, 1, 10, 10, 5, 0, DateTimeKind.Utc),
                        ReadAt = new DateTime(2026, 1, 10, 11, 0, 0, DateTimeKind.Utc)
                    },
                    new Notification
                    {
                        UserId = "emp-user-id-004",
                        Title = "Leave Request Approved",
                        Message = "Your casual leave request for January 25 has been approved.",
                        IsRead = false,
                        CreatedAt = new DateTime(2026, 1, 23, 14, 35, 0, DateTimeKind.Utc),
                        ReadAt = null
                    },
                    new Notification
                    {
                        UserId = "emp-user-id-001",
                        Title = "Payslip Available",
                        Message = "Your payslip for January 2026 is now available for download.",
                        IsRead = false,
                        CreatedAt = new DateTime(2026, 1, 31, 10, 5, 0, DateTimeKind.Utc),
                        ReadAt = null
                    },
                    new Notification
                    {
                        UserId = "emp-user-id-002",
                        Title = "Leave Request Submitted",
                        Message = "Your sick leave request for January 20-21 has been submitted for approval.",
                        IsRead = false,
                        CreatedAt = new DateTime(2026, 1, 19, 9, 0, 0, DateTimeKind.Utc),
                        ReadAt = null
                    },
                    new Notification
                    {
                        UserId = "emp-user-id-005",
                        Title = "Leave Request Rejected",
                        Message = "Your annual leave request for February 10-12 has been rejected. Reason: Too many staff on leave during this period.",
                        IsRead = false,
                        CreatedAt = new DateTime(2026, 2, 5, 9, 5, 0, DateTimeKind.Utc),
                        ReadAt = null
                    },
                    new Notification
                    {
                        UserId = "emp-user-id-006",
                        Title = "Leave Request Approved",
                        Message = "Your sick leave request for January 18-19 has been approved.",
                        IsRead = false,
                        CreatedAt = new DateTime(2026, 1, 17, 16, 5, 0, DateTimeKind.Utc),
                        ReadAt = null
                    },
                    new Notification
                    {
                        UserId = "emp-user-id-003",
                        Title = "Leave Request Submitted",
                        Message = "Your annual leave request for February 1-5 has been submitted for approval.",
                        IsRead = false,
                        CreatedAt = new DateTime(2026, 1, 25, 14, 35, 0, DateTimeKind.Utc),
                        ReadAt = null
                    }
                };

                await context.Notifications.AddRangeAsync(notifications);
                await context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
