# dotnet-core-essentials

A small ASP.NET Core Web API project demonstrating modern .NET fundamentals, clean architecture, dependency injection, and testing (unit + integration).

I've intentionally kept this project minimal to focus on correctness, structure, and best practices rather than features.

---

## Tech stack

- .NET (ASP.NET Core Web API)
- C# (async/await, records, nullable reference types)
- xUnit (unit testing)
- ASP.NET Core integration testing (`WebApplicationFactory`)
- Swagger / OpenAPI
- GitHub Actions (CI – added later)

---

## Project structure

dotnet-core-essentials/
├── DotNetCoreEssentials.sln
├── src/
│ └── DotNetCoreEssentials.Api/
│ ├── Controllers/
│ ├── Services/
│ ├── Models/
│ ├── DTOs/
│ ├── Program.cs
│ └── appsettings.json
├── tests/
│ └── DotNetCoreEssentials.Tests/
│ ├── NoteServiceTests.cs
│ └── NotesControllerTests.cs
└── README.md

---

## What this API does

A simple **Notes API** with CRUD-style operations:

- Create a note
- Retrieve all notes
- Retrieve a note by ID
- Delete a note

Data is stored **in-memory** to keep the focus on architecture and testing rather than persistence.

---

## Running the project locally

### Prerequisites
- .NET SDK (7 or later)

### Run the API
```bash
cd src/DotNetCoreEssentials.Api
dotnet run
Open Swagger UI:

bash
Copy code
http://localhost:5000/swagger
API endpoints
Method	Endpoint	Description
GET	/api/notes	Get all notes
GET	/api/notes/{id}	Get note by ID
POST	/api/notes	Create a new note
DELETE	/api/notes/{id}	Delete a note

Running tests
From the repository root:

bash
Copy code
dotnet test
Test coverage includes:
Unit tests for service-layer business logic

Integration tests for controller endpoints using real HTTP and dependency injection

What I learned
How to structure a small ASP.NET Core API using clear separation of concerns

Why business logic should be unit-tested at the service layer

How to write integration tests for controllers using WebApplicationFactory

Proper use of dependency injection and service lifetimes

How to design DTOs to decouple API contracts from domain models

How to maintain clean Git history using feature branches and focused commits
