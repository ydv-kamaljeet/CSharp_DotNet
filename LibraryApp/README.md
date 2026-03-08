# Library Book Management System
## Repository Pattern — Two Phase Implementation (.NET 10)

---

## Project Structure

```
LibraryApp/
├── Controllers/
│   └── BookController.cs          ← never changes between phases
├── Data/
│   └── LibraryDbContext.cs        ← EF Core DbContext
├── Models/
│   └── Book.cs
├── Repositories/
│   ├── IBookRepository.cs         ← shared contract
│   ├── MemoryBookRepository.cs    ← Phase 1
│   └── SqlBookRepository.cs      ← Phase 2
├── Views/Book/
│   ├── List.cshtml
│   ├── Details.cshtml
│   ├── Create.cshtml
│   └── Delete.cshtml
└── Program.cs
```

---

## Phase 1 — Running with In-Memory Storage

No database or configuration needed. Just run it.

```bash
dotnet run
```

Open browser at `https://localhost:5001` or `http://localhost:5000`.

Three sample books are pre-loaded on startup.

---

## Phase 2 — Switching to SQL Server

### Step 1 — Update Program.cs

Open `Program.cs` and:
- Comment out the Phase 1 line
- Uncomment the Phase 2 block

```csharp
// Comment this out:
// builder.Services.AddSingleton<IBookRepository, MemoryBookRepository>();

// Uncomment these:
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDb")));
builder.Services.AddScoped<IBookRepository, SqlBookRepository>();
```

### Step 2 — Update Connection String

Open `appsettings.json` and update the connection string to point to your SQL Server instance.

```json
"ConnectionStrings": {
  "LibraryDb": "Server=.;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Step 3 — Run Migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Step 4 — Run the app

```bash
dotnet run
```

The controller and views are identical — only the repository wired in DI has changed.

---

## Key Design Concept

```
BookController
     ↓ depends on
IBookRepository  (interface / abstraction)
     ↓ implemented by
MemoryBookRepository   OR   SqlBookRepository
```

The controller never knows or cares which implementation is active.
Swapping storage is a single-line change in `Program.cs`.
