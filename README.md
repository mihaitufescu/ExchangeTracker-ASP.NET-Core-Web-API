# ExchangeTracker - ASP.NET Core Web API

ExchangeTracker is a ASP.NET Core WebApi for currency rate tracking, with user registration and data management. It fetches data from the National Bank of Romania (BNR) API using Hangfire for background jobs. The implementation consist of a repository pattern architecture for underlying data access logic from the business logic, migrations for documenting and managing database schema changes, and AutoMapper for mapping between model classes and API DTOs.

## Key features

### Documentation with Swagger 📚

Swagger documentation and environment for testing and development. 

(placeholder)

### Entity Framework Mapping 🗺️

Usage of Entity Framework (EF) to map domain entities to the underlying SQL Server database, providing seamless interaction between the application's object-oriented model and the relational database. 

(placeholder)

### AutoMapper 🚀

Its role is to streamline the mapping process between domain model classes and Data Transfer Objects (DTOs) exposed by the API, while reducing boilerplate code and enhancing code maintainability. 

### Repository Pattern Implementation 🏛️

Facilitates the abstraction of data access operations from the application's business logic. This pattern enhances code maintainability and scalability by encapsulating data access operations within dedicated repository classes, promoting a clear separation of concerns. 

(placeholder)

### Hangfire Jobs 🕒

Hangfire is used in ExchangeTracker to manage background jobs, particularly for fetching data from the BNR API every working day at its publishing date. These services run asynchronously and are scheduled to ensure that currency rate data remains up-to-date without manual intervention. It also offers a dashboard for monitoring these background tasks. 

(placeholder)