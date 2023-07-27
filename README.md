# Bank Data Import

Bank Data Import Web App is responsible for Importing CSV file, Displaying imported data and providing a summary report on accounts transactions based on imported data.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Entity Framework Core Migrations](#entity-framework-core-migrations)
- [Setting up Multiple Project Startup in Visual Studio 2022](#setting-up-multiple-project-startup-in-visual-studio-2022)

## Features

1. **CSV Import into Database**: Allows importing data from CSV files into the database for easy data migration.
2. **Bank Accounts List**: Provides a list of bank accounts with relevant details.
3. **Transactions**: Manages transactions associated with bank accounts.
4. **Bank Accounts Transactions Summary List**: Presents a summary list of transactions for each bank account.
5. **MSSQL Data**: Utilizes MS SQL Server to store and retrieve data from the database.
6. **Entity Framework Core**: Integrates Entity Framework Core for database management.
7. **CQRS Patterns**: Implements CQRS (Command Query Responsibility Segregation) patterns for better separation of concerns.
8. **MediatR Library**: Uses MediatR library for handling queries and commands.

## Technologies Used

- .NET 6
- ASP.NET Core Web API
- Entity Framework Core
- MS SQL Server
- MediatR Library
- MudBlazor Library
- Blazor WebAssembly

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MS SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any other supported database server)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

### Installation

1. Clone the repository: `git clone https://github.com/DevJr14/Bank-Data-Import.git`
2. Navigate to the project directory: `cd Bank-Data-Import`
3. Restore dependencies: `dotnet restore`
4. Build the solution: `dotnet build`

## Database

Ensure that you have MSSQL Server installed locally
1. Update database server name inside  `appsettings.json` or `appsettings.Development.json` file.

## Entity Framework Core Migrations

To apply the Entity Framework Core migrations and create the database schema, follow these steps:

1. Go to Tools > Nuget Package Manager > Package Manager Console
2. Set WebApi project as a startup
3. Set Infrastructure as Default prohject on Package Manger Console
4 Run the following command to apply migrations:
	`update-database` and press enter

5. This will apply any pending migrations and create the necessary database tables.

Note: Make sure you have configured the database connection string in the `appsettings.json` or `appsettings.Development.json` file.

## Setting up Multiple Project Startup in Visual Studio 2022

To run both the Web API and the BankApp (Blazor WebAssembly) projects simultaneously during development, follow these steps:

1. Open the solution in Visual Studio 2022.
2. Right-click on the solution in the Solution Explorer and select "Configure Startup Projects".
3. In the Dialog, click Multiple startup projects.
5. Set the "Action" to "Start" for both the Web API project and the BankApp project.
6. If required, set the order in which the projects should start (Web API first, then BankApp).
7. Click the "Apply" button to save your changes, and then click "OK" to close the Solution Property Pages.
8. Now, when you run the solution (press F5 or click the "Start" button), both the Web API and the BankApp will start simultaneously.

This setup is beneficial during development as it enables seamless testing and debugging of the integrated projects. When you run the solution, you'll have both the API and the Blazor application running concurrently, which can help you test how they interact with each other in real-time.
