# 💸 Expense Tracker

A full-stack **Expense Tracking Web Application** built with **Angular 17** and **ASP.NET Core Web API (.NET 8)**. It helps users manage their personal finances with a clean dashboard, category-based filtering, and secure JWT authentication.

---

## 🚀 Live Demo
> Coming soon

---

## 📸 Screenshots

> Add your screenshots in a `/screenshots` folder and update the paths below

| Dashboard | Expenses |
|-----------|----------|
| ![Dashboard](screenshots/dashboard.png) | ![Expenses](screenshots/expenses.png) |

| Login | User Profile |
|-------|-------------|
| ![Login](screenshots/login.png) | ![Profile](screenshots/profile.png) |

---

## ✨ Features

- 🔐 **JWT Authentication** — Secure login & registration with token-based auth
- 📊 **Dashboard with Charts** — Visual overview of spending habits
- ➕ **Add / Edit / Delete Expenses** — Full CRUD expense management
- 👤 **User Profile** — Manage personal account details
- 🏷️ **Category Filtering** — Filter expenses by category for better insights

---

## 🛠️ Tech Stack

### Frontend
| Technology | Version |
|------------|---------|
| Angular | 17 |
| TypeScript | 5.x |
| Angular Material / TailwindCSS | Latest |
| Chart.js / NgRx | Latest |

### Backend
| Technology | Version |
|------------|---------|
| ASP.NET Core Web API | .NET 8 |
| Entity Framework Core | 8.x |
| SQL Server | Latest |
| JWT Bearer Authentication | Latest |

---

## 📁 Project Structure

```
Expense-Tracker/
├── frontend/          # Angular 17 application
│   ├── src/
│   │   ├── app/
│   │   │   ├── components/
│   │   │   ├── services/
│   │   │   ├── models/
│   │   │   └── guards/
│   └── package.json
│
└── backend/           # ASP.NET Core Web API
    ├── Controllers/
    ├── Data/
    ├── DTOs/
    ├── Helpers/
    ├── Interfaces/
    ├── Migrations/
    ├── Models/
    ├── Services/
    └── appsettings.json
```

---

## ⚙️ Getting Started

### Prerequisites
- Node.js v18+
- Angular CLI 17
- .NET 8 SDK
- SQL Server

---

### 🔧 Backend Setup

```bash
cd backend

# Restore packages
dotnet restore

# Update appsettings.json with your connection string
# "ConnectionStrings": { "DefaultConnection": "your-sql-server-connection" }

# Run migrations
dotnet ef database update

# Start the API
dotnet run
```

> API runs on `https://localhost:5001`

---

### 🎨 Frontend Setup

```bash
cd frontend

# Install dependencies
npm install

# Start the dev server
ng serve
```

> App runs on `http://localhost:4200`

---

## 🔑 Environment Variables

In `backend/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your-sql-server-string"
  },
  "JWT": {
    "Key": "your-secret-key",
    "Issuer": "your-issuer",
    "Audience": "your-audience"
  }
}
```

---

## 📡 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/register` | Register new user |
| POST | `/api/auth/login` | Login & get token |
| GET | `/api/expenses` | Get all expenses |
| POST | `/api/expenses` | Add new expense |
| PUT | `/api/expenses/{id}` | Update expense |
| DELETE | `/api/expenses/{id}` | Delete expense |
| GET | `/api/dashboard` | Get dashboard stats |
| GET | `/api/user/profile` | Get user profile |

---

## 👩‍💻 Author

**Aleena Mirza**
- GitHub: [@aleenamirza1](https://github.com/aleenamirza1)

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

⭐ If you found this project helpful, please give it a star!
