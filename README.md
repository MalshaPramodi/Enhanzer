# Enhanzer Full Stack Assignment

A full-stack web application developed as a technical assessment for **Enhanzer**, featuring user authentication through an external POS API and a Purchase Bill management interface.

## 📌 Overview

This project demonstrates a full-stack implementation using **Angular** and **ASP.NET Core Web API**, with **SQL Server** for data persistence.

### Key Features

- 🔐 **Login** — Authentication through Enhanzer's external POS API via the .NET backend
- 🧾 **Purchase Bill** — Create and manage purchase bill information
- 🔄 **API Integration** — Backend proxy for communication with the external POS API
- 🗄️ **Database Integration** — SQL Server for application data
- 📱 **Responsive UI** — Angular-based frontend

---

## 🛠️ Tech Stack

| Layer                 | Technology                    |
| --------------------- | ----------------------------- |
| **Frontend**          | Angular, TypeScript           |
| **Backend**           | ASP.NET Core Web API (.NET 8) |
| **Database**          | Microsoft SQL Server          |
| **API Communication** | REST API                      |

---

## 📋 Prerequisites

Make sure the following are installed before running the application:

| Tool            | Required Version                   | Check Installation   |
| --------------- | ---------------------------------- | -------------------- |
| **Node.js**     | 22.x LTS or higher                 | `node -v`            |
| **npm**         | 10.x or higher                     | `npm -v`             |
| **.NET SDK**    | 8.0.x                              | `dotnet --list-sdks` |
| **SQL Server**  | LocalDB, Express, or Full Instance | —                    |
| **Angular CLI** | Latest                             | Installed via `npx`  |

Test Request
{
"email": "info@enhanzer.com",
"password": "Welcome#5"
}
