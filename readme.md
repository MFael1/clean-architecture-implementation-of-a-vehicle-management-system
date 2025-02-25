# FaelMotors

A clean architecture implementation of a vehicle management system built with .NET 8. This project demonstrates domain-driven design principles, CQRS pattern with MediatR, and clean architecture separation of concerns.

## Project Structure

FaelMotors follows the clean architecture pattern with the following projects:

- **Motors.Domain**: Contains enterprise business rules, entities, value objects, and domain events
- **Motors.Application**: Contains application business rules, commands, queries, and validations
- **Motors.Infrastructure**: Contains frameworks, database access, and external services integration
- **Motors.Api**: Contains controllers and API configuration

## Technologies

- .NET 8
- Entity Framework Core 8
- PostgreSQL
- MediatR for CQRS pattern
- FluentValidation for request validation
- Swagger for API documentation

## Architecture Highlights

- **Domain-Driven Design**: Aggregate roots, value objects, domain events
- **CQRS Pattern**: Command and Query separation using MediatR
- **Repository Pattern**: Abstraction over data access
- **Unit of Work**: Ensures atomic operations
- **Fluent Validation**: Request validation pipeline
- **Global Exception Handling**: Centralized error management
- **Domain Events**: Allows for decoupled communication between aggregates

## Getting Started

### Prerequisites

- .NET 8 SDK
- PostgreSQL

### Database Setup

1. Update the connection string in `Motors.Api/appsettings.json` to match your PostgreSQL configuration
2. Apply migrations to create the database:

```bash
cd Motors.Api
dotnet ef database update
```

### Running the Application

```bash
cd Motors.Api
dotnet run
```

The API will be available at:
- HTTP: http://localhost:5167
- HTTPS: https://localhost:7119
- Swagger UI: http://localhost:5167/swagger

## API Endpoints

### Vehicles

- **POST /api/vehicles** - Create a new vehicle
- **GET /api/vehicles** - Get all vehicles

## Domain Model

### Vehicle Aggregate

- **Properties**:
  - Brand (required)
  - Model (optional)
  - Date (optional)
  
### Domain Events

- **VehicleCreatedEvent**: Triggered when a new vehicle is created

## Future Enhancements

- Authentication and authorization
- Additional vehicle properties and related aggregates
- Pagination for GET endpoints
- Reporting and analytics features
- Front-end implementation

## Development Patterns

- **Repository Pattern**: Abstract data access
- **Mediator Pattern**: Decouple request handlers
- **Validation Pipeline**: Validate requests before reaching handlers
- **Domain Events**: Decouple business logic across aggregates

## License

This project is licensed under the MIT License - see the LICENSE file for details.
