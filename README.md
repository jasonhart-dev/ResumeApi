# ResumeApi

An interview-ready ASP.NET Core application that demonstrates API design, Razor Pages UI, versioned endpoints, and production-oriented reliability patterns using a realistic resume-driven use case.

---

## Features

### UI (Razor Pages)
- Email capture entry page
- Resume display page
- Professional Summary and Experience loaded via API calls
- “Hire Me” interaction flow (Company + Job Title)
- Contextual banner showing which role the resume is being viewed for
- Logout action that resets view context and returns to entry page

### API
- Versioned REST APIs (/api/v2/...)
- Resume data endpoints (read-only)
- Email capture endpoint
- Hire Me submission endpoint
- Swagger / OpenAPI enabled

### Logging & Reliability
- Structured logging using Serilog
- Console and rolling file log sinks
- Request lifecycle logging (method, path, status, duration)
- Centralized global exception handling
- Standardized error responses using ProblemDetails
- Graceful failure behavior with no unhandled exceptions leaking to clients

---

## Application Flow

1. User lands on the Index page
2. Enters an email address
3. Redirected to Resume page
4. Resume data is retrieved via API calls
5. User can click Hire Me
6. Company + Job Title are submitted
7. Resume page shows “Viewing for: JobTitle @ Company”
8. User may Log Out to reset context
9. About Me page

---

## Tech Stack

- ASP.NET Core
- Razor Pages
- Web API
- Serilog (structured logging)
- Swagger / OpenAPI
- Dependency Injection
- IHttpClientFactory
- API Versioning
- In-memory services (no database yet)

---

## Running Locally

### Prerequisites
- .NET SDK installed
- Visual Studio 2022 or newer (optional)

### Run

From Visual Studio:
- Press **F5**

Or from the command line:
```bash
dotnet run
```

### Local URLs
- Index page: https://localhost:<port>/
- Resume page: https://localhost:<port>/Resume
- Swagger UI: https://localhost:<port>/swagger

---

## API Endpoints

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
```

Import Swagger into Postman:
```
https://hart-resume-api.azurewebsites.net/swagger/v1/swagger.json
```

---

## Deployment (Azure)

This application is deployed to **Azure App Service**.

After deployment:
- App URL: https://hart-resume-api.azurewebsites.net
- Swagger UI available publicly
- APIs accessible via browser or Postman
- Logs written at runtime (console + rolling files)

**Note:** The app currently uses in-memory storage. Restarting the app clears data.  
The app is restarted every 6 hours via an Azure Automation PowerShell script.

### Deployment URLs
- Index page: https://hart-resume-api.azurewebsites.net/
- Resume page: https://hart-resume-api.azurewebsites.net/Resume
- Swagger UI: https://hart-resume-api.azurewebsites.net/swagger

---

## Future Enhancements

- Add HttpClient retry and timeout policies for outbound calls
- Add health check endpoint for monitoring
- Add unit and integration tests
- Improve UI styling with Bootstrap or React
- Persist data using SQLite or SQL Server
- Add automatic email replies for captured emails
- Add a /api/meta endpoint describing the project and architecture

---

## Author

Jason Hart  
Senior Software Engineer
