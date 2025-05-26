# 💘 Dating App (Full Stack Project)

This is a full-stack **Dating Application** built with:

- 🎨 **Frontend**: Angular 19 (Standalone Components, TypeScript)
- ⚙️ **Backend**: ASP.NET Core Web API
- 🗃️ **Database**: SQLite (Development)
- 📊 **Logging**: Serilog

---

## 📁 Project Structure

├── DatingAppFrontend/ # Angular 19 frontend
├── DatingAppBackend/ # ASP.NET Core Web API backend
└── README.md # Project description


---

## 🚀 Getting Started

### 🖥 Frontend (Angular)

1. **Navigate to the frontend folder:**

```
cd DatingAppFrontend
Install dependencies:

npm install
Start the development server:

ng serve
App will be available at: http://localhost:4200


⚙️ Backend (ASP.NET Core)
Navigate to the backend folder:

cd DatingAppBackend
Run the Web API:

dotnet run
API will be available at: http://localhost:5000 (or as configured in launchSettings.json)

EF Core Migrations:
dotnet ef migrations add InitialCreate -o Data/Migrations
dotnet ef database update
🔧 Configuration
Database: datingapp.db (SQLite file)

Backend Port: Configured in Properties/launchSettings.json

Frontend Port: Configured in angular.json

Logging: Serilog configuration in Program.cs

🛠 Tech Stack
Layer	Tech
Frontend	Angular 19, TypeScript, RxJS
Backend	ASP.NET Core Web API, C#
Database	SQLite + Entity Framework Core
Auth	JWT (optional, for future)
Logging	Serilog
Dev Tools	Visual Studio Code, Visual Studio 2022, Git, GitHub

🧪 Features (Current & Planned)
 User registration & login (in progress)

 Responsive Angular UI

 Backend API with EF Core & SQLite

 JWT Authentication & Authorization

 Profile image upload

 Matching logic

 Real-time chat (SignalR)

💡 Development Tips
Use ng generate component --standalone for Angular 19 components.

Use dotnet watch run for auto-reloading the backend.

Keep .gitignore updated for both frontend and backend.

📄 License
MIT License


