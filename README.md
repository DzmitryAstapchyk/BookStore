![License: MIT](https://shields.io)
# 📚 BookStore Web API

A professional implementation of a RESTful API for a bookstore management system. This project demonstrates clean architecture principles, efficient data handling, and robust error management in the .NET ecosystem.

## 🚀 Tech Stack
*   **Framework:** .NET Core 3.1+ (supports .NET 6/8)
*   **Database:** MS SQL Server / MySQL
*   **ORM:** Entity Framework Core (Code-First)
*   **Documentation:** Swagger / OpenAPI
*   **Patterns:** Repository Pattern, Middleware, DTO Mapping

## 🏗 Key Features & Architecture
- **Repository Pattern:** Abstracting data access to promote testability and maintainability.
- **Global Exception Handling:** Custom Middleware to ensure consistent API responses during errors.
- **Separation of Concerns:** Clear distinction between **Entities** (database models) and **DTOs** (data transfer objects).
- **Code-First Migrations:** Fully automated database schema management.
- **Documentation:** Extensively documented using XML `<summary>` tags for all public members.

## 📋 Task Specifications
This project was built to fulfill the following technical requirements:

*   **Application:** Web API with a structured folder hierarchy and Swagger integration.
*   **Data Model:** Entities for `Books` and `Orders`. Support for multiple books per order.
*   **Filtering:** 
    *   Find books by Title and Release Date.
    *   Find orders by Order Number and Date.
*   **API Logic:** Get detailed book info by ID, save new orders, and retrieve order history.

## 📂 Project Structure
```text
BookStore/
├── BookStore.API/          # Controllers, Middlewares, and Configuration
├── BookStore.Data/         # DbContext, Migrations, and Repositories
├── BookStore.Core/         # Domain Entities and Interfaces
├── BookStore.Models/       # DTOs and Mapping Profiles
└── ...
```

## 🚥 Getting Started
1. **Configure Connection:** Update the connection string in `appsettings.json`.
2. **Apply Migrations:**
   ```bash
   Update-Database
   ```
3. **Run Application:** Launch the project to view the Swagger UI at `https://localhost:XXXX/swagger`.

---

<details>
<summary><b>Original Task Description (Russian)</b></summary>

# BookStore
Написать WebApi-приложение — магазин книг. Условия:
- .NET Core 3.1 и выше (без UI, Swagger)
- EF Core Code-First (MSSQL/MySQL)
- Паттерн Repository
- Сущности: книга, заказ (один заказ — несколько книг)
- Фильтрация книг (название, дата) и заказов (номер, дата)
- Middleware для обработки исключений
- Разделение Entity и Models
- Использование summary и комментариев

</details>

---
*Developed as a technical assessment for ООО «КАСПЕЛ-АН».*
