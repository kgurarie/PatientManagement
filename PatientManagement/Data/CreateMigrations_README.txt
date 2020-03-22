
EF CORE Migrations
https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/

Run from Package Manager Console
Make sure Data project is selected in PMC and set up as a start project in Solution Explorer.
config.json should be in the right folder DATA\bin\Debug

Create migration:
dotnet ef migrations add InitialCreate


Apply migrations:
dotnet ef database update

Generate migration script for deployment:
script-migration -idempotent -Output "dbMigrationScript.sql" -Context MyDbContext