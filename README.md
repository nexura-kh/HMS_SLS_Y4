# 🏨 Hotel Management System (README)

## Project overview
HMS is a small hotel management application 
implemented in .NET 8. It organizes bookings, customers, rooms, food orders and order items through a repository pattern and stores data in MySQL. The codebase uses repository classes in Repositories\*, domain models in Models\*, UI/interaction components in Components\*, and database helpers and seeders in Data\* and Seeders\*.

---

key files to inspect:

- Data\DatabsaeHelper.cs — holds the database connection string.
- 	Repositories\* — repositories such as OrderItemRepository.cs, BookingRepository.cs, PaymentRepository.cs.
- 	Components\* — UI/business components (e.g., Reservation.cs, Order.cs, Customer.cs).
- 	Seeders\SeedRoom.cs — sample data seeder.

##  Features

- 	Booking management (create/read/update bookings)
- 	Room and room-type management
-   Food menu, food orders and order items
- 	Repository pattern for data access (MySQL)
-	Seeders to bootstrap initial data
-   Customer and user management

---

##  Tech Stack
- .NET 8 
- Mysql(via MySql.Data)
- 	Desktop UI (uses MessageBox in repos — desktop app like WinForms/WPF)
- 	Repository pattern + DTOs

## Prerequisites 
- 	Visual Studio 2022 (or later) with .NET 8 workloads installed
-	MySQL server accessible (local or remote)
-	NuGet restore for packages (MySql.Data)


## Quick start - setup & run

1. Clone the repository and open the solution in Visual Studio 2022.
1. Restore NuGet packages: Project > Manage NuGet Packages or right-click solution and Restore NuGet Packages.
1. Update the DB connection string in Data\DatabsaeHelper.cs to point at your MySQL server.
1. Copy the SQL schema from the SQL folder and run it in your MySQL server to create the necessary tables.
1. (Optional) Run the seeders in Seeders\* to populate initial data.
1. Build and run the project (F5) to launch the application.
1. To login as admin, use username: `admin`, password: `12345`.






