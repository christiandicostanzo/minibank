# Minibank

A modern Core Banking System example built with .NET and microservices architecture, demonstrating best practices in enterprise software development.

## 🏦 About

Minibank is a comprehensive example of a Core Banking system that showcases modern software architecture patterns and technologies. The system allows for:

- **Customer Management**: Register and manage customer information
- **Account Management**: Create and manage banking accounts
- **Transaction Processing**: Handle financial transactions securely

## 🏗️ Architecture

The system follows **Clean Architecture** principles with a **microservices** approach, ensuring separation of concerns, testability, and maintainability.

### Services

- **Minibank.Customers**: Customer management service
- **Minibank.AccountsAndTransactions**: Account and transaction management service
- **Minibank.ApiGateway**: YARP-based API Gateway for routing and load balancing

### Architecture Layers (Example: Customers Service)

```
├── MiniBank.Customers.Api/          # Presentation Layer (Minimal APIs)
├── MiniBank.Customers.Application/  # Application Layer (Use Cases, DTOs)
├── MiniBank.Customers.Domain/       # Domain Layer (Entities, Repositories)
└── MiniBank.Customers.Infrastructure/ # Infrastructure Layer (Data Access, Cache)
```

## 🛠️ Technology Stack

- **.NET 10**: Latest version of .NET Core
- **YARP**: Reverse proxy for API Gateway
- **MongoDB**: Primary database for data persistence
- **PostgreSQL**: Relational database support
- **Redis**: Caching layer for performance optimization
- **Serilog**: Structured logging
- **MediatR**: CQRS and mediator pattern implementation
- **Apache Kafka**: Event streaming and messaging
- **Elasticsearch & Kibana**: Logging and monitoring

## 🎯 Design Patterns & Practices

- **Clean Architecture**: Separation of concerns with clear layer boundaries
- **Microservices**: Distributed system design
- **Dependency Injection**: IoC container for loose coupling
- **Specification Pattern**: Flexible query building
- **Repository Pattern**: Data access abstraction
- **CQRS**: Command Query Responsibility Segregation with MediatR
- **Minimal APIs**: Lightweight API endpoints
- **Result Pattern**: Functional error handling

## 🚀 Getting Started

### Prerequisites

- .NET 10 SDK
- Docker & Docker Compose
- Git

### Quick Start

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd minibank
   ```

2. **Start infrastructure services**
   ```bash
   docker-compose up -d
   ```
   This will start:
   - MongoDB (port 27017)
   - Redis (port 6379, UI on 8001)
   - Kafka (port 9092, UI on 8080)
   - Elasticsearch (port 9200)
   - Kibana (port 5601)

3. **Run the services**
   
   **API Gateway:**
   ```bash
   cd Minibank.ApiGateway/Minibank.ApiGateway
   dotnet run
   ```
   
   **Customers Service:**
   ```bash
   cd Minibank.Customers/service/MiniBank.Customers.Api
   dotnet run
   ```
   
   **Accounts & Transactions Service:**
   ```bash
   cd Minibank.AccountsAndTransactions/service/Minibank.AccountsAndTransactions.Api
   dotnet run
   ```

### API Documentation

Each service provides Swagger documentation when running in development mode:
- Customers API: `http://localhost:<port>/swagger`
- Accounts & Transactions API: `http://localhost:<port>/swagger`

## 🧪 Testing

Run unit tests for each service:

```bash
# Customers Service Tests
cd Minibank.Customers/testing/MiniBank.CustomersSrv.UnitTests
dotnet test

# Accounts & Transactions Tests
cd Minibank.AccountsAndTransactions/testing/MiniBank.AccountsAndTransactions.UnitTests
dotnet test
```

## 📁 Project Structure

```
minibank/
├── libs/MiniBank/                    # Shared library (common utilities)
├── Minibank.ApiGateway/             # API Gateway service
├── Minibank.Customers/              # Customer management service
├── Minibank.AccountsAndTransactions/ # Account & transaction service
├── compose.yaml                     # Docker Compose configuration
└── Dockerfile                       # Container configuration
```

## 🔧 Configuration

### Environment Variables

Key configuration settings can be found in `appsettings.json` files within each service:

- **Database connections** (MongoDB, PostgreSQL)
- **Redis cache** settings
- **Logging** configuration
- **Service discovery** settings

### Health Checks

Each service exposes health check endpoints at `/healthz` for monitoring and orchestration.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🎓 Learning Resources

This project demonstrates:
- Microservices architecture patterns
- Clean Architecture implementation
- Modern .NET development practices
- Event-driven architecture with Kafka
- Caching strategies with Redis
- API Gateway patterns with YARP
- Containerization with Docker

Perfect for learning enterprise-level .NET development and microservices patterns.