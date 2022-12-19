# netcore-ms

**Sample Demo App**

Sample .NET Core demo application,a simplified microservices architecture.
Microservices on .Net platform which used .Net Web API

**Sources:**

The source files of the project are controlled by Git.

**Backend:**

Technology:

- .Net Core 7
- Entity Framework (EF) Core
- Ocelot
- XUnit 

**Database:**

Technology:

- SQLite

**Architecture overview**

This demo application is cross-platform at the server.

The architecture proposes a microservice-oriented architecture implementation with multiple autonomous microservices (each one owning its own data/db) and implementing different approaches within each microservice using HTTP as the communication protocol between the client apps and the microservices.
![PIMS](https://user-images.githubusercontent.com/12660603/208417160-2eeb2c4e-b40b-47c7-9f92-f1f300fefd39.jpeg)



Some things to highlight:

Persistence:

- Identity microservice uses entity framework with repository pattern
- Microservices A, B and C will use entity framework with repository pattern and unit of work (All the transactions of the repository will be one single transaction)

Authentication:

- There is an identity API that provides JWT tokens.
  - In the future will:
    - Add refresh token
    - Move Auth Module to the gateway
    - Add support for JWKS in the identity API and remove Auth Module as in the following image:

<img width="745" alt="Screen Shot 2022-12-18 at 10 39 31" src="https://user-images.githubusercontent.com/12660603/208417332-d0d8a6dc-5ab3-481d-8707-139a5cbb01f8.png">
