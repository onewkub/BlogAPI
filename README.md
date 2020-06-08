# BlogAPI

## Server Set Up

install [.Net SDK](https://dotnet.microsoft.com/download)

```
dotnet tool install --global dotnet-ef
```
### create database 
```
create database: blogdatabase
if use Mysql run:
CREATE TABLE `__EFMigrationsHistory` ( `MigrationId` nvarchar(150) NOT NULL, `ProductVersion` nvarchar(32) NOT NULL, PRIMARY KEY (`MigrationId`) );
```

### Migrate
```
dotnet ef migrations add InitialCreate --context DBContext
dotnet ef database update
dotnet run
```
