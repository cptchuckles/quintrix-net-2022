# QuintrixMVC Web Application

Project example using ASP.NET Core, with EntityFramework Core.

 - Includes a `Players` table in the database, for `Player` entities.
   - `Email` must be validated by regex.
   - Project includes a CRUD interface for `Players`. Run `dotnet run` and visit `localhost:7293/Player` to see it
   - You can also browse the database without a CRUD interface by installing the [SQLiteBrowser](https://sqlitebrowser.org/) and viewing `app.db`
 - Includes a `Robots` table in the database, for `Robot` entities
   - `Robot` records must have a `PowerLevel` over 9000.
 - Includes Authentication/Authorization via EntityFrameworkCore Identity

### Dependencies
 - .NET Core SDK 6.0
 - ASP.NET Core 6.0
 - SQLite3

This project uses SQLite3 because it is a toy project.  Later MVC applications will use PostgresQL.
