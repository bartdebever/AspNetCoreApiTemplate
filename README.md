# AspNetCore Api Template

A basic ASP.NET Core template to easily create an ASP.NET Core API,
build on dotnet Core 2.2.

This template comes with:

- EntityFramework Core
- Serilog
- Swagger
- Basic CRUD Services and Repository implementation.

Dependencies installed but not used:

- AutoMapper
- NUnit
- FluentAssertions

You can also check out the `Optionals` folder to find items like a basic `.travis.yml` file and a Dockerfile *(coming soon)*.

## Running the project

It's recommended you launch without IIS to make full use of Serilog.
The project should launch to `baseUrl/index.html` and display the SwaggerUI.

The JSON that powers the UI is found at `baseUrl/swagger/v1/swagger.json`

## Personalized appsettings.json

The project is configured to allow the overwriting of appsettings.json if you are working with multiple people.
The project will look for `appsettings.NAME.json` where the name is provided in the startup arguments.
To add your configuration, add the `NAME` in the `Template.Api's Application Arguments`.

## CORS

CORS is currently configured to allow requests from `http://localhost:4200`.
This is the default URL for Angular projects and should be changed.
This can be found at `Template.Api.Startup line 82`.

## Serilog

Serilog is configured to log to file and console with a minimum level of `Information`.
You can configure Serilog by editing your `appsettings.json`.

## EntityFramework Core

EF Core is configured from the `appsettings.json` under the DefaultConnection.
Currently `SqlServer` is the only installed provider.