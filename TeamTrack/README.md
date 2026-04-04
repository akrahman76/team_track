# TeamTrack

<div align="center">

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-336791?logo=postgresql)
![Docker](https://img.shields.io/badge/Docker-✓-2496ED?logo=docker)
![License](https://img.shields.io/badge/License-MIT-green)

**A modern team and project management API built with Clean Architecture principles**

</div>

---

## 📖 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Architecture](#-architecture)
- [Tech Stack](#-tech-stack)
- [Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Database Setup](#database-setup)
  - [Docker Setup](#docker-setup)
  - [Running the Application](#running-the-application)
- [Configuration](#-configuration)
- [API Documentation](#-api-documentation)
  - [Authentication](#authentication)
  - [Organizations](#organizations)
  - [Projects](#projects)
  - [Tasks](#tasks)
- [Database Schema](#-database-schema)
- [Security](#-security)
- [Testing](#-testing)
- [Project Structure](#-project-structure)
- [Development](#-development)
- [Deployment](#-deployment)
- [Contributing](#-contributing)
- [License](#-license)

---

## 🎯 Overview

**TeamTrack** is a robust team and project management API designed to help organizations efficiently manage their projects, tasks, and team members. Built with modern software architecture principles, it provides a scalable and maintainable foundation for team collaboration tools.

### Key Capabilities

- **User Authentication & Authorization** - Secure JWT-based authentication with role-based access control
- **Organization Management** - Create and manage organizations with hierarchical roles (Owner, Admin, Member)
- **Project Management** - Organize work into projects within organizations
- **Task Tracking** - Create and manage tasks with status tracking (ToDo, InProgress, Done) and priority levels
- **Clean Architecture** - Well-organized codebase following industry best practices

---

## ✨ Features

- 🔐 **JWT Authentication** - Secure token-based authentication system
- 👥 **Role-Based Access Control** - Three-tier authorization (Owner, Admin, Member)
- 🏢 **Multi-Organization Support** - Users can create and join multiple organizations
- 📊 **Project Organization** - Group tasks and work within projects
- ✅ **Task Management** - Track tasks with status and priority
- 🏗️ **Clean Architecture** - Separation of concerns with Domain, Application, Infrastructure layers
- 🧪 **Unit Testing** - Comprehensive test coverage for business logic
- 🐳 **Docker Support** - Easy deployment with Docker Compose
- 📝 **Database Migrations** - Entity Framework Core migrations for schema management
- 🔒 **Policy-Based Authorization** - Fine-grained access control using ASP.NET Core policies

---

## 🏗️ Architecture

TeamTrack follows **Clean Architecture** principles, organizing the codebase into four distinct layers:

```
┌─────────────────────────────────────────────────┐
│                   API Layer                      │
│  (Controllers, DTOs, HTTP Configuration)         │
├─────────────────────────────────────────────────┤
│               Application Layer                  │
│  (Commands, Handlers, Services, Interfaces)      │
├─────────────────────────────────────────────────┤
│              Infrastructure Layer                │
│  (DbContext, Repositories, Identity, Auth)       │
├─────────────────────────────────────────────────┤
│                 Domain Layer                     │
│  (Entities, Enums, Business Rules)               │
└─────────────────────────────────────────────────┘
```

### Design Patterns

- **CQRS (Command Query Responsibility Segregation)** - Using MediatR for command handling
- **Repository Pattern** - Data access abstraction with Unit of Work
- **Dependency Injection** - Loose coupling throughout the application
- **Unit of Work** - Transactional consistency across repositories

### Layer Responsibilities

| Layer | Responsibility |
|-------|---------------|
| **Domain** | Core business entities, enums, and business rules |
| **Application** | Business logic, commands, handlers, and application services |
| **Infrastructure** | Data access, external services, authentication, persistence |
| **API** | HTTP endpoints, request/response handling, Swagger documentation |

---

## 🛠️ Tech Stack

### Backend
- **.NET 10** - Latest .NET framework with modern C# features
- **ASP.NET Core** - Web API framework
- **Entity Framework Core 10** - ORM for database access
- **MediatR** - CQRS implementation for command handling

### Database
- **PostgreSQL 16** - Primary relational database
- **Npgsql** - PostgreSQL provider for EF Core

### Authentication & Security
- **ASP.NET Identity** - User and role management
- **JWT Bearer Tokens** - Stateless authentication
- **Policy-Based Authorization** - Fine-grained access control

### DevOps & Tools
- **Docker & Docker Compose** - Containerization
- **OpenAPI/Swagger** - API documentation
- **xUnit** - Unit testing framework

---

## 🚀 Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker](https://www.docker.com/get-started) and Docker Compose
- [PostgreSQL](https://www.postgresql.org/download/) (if running without Docker)
- [Git](https://git-scm.com/downloads)

### Installation

1. **Clone the repository**
   ```bash
   git clone git@github.com:akrahman76/team_track.git
   cd TeamTrack
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   dotnet build
   ```

### Database Setup

#### Option 1: Using Docker (Recommended)

1. **Start PostgreSQL with Docker Compose**
   ```bash
   docker-compose up -d postgres
   ```

2. **Apply database migrations**
   ```bash
   cd TeamTrack.Infrastructure
   dotnet ef database update
   ```

#### Option 2: Local PostgreSQL

1. **Create a PostgreSQL database**
   ```sql
   CREATE DATABASE teamtrack;
   ```

2. **Update connection string** in `appsettings.json`
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=teamtrack;Username=your_user;Password=your_password"
   }
   ```

3. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

### Docker Setup

Start all services (PostgreSQL and pgAdmin):

```bash
docker-compose up -d
```

Access services:
- **PostgreSQL**: `localhost:5432`
- **pgAdmin**: `http://localhost:5050` (login: admin@example.com / admin)

### Running the Application

#### Development Mode

```bash
dotnet run --project TeamTrack
```

The API will be available at:
- **HTTP**: http://localhost:5038
- **HTTPS**: https://localhost:7085
- **Swagger UI**: https://localhost:7085/swagger (when enabled)

#### Using Visual Studio / Rider

1. Open `TeamTrack.slnx` in your IDE
2. Set `TeamTrack` as the startup project
3. Press F5 to run

---

## ⚙️ Configuration

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=teamtrack;Username=postgres;Password=postgres"
  },
  "Jwt": {
    "Issuer": "TeamTrack",
    "Audience": "TeamTrack.Client",
    "Key": "THIS_IS_A_DEV_ONLY_SECRET_KEY_CHANGE_LATER",
    "AccessTokenMinutes": 30
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Configuration Sections

| Section | Description |
|---------|-------------|
| **ConnectionStrings** | Database connection configuration |
| **Jwt** | JWT token settings (issuer, audience, secret key, expiration) |
| **Logging** | Logging level configuration |
| **AllowedHosts** | CORS and host restrictions |

### Environment Variables

For production, use environment variables instead of appsettings:

```bash
# Database
ConnectionStrings__DefaultConnection="Host=db;Database=teamtrack;Username=user;Password=pass"

# JWT
Jwt__Key="your-production-secret-key-here"
Jwt__Issuer="TeamTrack"
Jwt__Audience="TeamTrack.Client"
```

---

## 📚 API Documentation

### Base URL
```
https://localhost:7085/api
```

### Authentication

All authenticated endpoints require a JWT token in the Authorization header:
```
Authorization: Bearer <your_jwt_token>
```

#### Register User
```http
POST /api/auth/register
Content-Type: application/x-www-form-urlencoded

email=user@example.com&password=Password123!
```

#### Login
```http
POST /api/auth/login
Content-Type: application/x-www-form-urlencoded

email=user@example.com&password=Password123!
```

**Response:**
```json
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Organizations

#### Create Organization
```http
POST /api/org/organizations/create
Authorization: Bearer <token>
Content-Type: application/json

{
  "name": "My Organization"
}
```

**Response:** `201 Created` with location header

### Projects

#### Create Project
```http
POST /api/org/organizations/{organizationId}/projects
Authorization: Bearer <token>
Content-Type: application/json

{
  "name": "Project Alpha",
  "description": "Description of the project"
}
```

**Response:** `201 Created` with location header

### Tasks

#### Create Task
```http
POST /api/task/projects/{projectId}/create
Authorization: Bearer <token>
Content-Type: application/json

{
  "name": "Implement feature",
  "description": "Task description"
}
```

**Response:** `201 Created` with location header

### Authorization Policies

| Policy | Required Role | Description |
|--------|---------------|-------------|
| `OrgMember` | Member, Admin, Owner | Basic organization member access |
| `OrgAdmin` | Admin, Owner | Administrative privileges |
| `OrgOwner` | Owner | Organization owner privileges |

---

## 🗄️ Database Schema

### Entity Relationship Diagram

```
┌─────────────────┐     ┌─────────────────────┐
│      User       │     │    Organization     │
├─────────────────┤     ├─────────────────────┤
│ Id (PK)         │     │ Id (PK)             │
│ Email           │     │ Name                │
└─────────────────┘     └─────────────────────┘
        │                        │
        │                        │
        │                        │
┌─────────────────┐     ┌─────────────────────┐
│ OrganizationMember│   │      Project        │
├─────────────────┤     ├─────────────────────┤
│ Id (PK)         │     │ Id (PK)             │
│ UserId (FK)     │◄────│ OrganizationId (FK) │
│ OrganizationId  │     │ Name                │
│ Role            │     │ Description         │
└─────────────────┘     └─────────────────────┘
                               │
                               │
                               ▼
                        ┌─────────────────────┐
                        │      TaskItem       │
                        ├─────────────────────┤
                        │ Id (PK)             │
                        │ ProjectId (FK)      │
                        │ Title               │
                        │ Status              │
                        │ Priority            │
                        └─────────────────────┘
```

### Key Entities

| Entity | Description |
|--------|-------------|
| **User** | Application user with email |
| **Organization** | Company or team organization |
| **OrganizationMember** | Links users to organizations with roles |
| **Project** | Projects within an organization |
| **TaskItem** | Tasks within a project with status and priority |

### Enums

**OrganizationRole:**
- `Member` - Basic member access
- `Admin` - Administrative privileges
- `Owner` - Full organization control

**TaskStatus:**
- `ToDo` - Task not started
- `InProgress` - Task being worked on
- `Done` - Task completed

**TaskPriority:**
- `Low` - Low priority
- `Medium` - Normal priority (default)
- `High` - High priority
- `Critical` - Urgent priority

---

## 🔐 Security

### Authentication Flow

1. User registers with email and password
2. User logs in and receives JWT token
3. Token is included in Authorization header for subsequent requests
4. Token is validated on each request
5. User claims and roles are extracted from token

### Password Requirements

- Minimum length: 6 characters
- Requires digit: Yes
- Requires lowercase: Yes
- Requires uppercase: No
- Requires non-alphanumeric: No

### JWT Configuration

| Setting | Description | Default |
|---------|-------------|---------|
| **Issuer** | Token issuer identifier | TeamTrack |
| **Audience** | Intended audience | TeamTrack.Client |
| **Key** | Secret signing key | (dev key) |
| **AccessTokenMinutes** | Token expiration time | 30 minutes |

### Authorization Policies

The application uses policy-based authorization with custom handlers:

- **OrganizationRoleRequirement** - Validates user's role in organization
- **OrganizationAuthorizationService** - Checks organization membership and permissions

---

## 🧪 Testing

### Run All Tests

```bash
dotnet test
```

### Run Specific Test Project

```bash
dotnet test TeamTrack.Application.UnitTests
```

### Test Coverage

The project includes unit tests for:
- Command handlers (CreateProject, CreateTask, CreateOrganization)
- Business logic validation
- Error handling scenarios

### Writing Tests

Tests are located in `TeamTrack.Application.UnitTests/` and follow the Arrange-Act-Assert pattern:

```csharp
[Fact]
public async Task Handle_ShouldCreateProject_WhenValidCommand()
{
    // Arrange
    var command = new CreateProjectCommand(orgId, "Test", "Desc");
    
    // Act
    var result = await handler.Handle(command, CancellationToken.None);
    
    // Assert
    Assert.NotNull(result);
}
```

---

## 📂 Project Structure

```
TeamTrack/
├── TeamTrack/                    # API Layer
│   ├── Controllers/              # API endpoints
│   │   ├── AuthController.cs
│   │   ├── OrgController.cs
│   │   └── TaskController.cs
│   ├── DTO/                      # Data Transfer Objects
│   ├── Program.cs                # Application entry point
│   └── appsettings.json          # Configuration
│
├── TeamTrack.Domain/             # Domain Layer
│   ├── Entities/                 # Business entities
│   │   ├── User.cs
│   │   ├── Organization.cs
│   │   ├── OrganizationMember.cs
│   │   ├── Project.cs
│   │   └── TaskItem.cs
│   ├── Enums/                    # Value objects
│   │   ├── OrganizationRole.cs
│   │   ├── TaskStatus.cs
│   │   └── TaskPriority.cs
│   └── Common/                   # Base classes
│       └── BaseEntity.cs
│
├── TeamTrack.Application/        # Application Layer
│   ├── Command/                  # CQRS Commands
│   │   ├── CreateOrganizationCommand.cs
│   │   ├── CreateProjectCommand.cs
│   │   └── CreateTaskCommand.cs
│   ├── CommandHandler/           # Command handlers
│   │   ├── CreateOrganizationCommandHandler.cs
│   │   ├── CreateProjectCommandHandler.cs
│   │   └── CreateTaskCommandHandler.cs
│   ├── Services/                 # Application services
│   │   └── JwtTokenService.cs
│   ├── Common/                   # Shared interfaces
│   │   └── Interfaces/
│   └── Auth/                     # Authentication logic
│       └── Requirements/
│
├── TeamTrack.Infrastructure/     # Infrastructure Layer
│   ├── Persistence/              # Database context
│   │   ├── AppDbContext.cs
│   │   └── Configurations/
│   ├── Repositories/             # Data access
│   │   ├── OrganizationRepository.cs
│   │   ├── ProjectRepository.cs
│   │   ├── TaskItemRepository.cs
│   │   └── UnitOfWork.cs
│   ├── Identity/                 # ASP.NET Identity
│   │   └── ApplicationUser.cs
│   ├── Auth/                     # Authorization
│   │   ├── OrganizationAuthorizationService.cs
│   │   └── Handlers/
│   └── Migrations/               # EF Core migrations
│
├── TeamTrack.Application.UnitTests/  # Unit Tests
│   ├── CreateProjectCommandHandlerTests.cs
│   └── CreateTaskItemCommandHandlerTest.cs
│
├── docker-compose.yml            # Docker configuration
└── TeamTrack.slnx               # Solution file
```

---

## 🛠️ Development

### Adding New Features

1. **Create Domain Entity** (if needed)
   - Add entity to `TeamTrack.Domain/Entities/`
   - Define enums in `TeamTrack.Domain/Enums/`

2. **Create Command**
   - Add command class to `TeamTrack.Application/Command/`
   - Implement command handler in `TeamTrack.Application/CommandHandler/`

3. **Add Repository** (if needed)
   - Create repository interface in `TeamTrack.Application/Common/Interfaces/`
   - Implement repository in `TeamTrack.Infrastructure/Repositories/`

4. **Create Controller Endpoint**
   - Add controller action in appropriate controller
   - Apply authorization policies as needed

5. **Add Configuration**
   - Register services in `Program.cs`
   - Update `appsettings.json` if needed

### Code Style

- Follow C# naming conventions
- Use `async/await` for I/O operations
- Apply dependency injection
- Keep methods small and focused
- Write meaningful comments for complex logic

### Database Migrations

```bash
# Add new migration
dotnet ef migrations add MigrationName --project TeamTrack.Infrastructure

# Update database
dotnet ef database update

# Remove last migration
dotnet ef migrations remove --project TeamTrack.Infrastructure
```

---

## 🚀 Deployment

### Docker Deployment

1. **Build Docker image**
   ```bash
   docker build -t teamtrack-api .
   ```

2. **Run with Docker Compose**
   ```bash
   docker-compose up -d
   ```

3. **Access the API**
   ```
   http://localhost:5038
   ```

### Production Considerations

- **Use environment variables** for sensitive configuration
- **Change JWT secret key** to a strong, unique value
- **Enable HTTPS** in production
- **Use connection pooling** for database
- **Implement rate limiting** and API throttling
- **Add health checks** for monitoring
- **Configure logging** to external service (e.g., Serilog, Application Insights)
- **Use reverse proxy** (Nginx, Apache) for load balancing

### CI/CD Pipeline

Consider implementing:
- Automated testing on pull requests
- Docker image building and pushing to registry
- Database migration automation
- Deployment to staging/production environments

---

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Guidelines

- Write clean, maintainable code
- Add unit tests for new functionality
- Update documentation as needed
- Follow existing code patterns
- Ensure all tests pass before submitting

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 🙏 Acknowledgments

- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [MediatR Documentation](https://github.com/jbogard/MediatR)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

---

<div align="center">

**Built with ❤️ using .NET**

[Back to Top](#teamtrack)

</div>