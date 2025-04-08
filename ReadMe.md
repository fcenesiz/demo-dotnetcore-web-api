# Demo Web Api

Asp .Net 8 Stock Market Web Api

## Databse

    Postgres 8.0

## Api Layers

    - CONTROLLER LAYER
    - SERVICE LAYER
    - REPOSITORY LAYER
    - DATABASE

## Used Packages

    - Microsoft.EntityFrameworkCore.SqlServer
    - veya Npgsql.EntityFrameworkCore.PostgreSQL
    - Microsoft.EntityFrameworkCore.Tools
    - Microsoft.EntityFrameworkCore.Design
    - Newtonsoft.Json
    - Microsoft.AspNetCore.Mvc.NewtonsoftJson
    - Microsoft.Extensions.Identity.Core
    - Microsoft.AspNetCore.Identity.EntityFrameworkCore
    - Microsoft.AspNetCore.Authentication.JWTBearer

## Used Visual Studio Code Extensions

    - C#
    - C# Dev Kit
    - .NET Extension Pack
    - .NET Install Tool
    - Nuget Gallery
    - Prettier
    - C# Extension Pack by JosKreativ

## Entity Framework Database Migration

### 1. Install Entity Framework

    dotnet tool install --global dotnet-ef

### 2. Add Migration

    dotnet ef migrations add InitialCreate

### 3. Update Database

    dotnet ef database update

## Used Techniques

    - One-To-Many Creation
    - Many-To-Many Creation
    - Data Validation
    - Filtering
    - Sorting
    - Pagination ( Generic )
    - JWT Authorization
    - Register, Login
