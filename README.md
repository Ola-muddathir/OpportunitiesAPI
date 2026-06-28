# 🌿 OpportunitiesAPI

A RESTful Web API built with **ASP.NET Core (.NET 10)** for the **Forsa Khadra (فرص خضراء)** platform. It manages green opportunities such as scholarships, training programs, and competitions — with full CRUD operations, search filtering, pagination, and JWT-based authentication.

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core Web API (.NET 10) |
| Language | C# |
| Database | SQLite via Entity Framework Core |
| Authentication | JWT Bearer Tokens |
| API Docs | Scalar UI (`/scalar/v1`) |
| IDE | Visual Studio 2022 |

---

## 📁 Project Structure

```
OpportunitiesAPI/
├── Controllers/
│   ├── AuthController.cs           # Login & JWT token generation
│   └── OpportunitiesController.cs  # CRUD + filter endpoints
├── Data/
│   └── AppDbContext.cs             # EF Core database context
├── DTOs/
│   ├── LoginDto.cs                 # Login request model
│   ├── OpportunityCreateDto.cs     # Create/Update request model
│   └── OpportunityFilterDto.cs     # Search & pagination model
├── Models/
│   └── Opportunity.cs             # Main database entity
├── Repositories/
│   ├── IOpportunityRepository.cs  # Repository interface
│   └── OpportunityRepository.cs   # EF Core implementation
├── Services/
│   ├── IOpportunityService.cs     # Service interface
│   ├── OpportunityService.cs      # Business logic
│   ├── IAuthService.cs            # Auth interface
│   └── AuthService.cs             # JWT token logic
├── Migrations/                    # EF Core migrations
├── appsettings.json               # DB connection + JWT config
└── Program.cs                     # App entry point & DI setup
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/your-username/OpportunitiesAPI.git
cd OpportunitiesAPI
```

2. **Restore NuGet packages**
```bash
dotnet restore
```

3. **Apply database migrations**

Open **Package Manager Console** in Visual Studio and run:
```powershell
Update-Database
```

4. **Run the project**
```bash
dotnet run
```

Or press `Ctrl + F5` in Visual Studio.

5. **Open API docs**
```
https://localhost:{PORT}/scalar/v1
```

---

## 🔑 Authentication

The API uses **JWT Bearer Token** authentication.

### Login

```http
POST /api/auth/login
Content-Type: application/json

{
  "username": "admin",
  "password": "Admin@123"
}
```

### Response

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Using the Token

Add the token to the `Authorization` header for protected endpoints:

```
Authorization: Bearer {your_token_here}
```

---

## 📡 API Endpoints

### Auth

| Method | Endpoint | Description | Auth |
|---|---|---|---|
| `POST` | `/api/auth/login` | Login and get JWT token | ❌ Public |

### Opportunities

| Method | Endpoint | Description | Auth |
|---|---|---|---|
| `GET` | `/api/opportunities` | Get all (with filters + pagination) | ❌ Public |
| `GET` | `/api/opportunities/{id}` | Get single opportunity by ID | ❌ Public |
| `POST` | `/api/opportunities` | Create new opportunity | ✅ JWT |
| `PUT` | `/api/opportunities/{id}` | Update existing opportunity | ✅ JWT |
| `DELETE` | `/api/opportunities/{id}` | Delete opportunity | ✅ JWT |

---

## 🔍 Filter & Pagination

`GET /api/opportunities` supports the following query parameters:

| Parameter | Type | Default | Description |
|---|---|---|---|
| `keyword` | `string` | - | Search in Title and Description |
| `type` | `string` | - | Filter by type (e.g. منحة، تدريب) |
| `country` | `string` | - | Filter by country |
| `isFullyFunded` | `bool` | - | Filter by funding status |
| `page` | `int` | `1` | Page number |
| `pageSize` | `int` | `10` | Results per page |

### Example

```
GET /api/opportunities?keyword=منحة&country=مصر&isFullyFunded=true&page=1&pageSize=5
```

### Response Format

```json
{
  "data": [...],
  "totalCount": 25,
  "page": 1,
  "pageSize": 5
}
```

---

## 📦 Data Model

### Opportunity

```json
{
  "id": 1,
  "title": "منحة جامعة القاهرة",
  "description": "منحة دراسية كاملة لدرجة الماجستير",
  "type": "منحة",
  "country": "مصر",
  "deadline": "2026-12-31T00:00:00",
  "isFullyFunded": true,
  "createdAt": "2026-06-28T10:00:00"
}
```

---

## ⚙️ Configuration

Edit `appsettings.json` to change the database path or JWT settings:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=opportunities.db"
  },
  "Jwt": {
    "Key": "YourSuperSecretKeyHere1234567890!@#",
    "Issuer": "OpportunitiesAPI",
    "Audience": "OpportunitiesAPIUsers"
  }
}
```

> ⚠️ **Important:** Change the `Jwt:Key` to a strong secret key before deploying to production.

---

## 🏗️ Architecture

The project follows a clean **4-layer architecture**:

```
HTTP Request
     ↓
[Controllers]  →  Handles HTTP, validates input
     ↓
[Services]     →  Business logic
     ↓
[Repositories] →  Data access via EF Core
     ↓
[Database]     →  SQLite
```

---

## 📋 HTTP Response Codes

| Code | Meaning |
|---|---|
| `200 OK` | Successful GET or PUT |
| `201 Created` | Successfully created via POST |
| `204 No Content` | Successfully deleted via DELETE |
| `401 Unauthorized` | Missing or invalid JWT token |
| `404 Not Found` | Resource not found |

---

## 📄 License

This project is part of the **Forsa Khadra** platform — Backend Team 2026.
