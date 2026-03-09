<div align="center">

# 🏢 Enterprise Employee Management System (First MVC Project)

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET_Core_MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview)
[![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-3BB3D9?style=for-the-badge&logo=.net&logoColor=white)](https://docs.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
[![Architecture](https://img.shields.io/badge/Architecture-N--Tier-brightgreen?style=for-the-badge)](https://en.wikipedia.org/wiki/Multitier_architecture)

> **A robust, scalable, and highly maintainable ASP.NET Core MVC application built with N-Tier Architecture, demonstrating enterprise-level design patterns and clean code principles.**

</div>

---

## 🌟 Overview

The **Enterprise Employee Management System** is a comprehensive web application designed to manage organizational structures, departments, and employees efficiently. 

Built from the ground up using **.NET 8**, this project serves as a showcase of modern backend development practices, focusing on separation of concerns, scalability, and performance optimization. It features a complete **N-Tier Architecture**, ensuring that presentation, business logic, and data access layers remain decoupled and independently maintainable.

---

## ✨ Key Features

- **🏢 Department Management:** Full CRUD operations for company departments.
- **👥 Employee Management:** Advanced employee records management with relational mapping to departments.
- **🔐 Secure Authentication:** Ready-to-use ASP.NET Identity configurations.
- **🔄 Data Mapping:** Automated and clean object-to-object mapping using **AutoMapper** (DTOs to Domain Models).
- **🛡️ Data Integrity:** Strongly-typed models, validation attributes, and fluent API configurations.
- **🎨 Responsive UI:** Built utilizing ASP.NET Core MVC Views (`.cshtml`) tailored for seamless user experiences.

---

## 🏗️ System Architecture (N-Tier)

The application rigidly follows the **N-Tier (Clean Architecture)** principles, divided into three main logical and physical layers:

1. **Presentation Layer (`Presentation Profile`)**
   - Handles HTTP requests and responses.
   - Contains Controllers, Views (`.cshtml`), ViewModels, and AutoMapper Profiles.
   - Entry point of the application (`Program.cs`) integrating Dependency Injection.

2. **Business Logic Layer (`BLL`)**
   - Contains the core business rules and logic.
   - Defines Interfaces and implementations for Repositories and `UnitOfWork`.
   - Acts as a bridge between the Presentation and Data Access layers.

3. **Data Access Layer (`DAL`)**
   - Manages communication with the database.
   - Contains Entity Framework Core `DbContext` (`CompanyDbcontext`), Migrations, and Domain Entity Models (`Employee`, `Department`, `BaseEntity`).
   - Handles SQL Server integration natively.

---

## 🛠️ Technologies & Tools

- **Framework:** .NET 8.0
- **Web Technology:** ASP.NET Core MVC
- **ORM:** Entity Framework Core 8
- **Database:** Microsoft SQL Server
- **Mapping:** AutoMapper 15.0
- **Authentication:** ASP.NET Core Identity
- **Design Patterns:**
  - 📐 **Repository Pattern (Generic & Specific)**
  - 📦 **Unit of Work Pattern**
  - 💉 **Dependency Injection (DI)**
  - 🔄 **DTO (Data Transfer Object) Pattern**

---

## 🚀 Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or Visual Studio Code
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or Developer Edition)

### Installation Steps

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/First-MVC-Project.git
   cd First-MVC-Project
   ```

2. **Configure the Database Connection:**
   Navigate to `Presentation Layer/appsettings.json` and update the `DefaultConnection` string with your local SQL Server instance details.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=CompanyMVC;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
   }
   ```

3. **Apply Database Migrations:**
   Open the Package Manager Console (PMC) in Visual Studio, set the **Default project** to `Data Access Layer`, and run:
   ```powershell
   Update-Database
   ```
   *Alternatively, using the .NET CLI:*
   ```bash
   dotnet ef database update --project "Data Access Layer" --startup-project "Presntation  Layer"
   ```

4. **Run the Application:**
   Press `F5` in Visual Studio or run the following command in the CLI:
   ```bash
   dotnet run --project "Presntation  Layer"
   ```

---

## 📂 Folder Structure Highlights

```text
📦 First-MVC-Project
 ┣ 📂 Presntation Layer        # Controllers, Views, DTOs, Mapping Profiles
 ┣ 📂 Business Logic Layer     # Interfaces, Repositories, UnitOfWork
 ┣ 📂 Data Access Layer        # Models, DbContexts, Configurations, Migrations
 ┗ 📜 First MVC Project.sln    # Solution File
```

---

## 💡 Why This Project Stands Out?

This project is not just a standard CRUD application; it represents a commitment to **Clean Code** and **Enterprise Patterns**:
> Instead of injecting multiple repositories into controllers leading to constructor over-injection, the **Unit of Work** pattern was implemented to ensure that multiple repository operations share a single database context, guaranteeing transaction atomicity and maximizing performance.

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome! 
Feel free to check [issues page](https://github.com/yourusername/First-MVC-Project/issues) if you want to contribute.

---

<div align="center">
  <b>Developed with ❤️ passionately applying the best coding practices.</b>
</div>
