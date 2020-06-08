# BlogAPI

## Server Set Up

install [.Net SDK](https://dotnet.microsoft.com/download)

```
dotnet tool install --global dotnet-ef
```
### Create database 
```
create database: blogdatabase
if use Mysql run:
CREATE TABLE `__EFMigrationsHistory` ( `MigrationId` nvarchar(150) NOT NULL, `ProductVersion` nvarchar(32) NOT NULL, PRIMARY KEY (`MigrationId`) );
```
### Edit your connetion string
./__in appsettings.json__
```json
{
...,
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;User=root;Database=BlogDatabase;" << Your connection string
  }
}
```

### Migrate
```
dotnet ef migrations add InitialCreate --context DBContext
dotnet ef database update
dotnet run
```
