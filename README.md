# SimpleCSharpApiBlazorFrontend 🎯

A lightweight Blazor WebAssembly frontend that interacts with a C# API backend, demonstrating a clean and modern full-stack .NET application.

---

## 📂 Repository Overview

```
/CarOffer.API    → ASP.NET Core Web API project  
/CarOffer.Frontend     → Blazor WebAssembly frontend  
```

- **Server**  
  - Exposes REST endpoints (e.g. `GET /api/cars`, `POST /api/car`)  
  - Uses dependency injection, controllers, Swagger/OpenAPI  
- **Client**  
  - Blazor WebAssembly project calling the API using `HttpClient` 
- **Shared**  
  - Models (`Item`, `CreateItemDto`, etc.) shared between both projects

---

## 🚀 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com) (or compatible version)  
- Code editor: Visual Studio 2022, VS Code, Rider, etc.

---


## 🧩 Project Structure

| Project       | Purpose |
|---------------|---------|
| **CarOffer.API**    | Defines API endpoints, controllers, services, models |
| **CarOffer.Frontend**    | Presents Blazor UI, consumes the API |

---

### TL;DR

A simple, extendable .NET 9 demo combining a C# API with a Blazor WebAssembly frontend. Perfect as a starting point for full-stack .NET development.

---

