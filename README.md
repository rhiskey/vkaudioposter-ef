# vkaudioposter-ef
EntityFramework CodeFirst

An utility to create, seed and use database for music posts service.

1. Create MySQL Database user with SUPER privilegies in order to create functions
2. Provide .env file:
.env```
SERVER="localhost"
USER=dbuser
PASSWORD=********
DATABASE=dbname
```
3. Do Migrations first:
`dotnet ef migrations add InitialCreate`
`dotnet ef database update`
`dotnet ef migrations add TaskMigration`