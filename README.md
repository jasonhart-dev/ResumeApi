# ResumeApi

An interview-ready ASP.NET Core application that demonstrates API design, Razor Pages UI, versioned endpoints, persistent database storage, and production-oriented reliability patterns using a realistic resume-driven use case.

---

## Features

### UI (Razor Pages)
- Email capture entry page
- Resume display page
- Professional Summary and Experience loaded via API calls
- "Hire Me" interaction flow (Company + Job Title)
- Contextual banner showing which role the resume is being viewed for
- Logout action that resets view context and returns to entry page
- **NEW:** Live visit counter displayed on homepage (persists across restarts)

### API
- Versioned REST APIs (/api/v2/...)
- Resume data endpoints (read-only)
- Email capture endpoint
- Hire Me submission endpoint
- **NEW:** Visit Counter endpoints:
  - `GET /api/visitcounter` - Get current visit count
  - `POST /api/visitcounter/increment` - Increment and return new total
  - `GET /api/visitcounter/audit?limit=100` - Get audit history
- Swagger / OpenAPI enabled

### Database & Persistence
- **NEW:** Azure SQL Database integration using Entity Framework Core
- **NEW:** Visit counter with persistent storage across app restarts
- **NEW:** Automatic audit trail tracking all visit count changes via SQL Server trigger
- Structured data models:
  - `VisitCounter` - Tracks total visits
  - `VisitCountersAudit` - Audit log of all visit count changes
- ApplicationDbContext for all database operations
- Entity Framework Core migrations for schema management

### Logging & Reliability
- Structured logging using Serilog
- Console and rolling file log sinks
- Request lifecycle logging (method, path, status, duration)
- Centralized global exception handling
- Standardized error responses using ProblemDetails
- Graceful failure behavior with no unhandled exceptions leaking to clients

---

## Testing & Coverage

This project includes **automated unit and integration tests** to validate API behavior and ensure changes can be made safely.

### Unit Tests
- Controller-level unit tests using **xUnit**
- Dependencies mocked with **Moq**
- Verifies:
  - HTTP 200 (OK) responses for valid requests
  - HTTP 404 (Not Found) behavior for missing resources
  - Correct DTOs returned from controller actions

### Integration Tests
- End-to-end API tests using **WebApplicationFactory**
- Runs the application in-memory with real routing and dependency injection
- Verifies:
  - `/api/v2/resume/summary` returns HTTP 200 and valid payload
  - Missing resources return proper HTTP status codes (404)

### Code Coverage
- Coverage collected using **Coverlet**
- HTML coverage reports generated via **ReportGenerator**
- Coverage highlights which API paths and controller logic are exercised by tests

#### Run Tests
```bash
dotnet test ResumeApi.Tests/ResumeApi.Tests.csproj
```

#### Generate Coverage Report (HTML)
A helper script is included to generate and open the coverage report:

```bash
coverage.cmd
```

The report opens automatically in a browser and visually shows covered vs. uncovered code paths.

---

## Application Flow

1. User lands on the Index page
2. Visits are automatically tracked and persisted to the database
3. Live visit counter displays at the bottom of the page
4. User enters an email address
5. Redirected to Resume page
6. Resume data is retrieved via API calls
7. User can click Hire Me
8. Company + Job Title are submitted
9. Resume page shows "Viewing for: JobTitle @ Company"
10. User may Log Out to reset context
11. About Me page

---

## Tech Stack

### Backend
- ASP.NET Core (.NET 10.0)
- C# 12
- Entity Framework Core 10.0
- Microsoft SQL Server

### Frontend
- Razor Pages
- Bootstrap 5
- HTML5 / CSS3
- JavaScript

### API & Documentation
- RESTful Web API
- Swagger / OpenAPI
- API Versioning

### Database
- Azure SQL Database
- Entity Framework Core migrations
- SQL Server triggers

### Logging & Monitoring
- Serilog (structured logging)
- Rolling file logs

### Testing & Quality
- xUnit (unit testing)
- Moq (mocking)
- Coverlet (code coverage)
- WebApplicationFactory (integration testing)

### Dependency Injection
- ASP.NET Core DI Container
- Service registration and lifetime management

---

## Running Locally

### Prerequisites
- .NET 10.0 SDK or later
- Visual Studio 2022 or VS Code
- Azure SQL Database (or local SQL Server)
- SSMS (SQL Server Management Studio) for database management

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/jasonhart-dev/ResumeApi.git
   cd ResumeApi
   ```

2. **Configure your connection string**
   
   Update `appsettings.json` with your Azure SQL Database connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=tcp:your-server.database.windows.net,1433;Initial Catalog=your-db;Persist Security Info=False;User ID=your-user;Password=your-password;..."
     }
   }
   ```

3. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   
   From Visual Studio:
   - Press **F5**

   Or from command line:
   ```bash
   dotnet run
   ```

### Local URLs
- Index page: https://localhost:<port>/
- Resume page: https://localhost:<port>/Resume
- Swagger UI: https://localhost:<port>/swagger
- About page: https://localhost:<port>/About

---

## Database Architecture

### VisitCounters Table
Tracks the total number of visits to the application.

| Column | Type | Notes |
|--------|------|-------|
| Id | int | Primary Key |
| TotalVisits | bigint | Running total of all visits |
| LastUpdated | datetime2 | UTC timestamp of last visit |

### VisitCountersAudit Table
Automatically populated by SQL trigger to track every visit count change.

| Column | Type | Notes |
|--------|------|-------|
| Id | int | Primary Key |
| PreviousVisitCount | bigint | Visit count before increment |
| NewVisitCount | bigint | Visit count after increment |
| UpdatedAt | datetime2 | UTC timestamp when trigger fired |
| Action | nvarchar(50) | Action type (e.g., "Increment") |

### SQL Trigger
`trg_VisitCounters_Audit` - Automatically inserts audit records whenever the VisitCounters table is updated.

---

## API Endpoints

### Visit Counter
- **GET** `/api/visitcounter` - Get current visit count
  - Response: `{ "totalVisits": 42 }`

- **POST** `/api/visitcounter/increment` - Increment counter
  - Response: `{ "totalVisits": 43 }`

- **GET** `/api/visitcounter/audit?limit=100` - Get audit history
  - Response: Array of audit records with timestamps and counts
  - Query parameter `limit` (optional, default: 100) - Maximum records to return

### Resume (v2)
- GET /api/v2/resume/summary
- GET /api/v2/resume/experience
- GET /api/v2/resume/experience/{id}
- GET /api/v2/resume/skills
- GET /api/v2/resume/education

### Email Capture
- POST /api/emails
- GET /api/emails

### Hire Me
- POST /api/v2/hireme

Example request body:
```json
{
  "company": "Acme Corp",
  "jobTitle": "Senior Software Engineer"
}
```

---

## Swagger

Local:
```
https://localhost:<port>/swagger
```

After deployment:
```
https://hart-resume-api.azurewebsites.net/swagger
```

---

## Postman

All APIs can be exercised via Postman.

Example:
```
GET https://hart-resume-api.azurewebsites.net/api/v2/resume/summary
POST https://hart-resume-api.azurewebsites.net/api/visitcounter/increment
```

Import Swagger into Postman:
```
https://hart-resume-api.azurewebsites.net/swagger/v1/swagger.json
```

---

## Deployment (Azure)

This application is deployed to **Azure App Service** with **Azure SQL Database**.

### Deployment Features
- Data persists across app restarts
- Visit counter maintains accurate running total
- Audit trail automatically captured for all changes
- Structured logging to Application Insights (optional)

### Deployment URLs
- App URL: https://hart-resume-api.azurewebsites.net
- Index page: https://hart-resume-api.azurewebsites.net/
- Resume page: https://hart-resume-api.azurewebsites.net/Resume
- Swagger UI: https://hart-resume-api.azurewebsites.net/swagger

### App Restart Schedule
The app is restarted every 6 hours via Azure Automation. Visit counter data is preserved in the database.

---

## Recent Updates

### Phase 1-2: Visit Counter with Azure SQL Database
- Integrated Entity Framework Core with SQL Server provider
- Created VisitCounter model and ApplicationDbContext
- Implemented VisitCounterService with increment/query logic
- Created VisitCounterController with REST endpoints
- Added live visit counter display to homepage
- Data persists across app restarts

### Phase 3: Audit Trail with SQL Trigger
- Created VisitCountersAudit table for tracking changes
- Implemented SQL Server trigger for automatic audit logging
- Added GetAuditHistoryAsync service method with limit parameter
- Created GET /api/visitcounter/audit endpoint
- Configured EF Core to work with database triggers

---

## Future Enhancements

- [ ] Persist captured emails to database (with optional restoration)
- [ ] Email analytics and reporting dashboard
- [ ] Add date range filtering for audit history
- [ ] Health check endpoint for monitoring
- [ ] HttpClient retry and timeout policies for outbound calls
- [ ] Automatic email replies for captured emails
- [ ] Visit analytics dashboard with charts and trends
- [ ] Database performance optimization (indexing, query optimization)
- [ ] Backup and disaster recovery automation

---

## Development Workflow

This project uses feature branch development with pull requests:

1. Create a feature branch: `git checkout -b feature/feature-name`
2. Make changes and commit: `git commit -m "feat: description"`
3. Push to remote: `git push origin feature/feature-name`
4. Create a Pull Request on GitHub
5. Review and merge to main
6. Delete feature branch

---

## Author

Jason Hart  
Senior Software Engineer

---

## License

MIT License - See LICENSE file for details
