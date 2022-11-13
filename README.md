# Blazor with API Starter! (.NET 7)
This is a starter project / template which consists of a Blazor frontend and a ASP.NET Core backend.
The Blazor app in this template is served from the ASP.NET Core Server.

When running this solution, please set the Server project as Startup project if you're running this in Visual Studio or if running this via VS Code please cd into the Server Project folder and run `dotnet run` in your cmd/powershell/terminal of choice

# At a glance this project contains:
- A Blazor Client (containing the default blazor project pieces minus the WeatherAPI bits)
- ASP.NET CORE Server (API)
- A Shared Project (for sharing code and services between the frontend and backend)
- Test projects Client, Server and Shared

# So what's configured?
## All projects are targeting .NET 7
## All test projects are configured to use XUnit and contain Moq for mocking dependencies.
## The Blazor Test Project has Bunit for Testing pages and components
## The Server Test Project contains a Fixture which creates a In-memory Entity Framework Core 7 Database (see example in the server test's InMemoryDbTests.cs file), this will enable you to test without using a physical DB!
## The Client Project has an example of A Typed Http-Client to call to the Server which can be injected into your components and pages.
## The Server Project has examples of:
- A Controller
- A Service
- A Middleware
- A DbContext (EF Core 7) which is tied to a SQLite db called Example.db (this is to have a working db out of the box feel free to retarget to any that EF-Core supports!)
- Usage of Automapper

