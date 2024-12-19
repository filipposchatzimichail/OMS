# OMS
### Order Management System (OMS)

An Order Management System for delivery/takeaway restaurant operations.

- Backend: .NET 8 
- Frontend: Angular v19
- SOLID Architecture
- Repository/Unit of work pattern
- Reusable Classes
- Best Practices
- Dependency Injection
- EF Core (9.0.0)

### Features
- Ability to switch between public and admin mode
- Ability to create delivery or pickup orders
- Ability to modify (Add/Remove/Update) the current Menu (Admin mode)
- Ability to view all orders (Admin mode)

### Setup Instructions
- Run the command `dotnet ef database update --project ./OMS.DataAccess --startup-project ./OMS.App` from the folder ./src/server (An SQL server DB sould be installed)
- Open up the OMS.sln (Requires Visual Studio)
- Build & Run the solution to start up the backend
- The client frontend should be available at http://localhost:58000/ after a few seconds

### Seeding the database
- Import or run the file ./src/server/OMS.DataAccess/SeedData.sql to create the Restaurant Menu and 2 sample orders (1 delivery and 1 pickup)




