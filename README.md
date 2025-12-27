# ResumeApi

An interview-ready ASP.NET Core application that demonstrates API design, Razor Pages UI, versioned endpoints, and clean separation of concerns using a realistic resume-driven use case.

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

---

## Tech Stack

- ASP.NET Core
- Razor Pages
- Web API
- Swagger / OpenAPI
- Dependency Injection
- IHttpClientFactory
- In-memory services (no database yet)

---

## Running Locally

### Prerequisites
- .NET SDK installed
- Visual Studio 2022 or newer (optional)

### Run

From Visual Studio:
- Press F5

Or from the command line:
dotnet run

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
{
  "company": "Acme Corp",
  "jobTitle": "Senior Software Engineer"
}

---

## Swagger
 
Local:
https://localhost:<port>/swagger

After deployment:
https://<your-app>.azurewebsites.net/swagger

---

## Postman

You can call all APIs using Postman.

Example:
GET https://<your-app>.azurewebsites.net/api/v2/resume/summary

Import Swagger into Postman:
https://<your-app>.azurewebsites.net/swagger/v1/swagger.json

---

## Deployment (Azure)

This application is designed to be deployed to Azure App Service.

After deployment:
- App URL: https://<your-app>.azurewebsites.net
- Swagger UI available publicly
- APIs accessible via browser or Postman

Note: The app currently uses in-memory storage. Restarting the app clears data.

---

## Future Enhancements

###- Persist data using SQLite or SQL Server
###- Add authentication
###- Improve UI styling with Bootstrap or React
###- Add admin dashboard for Hire Me submissions

---

## Author

Jason Hart
Senior Software Engineer
