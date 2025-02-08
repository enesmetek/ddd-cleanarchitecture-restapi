# DDD Clean Architecture REST API

A RESTful API built with .NET 8, demonstrating **Domain-Driven Design (DDD)** and **Clean Architecture** principles. This API supports Create, Read, Update, and Delete (CRUD) operations for managing dinner entities.

---

## 📌 Architectural Overview
This project follows a **DDD and Clean Architecture** approach, ensuring a modular, maintainable, and scalable application structure. The key components include:

- **BuberDinner.Api** – Handles HTTP requests and responses.
- **BuberDinner.Application** – Contains business logic, commands, and queries.
- **BuberDinner.Domain** – Encapsulates core domain entities and logic.
- **BuberDinner.Infrastructure** – Manages database access and external integrations.
- **BuberDinner.Contracts** – Defines DTOs and contracts shared across layers.

---

## 🏗️ Project Components

### 🌐 BuberDinner.Api
The **API layer** acts as the entry point for handling client requests and forwarding them to the application layer.

### 🏛️ BuberDinner.Application
Contains the core application logic, implementing **CQRS** (Command and Query Responsibility Segregation) principles to separate read and write operations.

### 📦 BuberDinner.Domain
Defines the domain entities, aggregates, value objects, and business rules that are at the heart of the application.

### 🗄️ BuberDinner.Infrastructure
Manages external concerns such as database access (via **Entity Framework Core**), authentication, and integrations with external services.

### 📑 BuberDinner.Contracts
Holds the **DTOs (Data Transfer Objects)** and **contracts** that ensure consistent communication between different layers and external consumers.

---

## 🚀 Running the Project Locally

### 📌 Prerequisites
- **.NET 8.0** installed on your system.

### 🔧 Setup Instructions
1. Clone the repository:
   ```sh
   git clone https://github.com/enesmetek/ddd-cleanarchitecture-restapi.git
   ```
2. Navigate into the project directory:
   ```sh
   cd ddd-cleanarchitecture-restapi
   ```
3. Build the solution:
   ```sh
   dotnet build
   ```
4. Run the application:
   ```sh
   dotnet run --project BuberDinner.Api
   ```

   The API will be accessible at `https://localhost:5001` by default.

---

## 📡 API Endpoints
Below are the available endpoints in **BuberDinner.API**:

| HTTP Method | Endpoint                 | Description            |
|------------|-------------------------|------------------------|
| `GET`      | `/api/dinners`           | Get all dinners       |
| `GET`      | `/api/dinners/{id}`      | Get a specific dinner |
| `POST`     | `/api/dinners`           | Create a new dinner  |
| `PUT`      | `/api/dinners/{id}`      | Update an existing dinner |
| `DELETE`   | `/api/dinners/{id}`      | Delete a dinner       |

---

## 📜 License
This project is licensed under the **MIT License**.

---

## 🤝 Contributing
Contributions are welcome! Feel free to submit a pull request or open an issue.

---

## 📧 Contact
For any questions or issues, please reach out via GitHub Issues or email me at **[emkafali@gmail.com]**.

---

### 📢 Star the Repository ⭐
If you found this project useful, consider giving it a star on GitHub! 😊

