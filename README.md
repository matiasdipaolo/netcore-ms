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
- net

**Database:**

Technology:

- SQLite

**Architecture overview**

This demo application is cross-platform at the server.

The architecture proposes a microservice-oriented architecture implementation with multiple autonomous microservices (each one owning its own data/db) and implementing different approaches within each microservice using HTTP as the communication protocol between the client apps and the microservices.

![](RackMultipart20221219-1-3kn0kx_html_17168a75d26c126f.jpg)

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

![](RackMultipart20221219-1-3kn0kx_html_3e7e62de53c1ca7d.png)
