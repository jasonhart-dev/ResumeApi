# ResumeApi Sample Project

## Overview
This is a sample ASP.NET Core 10 Razor Pages project designed for interview purposes.  
It demonstrates:
- Razor Pages form with validation
- Email capture with duplicate prevention
- In-memory storage using a service layer
- Admin page to view captured emails
- API endpoints for external consumption
- Dependency Injection and clean architecture

---

## Project Structure
Controllers/ # API controllers
Pages/ # Razor Pages UI
Services/ # Business logic and storage
Program.cs # App startup and DI

---

## How to Run

1. Open in Visual Studio 2022 or later
2. Restore NuGet packages
3. Press F5 to run
4. Visit: 
   - `https://localhost:7117/` → Email capture page
   - `https://localhost:7117/admin/emails` → Admin view
   - `https://localhost:7117/api/emails` → API endpoint

---

## Features

- **Email capture**
  - Validates format
  - Prevents duplicates
- **Admin page**
  - View all captured emails
  - Read-only
- **API**
  - `GET /api/emails` → List of emails
  - `POST /api/emails` → Capture email (returns success / duplicate message)
- **Architecture**
  - Separation of concerns (UI, service, API)
  - Dependency Injection (constructor injection)
  - PRG pattern for Razor Page submission
- **Resume details  IN PROGRESS**
	-Basic outline of my resume, will update with more detail and be searchable by job via API

---

## API Documentation (Swagger)

This project includes Swagger for API exploration.  

- Visit `https://localhost:7117/swagger` to see the interactive API UI.
- You can test:
  - `GET /api/emails` → List captured emails
  - `POST /api/emails` → Capture an email (returns success / duplicate message)
- Swagger automatically documents endpoints and request/response formats.

---

## Notes

- Emails are stored **in-memory**. Restarting the app clears data.
- Duplicate emails are prevented at the service layer, so all access points respect the rule.
- Designed to be **interview-ready** and easy to extend (e.g., swap in database).

