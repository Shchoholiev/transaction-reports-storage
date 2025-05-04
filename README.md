# Transaction Reports Storage

An application that displays a report of completed transactions. Developed as a test task for a Junior position, completed within 4 hours using WinForms and DevExpress.

## Table of Contents

- [Features](#features)
- [Stack](#stack)
- [Installation](#installation)
  - [Prerequisites](#prerequisites)
  - [Setup Instructions](#setup-instructions)
- [Configuration](#configuration)
- [Usage](#usage)

## Features

- Display reports of completed transactions.
- User-friendly interface with DevExpress components.
- Efficient data handling using Entity Framework Core.

## Stack

- **Programming Language:** C#
- **Framework:** .NET 6
- **UI Framework:** WinForms with DevExpress
- **ORM:** Entity Framework Core
- **Database:** SQL Server

## Installation

### Prerequisites

- **.NET 6 SDK:** Ensure that the .NET 6 SDK is installed on your machine. You can download it from the [.NET official website](https://dotnet.microsoft.com/download/dotnet/6.0).
- **SQL Server:** A running instance of SQL Server is required for the database.

### Setup Instructions

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/Shchoholiev/transaction-reports-storage.git
   cd transaction-reports-storage
   ```

2. **Restore Dependencies:**

   Navigate to the project directory and restore the necessary NuGet packages:

   ```bash
   cd TransactionReportsStorage
   dotnet restore
   ```

3. **Configure the Database:**

   - Update the `appsettings.json` file with your SQL Server connection string:

     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TransactionReports;Trusted_Connection=True;"
       }
     }
     ```

   - Apply the database migrations to set up the database schema:

     ```bash
     dotnet ef database update
     ```

4. **Build and Run the Application:**

   ```bash
   dotnet build
   dotnet run
   ```

## Configuration

- **Connection Strings:** Ensure that the `appsettings.json` file contains the correct connection string to your SQL Server instance.
- **DevExpress License:** If you have a DevExpress license, ensure that it is properly configured. For trial versions, follow the DevExpress documentation for setup.

## Usage

- **View Transaction Reports:** Launch the application to view reports of completed transactions.
- **Filter Transactions:** Utilize the filtering options to view specific transactions based on criteria such as date range or transaction type.
- **Export Reports:** Export transaction reports to various formats for further analysis or record-keeping.
