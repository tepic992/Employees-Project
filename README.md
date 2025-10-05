# 🧭 Job Management System

A modular, extensible and domain-driven system for managing employees, jobs, managers, and skills — built using C# and a layered architecture.

---

## 🏗️ Project Structure

This project is organized into three main architectural layers:

- **Models** – Domain entities representing core business concepts
- **Repositories** – Data access layer (abstraction over database)
- **Services** – Business logic layer

---

### 📁 Domain Models

These classes define the core business entities of the system:

| Class                  | Description |
|------------------------|-------------|
| `Employee.cs`          | Base class representing an employee |
| `Worker.cs`            | Represents a working employee (subtype of `Employee`) |
| `Manager.cs`           | Represents a manager with additional responsibilities |
| `ManagerType.cs`       | Defines various categories/types of managers |
| `Job.cs`               | Represents a job or task within the organization |
| `JobType.cs`           | Describes the classification/type of a job |
| `JobAvailability.cs`   | Represents the availability status of a job |
| `JobTypeSkill.cs`      | Defines the required skills for specific job types |
| `Skill.cs`             | Represents a skill (e.g., programming, leadership) |

---

### 🗂️ Repository Layer

Repositories abstract data access and encapsulate persistence logic.

| Interface / Class           | Responsibility |
|-----------------------------|----------------|
| `IEmployeeRepository.cs`    | Access to employee data |
| `IJobRepository.cs`         | Access to job records |
| `ISkillRepository.cs`       | Access to skills and capabilities |
| `IManagerRepository.cs`     | Access to manager data |
| `IJobTypeRepository.cs`     | Fetching job type metadata |
| `RepositoryBase.cs` (if any)| Generic repository logic |

> 🧩 Implementations follow the `IRepository` pattern and are compatible with dependency injection.

---

### ⚙️ Service Layer

Service classes handle business logic and coordinate between repositories.

| Service Class               | Description |
|-----------------------------|-------------|
| `EmployeeService.cs`        | Handles employee-related operations |
| `JobService.cs`             | Manages job creation, assignment, and updates |
| `ManagerService.cs`         | Business logic for manager roles |
| `SkillService.cs`           | Manages creation and mapping of skills |
| `JobAssignmentService.cs`   | Assigns jobs based on skill matching (if implemented) |

---

## 🧱 Architecture Overview

```text
[ Controllers / APIs ]
          ↓
[     Service Layer     ]
          ↓
[   Repository Layer    ]
          ↓
[   Database / Storage  ]




