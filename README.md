# Grocerie - Shopping List API

This is a backend API built with **ASP.NET Core 9** and Clean Architecture for a grocery shopping list web application. It allows users to sign in, create, edit, and delete grocery lists, as well as manage grocery items.

## Features

- **User Authentication**: Users can sign up and log in to manage their grocery lists.
- **Grocery Lists**: Users can create, edit, and delete grocery lists.
- **Grocery Items**: Users can create, edit, and delete grocery items within their lists.
- **Clean Architecture**: The project follows Clean Architecture principles for separation of concerns and maintainability.

## Technologies Used

- **ASP.NET Core 9**: A cross-platform framework for building modern web APIs.
- **Entity Framework Core**: An ORM for database interactions.
- **JWT Authentication**: For secure user authentication.
- **SQL Server**: Database for storing user data, lists, and items.
- **MediatR**: For implementing the CQRS pattern.
- **FluentValidation**: For validating requests.

## Project Structure

The project follows Clean Architecture with the following layers:

1. **Domain**: Contains the core business logic, entities, and interfaces.
2. **Application**: Implements use cases, CQRS commands/queries, and application-specific logic.
3. **Infrastructure**: Handles external concerns like database access, authentication, and third-party integrations.
4. **Presentation**: Contains the Web API controllers and middleware.
