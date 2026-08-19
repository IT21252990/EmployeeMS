# Employee Management System

A comprehensive enterprise-grade Employee Management System built with ASP.NET Core Web API and Blazor WebAssembly, featuring role-based access control, leave management, payroll processing, and more.

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Architecture](#architecture)
- [Database Schema](#database-schema)
- [Prerequisites](#prerequisites)
- [Installation & Setup](#installation--setup)
- [Configuration](#configuration)
- [Running the Application](#running-the-application)
- [API Documentation](#api-documentation)
- [Testing](#testing)
- [Default Credentials](#default-credentials)
- [Project Structure](#project-structure)
- [Implemented Features](#implemented-features)
- [Future Enhancements](#future-enhancements)

## 🎯 Overview

The Employee Management System is a full-stack web application designed to streamline HR operations, employee management, and payroll processing. It provides three distinct user roles with appropriate permissions:

- **Admin**: Full system access, user management, system settings
- **HR**: Employee management, leave processing, payslip generation
- **Employee**: Self-service portal for leave requests, payslip viewing, profile management

## ✨ Features

### Authentication & Authorization
- ✅ JWT-based authentication
- ✅ Role-based authorization (Admin, HR, Employee)
- ✅ Secure password hashing with ASP.NET Core Identity
- ✅ Account lockout and password policies
- ✅ Token refresh mechanism

### Employee Management
- ✅ Complete CRUD operations
- ✅ Employee profile with personal and professional details
- ✅ Department assignment
- ✅ Employee status management (Active/Inactive)
- ✅ Employee number generation
- ✅ Search and filter capabilities

### Department Management
- ✅ Department CRUD operations
- ✅ Department assignment for employees
- ✅ Active/Inactive department management

### Leave Management
- ✅ Leave request submission
- ✅ Leave approval/rejection workflow
- ✅ Leave balance tracking
- ✅ Multiple leave types (Annual, Sick, Casual, etc.)
- ✅ Overlapping leave detection
- ✅ Leave status tracking (Pending, Approved, Rejected, Cancelled)
- ✅ Automatic leave balance updates

### Payroll Management
- ✅ Payslip generation
- ✅ PDF payslip download with QuestPDF
- ✅ Salary breakdown (Basic, Allowances, Deductions)
- ✅ Net salary calculation
- ✅ Historical payslip viewing

### Notifications
- ✅ In-app notifications
- ✅ Real-time notification center
- ✅ Read/Unread status
- ✅ Notification count badge

### Dashboard
- ✅ Role-based dashboards
- ✅ Key metrics and statistics
- ✅ Recent activity feed
- ✅ Quick action buttons

### Security Features
- ✅ JWT token validation
- ✅ Role-based authorization
- ✅ Input validation
- ✅ SQL injection protection (EF Core)
- ✅ Global exception handling
- ✅ CORS configuration
- ✅ Audit logging ready

## 🛠️ Technology Stack

### Backend
| Layer | Technology |
|-------|------------|
| Framework | ASP.NET Core 8.0 |
| Language | C# 12 |
| ORM | Entity Framework Core 8.0 |
| Database | SQL Server |
| Authentication | ASP.NET Core Identity |
| API Authentication | JWT Bearer |
| Authorization | Roles + Policies |
| PDF Generation | QuestPDF |
| Email (Planned) | MailKit |
| Validation (Planned) | FluentValidation |
| API Documentation | Swagger/OpenAPI |
| Logging (Planned) | Serilog |
| Testing | xUnit |

### Frontend
| Layer | Technology |
|-------|------------|
| Framework | Blazor WebAssembly 8.0 |
| UI Library | MudBlazor |
| Language | C# 12 |
| HTTP Client | HttpClient |
| State Management | Blazor State |
| Authentication | JWT Interceptor |

### Development Tools
| Tool | Purpose |
|------|---------|
| Git | Version Control |
| GitHub | Repository Hosting |
| Visual Studio 2022 | IDE |
| SQL Server Management Studio | Database Management |
| Swagger | API Testing |
| Postman | API Testing |

## 🏗️ Architecture

The application follows a clean, layered architecture:

```
┌─────────────────────────────────────────────────────────────┐
│                      Blazor WebAssembly                     │
│                          (Frontend)                         │
└──────────────────────────┬──────────────────────────────────┘
                           │ HTTPS / JSON
                           ▼
┌─────────────────────────────────────────────────────────────┐
│                     ASP.NET Core Web API                    │
│                                                             │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────────────┐ │
│  │ Controllers │→│  Services   │→│   Entity Framework   │ │
│  └─────────────┘  └─────────────┘  └─────────────────────┘ │
│                                                             │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────────────┐ │
│  │   Identity  │  │    JWT      │  │   Middleware Stack  │ │
│  └─────────────┘  └─────────────┘  └─────────────────────┘ │
└──────────────────────────┬──────────────────────────────────┘
                           │
                           ▼
┌─────────────────────────────────────────────────────────────┐
│                         SQL Server                          │
│                                                             │
│  Users │ Roles │ Employees │ Departments │ Leave Requests  │
│  Payslips │ Notifications │ Audit Logs │ Leave Types      │
└─────────────────────────────────────────────────────────────┘
```

### Project Structure

```
EmployeeManagementSystem/
│
├── EmployeeManagement.API/          # Backend API
│   ├── Controllers/                 # API Controllers
│   │   ├── AuthController.cs
│   │   ├── EmployeesController.cs
│   │   ├── DepartmentsController.cs
│   │   ├── LeaveRequestsController.cs
│   │   ├── PayslipsController.cs
│   │   └── NotificationsController.cs
│   │
│   ├── Data/                        # Database Context & Seeding
│   │   ├── ApplicationDbContext.cs
│   │   └── DbSeeder.cs
│   │
│   ├── Models/                      # Entity Models
│   │   ├── ApplicationUser.cs
│   │   ├── Employee.cs
│   │   ├── Department.cs
│   │   ├── LeaveRequest.cs
│   │   ├── LeaveType.cs
│   │   ├── Payslip.cs
│   │   ├── Notification.cs
│   │   └── AuditLog.cs
│   │
│   ├── DTOs/                        # Data Transfer Objects
│   │   ├── Auth/
│   │   ├── Employees/
│   │   ├── Departments/
│   │   ├── Leave/
│   │   ├── Payslips/
│   │   └── Notifications/
│   │
│   ├── Services/                    # Business Logic
│   │   ├── AuthService.cs
│   │   ├── EmployeeService.cs
│   │   ├── DepartmentService.cs
│   │   ├── LeaveService.cs
│   │   ├── PayslipService.cs
│   │   └── NotificationService.cs
│   │
│   ├── Interfaces/                  # Service Interfaces
│   │   ├── IAuthService.cs
│   │   ├── IEmployeeService.cs
│   │   ├── IDepartmentService.cs
│   │   ├── ILeaveService.cs
│   │   ├── IPayslipService.cs
│   │   └── INotificationService.cs
│   │
│   ├── Helpers/                     # Utility Classes
│   │   ├── JwtTokenGenerator.cs
│   │   └── MappingProfile.cs
│   │
│   ├── Middleware/                  # Custom Middleware
│   │   └── ExceptionMiddleware.cs
│   │
│   ├── Program.cs                   # Application Entry Point
│   └── appsettings.json             # Configuration
│
├── EmployeeManagement.Web/          # Frontend Application
│   ├── Pages/                       # Blazor Pages
│   │   ├── Login.razor
│   │   ├── Dashboard.razor
│   │   ├── Employees/
│   │   ├── Departments/
│   │   ├── Leave/
│   │   └── Payslips/
│   │
│   ├── Services/                    # Frontend Services
│   │   ├── AuthService.cs
│   │   ├── EmployeeService.cs
│   │   ├── DepartmentService.cs
│   │   ├── LeaveService.cs
│   │   ├── PayslipService.cs
│   │   └── NotificationService.cs
│   │
│   ├── Components/                  # Reusable Components
│   ├── Layout/                      # Layout Components
│   ├── wwwroot/                     # Static Assets
│   └── Program.cs                   # App Entry Point
│
├── EmployeeManagement.Tests/        # Unit Tests
│   ├── Controllers/
│   ├── Services/
│   └── Helpers/
│
├── EmployeeManagementSystem.sln     # Solution File
└── README.md                        # This File
```

## 🗄️ Database Schema

### Entity Relationship Diagram

```
┌──────────────────────┐          ┌──────────────────────┐
│    AspNetUsers       │ 1───────1│     Employees         │
│──────────────────────│          │──────────────────────│
│ Id (PK)              │◄─────────│ UserId (FK)          │
│ Email                │          │ Id (PK)              │
│ UserName             │          │ EmployeeNumber       │
│ FullName             │          │ FirstName            │
│ EmployeeId (FK)      │─────────►│ LastName             │
└──────────────────────┘          │ Email                │
          │                       │ PhoneNumber          │
          │ 1                     │ DateOfBirth          │
          │                       │ JoiningDate          │
          ▼                       │ JobTitle             │
┌──────────────────────┐          │ BasicSalary          │
│  AspNetRoles         │          │ DepartmentId (FK)    │
│──────────────────────│          │ IsActive             │
│ Id (PK)              │          └──────────────────────┘
│ Name                 │                    │
└──────────────────────┘                    │
          │                                 │ n
          │ n                               │
          ▼                                 ▼
┌──────────────────────┐          ┌──────────────────────┐
│  AspNetUserRoles     │          │    Departments       │
│──────────────────────│          │──────────────────────│
│ UserId (FK)          │          │ Id (PK)              │
│ RoleId (FK)          │          │ Name                 │
└──────────────────────┘          │ Description          │
                                   │ IsActive             │
                                   └──────────────────────┘
                                            │
                                            │ 1
                                            │
          ┌─────────────────────────────────┼─────────────────────────────────┐
          │                                 │                                 │
          ▼                                 ▼                                 ▼
┌──────────────────────┐          ┌──────────────────────┐          ┌──────────────────────┐
│   LeaveRequests      │          │     Payslips         │          │    Notifications     │
│──────────────────────│          │──────────────────────│          │──────────────────────│
│ Id (PK)              │          │ Id (PK)              │          │ Id (PK)              │
│ EmployeeId (FK)      │          │ EmployeeId (FK)      │          │ UserId (FK)          │
│ LeaveTypeId (FK)     │          │ Year                 │          │ Title                │
│ StartDate            │          │ Month                │          │ Message              │
│ EndDate              │          │ BasicSalary          │          │ IsRead               │
│ Reason               │          │ Allowances           │          │ CreatedAt            │
│ Status               │          │ Deductions           │          │ ReadAt               │
│ ReviewedBy           │          │ NetSalary            │          └──────────────────────┘
│ ReviewedAt           │          │ GeneratedAt          │
│ ReviewComment        │          └──────────────────────┘
└──────────────────────┘
          │
          │ n
          │
          ▼
┌──────────────────────┐
│    LeaveTypes        │
│──────────────────────│
│ Id (PK)              │
│ Name                 │
│ DefaultDays          │
│ IsActive             │
└──────────────────────┘
```

## 📋 Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB or Full)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/downloads)
- [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (Optional)

## 🚀 Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/EmployeeManagementSystem.git
cd EmployeeManagementSystem
```

### 2. Create the Solution and Projects

```bash
# Create the main directory
mkdir EmployeeManagementSystem
cd EmployeeManagementSystem

# Create solution
dotnet new sln -n EmployeeManagementSystem

# Create API project
dotnet new webapi -n EmployeeManagement.API

# Create Blazor WebAssembly project
dotnet new blazorwasm -n EmployeeManagement.Web

# Create Test project
dotnet new xunit -n EmployeeManagement.Tests

# Add projects to solution
dotnet sln add EmployeeManagement.API
dotnet sln add EmployeeManagement.Web
dotnet sln add EmployeeManagement.Tests
```

### 3. Install Backend Packages

Navigate to the API project:

```bash
cd EmployeeManagement.API
```

Install required packages:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Swashbuckle.AspNetCore
dotnet add package FluentValidation.AspNetCore
dotnet add package QuestPDF
dotnet add package MailKit
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Serilog.AspNetCore
```

### 4. Install Frontend Packages

Navigate to the Web project:

```bash
cd ../EmployeeManagement.Web
```

Install required packages:

```bash
dotnet add package Microsoft.AspNetCore.Components.WebAssembly.Authentication
dotnet add package Microsoft.Extensions.Http
dotnet add package MudBlazor
```

### 5. Restore Packages

```bash
cd ..
dotnet restore
```

## ⚙️ Configuration

### Database Connection

Update `appsettings.json` in the API project:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=EmployeeManagementDb;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Jwt": {
    "Key": "YourSuperSecretKeyWithAtLeast32Characters!",
    "Issuer": "EmployeeManagementAPI",
    "Audience": "EmployeeManagementWeb",
    "ExpiresInMinutes": 60
  },
  "Email": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "SenderEmail": "your-email@gmail.com",
    "SenderName": "Employee Management System"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### JWT Secret Configuration (Development)

For local development, use user secrets:

```bash
cd EmployeeManagement.API
dotnet user-secrets init
dotnet user-secrets set "Jwt:Key" "YourSuperSecretKeyWithAtLeast32Characters!"
```

### Frontend Configuration

Update `appsettings.json` in the Web project:

```json
{
  "ApiBaseUrl": "https://localhost:7000"
}
```

## 🏃 Running the Application

### 1. Database Migration

Create and apply migrations:

```bash
cd EmployeeManagement.API
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 2. Run the Backend API

```bash
dotnet run --project EmployeeManagement.API
```

The API will be available at:
- HTTPS: `https://localhost:7000`
- HTTP: `http://localhost:5000`
- Swagger UI: `https://localhost:7000/swagger`

### 3. Run the Frontend

```bash
dotnet run --project EmployeeManagement.Web
```

The Blazor app will be available at:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

### 4. Run Both Projects Simultaneously (Visual Studio)

1. Right-click on the solution in Solution Explorer
2. Select "Set Startup Projects..."
3. Choose "Multiple startup projects"
4. Set both API and Web to "Start"
5. Press F5 to run

## 📚 API Documentation

### Swagger UI

Access the Swagger UI at:
```
https://localhost:7000/swagger/index.html
```

### API Endpoints

#### Authentication
| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| POST | `/api/auth/login` | User login | Public |
| POST | `/api/auth/register` | User registration | Public |
| POST | `/api/auth/logout` | User logout | Authenticated |

#### Employees
| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| GET | `/api/employees` | Get all employees | Admin, HR |
| GET | `/api/employees/{id}` | Get employee by ID | Admin, HR |
| POST | `/api/employees` | Create new employee | Admin, HR |
| PUT | `/api/employees/{id}` | Update employee | Admin, HR |
| PATCH | `/api/employees/{id}/activate` | Activate employee | Admin, HR |
| PATCH | `/api/employees/{id}/deactivate` | Deactivate employee | Admin, HR |
| DELETE | `/api/employees/{id}` | Delete employee | Admin |

#### Departments
| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| GET | `/api/departments` | Get all departments | Admin, HR |
| GET | `/api/departments/{id}` | Get department by ID | Admin, HR |
| POST | `/api/departments` | Create department | Admin |
| PUT | `/api/departments/{id}` | Update department | Admin |
| DELETE | `/api/departments/{id}` | Delete department | Admin |

#### Leave Requests
| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| GET | `/api/leaverequests` | Get all leave requests | Admin, HR |
| GET | `/api/leaverequests/my-leaves` | Get my leave requests | Employee |
| GET | `/api/leaverequests/{id}` | Get leave request by ID | All |
| POST | `/api/leaverequests` | Create leave request | Employee |
| PUT | `/api/leaverequests/{id}` | Update leave request | Employee |
| POST | `/api/leaverequests/{id}/approve` | Approve leave request | Admin, HR |
| POST | `/api/leaverequests/{id}/reject` | Reject leave request | Admin, HR |
| POST | `/api/leaverequests/{id}/cancel` | Cancel leave request | Employee |
| GET | `/api/leaverequests/balance` | Get leave balance | Employee |
| GET | `/api/leaverequests/types` | Get leave types | All |

#### Payslips
| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| GET | `/api/payslips` | Get all payslips | Admin, HR |
| GET | `/api/payslips/{id}` | Get payslip by ID | All |
| GET | `/api/payslips/employee/{employeeId}` | Get employee payslips | All |
| POST | `/api/payslips` | Generate payslip | Admin, HR |
| GET | `/api/payslips/{id}/pdf` | Download payslip PDF | All |
| DELETE | `/api/payslips/{id}` | Delete payslip | Admin |

#### Notifications
| Method | Endpoint | Description | Access |
|--------|----------|-------------|--------|
| GET | `/api/notifications` | Get my notifications | All |
| GET | `/api/notifications/unread` | Get unread notifications | All |
| GET | `/api/notifications/unread-count` | Get unread count | All |
| POST | `/api/notifications` | Create notification | Admin, HR |
| POST | `/api/notifications/{id}/read` | Mark as read | All |
| POST | `/api/notifications/read-all` | Mark all as read | All |
| DELETE | `/api/notifications/{id}` | Delete notification | All |

## 🔐 Default Credentials

After seeding the database, you can use these credentials:

| Role | Email | Password |
|------|-------|----------|
| **Admin** | `admin@employeemanagement.com` | `Admin@123456` |
| **HR** | `hr@employeemanagement.com` | `HR@123456` |
| **HR 2** | `hr2@employeemanagement.com` | `HR@123456` |
| **Employee** | `john.smith@company.com` | `Employee@123` |
| **Employee** | `sarah.lee@company.com` | `Employee@123` |
| **Employee** | `david.kim@company.com` | `Employee@123` |
| **Employee** | `emma.wilson@company.com` | `Employee@123` |
| **Employee** | `michael.brown@company.com` | `Employee@123` |
| **Employee** | `jessica.taylor@company.com` | `Employee@123` |
| **Employee** | `robert.davis@company.com` | `Employee@123` |
| **Employee** | `lisa.chen@company.com` | `Employee@123` |
| **Employee** | `james.martinez@company.com` | `Employee@123` |
| **Employee** | `maria.garcia@company.com` | `Employee@123` |
| **Employee** | `thomas.anderson@company.com` | `Employee@123` |
| **Employee** | `patricia.jackson@company.com` | `Employee@123` |

## ✅ Implemented Features

### Backend (100% Complete)
- ✅ ASP.NET Core Web API with JWT Authentication
- ✅ Entity Framework Core with SQL Server
- ✅ ASP.NET Core Identity for user management
- ✅ Role-based authorization (Admin, HR, Employee)
- ✅ Complete CRUD operations for all entities
- ✅ AutoMapper for DTO mapping
- ✅ Global exception handling middleware
- ✅ Swagger/OpenAPI documentation
- ✅ Database seeding with test data
- ✅ JWT token generation and validation
- ✅ PDF generation for payslips using QuestPDF
- ✅ Notification system
- ✅ Leave management with workflow
- ✅ Payroll management
- ✅ Department management
- ✅ Employee management with status tracking

### Frontend (In Progress)
- ✅ Blazor WebAssembly setup
- ✅ Authentication service
- ✅ Employee service
- ✅ Department service
- ✅ Leave service
- ✅ Payslip service
- ✅ Notification service
- ✅ Login page
- ✅ Dashboard (basic)
- ⬜ Employee CRUD pages (Partially Complete)
- ⬜ Department management pages
- ⬜ Leave management pages
- ⬜ Payslip management pages
- ⬜ Notification center
- ⬜ Profile management
- ⬜ User management (Admin)

## 🚧 Future Enhancements

### Immediate Priorities
- [ ] **Email Service** - Implement MailKit for email notifications
- [ ] **Audit Logging** - Track all system actions
- [ ] **Pagination & Filtering** - Add pagination to all list endpoints
- [ ] **FluentValidation** - Implement request validation
- [ ] **Forgot Password** - Password reset functionality
- [ ] **User Management** - Admin interface for managing HR users
- [ ] **Complete Blazor Frontend** - All CRUD pages

### Medium Term
- [ ] **Reporting Module**
  - [ ] Employee turnover reports
  - [ ] Leave statistics
  - [ ] Payroll summary
  - [ ] Department-wise reports
  - [ ] Export to Excel/PDF

- [ ] **Advanced Leave Features**
  - [ ] Leave accrual (monthly/annual)
  - [ ] Leave carry forward
  - [ ] Leave encashment
  - [ ] Holiday calendar
  - [ ] Team calendar view

- [ ] **Payroll Enhancements**
  - [ ] Tax calculations
  - [ ] EPF/ETF contributions
  - [ ] Overtime calculations
  - [ ] Bonus management
  - [ ] Bulk payslip generation

- [ ] **System Settings**
  - [ ] Configurable leave policies
  - [ ] Department budgets
  - [ ] Payroll settings
  - [ ] Email templates

### Long Term
- [ ] **Advanced Security**
  - [ ] Rate limiting
  - [ ] Two-factor authentication
  - [ ] IP whitelisting
  - [ ] Request validation
  - [ ] Security headers

- [ ] **Integration Features**
  - [ ] HRIS integration
  - [ ] Accounting software integration
  - [ ] Biometric system integration
  - [ ] Calendar integration
  - [ ] Slack/Teams notifications

- [ ] **Performance Enhancements**
  - [ ] Redis caching
  - [ ] Background jobs with Hangfire
  - [ ] Database optimization
  - [ ] Load balancing
  - [ ] CDN for static assets

- [ ] **Mobile App**
  - [ ] React Native mobile app
  - [ ] Push notifications
  - [ ] Offline support
  - [ ] Biometric login

- [ ] **Advanced Analytics**
  - [ ] Employee satisfaction surveys
  - [ ] Performance reviews
  - [ ] Training management
  - [ ] Goal tracking
  - [ ] 360-degree feedback

## 🧪 Testing

### API Testing with Swagger
1. Navigate to `https://localhost:7000/swagger`
2. Login to get JWT token
3. Click "Authorize" and enter `Bearer {token}`
4. Test any endpoint

## 📊 Performance Considerations

- **Database Indexing**: Ensure proper indexes on foreign keys and frequently queried columns
- **Caching**: Implement Redis caching for frequently accessed data
- **Pagination**: All list endpoints should support pagination
- **Query Optimization**: Use `.Include()` and `.ThenInclude()` carefully
- **Connection Pooling**: Configure SQL Server connection pooling

## 🔒 Security Best Practices

1. **Never commit secrets** - Use user-secrets or environment variables
2. **HTTPS in production** - Always use HTTPS in production
3. **CORS configuration** - Restrict CORS to specific origins
4. **Input validation** - Validate all user inputs
5. **SQL injection prevention** - Use EF Core for all queries
6. **JWT expiration** - Keep token expiration reasonable
7. **Password policies** - Enforce strong passwords
8. **Role-based access** - Always check authorization
9. **Audit logging** - Log all sensitive operations
10. **Error handling** - Don't expose internal errors

### Documentation
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [Blazor Documentation](https://docs.microsoft.com/en-us/aspnet/core/blazor/)
- [MudBlazor Documentation](https://mudblazor.com/)
